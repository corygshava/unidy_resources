// C:\Users\CORY\Documents\Unity works\SA maps racing game\Assets\scripts\borrowed
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoToggle : MonoBehaviour
{
    // this script proceduraly switches between 2 or more objects
    
    public GameObject[] items;
    public float interval;

    [Header("timer method")]
    public int curitem;
    public float timer = 0.0f;

    [Header("switches")]
    public bool runOnAwake;
    public bool useTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        if(interval == 0){interval = 1.0f;}
        if(!useTimer){if(runOnAwake){runIt();}}
        else {timer = 0;}
    }

    // Update is called once per frame
    void Update()
    {
        if(useTimer){
            if(timer >= interval){
                changeIt();
                timer = 0;
            } else {
                timer += Time.deltaTime;
            }
        }
    }

    public void runIt(){
        if(items != null){StartCoroutine(SwitchIt(interval));}
    }

    public void changeIt(){
        curitem += 1;
        
        if(curitem == items.Length){curitem = 0;}

        cm.deactArray(items,1);
        cm.deact(items[curitem],2);
    }

    IEnumerator SwitchIt(float tym){
        Debug.Log("toggle started");

        for(int x = 0;x < 200;x++){
            for(int i = 0;i<items.Length;i++){
                cm.deactArray(items,1);
                cm.deact(items[i],2);

                Debug.Log("Autotoggle : toggle running, " + x + " cycles remaining ");
                yield return new WaitForSeconds(tym);
            }
            Debug.Log("Autotoggle : entered loop, " + x + " cycles remaining ");
        }
        Debug.Log("Autotoggle : left the loop");
        cm.deactArray(items,1);
    }
}
