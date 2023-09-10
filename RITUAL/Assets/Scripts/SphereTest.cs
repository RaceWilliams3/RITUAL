using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTest : MonoBehaviour
{
    public Material x;
    public Material y;
    public Material z;
    public Material def;

    private Material mat;
    private Transform trans;

    void Start()
    {
        //mat = GetComponent<Renderer>().material;
        trans = GetComponent<Transform>();

        if (trans.position.x == 0)
        {
            GetComponent<Renderer>().material = x;
            if (trans.position.y == 0 && trans.position.z == 0)
            {
                GetComponent<Renderer>().material = def;
            }
        }
        else if (trans.position.y == 0)
        {
            GetComponent<Renderer>().material = y;
        }
        else if (trans.position.z == 0)
        {
            GetComponent<Renderer>().material = z;
        } else
        {
            GetComponent<Renderer>().material = def;
        }


    }
}
