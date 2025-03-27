// last updated on 19/01/2025 at 7:05pm

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMe : MonoBehaviour
{
    public GameObject toSpawn;
    public GameObject[] spawns;
    public GameObject refObj;
    public GameObject parent;
    public GameObject spawned = null;

    [Header("spawn helpers")]
    public bool useArray = false;
    public bool SpawnAgain;
    public bool SpawnOnAwake;
    public bool SpawnHere = true;
    public bool illHoldIt = false;

    // runtime events
    public event Action<GameObject> OnSpawn;

    // Start is called before the first frame update
    void Start()
    {
        if(illHoldIt){parent = gameObject;}
        if(SpawnOnAwake){if(!useArray){spawnIt();}else{spawnArray(spawns);}}
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnAgain){SpawnAgain = false;if(!useArray){spawnIt();}else{spawnArray(spawns);}}
    }

    public void spawnIt(){
        if(toSpawn != null){
            Vector3 pos = refObj == null ? Vector3.zero : refObj.transform.position;
            Quaternion rot = refObj == null ? Quaternion.identity : refObj.transform.rotation;
            
            if(SpawnHere){pos = transform.position;rot = transform.rotation;}
            if(parent == null){spawned = Instantiate(toSpawn,pos,rot);}
            else {spawned = Instantiate(toSpawn,pos,rot,parent.transform);}
        }

        OnSpawn?.Invoke(spawned);
    }

    public void setSpawn(GameObject what){
        toSpawn = what;
    }

    public void spawnAndGo(GameObject what){
        setSpawn(what);
        spawnIt();
    }

    public void spawnArray(GameObject[] what){
        foreach (GameObject me in what)
        {
            spawnAndGo(me);
        }
    }

    //returns gameObjects

    public static GameObject spawnRes(string path){
        GameObject res = Instantiate(Resources.Load<GameObject>(path));
        return res;
    }

    public static GameObject spawnRes(string path,Transform itsparent){
        GameObject res = Instantiate(Resources.Load<GameObject>(path),Vector3.zero,Quaternion.identity,itsparent);
        return res;
    }

    public static GameObject spawnRef2(GameObject what,GameObject refItem){
        return Instantiate(what,refItem.transform.position,refItem.transform.rotation);
    }

    public static GameObject spawnIt(GameObject what){
        return Instantiate(what,Vector3.zero,Quaternion.identity);
    }

    // just runs

    public static void spawnMe(GameObject what){
        Instantiate(what,Vector3.zero,Quaternion.identity);
    }

    public static void spawnRef(GameObject what,GameObject refItem){
        Instantiate(what,refItem.transform.position,refItem.transform.rotation);
    }

    public static void spawnMe(GameObject what,Vector3 where,Quaternion rot){
        Instantiate(what,where,rot);
    }

    public static void spawnMe(GameObject what,Vector3 where,Quaternion rot,GameObject holder){
        Instantiate(what,where,rot,holder.transform);
    }

    public static void spawnAndHold(GameObject what,GameObject holder){
        Instantiate(what,holder.transform.position,holder.transform.rotation,holder.transform);
    }
}
