using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontKillMe : MonoBehaviour
{
    public GameObject keeper;
    public static DontKillMe instance;
    public bool me;
    // Start is called before the first frame update
    void Start()
    {
        if(keeper == null || me){
            keeper = gameObject;
        }

        if(instance == null){
            DontDestroyOnLoad(keeper);
        } else {
            if(instance != this){
                Destroy(keeper);
            } else {
                DontDestroyOnLoad(keeper);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
