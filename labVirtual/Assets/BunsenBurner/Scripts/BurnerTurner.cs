using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerTurner : MonoBehaviour
{
    // Simple script that rotates the object based on speed that can be changed in the editor

    public float speed;
    public bool hovered;

    void Update()
    {
        // The hovered bool is set by the Pointer script
        if (hovered)
        { 
            transform.Rotate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
