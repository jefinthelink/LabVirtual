
using UnityEngine.UI;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    private float time = 0.0f;
    public bool canCountTime = false;

   [SerializeField] private Text timeText; 
    void Start()
    {
        
    }

    
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

}
