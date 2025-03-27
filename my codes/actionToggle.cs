using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionToggle : MonoBehaviour
{
    public GameObject what;
    public bool toggleMe;
    public bool runOnAwake;
    public bool runOnKeyPress = false;
    public bool useShift = false;
    public KeyCode thekey = KeyCode.A;

    // Start is called before the first frame update
    void Start(){
        toggleMe = runOnAwake;
    }

    // Update is called once per frame
    void Update(){
        if(toggleMe){
            toggleMe = false;
            toggleIt();
        }

        if(runOnKeyPress){
            if(useShift){
                toggleMe = Input.GetKeyDown(thekey) && Input.GetKey(KeyCode.LeftShift);
            } else {
                toggleMe = Input.GetKeyDown(thekey);
            }
        }
    }

    public void toggleIt() {
        string text = "nada";

        if(what != null){
            text = $"{what.name} toggled";
            cm.toggleActive(what);
        } else {
            text = "no gameObject set";
        }

        Debug.Log($"[{gameObject.name}] - actToggle : {text}");
    }
}
