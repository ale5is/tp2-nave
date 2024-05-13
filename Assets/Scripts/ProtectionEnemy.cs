using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionEnemy : MonoBehaviour
{
    public static bool protection;
    private Renderer render;
    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        color = render.material.color;
        
        int rnd = UnityEngine.Random.Range(0, 3);
        if (rnd == 2)
        {
            protection = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForceField();
    }
    private void CheckForceField()
    {
        if (protection)
        {
            render.material.color = Color.blue;
        }
        else
        {
            render.material.color = color;
        }
    }
}
