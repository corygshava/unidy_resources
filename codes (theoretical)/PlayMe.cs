using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMe : MonoBehaviour
{

    public Animator anim;
    public bool PlayIt;
    public string AnimName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayIt){
            PlayIt = false;
            playAnim();
        }
    }

    public void playAnim(){
        anim.Play(AnimName);
    }

    public void PlayThis(string what){
        anim.Play(what);
    }

    public void playThis2(string what,Animator animm){
        animm.Play(what);
    }

    public void SetBool(string what,bool value){
        anim.SetBool(what,value);
    }

    public void SetFloat(string what,float value){
        anim.SetFloat(what,value);
    }
}
