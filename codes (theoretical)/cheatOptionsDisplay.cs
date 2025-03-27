using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatOptionsDisplay : MonoBehaviour
{
    // this is code for showing all the different cheats available to the player
    public CheatsListener cl;
    public CheatsHandler ch;
    public GameObject display;
    public List<string> texts = new List<string>();

    public float timer;
    public float interval;
    public int curtext = 0;
    [SerializeField]bool active = false;

    void Start() {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<CheatsHandler>()){
            active = true;
        } else {
            active = false;
            return;
        }

        if(active){
            cl = FindObjectOfType<CheatsListener>();
            ch = FindObjectOfType<CheatsHandler>();
            getStuff();
        }

        if(timer <= interval){
            timer += Time.deltaTime;
        } else {
            updateit();
        }
    }

    void getStuff(){
        texts = ch.cheatsReport;
    }

    void updateit(){
        timer = 0.0f;
        curtext += 1;

        if(curtext < 0){
            curtext = texts.Count + 1;
        } else if (curtext >= texts.Count){
            curtext = 0;
        }

        cm.seTxt(display,texts[curtext]);
    }
}
