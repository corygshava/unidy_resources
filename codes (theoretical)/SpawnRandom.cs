using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    public GameObject[] liGoSpawn;
    public GameObject Holder;
    public bool userot;
    public bool SpawnOnAwake;
    public bool keepMe;

    // Start is called before the first frame update
    void Start()
    {
        if(SpawnOnAwake){
            SpawnMe();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {
        UnityEngine.Debug.Log("SpawnerDestroyed");
    }

    void SpawnMe(){
        GameObject goToSpawn = liGoSpawn[Random.Range(0,liGoSpawn.Length)];

        if(Holder != null){
            if(userot){
                Instantiate(goToSpawn,transform.position,Quaternion.identity,Holder.transform);
            } else {
                Instantiate(goToSpawn,transform.position,transform.rotation,Holder.transform);
            }
        } else {
            Instantiate(goToSpawn,transform.position,transform.rotation);
        }
        if(!keepMe){
            Destroy(gameObject);
        }
    }
}
