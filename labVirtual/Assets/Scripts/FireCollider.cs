using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    public bool busy = false;
    public Cube cube;
    [HideInInspector] public bool burnCubeBool = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            busy = true;
            cube = other.GetComponent<Cube>();
            if (burnCubeBool)
            {
                cube.isFireState = true;
            }
        }
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            busy = false;
           cube.isFireState = false;
        }
    }

    public void BurnCube()
    {
        if (!cube)
        {
            return;
        }
        else
        {
        cube.isFireState = true;
        }
    }
    public void DoNotBurnCube()
    {
        if (!cube)
        {
            return;
        }
        else
        {
            cube.isFireState = false;
        }
    }

}
