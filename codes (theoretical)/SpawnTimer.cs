using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{

    public GameObject Spawns;
    public Transform parent;
    public float timer;
    public float waitDuration = 12f;
    public bool once;

    // Start is called before the first frame update
    void Start()
    {
        parent = FindObjectOfType<EnemiesHolder>().gameObject.transform;
        SpawnMe();
    }

    // Update is called once per frame
    void Update()
    {
        if(!once){
            if(timer <= waitDuration){
                timer += Time.deltaTime;
            } else {
                SpawnMe();
                timer = 0;
            }
        }
    }

    public void SpawnMe(){
        Instantiate(Spawns,transform.position,transform.rotation,parent);
    }
}
