using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traceMe : MonoBehaviour {

	public GameObject traced;
	public bool imTheTracer;
	public GameObject traceObject;
	public bool OnlyOnce;
	public bool smoothTrace;
	private GameObject reference;

	// Use this for initialization
	void Start () {
		reference = traceObject;

		if(traced != null){
			if (imTheTracer) {
				if (smoothTrace) {
					traceObject.transform.LookAt (traced.transform.position);
					gameObject.transform.rotation = smoothTrace ? Quaternion.Slerp (gameObject.transform.rotation, reference.transform.rotation, 0.7f) : reference.transform.rotation;
				} else {
					gameObject.transform.LookAt (traced.transform.position);
				}
			} else {
				traceObject.transform.LookAt (traced.transform.position);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(traced != null){
			if (imTheTracer) {
				if (smoothTrace) {
					traceObject.transform.LookAt (traced.transform.position);
					gameObject.transform.rotation = smoothTrace ? Quaternion.Slerp (gameObject.transform.rotation, reference.transform.rotation, 0.7f) : reference.transform.rotation;
				} else {
					gameObject.transform.LookAt (traced.transform.position);
				}
			} else {
				traceObject.transform.LookAt (traced.transform.position);
			}
		}
	}
}
