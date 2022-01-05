using UnityEngine.UI;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    #region Variaveis
    [HideInInspector]public bool canCountTime = false;
    [Header("texto do cronometro")]
    [SerializeField] private Text timeText; 
    private float time = 0.0f;
    #endregion
    #region Metodos
    void Update()
    {
        CountTime();
    }
    public void StartCount()
    {
        canCountTime = true;
        Missions.instance.MissionStopwatch();
    }
    private void CountTime()
    {
        if(canCountTime)
        {
            time += Time.deltaTime;
            timeText.text = time.ToString("f");
        }
    }
    public void PauseTime()
    {
        canCountTime = false;
    }
    public void ResetTime ()
    {
        PauseTime();
        time = 0.0f;
        timeText.text = time.ToString("f");
    }
    #endregion
}
