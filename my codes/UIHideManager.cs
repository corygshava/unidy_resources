using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHideManager : MonoBehaviour
{
    [Header("UI items (must be less that 11 to work properly)")]
    public GameObject[] uiItems;

    // Update is called once per frame
    void Update()
    {
        for (var x = 0; x <= 9; x++){
            if(x >= uiItems.Length){
                break;
            }
            if(Input.GetKeyDown(x+"")){
                if(uiItems[x] != null){
                    cm.toggleActive(uiItems[x]);
                }
            }
        }
    }
}
