using UnityEngine;

public class CubeHeating : MonoBehaviour
{
    #region Variaveis
    private Cube cube;
    [Header("Temperaturas")]
    public float temperatureCeucius = 25.0f;
    public float starttemperature;
    [SerializeField] private float maxTemperatureCeucius = 200.0f;
    [Header("tempo para o aquecimento ou resfriamento")]
    public float seconds = 0.0f;
    [Header("constantes do cubo")]
    [SerializeField] private float constantThatcement;
    [SerializeField] private float constantOfCube;
    private float minTemperatureCeucius = 25.0f;
    private float e = 2.7182818284f;
    private float time = 0.0f;
    #endregion
    #region Metodos
    private void Start()
    {
        SetValues();
    }
    private void SetValues()
    {
        cube = transform.GetComponent<Cube>();
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
        Debug.Log("queimando");
        temperatureCeucius = starttemperature + (maxTemperatureCeucius - starttemperature) * (1 - (Mathf.Pow(e, (-constantThatcement * seconds))));
    }
    private void Cooling()
    {

        temperatureCeucius = starttemperature + (minTemperatureCeucius - starttemperature) * (1 - (Mathf.Pow(e, (-constantOfCube * seconds))));
    }
    #endregion
}
