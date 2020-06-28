using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [Header("Time in seconds")]
    public float timeLimit;   //timeLimit is the amount of time for the game in minutes
    float currentTime = 0.0f;

    int minutesPassed = 0;
    int secondsPassed = 0;

    bool isCounting = false;
    bool timeUp = false;        // timeUp bool used to measure wether the game is out of time or not

    // Start is called before the first frame update
    void Start()
    {
        isCounting = true;
    }

    void Update()
    {
        minutesPassed = (int)(currentTime/60);
        secondsPassed = (int)currentTime%60;

        if (currentTime >= timeLimit) {
            timeUp = true;
            isCounting = false;
        }
      
        if (isCounting)
        {
            currentTime += Time.deltaTime; 
        }
    }
}
