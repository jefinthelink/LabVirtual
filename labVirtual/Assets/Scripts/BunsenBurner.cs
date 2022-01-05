﻿using UnityEngine;

public class BunsenBurner : MonoBehaviour
{
    #region Variaveis
    [Header("colisor")]
    [SerializeField] private GameObject fireCollider;
    [Header("particulas")]
    [SerializeField] private ParticleSystem psFire, psFire2;
    [Header("animator")]
    [SerializeField] private Animator collarAnimator;
    [Header("tempo de mudança")]
    [SerializeField] private float delayToChange = 3.0f;
    private float delayToChangeAux;
    private bool turnOnFire = false, canBeChange = true;
    #endregion
    #region Metodos
    private void Start()
    {
        SetValues();
    }
    private void SetValues()
    {
        delayToChangeAux = delayToChange;
    }
    private void Update()
    {
        if (!canBeChange)
        {
            delayToChange -= Time.deltaTime;
            if (delayToChange <= 0f)
            {
                canBeChange = true;
                delayToChange = delayToChangeAux;
            }
        }
    }
    public void HandleTurnOnFire()
    {
        if (turnOnFire && canBeChange)
        {
            //apagando
            canBeChange = false;
            turnOnFire = false;
            collarAnimator.SetBool("TurnOn", false);
            collarAnimator.SetBool("TurnOf", true);
            fireCollider.GetComponent<FireCollider>().DoNotBurnCube();
            psFire.Stop();
            psFire2.Stop();
        }
        else if (!turnOnFire && canBeChange) 
        {
            //acendendo
            canBeChange = false;
            turnOnFire = true;
            collarAnimator.SetBool("TurnOn", true);
            collarAnimator.SetBool("TurnOf", false);
            fireCollider.GetComponent<FireCollider>().BurnCube();
            fireCollider.GetComponent<FireCollider>().burnCubeBool = true;
             psFire.Play();
            psFire2.Play();
        }
    }
    #endregion
}
