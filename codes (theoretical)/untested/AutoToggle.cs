using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoToggle : MonoBehaviour
{
    public GameObject[] items;
    public float interval;
    [Tooltip("how many times should it cycle through them 0 makes it infinite")]
    public float cycles = 0;

    [Header("switches")]
    public bool runOnAwake;
    public bool infinite = true;
    public bool endit = false;

    // Start is called before the first frame update
    void Start(){
        if(interval == 0){interval = 1.0f;}
        if(runOnAwake){runIt();}
    }

    // Update is called once per frame
    void Update(){
        if(endit){
            endit = false;

            StopCoroutine(SwitchIt(interval));;
        }
    }

    public void runIt(){
        if(items != null){StartCoroutine(SwitchIt(interval));}
    }

    IEnumerator SwitchIt(float tym){
        Debug.Log("toggle started");

        for(int x = 0;x < cycles;x++){
            for(int i = 0;i<items.Length;i++){
                cm.deactArray(items,1);
                cm.deact(items[i],2);

                Debug.Log("toggle running");
                yield return new WaitForSeconds(tym);
            }

            Debug.Log("entered loop");
        }
        Debug.Log("left the loop");
        cm.deactArray(items,1);
    }
}
