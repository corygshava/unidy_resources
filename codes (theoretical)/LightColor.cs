using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{
    public Light lamp;
    public Color col;

    [Header("switches")]
    public bool updateIt = true;
    public bool itsme = true;

    // Start is called before the first frame update
    void Start()
    {
        if(itsme){if(GetComponent<Light>()){lamp = GetComponent<Light>();}}
    }

    // Update is called once per frame
    void Update()
    {
        if(updateIt){
            updateIt = false;
            if(lamp != null){lamp.color = col;}
        }
    }

    public void updateCol(Color thecol){
        col = thecol;
        updateIt = true;
    }
}
