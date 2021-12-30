using TMPro;
using UnityEngine;

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
    private float temperatureFahrenheit, temperatureCeucius;
    [HideInInspector] public bool turnOn = false;
    private bool delayToSTart = true;
    private bool pressTrigger = false;
    public modesOfThermometer modes;





    void Start()
    {
        SetValues();    
    }

    private void SetValues()
    {
        initialPosition = transform.position;
    }
    private void Update()
    {
        Move();
        if (turnOn && delayToSTart)
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
            delayToSTart = false;
            CountTemperature();
        }
    }

    private void FinishCountTemperature()
    {
        turnOn = false;
    }

    private void CountTemperature()
    {
        //fazer um raycast
        ShowHay();
        if (modes == modesOfThermometer.ceucius)
        {
            //retornar valor em ceucius
        }
        else if (modes == modesOfThermometer.fahrenheit)
        {
            convertToFahrenheit(temperatureCeucius);

        }
    }


    private void ShowHay()
    {
        Debug.DrawRay(aimThermometer.transform.position,Vector3.right,Color.red);
    }

    private void ResetTemperatureMax()
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
