// last updated on 8/1/2024 at 4:49am

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// requires cm to work

public class ActionHit : MonoBehaviour
{
    public string thetag = "Player";

    [Header("the events")]
    public UnityEvent OnHit;
    public UnityEvent OnStopHit;
    public UnityEvent OnContact;

    GameObject latest;

    void OnCollisionEnter(Collision other) {
        latest = other.gameObject;
        if(checktag(other.gameObject.tag)){
            OnHit?.Invoke();
        }
    }

    void OnCollisionExit(Collision other) {
        latest = other.gameObject;
        if(checktag(other.gameObject.tag)){
            OnStopHit?.Invoke();
        }
    }

    void OnCollisionStay(Collision other) {
        latest = other.gameObject;
        if(checktag(other.gameObject.tag)){
            OnContact?.Invoke();
        }
    }

    bool checktag(string what){
        // Debug.Log($"{cm.hasTxt(what,thetag)} -- [{what}] _ [{thetag}] _ [by {latest.name}]");
        return cm.hasTxt(what,thetag);
    }
}
