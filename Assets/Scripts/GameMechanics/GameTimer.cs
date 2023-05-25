using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour 
{

    private Slider slider;

    public delegate void TimeIsOver();
    public event TimeIsOver OnTimeIsOver;

    [SerializeField][Tooltip("In seconds")]
    private float LevelDuration = 10f;

    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = LevelDuration;
    }

    
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad;
        if (Time.timeSinceLevelLoad >= LevelDuration ){
            OnTimeIsOver();
            enabled = false;
        }
    }
}
