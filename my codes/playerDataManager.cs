using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerDataManager : MonoBehaviour
{
    [Header("all possible prefs")]
    public string[] allprefs = new string[]{"prefname"};

    int curslot = 0;
    string prefix = "";

    [Header("stuff to run")]
    public UnityEvent Onkillprefs;
    public event Action Ondeleteprefs;
    public event Action Ondeleteeverything;

    void setupstuff(){
        curslot = PlayerPrefs.GetInt("CurrentSlot",0);
        prefix = "saveslot_"+curslot+"_";
    }

    public void deleteMyData(){
        setupstuff();

        for (var x = 0; x < allprefs.Length; x++){
            cm.killpref(prefix + allprefs[x]);

            Debug.Log("playerdata : playerpref [" + prefix + allprefs[x] + "] deleted");
        }
        Ondeleteprefs?.Invoke();
        Onkillprefs?.Invoke();
    }

    public void deleteEverything(){
        PlayerPrefs.DeleteAll();
        Ondeleteeverything?.Invoke();
    }
}
