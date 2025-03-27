using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mathPlayground : MonoBehaviour
{
    [Header("amount to modify")]
    public float amount;

    [Header("exponential square equation")]
    public float factor;

    [Header("shavian equation")]
    public float factor_2;

    [Header("universality equation")]
    [Range(0f,4.57f)]
    public float growthRate;

    [Header("level")]
    [Range(0,25)]
    public int level;

    [Header("results")]
    public float result_1;
    public float result_2;
    public float uni_resunt_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        result_1 = setMyAmount(amount,level,factor);
        result_2 = setOtherAmount(amount,level,factor_2);
        uni_resunt_2 = uniEQ(amount / 4,amount,level,growthRate);
    }

    public static float setMyAmount(float what,int points,float facto){
        // exponential scaling algorithm (HUGE numbers as it grows)
        float newpoints = points * facto;
        return (float) ((Math.Pow(what,newpoints)) * facto * what);
    }

    public static float setOtherAmount(float what,int points,float facto){
        // shavian scaling algorithm (Moderate scaling system)
        float res = (float) (points / facto) * what; 
        if (res > 999999999){res = 999999999;}
        return res;
    }

    public static float uniEQ(float startAmt,float nermal,int cycles,float rate){
        // universality equation (perfect for CHAOS in numbers scaling)
        float former = startAmt / nermal;

        for (var x = 0; x <= cycles; x++){
            former = rate * former * (1 - former);
        }

        return nermal * former;
    }

    public static float halfner(int cycles,float factor){
        // like in dead cells
        float final = factor;
        for(int x = 0;x <= cycles;x++){
            final = final / 2;
        }

        return final;
    }

    public static float halfner(int cycles,float factor,float divisor){
        // like in dead cells
        float final = factor;
        for(int x = 0;x <= cycles;x++){
            final = final / divisor;
        }

        return final;
    }
}
