using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeReset : MonoBehaviour
{
    public bool resetTime = false;
    [SerializeField]float timespeed = 1.2f;

    // Update is called once per frame
    void Update(){
        if(resetTime){resetTime = false;resetIt();}
        timespeed = Time.timeScale;
    }

    public static void resetIt(){
        Time.timeScale = 1;
    }

    public void resetTimeScale() {
        resetIt();
    }
}
