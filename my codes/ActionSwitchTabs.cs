using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSwitchTabs : MonoBehaviour
{
    public GameObject[] tabs;
    public int curtab = 0;

    [Header("for using canvas group")]
    public float maxAlpha = 0.99f;
    public float minAlpha = 0.3f;

    [Header("switches")]
    public bool useCanvasGroup = false;
    [SerializeField] bool RunOnAwake = true;
    [SerializeField] bool next = false;
    [SerializeField] bool previous = false;

    // Start is called before the first frame update
    void Start(){
        if(RunOnAwake){
            switchtab(curtab);
        }
    }

    // Update is called once per frame
    void Update(){
        if(next){
            curtab += 1;
            next = false;
            switchtab(curtab);
        }
        if(previous){
            curtab += 1;
            previous = false;
            switchtab(curtab);
        }
    }

    public void switchtab(int num) {
        foreach (var item in tabs){
            if(item != null){
                if(!useCanvasGroup){
                    cm.deact(item,1);
                } else {
                    if(item.GetComponent<CanvasGroup>()){
                        item.GetComponent<CanvasGroup>().alpha = minAlpha;
                    } else {
                        Debug.Log("didnt work");
                    }
                }
            }
        }

        int theid = num % tabs.Length;
        var myitem = tabs[theid];
        if(myitem != null){
            if(!useCanvasGroup){
                cm.deact(myitem,2);
            } else {
                if(myitem.GetComponent<CanvasGroup>()){
                    myitem.GetComponent<CanvasGroup>().alpha = maxAlpha;
                } else {
                    Debug.Log("didnt work");
                }
            }
        }
    }
}
