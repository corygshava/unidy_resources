using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//needs ScreenTag script to work correctly

public class tagTrigger : MonoBehaviour
{
    public string mytag;
    public GameObject myclient;
    public bool inrange;

    [Header("UI tag")]
    public string tagtype;
    public ScreenTag uitag;
    public Vector3 offset;
    
    [Header("display data")]
    public bool useTxt;
    public string toshow;

    // Start is called before the first frame update
    void Start()
    {
        getTag();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag(mytag)){
            if(uitag != null){
                uitag.playanim();
            } else {
                cm.logme(this,"no UI tag attached");
            }
        } else {
            cm.logme(this,"not my tag");
        }
    }

    void OnTriggerStay(Collider other) {
        if(other.CompareTag(mytag)){
            if(uitag != null){
                inrange=true;
                myclient = other.gameObject;
                uitag.setTarget(myclient,offset);

                if(useTxt){uitag.setTxt(toshow);}
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.CompareTag(mytag)){
            inrange=false;
            myclient = null;
            if(uitag != null){uitag.resetMe();}
        }
    }

    void getTag(){
        ScreenTag[] alltags = FindObjectsOfType<ScreenTag>();

        for (var x = 0; x < alltags.Length; x++){
            if(alltags[x].type == tagtype){
                uitag = alltags[x];
            }
        }
    }

    void OnDestroy(){
        if(uitag != null){uitag.resetMe();}
    }
}
