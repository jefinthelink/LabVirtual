using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Thermometer : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private Vector3 initialPosition;
    [SerializeField] private Transform ThermometerPosition;
    private bool moveToThermometerPosition = false;
    private bool moveToInitialPosition = false;
    private bool useState = false;

    [SerializeField] private GameObject aimThermometer;
    [SerializeField] private TMP_Text temperaturetext, temperatureMaxText, temperatureTypeText;
    [SerializeField] private float delayOfStartResponse = 0.8f;
    [SerializeField] private float delayOfSmaplingq = 0.1f;
    [SerializeField] private float delayTurnOffAutomatic = 15f;
    private float temperatureMax;
    public float temperatureFahrenheit, temperatureCeucius;
     public bool turnOn = false;
    private bool delayToSTart = true;
    private bool pressTrigger = false;
    public modesOfThermometer modes;
    private Laser laser;





    void Start()
    {
        SetValues();    
    }

    private void SetValues()
    {
        initialPosition = transform.position;
        laser = aimThermometer.GetComponent<Laser>();
    }
    private void Update()
    {
        Move();
        if (turnOn)
        {
            StartCountTemperature();
        }
    }

    private void StartCountTemperature()
    {
        
        delayOfStartResponse -= Time.deltaTime;
        if (delayOfStartResponse <= 0f)
        {
            delayOfStartResponse = 0.9f;
            //delayToSTart = false;
            CountTemperature();
        }
    }

    private void FinishCountTemperature()
    {
        turnOn = false;
    }

    private void CountTemperature()
    {
        RaycastHit hit;
        if (Physics.Raycast(aimThermometer.transform.position, aimThermometer.transform.right, out hit, Mathf.Infinity))
        {
            laser.showRay(aimThermometer.transform.position,hit.point); 
            if (hit.transform.tag == "Cube")
            {
                Debug.Log("achou o cubo");
                if (modes == modesOfThermometer.ceucius)
                {
                    temperatureCeucius = hit.transform.GetComponent<CubeHeating>().temperatureCeucius;
                    ShowValueInText(temperatureCeucius,temperatureMax,"C");
                }
                else if (modes == modesOfThermometer.fahrenheit)
                {
                    temperatureFahrenheit = convertToFahrenheit(hit.transform.GetComponent<CubeHeating>().temperatureCeucius);
                    ShowValueInText(temperatureFahrenheit, temperatureMax, "F");
                }
            }
            else
            {
                Debug.Log("não achou o cubo");
            }
        }
        
       // ShowHay();

    }


    

    public void ResetTemperatureMax()
    {
        temperatureMax = 0.0f;
        if (modes == modesOfThermometer.ceucius)
        {
            ShowValueInText(temperatureCeucius,temperatureMax,"HOLD C");
        }
    }
    private void ShowValueInText(float temperature, float maxTemperature, string typeOfTemperature) 
    {
        temperatureMaxText.text = maxTemperature.ToString("f");
        temperaturetext.text = temperature.ToString("f");
        temperatureTypeText.text = typeOfTemperature;
    }
    private float convertToFahrenheit(float temperatureToConvert)
    {
        return temperatureToConvert = (temperatureCeucius * 9 / 5) + 32;
    }

    #region MOVIMENT
    private void Move()
    {
        if (moveToThermometerPosition)
        {
            MoveWards(ThermometerPosition.transform.position);
            if (transform.position == ThermometerPosition.transform.position)
            {
                moveToThermometerPosition = false;
                useState = true;
            }
        }

        if (moveToInitialPosition)
        {
            MoveWards(initialPosition);
            if (transform.position == initialPosition)
            {
                moveToInitialPosition = false;
                useState = false;
            }

        }

    }
    private void MoveWards(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void HandlerState()
    {
        
        if (!useState)
        {
            moveToThermometerPosition = true;
        }
        if (useState)
        {
            moveToInitialPosition = true;
        }
    }
    private void OnMouseDown()
    {
        HandlerState();
    }
    #endregion


}

public enum modesOfThermometer
{
ceucius,
fahrenheit
}
