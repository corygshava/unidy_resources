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

    // Start is called before the first frame update
    void Start()
    {
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

    public static GameObject spawnRes(string path){
        GameObject res = Instantiate(Resources.Load<GameObject>(path));
        return res;
    }
}
