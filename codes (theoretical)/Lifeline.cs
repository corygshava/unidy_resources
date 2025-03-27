using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lifeline : MonoBehaviour
{
    //the main idea is that the linked item is required for another object to exist
    public GameObject linked;
    public GameObject item;
    public float delay = 1.0f;

    public enum action{
        i_destroy,
        i_deactivate,
        i_activate,
        i_run
    }

    [Header("in case i am to run something")]
    public UnityEvent OnRun;

    [Header("switches")]
    public bool itsMe = true;
    public bool itsOn = true;
    public action doWhat = action.i_destroy;

    bool itsrun = false;

    // Update is called once per frame
    void Update()
    {
        if(itsOn){
            if(linked == null){
                HandleIt();
            }
        }
    }

    void HandleIt(){
        if(itsMe){item = gameObject;}

        if(item != null){
            switch (doWhat)
            {
                case action.i_destroy:
                    Destroy(item,delay);
                    break;
                case action.i_deactivate:
                    cm.deact(item,1);
                    break;
                case action.i_run:
                    OnRun.Invoke();
                    break;
                default:
                    cm.deact(item,2);
                    break;
            }
        }
    }
}
