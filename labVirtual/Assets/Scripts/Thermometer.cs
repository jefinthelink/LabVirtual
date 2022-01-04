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
    [SerializeField] private GameObject thermometerPanel;
    [SerializeField] private float delayOfStartResponse = 0.8f;
    [SerializeField] private float delayOfSmaplingq = 0.1f;
     private float delayTurnOffAutomatic = 0f;
    public float temperatureMax;
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
            laser.TurnOnRay();
            laser.showRay();
            StartCountTemperature();
        }
        else if(!turnOn && delayTurnOffAutomatic > 0f)
        {
            laser.TurnOnRay();
            laser.showRay();
            StartCountTemperature();
            delayTurnOffAutomatic -= Time.deltaTime;
            if (delayTurnOffAutomatic < 0f)
            {
            laser.TurnOfRay();
            ShowUI(false);
            }
        }
    }

    public void ShowUI(bool value)
    {
        thermometerPanel.SetActive(value);   
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
    private void CountTemperature()
    {
        RaycastHit hit;
        if (Physics.Raycast(aimThermometer.transform.position, aimThermometer.transform.right, out hit, Mathf.Infinity))
        {
            
            if (hit.transform.tag == "Cube")
            {
               
                if (modes == modesOfThermometer.ceucius)
                {
                    temperatureCeucius = hit.transform.GetComponent<CubeHeating>().temperatureCeucius;
                    
                    if (temperatureMax < temperatureCeucius)
                    {
                        temperatureMax = temperatureCeucius;
                    }


                    // erro de mais ou menos 2% na medição
                    float percentagem = (temperatureCeucius / 100) * 2;
                    if (Random.Range(-1f, 1f) > 0)
                    {
                        temperatureCeucius = temperatureCeucius + percentagem;
                    }
                    else
                    {
                        temperatureCeucius = temperatureCeucius - percentagem;
                    }



                    ShowValueInText(temperatureCeucius,temperatureMax,"C");
                }
                else if (modes == modesOfThermometer.fahrenheit)
                {
                   
                    temperatureCeucius = hit.transform.GetComponent<CubeHeating>().temperatureCeucius;

                    if (temperatureMax < temperatureCeucius)
                    {
                        temperatureMax = temperatureCeucius;
                    }

                    // erro de mais ou menos 2% na medição
                    float percentagem = (convertToFahrenheit(temperatureCeucius)/100) * 2;
                    if (Random.Range(-1f, 1f) >0)
                    {
                    temperatureFahrenheit = convertToFahrenheit(temperatureCeucius) + percentagem;
                    }
                    else
                    {
                        temperatureFahrenheit = convertToFahrenheit(temperatureCeucius) - percentagem; 
                    }
                    
                    
                    ShowValueInText(temperatureFahrenheit, temperatureMax, "F");
                }
            }
      
        }
        
    }
    public void ResetDelayTurnOffAutomatic()
    {
        delayTurnOffAutomatic = 15f;
    }
    public void ResetTemperatureMax()
    {
        temperatureMax = 0.0f;
        if (modes == modesOfThermometer.ceucius)
        {
            ShowValueInText(temperatureCeucius,temperatureMax,"HOLD C");
        }
        if (modes == modesOfThermometer.fahrenheit)
        {
            ShowValueInText(temperatureFahrenheit, temperatureMax, "HOLD C");
        }
    }
    private void ShowValueInText(float temperature, float maxTemperature, string typeOfTemperature) 
    {
        temperatureMaxText.text = "Max " + System.Math.Round(maxTemperature,1) + " C";
        temperaturetext.text = System.Math.Round(temperature,1).ToString();
        temperatureTypeText.text = "HOLD" +typeOfTemperature;
    }
    private float convertToFahrenheit(float temperatureToConvert)
    {
        return  (temperatureToConvert * 9 / 5) + 32;
    }

    private float ConvertToCeucius(float temperatureToConvert)
    {
        return (temperatureToConvert - 32) * (5 / 9); 
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
    public void HandlerState()
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
    //private void OnMouseDown()
    //{
    //    HandlerState();
    //}
    #endregion


}

public enum modesOfThermometer
{
ceucius,
fahrenheit
}
