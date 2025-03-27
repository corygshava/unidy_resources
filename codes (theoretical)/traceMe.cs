using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traceMe : MonoBehaviour {

	public GameObject traced;
	public bool imTheTracer;
	public GameObject traceObject;
	public bool OnlyOnce;

	// Use this for initialization
	void Start () {
		if (imTheTracer) {
			gameObject.transform.LookAt (traced.transform.position);
		} else {
			traceObject.transform.LookAt (traced.transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!OnlyOnce) {
			if (imTheTracer) {
				gameObject.transform.LookAt (traced.transform.position);
			} else {
				traceObject.transform.LookAt (traced.transform.position);
			}
		}
	}
}
