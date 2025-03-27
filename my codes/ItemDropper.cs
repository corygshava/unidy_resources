using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    // requires Spawnme class to work
    // it tracks an object until its destroyed
    // in that case, the item to drop is spawned
    // provided the item wasnt too close to the destination (specific for Cubie Can Shoot game)
    // delete the part containing UnlockHandler if this aint Cubie Can Shoot

    // in case it is after here data is passed onto UnlockHandler compo

    public GameObject todrop;
    public GameObject totrack;

    [Header("for passing on data to the drop item")]        // specific for Cubie can shoot
    public string topassOn = "I made you";

    [Header("for the distance threshold")]
    public GameObject destination;
    [SerializeField] float distance = 0.1f;
    [SerializeField] float minDistance = 4.876193f;
    [SerializeField] bool trackit = false;
    [SerializeField] bool itemDead = false;
    bool runkiller = false;
    Vector3 pos = Vector3.zero;

    // Update is called once per frame
    void Update(){
        if(trackit){
            traceItem();
        }

        if(runkiller){
            dropsomething();
        }
    }

    void traceItem(){
        if(totrack == null){
            itemDead = true;
            runkiller = true;
            // Debug.Log("dropper : item is dead");
        } else {
            pos = totrack.transform.position;
            pos.y = 0.25f;
            transform.position = pos;
            distance = Vector3.Distance(transform.position,destination.transform.position);
            // Debug.Log("dropper : item is alive");
        }
    }

    void dropsomething(){
        trackit = false;
        runkiller = false;
        bool spawnit = true;

        if(destination != null){
            distance = Vector3.Distance(transform.position,destination.transform.position);

            spawnit = distance > minDistance;
            if(!spawnit){Debug.Log("dropper : too close");}
            else {Debug.Log($"dropper : close enough ({distance} / {minDistance})");}
        }

        if(spawnit & todrop != null){
            nowdropit();
        }
    }

    void nowdropit(){
        if(todrop.GetComponent<UnlockHandler>()){
            todrop.GetComponent<UnlockHandler>().unlockStr = topassOn;
        }

        // and thus ends my journey as the tracking device of an enemy
        SpawnMe.spawnRef(todrop,gameObject);
        Destroy(gameObject);
    }

    // setup scripts
    public void setMeup(GameObject dropme,GameObject trackme) {
        todrop = dropme;
        totrack = trackme;
        trackit = true;
    }

    public void setMeup(GameObject dropme,GameObject trackme,GameObject target) {
        todrop = dropme;
        totrack = trackme;
        destination = target;
        trackit = true;
    }
}
