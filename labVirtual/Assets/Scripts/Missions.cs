using TMPro;
using UnityEngine;


public class Missions : MonoBehaviour
{
    #region Variaveis
    public static Missions instance;
    [Header("textos das missões")]
    [SerializeField] private TMP_Text textMissionMoviment;
    [HideInInspector] public bool missionMovimentBool = false;
    private bool w;
    private bool a;
    private bool s;
    private bool d;

    [SerializeField] private TMP_Text textMissionStopwatch;
    [HideInInspector] public bool missionStopwatch = false;
    [SerializeField] private TMP_Text textMissionThermometer;
    [HideInInspector] public bool missionThermometer = false;
    #endregion
    #region Metodos
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        MissionMove();
    }
    public void MissionMove()
    {
  

        if (Input.GetKeyDown(KeyCode.A))
        {
            a = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            w = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            s = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            d = true;
        }

        if (a && w && d && s)
        {
            missionMovimentBool = true;
            textMissionMoviment.text = "Concludo";
        }
        
    }
    public void MissionStopwatch()
    {
        missionStopwatch = true;
        textMissionStopwatch.text = "Concluido";
    }
    public void MissionThermometer()
    {
        missionThermometer = true;
        textMissionThermometer.text = "Concluido";
    }
    #endregion
}
