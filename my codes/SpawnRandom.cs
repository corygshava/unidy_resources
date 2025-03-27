// created on firstDay/24 at 12:40PM
// last modified on firstDay/24 at 2:51PM

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    [Tooltip("options to choose from")]
    public GameObject[] items;
    [Tooltip("where could they spawn")]
    public GameObject[] refitems;
    [Tooltip("what will hold the spawned items")]
    public GameObject holder;
    [Tooltip("Only use the first spawnpoint")]
    public bool singleSpawnPoint = true;
    [Tooltip("what has been spawned")]
    public GameObject spawned;

    [Header("switches")]
    public bool spawnNow = false;
    public bool spawnOnAwake = true;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnOnAwake){
            spawnIt();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnNow){
            spawnNow = false;
            spawnIt();
        }
    }

    public void spawnIt(){
        if(items.Length > 0 && refitems.Length > 0){
            int spawnid = Random.Range(0,items.Length);
            int spawnid2 = 0;

            if(!singleSpawnPoint){
                spawnid2 = Random.Range(0,refitems.Length);
            }

            if(holder == null)
                spawned = Instantiate(items[spawnid],refitems[spawnid2].transform.position,refitems[spawnid2].transform.rotation);
            else
                spawned = Instantiate(items[spawnid],refitems[spawnid2].transform.position,refitems[spawnid2].transform.rotation,holder.transform);
        } else {
            Debug.Log($"{this} : set the required items first");
        }
    }
}
