using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activator : MonoBehaviour
{
    // this class activates/deactivates an object (obviously)

    public GameObject what;
    public bool activate = true;
    public bool runOnAwake = true;
    public bool runit = false;

    // Start is called before the first frame update
    void Start(){
        if(runOnAwake){runit = true;}
    }

    // Update is called once per frame
    void Update(){
        if(what != null){
            if(runit){
                runit = false;
                dosomething();
            }
        }
    }

    public void dosomething(){
        int num = activate ? 2 : 1;
        if(what != null){
            cm.deact(what,num);
        } else {
            Debug.Log("activator : no item to work on");
        }
    }
}
