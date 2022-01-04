using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    public bool busy = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            busy = true;
            other.GetComponent<Cube>().isFireState = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            busy = false;
            other.GetComponent<Cube>().isFireState = false;
        }
    }


}
