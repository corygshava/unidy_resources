using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomActivator : MonoBehaviour
{
    public GameObject[] items;
    public GameObject chosen;

    public bool RunOnAwake = true;
    public bool runit;

    // Start is called before the first frame update
    void Start(){
        runit = RunOnAwake;
    }

    // Update is called once per frame
    void Update(){
        if(runit){runit = false;doit();}
    }

    void doit(){
        if(items.Length == 0){
            Debug.Log("randActivator : add items for me to work properly");
            return;
        }

        int tospawn = (items.Length > 1) ? Random.Range(0,items.Length) : 0;
        chosen = items[tospawn];

        cm.deactArray(items,1);
        cm.deact(chosen,2);
        Debug.Log("randActivator : it should have activated");
    }
}
