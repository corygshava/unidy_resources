using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class creditNames : MonoBehaviour
{
    public string[] NamesNRoles;        // write as "role|name"
    int currole = -1;
    [SerializeField] int startingNumber = 0;
    public GameObject[] texts = new GameObject[2];

    [Header("runtime data")]
    public float interval = 5.0f;
    float timer = 0;
    [SerializeField] bool cyclic = true;
    [SerializeField] bool usebar = false;

    [Header("events")]
    public UnityEvent OnRoundOver;
    public UnityEvent OnFinishAll;

    [Header("for the bar effect")]
    public GameObject thebar;
    public float ratio;

    [Header("for extra but unneccessary stuff")]
    public GameObject extraTxt;
    public int toskip = 0;

    event Action OnFinishRound;
    event Action OnFinish;

    // Start is called before the first frame update
    void Start(){
        OnFinishRound += nextline;
    }

    // Update is called once per frame
    void Update(){
        if(timer < interval){
            timer += Time.deltaTime;
            updateratio();
        } else {
            OnFinishRound?.Invoke();
            OnRoundOver?.Invoke();
        }
    }

    void updateratio(){
        ratio = (float) timer / interval;
        if(usebar){
            if(thebar != null){cm.setColorBgAmt(thebar,ratio);}
            else{Debug.Log("creditnames : assign a bar image object for me to work");}
        }
    }

    void nextline(){
        currole += 1;
        startingNumber = Mathf.Clamp(startingNumber,0,NamesNRoles.Length - 1);

        if(currole >= NamesNRoles.Length){
            timer = cyclic ? 0 : timer;
            currole = cyclic ? startingNumber : (NamesNRoles.Length - 1);
            OnFinish?.Invoke();
            OnFinishAll?.Invoke();
        } else {
            timer = 0;
        }

        // Debug.Log("crednames : currole set to "+ currole);

        string[] wads = cm.splitTxt("|",NamesNRoles[currole]);

        for (var x = 0; x < wads.Length; x++){
            if(x < texts.Length){
                if(texts[x] != null){
                    cm.seTxt(texts[x],wads[x]);
                    // Debug.Log("crednames : set text["+x+"] to " + wads[x]);
                }
            }
        }

        if(extraTxt != null){cm.seTxt(extraTxt,currole + " / " + (NamesNRoles.Length - toskip));}
    }

    // just for fun
    public void removetime(float what) {
        interval -= what;
        if(interval <= 0.5f){interval = 6.3f;}
    }

    public void addtime(float what) {
        interval += what;
        if(interval >= 6.5f){interval = 0.9f;}
    }
}
