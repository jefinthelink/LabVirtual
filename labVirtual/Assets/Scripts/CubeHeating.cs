using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHeating : MonoBehaviour
{
    private Cube cube;
    public float temperatureCeucius = 25.0f;
    private float minTemperatureCeucius = 25.0f;
    public float starttemperature;
    [SerializeField] private float maxTemperatureCeucius = 200.0f;
    private float e = 2.7182818284f;
    [SerializeField] private float constantThatcement;
    [SerializeField] private float constantOfCube;
     public float seconds = 0.0f;
    private float time = 0.0f;

    private void Start()
    {
        SetValues();
    }
    private void SetValues()
    {
        cube = transform.GetComponent<Cube>();
        //constantThatcement = Mathf.Pow(constantThatcement, -1);
        //constantOfCube = Mathf.Pow(constantOfCube, -1);
        
    }
    private void Update()
    {
        if (cube.isFireState)
        {
            time += Time.deltaTime;
            if (time >= 1f && temperatureCeucius < maxTemperatureCeucius)
            {
                time = 0.0f;
                seconds += 1;
                Heating();
            }
        }
        else
        {
            time += Time.deltaTime;
            if (time >= 1f && temperatureCeucius > minTemperatureCeucius)
            {
                time = 0.0f;
                seconds += 1;
                Cooling();
            }
        }
    }
    private void Heating()
    {
        Debug.Log("Aquecendo");
        temperatureCeucius = starttemperature + (maxTemperatureCeucius - starttemperature) * (1 - (Mathf.Pow(e, (-constantThatcement * seconds))));
    }

    private void Cooling()
    {
        Debug.Log("Resfriando");
        temperatureCeucius = starttemperature + (minTemperatureCeucius - starttemperature) * (1 - (Mathf.Pow(e, (-constantThatcement * seconds))));
    }
}
