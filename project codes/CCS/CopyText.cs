using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyText : MonoBehaviour
{
    public Text source;
    public Text destination;

    [Header("additional text")]
    public string prefix = "";
    public string suffix = "";

    [Header("switches")]
    [SerializeField] bool runOnAwake = true;
    [SerializeField] bool everyFrame = false;
    public bool runit = true;

    // Start is called before the first frame update
    void Start(){
        runit = runOnAwake;
    }

    // Update is called once per frame
    void Update(){
        if(runit){
            runit = false;

            dostuff();
        }

        runit = everyFrame;
    }

    void dostuff(){
        string intertxt = cm.getValue(source.gameObject);
        cm.seTxt(destination.gameObject,$"{prefix}{intertxt}{suffix}");
    }
}
