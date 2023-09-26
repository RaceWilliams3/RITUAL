using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public bool connected = false;

    void OnTriggerEnter()
    {
        if (connected == false)
        {
            this.transform.parent.GetComponent<CellObject>().connectorCollided(this);
            connected = true;
        }
    }
}