using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemykilla : MonoBehaviour
{
    // requires healthmanager class to work
    // this class autokills anything with a healthManager component attached so stay away, please

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<healthManager>()){
            other.GetComponent<healthManager>().armor = 0;
            other.GetComponent<healthManager>().hurt(other.GetComponent<healthManager>().maxhealth + 1);
        }
    }
}
