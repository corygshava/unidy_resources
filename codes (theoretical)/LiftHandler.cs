using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftHandler : MonoBehaviour
{
    public PlayMe pm;
    public string ParamOn;
    public string ParamOff;
    
    public void runit(){
        if(pm.anim.GetBool(ParamOn)){
            pm.anim.SetBool(ParamOn,false);
            pm.anim.SetBool(ParamOff,true);
        } else {
            pm.anim.SetBool(ParamOn,true);
            pm.anim.SetBool(ParamOff,false);
        }
    }
}
