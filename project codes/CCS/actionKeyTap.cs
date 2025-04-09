using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class actionKeyTap : MonoBehaviour
{
    public UnityEvent ToRun;
    public event Action OnActivated;
    public float delay = 0.1f;

    public bool useShift = false;
    public KeyCode thekey = KeyCode.A;
    bool itscalled = false;

    void Update() {
        bool tryme = false;
        if(useShift){
            tryme = (Input.GetKeyDown(thekey) && Input.GetKey(KeyCode.LeftShift)) || (Input.GetKeyDown(thekey) && Input.GetKey(KeyCode.RightShift));
        } else {
            tryme = Input.GetKeyDown(thekey);
        }

        if(tryme){
            if(!itscalled){
                Invoke("runit",delay);
                itscalled = true;
            }
        }
    }

    void runit(){
        ToRun?.Invoke();
        OnActivated?.Invoke();
        itscalled = false;
    }
}