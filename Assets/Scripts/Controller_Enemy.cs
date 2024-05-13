using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Controller_Enemy : MonoBehaviour
{
    public float enemySpeed;

    public float xLimit;

    private float shootingCooldown;

    public GameObject enemyProjectile;

    public GameObject powerUp;
    public GameObject powerUpInvensible;
    Vector3 spawn=new Vector3(3,0,0);

    void Start()
    {
        shootingCooldown = UnityEngine.Random.Range(1, 10);
    }

    public virtual void Update()
    {
        shootingCooldown -= Time.deltaTime;
        CheckLimits();
        ShootPlayer();
    }

    void ShootPlayer()
    {
        if (Controller_Player._Player != null)
        {
            if (shootingCooldown <= 0)
            {
                Instantiate(enemyProjectile, transform.position, Quaternion.identity);
                shootingCooldown = UnityEngine.Random.Range(1, 10);
            }
        }
    }


    private void CheckLimits()
    {
        if (this.transform.position.x < xLimit)
        {
            Destroy(this.gameObject);
        }
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (ProtectionEnemy.protection)
            {
                ProtectionEnemy.protection = false;
            }
            else 
            {
                GeneratePowerUp();
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                Controller_Hud.points++;
            }
            
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            GeneratePowerUp();
            Destroy(this.gameObject);
            Controller_Hud.points++;
        }
    }

    private void GeneratePowerUp()
    {
        int rnd = UnityEngine.Random.Range(0, 3);
        if (rnd == 2)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity);
            rnd = UnityEngine.Random.Range(0, 3);
            
            if (rnd <= 2)
            {
                Instantiate(powerUpInvensible, transform.position+spawn, Quaternion.identity);
            }
        }
    }
}
