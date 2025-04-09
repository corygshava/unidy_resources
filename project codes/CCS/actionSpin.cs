using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionSpin : MonoBehaviour
{
    // this class spins an object based on a predefined axis

    public bool spin;
    public Vector3 spinaxis = new Vector3(0,10,0);
    public bool timeDependant = true;               // if it should depend on time speed
    float multiplier = 25.2f;

    // Update is called once per frame
    void Update(){
        if(spin){
            if(!timeDependant){
                transform.Rotate(spinaxis);
            } else {
                transform.Rotate(spinaxis * Time.deltaTime * multiplier);
            }
        }
    }

    public void toggleSpin(){
        spin = !spin;
    }

    public void spinme(bool con){
        spin = con;
    }

    public void spinme(){
        spin = true;
    }

    public void dontspin(){
        spin = false;
    }

    public void setaxis(Vector3 ax){
        spinaxis = ax;
    }

    public void settimescaling(bool con){
        timeDependant = con;
    }

    public void setmultiplier(float mul) {
        multiplier = mul;
    }
}
