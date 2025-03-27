using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitDetector : MonoBehaviour
{
    // this is a script meant to respond to projectiles or colliders which want to cause harm to this object

    [SerializeField] int hits;
    [SerializeField] int maxhits = 2;

    public UnityEvent OnhitAction;
    public UnityEvent OnDieAction;

    // events for further communication
    public event Action OnHit;
    public event Action OnDie;

    bool imdead = false;

    public void hitme(){
        if(!imdead){
            hits += 1;
            OnhitAction?.Invoke();
            OnHit?.Invoke();
            if(hits >= maxhits){dieNow();}
        } else {
            Debug.Log("hitdetector : im already dead damn it");
        }
    }

    void dieNow(){
        OnDieAction?.Invoke();
        OnDie?.Invoke();
        imdead = false;
    }
}
