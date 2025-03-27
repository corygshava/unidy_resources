using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour
{
    public GameObject[] texts;
    public Color thecolor;

    public bool run;
    public bool runOnAwake = true;
    // Start is called before the first frame update
    void Start(){
        run = runOnAwake;
    }

    // Update is called once per frame
    void Update(){
        if(run){
            run = false;
            setcolor();
        }
    }

    public void setcolor() {
        for (var x = 0; x < texts.Length; x++){
            cm.setTxtColor(texts[x],thecolor);
        }
    }

    public void setcolorref(GameObject text) {
        thecolor = cm.getTxtColor(text);
    }
}
