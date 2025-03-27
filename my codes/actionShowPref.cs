using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionShowPref : MonoBehaviour
{
    public string prefname = "prefname|preftype";
    public string thevalue = "--";
    public GameObject display;

    [Header("switches")]
    public bool slotbased = true;
    public bool runOnAwake = true;
    public bool everyframe = true;

    // Start is called before the first frame update
    void Start(){
        if(runOnAwake){
            showIt();
        }
    }

    // Update is called once per frame
    void Update(){
        if(everyframe){
            showIt();
        }
    }

    public void showIt() {
        string prefix = "";
        string[] tempdata = cm.splitTxt(prefname);

        if(slotbased){
            int curslot = PlayerPrefs.GetInt("CurrentSlot",0);
            prefix = $"saveslot_{curslot}_";
        }

        // Debug.Log(tempdata.Length);
        // return;
        thevalue = cm.getpref($"{prefix}{tempdata[0]}",tempdata[1],"0");

        // update UI
        if(display != null){
            cm.seTxt(display,thevalue);
        }
    }
}
