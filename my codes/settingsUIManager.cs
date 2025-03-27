using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsUIManager : MonoBehaviour
{
    // makes it easier to set stuff based on turning playerprefs on or off

    [Header("prefs data")]
    public int curslot;
    [SerializeField] string prefix;
    [SerializeField] string setts_prefix = "";

    [Header("main UI panels and buttons")]
    public GameObject[] catBtns;
    public GameObject[] catUIs;

    [Header("UI panels prefs and markers (category 1)")]
    public string[] cat_1_prefs;
    public GameObject[] cat_1_markers;
    public bool cat_1_playerbased = true;
    public AudioSource cat_1_sfx;
    public string cat_1_sound;             // soundmanager reusable required

    [Header("UI panels prefs and markers (category 2)")]
    public string[] cat_2_prefs;
    public GameObject[] cat_2_markers;
    public bool cat_2_playerbased = true;
    public AudioSource cat_2_sfx;
    public string cat_2_sound;             // soundmanager reusable required

    [Header("common data")]
    public string negative_sound;
    public Color[] colors;
    public bool useSoundManager = true;

    // Start is called before the first frame update
    void Start(){
        getdata();
        setcat(0);
    }

    public void setcat(int what){
        GameObject who = catBtns[0];
        cm.deactArray(catUIs,1);
        cm.deact(catUIs[what],2);

        for (var x = 0; x < catBtns.Length; x++){
            who = catBtns[x];
            who.GetComponent<CanvasGroup>().alpha = 0.49f;
        }

        who = catBtns[what];
        who.GetComponent<CanvasGroup>().alpha = 0.99f;
    }

    void getdata(){
        curslot = PlayerPrefs.GetInt("CurrentSlot",0);
        setts_prefix = "GameSettings";                 // for global game settings
        prefix = "saveslot_" + curslot;                 // for player based settings

        string markerTxt = "OON",myprefix = cat_1_playerbased ? prefix : setts_prefix;
        Color mycol = colors[0];

        if(cat_1_prefs != null){
            for (var x = 0; x < cat_1_prefs.Length; x++){
                if(cat_1_markers[x] != null){
                    markerTxt = PlayerPrefs.GetInt(myprefix + "_" + cat_1_prefs[x],0) == 1 ? "ON" : "OFF";
                    mycol = markerTxt == "ON" ? colors[0] : colors[1];
                    cm.seTxtColor(cat_1_markers[x],mycol);
                    cm.seTxt(cat_1_markers[x],markerTxt);
                }
            }
        }
        // Debug.Log("settsUI man : cat 1 updated");

        myprefix = cat_2_playerbased ? prefix : setts_prefix;

        if(cat_2_prefs != null){
            for (var x = 0; x < cat_2_prefs.Length; x++){
                if(cat_2_markers[x] != null){
                    markerTxt = PlayerPrefs.GetInt(myprefix + "_" + cat_2_prefs[x],0) == 1 ? "ON" : "OFF";
                    mycol = markerTxt == "ON" ? colors[0] : colors[1];
                    cm.seTxtColor(cat_2_markers[x],mycol);
                    cm.seTxt(cat_2_markers[x],markerTxt);
                }
            }
        }
        // Debug.Log("settsUI man : cat 2 updated");
    }

    public void updateSetting(int catno,int rno) {
        string[] prefs;
        string myprefix = "",mypref = "",thesound = "nada";
        int theval = 0;

        switch (catno){
            case 1:
                myprefix = cat_1_playerbased ? prefix : setts_prefix;
                prefs = cat_1_prefs;
                if(cat_1_sfx != null && !useSoundManager){
                    cat_1_sfx.Play();
                }
                thesound = cat_1_sound;
                break;
            case 2:
                myprefix = cat_2_playerbased ? prefix : setts_prefix;
                prefs = cat_2_prefs;
                if(cat_2_sfx != null && !useSoundManager){
                    cat_2_sfx.Play();
                }
                thesound = cat_2_sound;
                break;
            default:
                return;
        }

        if(rno >= prefs.Length){return;}

        mypref = myprefix + "_" + prefs[rno];

        theval = PlayerPrefs.GetInt(mypref,0) == 1 ? 0 : 1;
        PlayerPrefs.SetInt(mypref,theval);
        thesound = theval == 1 ? thesound : negative_sound;
        if(FindObjectOfType<SoundManager>()){FindObjectOfType<SoundManager>().PlaySound(thesound);}

        getdata();
        cm.logme(this,"UI updated");
    }

    public void updateSetting_cat1(int what){updateSetting(1,what);}
    public void updateSetting_cat2(int what){updateSetting(2,what);}
}
