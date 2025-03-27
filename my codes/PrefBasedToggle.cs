using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefBasedToggle : MonoBehaviour
{
    // this script kinda explains itself
    public enum mycon{equalto,greater,less,greaterEq,lessEq}
    public string pref = "prefname|preftype";                     // Playerprefname|playerpreftype(no spaces unless you want them)
    public string positivevalue = "0";
    public string thevalue = "nada";
    public GameObject[] theitems = new GameObject[2];
    public bool turnon;

    [Header("switches")]
    public mycon way = mycon.equalto;
    public bool slotbased = true;
    public bool runOnAwake = true;
    public bool everyFrame = true;

    // Start is called before the first frame update
    void Start(){
        if(runOnAwake){runit();}
    }

    // Update is called once per frame
    void Update(){
        if(everyFrame){runit();}
    }

    void runit(){
        string[] tempdata = cm.splitTxt(pref);
        string prefix = "";
        if(slotbased){prefix = "saveslot_" + PlayerPrefs.GetInt("CurrentSlot",0) + "_";}
        thevalue = cm.getpref(prefix + tempdata[0],tempdata[1],"0");

        if(tempdata[1] == "string"){
            turnon = thevalue == positivevalue;
        } else {
            float refval = float.Parse(positivevalue);
            float myval = float.Parse(thevalue);
            switch (way){
                case mycon.equalto:
                    turnon = myval == refval;
                    break;
                case mycon.greater:
                    turnon = myval > refval;
                    break;
                case mycon.less:
                    turnon = myval < refval;
                    break;
                case mycon.greaterEq:
                    turnon = myval >= refval;
                    break;
                case mycon.lessEq:
                    turnon = myval <= refval;
                    break;
                default:
                    break;
            }
        }


        if(theitems.Length > 1){
            int num = turnon ? 2 : 1;
            int othernum = turnon ? 1 : 2;

            if(theitems[0] != null){cm.deact(theitems[0],num);}
            if(theitems[1] != null){cm.deact(theitems[1],othernum);}
        }
    }
}
