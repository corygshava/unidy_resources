using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mytag : MonoBehaviour
{
    // used as a simpler version of screentag 
    // attach to a UI element you want to follow a gameObject around the screen

    public Camera cam;

    [Header("in case you want to use a gameObject")]
    public GameObject target;       // in case you want to use a gameobject

    [Header("for using a preset position")]
    public Vector3 trackpos;
    public bool usetrackpos;

    public Vector3 offset;

    // Update is called once per frame
    void Update(){
        if(cam == null){cam = FindObjectOfType<Camera>();}

        trackit();
    }

    void trackit(){
        Vector3 pos = Vector3.zero;
        if(usetrackpos){
            pos = cam.WorldToScreenPoint(trackpos + offset);
        }else if(target != null){
            pos = cam.WorldToScreenPoint(target.transform.position + offset);
        } else {
            Debug.Log("mytag : cant run without a target or position");
            return;
        }

        transform.position = pos;
    }
}
