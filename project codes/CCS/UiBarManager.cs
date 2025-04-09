using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBarManager : MonoBehaviour
{
    public Image bar;
    public float MaxValue = 1.0f;
    public float curValue = 0.4f;
    public float ratio = 0.1f;
    public float dampAmt = 0;
    public float refvel = 0;

    [Header("switches")]
    public bool ImageAttached = false;
    public bool realtime = true;
    public bool calculateRatio = true;
    public bool dampen = true;

    private void Start() {
        if(ImageAttached){
            bar = gameObject.GetComponent<Image>();
        }
    }

    private void Update() {
        if(curValue > MaxValue){
            curValue = MaxValue;
        } else if(curValue < 0){
            curValue = 0;
        }

        if(calculateRatio){ratio = (float) curValue / MaxValue;}
        if(dampen){dampAmt = Mathf.SmoothDamp(dampAmt,ratio,ref refvel,0.9f);}else {dampAmt = ratio;}
        if(dampAmt > ratio){dampAmt = ratio;}
        if(bar != null){bar.fillAmount = dampAmt;}
    }
}
