using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsTest : MonoBehaviour
{
    // this class is a playground for events
    // use it as a reference to find out how events work

    public event EventHandler<customEventArgs> OnSpacePressed;
    public class customEventArgs : EventArgs {
        public int times;
    }
    public int timespressed = 0;

    public delegate void Testdelegate(float wt);
    public event Testdelegate OnNewEvent;

    public delegate void customEvent(float amt);
    public event customEvent OnNewAct;

    public delegate void newma();
    public event newma OnNewThingy;

    public event Action OnnewAction0;
    public event Action<int,bool> OnNewAction;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
