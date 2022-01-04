using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunsenBurner : MonoBehaviour
{

    [SerializeField] private GameObject fireCollider;
    [SerializeField] private ParticleSystem psFire, psFire2;
    [SerializeField] private Animator collarAnimator;
    private bool turnOnFire = false;
    private Vector3 initialRotationCollar, finalRotateCollar;
    private void Start()
    {

        
    }
    public void HandleTurnOnFire()
    {
        if (turnOnFire)
        {
            Debug.Log("acendendo");
            turnOnFire = false;
            collarAnimator.SetBool("TurnOn", false);
            collarAnimator.SetBool("TurnOf", true);
            fireCollider.GetComponent<FireCollider>().DoNotBurnCube();
            psFire.Stop();
            psFire2.Stop();
        }
        else
        {
            Debug.Log("apagando");
            turnOnFire = true;
            collarAnimator.SetBool("TurnOn", true);
            collarAnimator.SetBool("TurnOf", false);
            fireCollider.GetComponent<FireCollider>().BurnCube();
             psFire.Play();
            psFire2.Play();
        }
    }
}
