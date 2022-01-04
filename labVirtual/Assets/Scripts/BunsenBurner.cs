using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunsenBurner : MonoBehaviour
{

    [SerializeField] private GameObject fireCollider;
    [SerializeField] private ParticleSystem psFire;
    private bool turnOnFire = false;
    public void HandleTurnOnFire()
    {
        if (turnOnFire)
        {
            turnOnFire = false;
            fireCollider.SetActive(false);
           // psFire.Stop();
        }
        else
        {
            turnOnFire = true;
            fireCollider.SetActive(true);
            // psFire.Play();
        }
    }
}
