using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    
    public float timerDuration = 120f;
    public float gameTimer;
    
    [SerializeField] TMP_Text timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        timerText.text = "Time Left: " + gameTimer.ToString("0");
        if (gameTimer <= 0f)
        {
            Singleton.instance.Reset();
        }
    }
}
