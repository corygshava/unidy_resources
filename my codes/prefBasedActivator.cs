// last modified on 9/8/23 at 11:44am
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefBasedActivator : MonoBehaviour
{
    public enum mycon{equalto,greater,less,greaterEq,lessEq,hastext,isnot}
    public string pref = "prefname|preftype";                     // prefname|preftype
    public string positivevalue = "0";
    public string thevalue = "nada";
    public GameObject theitem;
    public GameObject[] items;
    public bool turnon;

    [Header("switches")]
    [Tooltip("for string types you can only use equalto,hastext and isnot")]
    public mycon way = mycon.equalto;
    public bool slotbased = true;
    public bool runOnAwake = true;
    public bool everyFrame = true;
    public bool itsme = false;

    void Awake() {
        if(theitem == null){
            if(items != null){
                theitem = (items.Length == 0) ? gameObject : items[0];
            } else {
                theitem = gameObject;
            }
        }

        if(itsme){theitem = gameObject;}
    }

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

            switch(way){
                case mycon.equalto:
                    turnon = turnon;
                    break;
                case mycon.hastext:
                    turnon = cm.hasTxt($"{positivevalue}",$"{thevalue}");
                    break;
                case mycon.isnot:
                    turnon = thevalue != positivevalue;
                    break;
                default:
                    cm.logme(this,"please specify a valid way");
                    break;
            }
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
                case mycon.hastext:
                    turnon = cm.hasTxt($"{positivevalue}",$"{thevalue}");
                    break;
                case mycon.isnot:
                    turnon = myval != refval;
                    break;
                default:
                    break;
            }
        }

        if(theitem != null){
            int num = turnon ? 2 : 1;
            cm.deact(theitem,num);
            if(items != null){
                if(items.Length > 0){
                    cm.deactArray(items,num);
                }
            }
        }
    }
}
