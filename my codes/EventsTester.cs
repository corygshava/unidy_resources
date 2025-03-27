using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsTester : MonoBehaviour
{
    // requires eventstest class to work
    // this was made to test out functionality of the eventstest class

    EventsTest testguy;
    public int num = 3;
    // Start is called before the first frame update
    void Start(){
        testguy = GetComponent<EventsTest>();
        testguy.OnSpacePressed += dosomething;
        testguy.OnNewEvent += dosomethingelse;
        testguy.OnNewAct += dosomethingnew;
        testguy.OnNewThingy += dosomethingBoring;
    }

    void dosomething(object sender,EventsTest.customEventArgs e){
        Debug.Log("Space! pressed this many times - "+e.times);
    }

    void dosomethingelse(float what){
        Debug.Log("and your number is "+what);
    }

    void dosomethingnew(float amtr){
        Debug.Log("your lucky number is "+amtr);
    }

    void dosomethingBoring(){
        Debug.Log("boooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooring");
    }

    void dosomethingnewer(){
        Debug.Log("OK jeez, i get it you can press the space button. now ill reset it to 0");
    }
}
