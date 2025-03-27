using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOthers : MonoBehaviour
{
    // the point is to create a script that hides items when im active and unhides them when I'm not
    public GameObject[] items;
    [SerializeField] bool canWork = true;
    [SerializeField] bool enable = false;

    private void OnEnable() {
        if(canWork){cm.deactArray(items,!enable);}
    }

    private void OnDisable() {
        if(canWork){cm.deactArray(items,enable);}
    }
}
