using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class autorunMe : MonoBehaviour
{
    public UnityEvent ToRun;
    public event Action OnActivated;
    public float delay = 0.1f;

    public bool RunOnAwake = false;
    public bool RunOnEnable = true;
    public bool Everyframe = false;
    public bool UseKey = false;
    public KeyCode thekey;
    bool itscalled = false;

    // Start is called before the first frame update
    void Start(){
        if(RunOnAwake){
            Invoke("runit",delay);
        }
    }

    void Update() {
        if(!itscalled){
            if(Everyframe){
                Invoke("runit",delay);
                itscalled = true;
            }
        }

        if(Input.GetKeyDown(thekey) && UseKey){
            Invoke("runit",delay);
            itscalled = true;
        }
    }

    void OnEnable() {
        if(RunOnEnable){
            Invoke("runit",delay);
        }
    }

    void runit(){
        ToRun?.Invoke();
        OnActivated?.Invoke();
        itscalled = false;
    }
}