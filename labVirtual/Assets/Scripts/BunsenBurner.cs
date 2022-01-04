using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunsenBurner : MonoBehaviour
{

    [SerializeField] private GameObject fireCollider;
    [SerializeField] private ParticleSystem psFire, psFire2;
    private bool turnOnFire = false;
    public void HandleTurnOnFire()
    {
        if (turnOnFire)
        {
            turnOnFire = false;

            fireCollider.GetComponent<FireCollider>().DoNotBurnCube();
            psFire.Stop();
            psFire2.Stop();
        }
        else
        {
            turnOnFire = true;
            
            fireCollider.GetComponent<FireCollider>().BurnCube();
             psFire.Play();
            psFire2.Play();
        }
    }
}
