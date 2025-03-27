using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarDisplay : MonoBehaviour
{
    public Image thebar;
    [Range(0,1)]
    public float amt;

    // Update is called once per frame
    void Update(){
        updateIt();
    }

    void updateIt(){
        if(thebar != null){
            thebar.fillAmount = amt;
        } else {
            Debug.Log($"[{gameObject.name}] BarDis : no image attached, deactivating");
            this.enabled = false;
        }
    }
}
