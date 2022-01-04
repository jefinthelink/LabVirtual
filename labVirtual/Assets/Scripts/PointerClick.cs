using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerClick : MonoBehaviour
{
    [SerializeField] private KeyCode iPT_001 = KeyCode.Mouse0;
    [SerializeField] private KeyCode iPT_002 = KeyCode.Mouse1;
    private void Update()
    {
        Raycast();
    }
    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Cube")
            {
                if (Input.GetKeyDown(iPT_001))
                {
                Debug.Log("achou o cubo");
                hit.transform.gameObject.GetComponent<Cube>().HandlerState();
                }
            }
            if (hit.transform.tag == "Thermometer")
            {

                if (Input.GetKeyDown(iPT_001))
                {
                    hit.transform.gameObject.GetComponent<Thermometer>().HandlerState();
                }
                if (Input.GetKey(iPT_002))
                {
                    hit.transform.gameObject.GetComponent<Thermometer>().ResetDelayTurnOffAutomatic();
                    hit.transform.gameObject.GetComponent<Thermometer>().turnOn = true;
                    hit.transform.gameObject.GetComponent<Thermometer>().ShowUI(true);
                }
                else
                {
                    hit.transform.gameObject.GetComponent<Thermometer>().turnOn = false;
                }
            }
            if (hit.transform.tag == "BunsenBurner")
            {
                if (Input.GetKeyDown(iPT_001))
                {
                    hit.transform.GetComponent<BunsenBurner>().HandleTurnOnFire();
                }
            }
            if (hit.transform.tag == "Button1")
            {
                if (Input.GetKeyDown(iPT_001))
                {
                    hit.transform.GetComponentInParent<Thermometer>().modes = modesOfThermometer.ceucius;
                  
                }
            }
            if (hit.transform.tag == "Button2")
            {
                if (Input.GetKeyDown(iPT_001))
                {
                hit.transform.GetComponentInParent<Thermometer>().ResetTemperatureMax();
                }
            }
            if (hit.transform.tag == "Button3")
            {
                if (Input.GetKeyDown(iPT_001))
                {
                hit.transform.GetComponentInParent<Thermometer>().modes = modesOfThermometer.fahrenheit;
                 
                }
            }

        }
    }
}
