// last modified on 25/1/24 at 2:58PM and i was getting late for the session

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrigAction : MonoBehaviour
{
    public string thetag;
    public UnityEvent OnTrig;
    public event Action trigevent; 

    void OnTriggerEnter(Collider other){
        bool thecon = false;

        if(cm.hasTxt(",",thetag)){
            string[] items = cm.splitTxt(",",thetag);
            int found = 0;

            for (var x = 0; x < items.Length; x++){
                if(other.CompareTag(items[x])){
                    found += 1;
                }
            }

            thecon = found > 0;
        } else {
            thecon = other.CompareTag(thetag);
        }

        if(thecon){
            OnTrig?.Invoke();
            trigevent?.Invoke();
        }
    }
}
