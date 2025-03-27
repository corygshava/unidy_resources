using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// from LoRL

public class DeactMe : MonoBehaviour
{
    public GameObject toDeact;
    public bool itsMe = true;
    public float delay = 1.2f;

    [Header("Switches")]
    public bool RunOnAwake = false;
    public bool runIt = false;
    public bool cancelIt = false;
    public bool destroyIt = false;
    public bool killWhenDone = true;

    // Start is called before the first frame update
    void Start()
    {
        if(itsMe == true){
            toDeact = this.gameObject;
        }

        if(RunOnAwake){
            runIt = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(runIt){StartCoroutine(Doit());runIt = false;}
        if(cancelIt){StopCoroutine(Doit());cancelIt = false;}
    }

    IEnumerator Doit(){
        delay = delay <= 0 ? 0.2f : delay;

        yield return new WaitForSeconds(delay);
        if(destroyIt){Destroy(toDeact);}
        else{cm.deact(toDeact,1);}

        if(killWhenDone){Destroy(this);}
    }
}
