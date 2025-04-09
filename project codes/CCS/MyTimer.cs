// last modified on 11/6/23 at 7:52pm

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyTimer : MonoBehaviour
{
    public enum showmode{LongTime,ShortTime,PlainTime};

    public GameObject thetext;
    public float thetime;
    [Tooltip("text before the time")]
    public string captionText = "time : ";
    public string suffix = "s";

    [Header("switches")]
    [Tooltip("if you want it to count from thetime to 0")]
    public bool countdown;
    [Tooltip("whether or not to count")]
    public bool count;
    [Tooltip("run as soon as I'm spawned or activated")]
    public bool runOnAwake;

    [Header("counter data")]
    public showmode TimeFormat = showmode.ShortTime;
    public bool fixedTime = false;

    string caption = "nada";

    [Header("if its in countdown mode")]
    public bool countdownOver = false;
    // only work if the mode is countdown
    public UnityEvent OntimerEnd;
    public event Action OnTimerEnd2;

    // Start is called before the first frame update
    void Start(){
        if(runOnAwake){
            count = true;
        }
    }

    // Update is called once per frame
    void Update(){
        caption = string.IsNullOrEmpty(captionText) ? "" : captionText;

        if(count){
            if(countdown){
                if(thetime > 0){
                    thetime -= fixedTime ? Time.unscaledDeltaTime : Time.deltaTime;
                    countdownOver = false;
                } else {
                    if(!countdownOver){
                        countdownOver = true;
                        OnTimerEnd2?.Invoke();
                        OntimerEnd?.Invoke();
                    }
                }
            } else {
                thetime += fixedTime ? Time.unscaledDeltaTime : Time.deltaTime;
            }
        }

        if(thetext != null){
            handleTime();
        }
    }

    void handleTime(){
        string outxt = "";
        switch (TimeFormat)
        {
            case showmode.ShortTime:
                outxt = cm.convertTime(thetime);
                break;
            case showmode.LongTime:
                outxt = cm.convertTimeLong(thetime);
                break;
            default:
                outxt = $"{thetime.ToString("0.00")}";
                break;
        }

        cm.seTxt(thetext, $"{caption} {outxt} {suffix}");
    }

    public void startCounting(){count = true;}
    public void countme(bool con) {count = con;}
    public void addtime(float amt) {thetime += amt;}
    public void settime(float amt) {thetime = amt;}
}
