// last modified on 23/7/23 at 11:36pm
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsChanger : MonoBehaviour
{
    public enum prefJob{setme,readme};
    public prefJob task = prefJob.setme;
    public string val = "0";
    public string key = "unknown";
    public string prefix = "pref_";

    [Header("switches")]
    public bool usePrefix;
    public bool slotPref;
    public bool EveryFrame = false;
    public bool RunOnAwake = false;
    public bool runit = false;

    public enum Preftype{a_string,a_float,a_int};
    public Preftype type;

    void Start() {
        runit = RunOnAwake;
    }

    // Update is called once per frame
    void Update(){
        if(runit){
            runit = false;
            PrefOp(task == prefJob.readme);
        }
    }

    public void PrefOp(bool getit){

        string mykey = "",myval = "";

        mykey = usePrefix ? prefix + key : key;
        myval = val;

        if(slotPref){
            prefix = "saveslot_" + PlayerPrefs.GetInt("CurrentSlot",0) + "_";
            mykey = prefix + key;
        }

        switch (type)
        {
            case Preftype.a_string:
                if(getit){
                    val = "" + PlayerPrefs.GetString(mykey,"not found");
                } else {
                    PlayerPrefs.SetString(mykey,myval);
                }

                break;
            case Preftype.a_float:
                if(getit){
                    val = "" + PlayerPrefs.GetFloat(mykey,0.0f);
                } else {
                    PlayerPrefs.SetFloat(mykey,float.Parse(myval));
                }

                break;
            case Preftype.a_int:
                if(getit){
                    val = "" + PlayerPrefs.GetInt(mykey,0);
                } else {
                    PlayerPrefs.SetInt(mykey,int.Parse(myval));
                }

                break;
            default:
                break;
        }
    }

    public void setme(string what){
        val = what;
        PrefOp(false);
    }
}
