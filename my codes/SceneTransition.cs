using System.Security.Cryptography;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{

    [Header("Input data")]
    public float interval;
    public int SceneID;
    public string SceneName;
    public float TimeElapsed;

    [Header("Runtime data")]
    public bool useName;
    public bool runTimer;
    public bool RunOnAwake;
    public bool Terminate;
    public bool running = false;
    public bool usekey;

    // Start is called before the first frame update
    void Start(){
        if(RunOnAwake){
            StartCoroutine(LoadIt());
        }
    }

    // Update is called once per frame
    void Update(){
        if(runTimer){
            StartCoroutine(LoadIt());
            runTimer = false;
        }

        if(Terminate){
            StopCoroutine(LoadIt());
            Terminate = false;
        }

        if(usekey){
            if(Input.GetKeyDown(KeyCode.Return)){
                runTimer = true;
            }
        }

        TimeElapsed += Time.deltaTime;
    }

    IEnumerator LoadIt(){
        running = true;
        interval = interval == 0 ? 1.0f : interval;

        yield return new WaitForSeconds(interval);

        if(!useName){
            cm.loadLvla (SceneID);
        } else {
            cm.loadLvlb (SceneName);
        }

        running = false;
    }

    public void SetSceneName(string what){
        SceneName = what;
    }

    public void SetSceneId(int what){
        SceneID = what;
    }

    public void SetTimer(float what){
        interval = what;
    }

    public void runLoader(){
        if(!running){
            runTimer = true;
        }
    }

    public void StopIt(){
        Terminate = true;
    }

    //Special functions
    public void ContinueLastLvl(){
        string thescene = PlayerPrefs.GetString("LastLvl");

        if(thescene == null || thescene == ""){
            thescene = "tutorial";
        }
        
        SetSceneName(thescene);
        runLoader();
    }
}
