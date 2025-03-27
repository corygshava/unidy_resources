// last modified on 29/7/23 at 12:40 pm

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoHandler : MonoBehaviour
{
    public enum mymethod{
        enable,
        disable,
        normal,
        toggleEnable,
        toggleDisable
    }
    public float slowmoFactor = 0.3f;
    public mymethod how = mymethod.normal;
    [SerializeField] bool doit;

    // Update is called once per frame
    void Update(){
        if(how == mymethod.normal){
            if(doit){doit = false;runme();}
        }
    }

    void runme(){
        slowmoFactor = Mathf.Clamp(slowmoFactor,0f,1.0f);
        Time.timeScale = slowmoFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void resettimer(){
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    private void OnEnable() {
        if(how == mymethod.enable){runme();}
        else if(how == mymethod.disable){resettimer();}
        else if(how == mymethod.toggleEnable){runme();}
        else if (how == mymethod.toggleDisable){resettimer();}
    }

    private void OnDisable() {
        if(how == mymethod.enable){resettimer();}
        else if(how == mymethod.disable){runme();}
        else if(how == mymethod.toggleDisable){
            runme();
        } else if (how == mymethod.toggleEnable){
            resettimer();
        }
    }
}
