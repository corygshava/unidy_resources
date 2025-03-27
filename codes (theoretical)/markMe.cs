// last updated on 21/7/23 at 2:01am

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markMe : MonoBehaviour {

	public enum updateType{Fixed,Late,Normal};
	public GameObject markObj;
	public updateType updateMode = updateMode.Normal;
	[Header("Position tracking")]
	public Vector3 offset;
	public bool smoothFollow;
	public float damping;

	[Header("Rotation tracking")]
	public bool rotationToo;
	public float smoothspeed = 0.2f;
	public bool smoothRotation;

	// Use this for initialization
	void Start () {
		if(markObj != null){gameObject.transform.position = markObj.transform.position;}
	}
	
	// Update is called once per frame
	void Update () {
		if(updateMode == updateType.Normal){
			if(markObj != null){
				if(!smoothFollow){
					gameObject.transform.position = markObj.transform.position + offset;
				} else {
					transform.position = Vector3.Lerp(transform.position,markObj.transform.position,damping);
				}
				if (rotationToo) {
					if (smoothRotation) {
						gameObject.transform.rotation = Quaternion.Slerp (transform.rotation, markObj.transform.rotation, smoothspeed * Time.deltaTime);
					} else {
						gameObject.transform.rotation = markObj.transform.rotation;
					}
				}
			}
		}
	}

	void FixedUpdate() {
		if(updateMode == updateType.Fixed){
			if(markObj != null){
				if(!smoothFollow){
					gameObject.transform.position = markObj.transform.position + offset;
				} else {
					transform.position = Vector3.Lerp(transform.position,markObj.transform.position,damping);
				}
				if (rotationToo) {
					if (smoothRotation) {
						gameObject.transform.rotation = Quaternion.Slerp (transform.rotation, markObj.transform.rotation, smoothspeed * Time.deltaTime);
					} else {
						gameObject.transform.rotation = markObj.transform.rotation;
					}
				}
			}
		}
	}

	void LateUpdate() {
		if(updateMode == updateType.Late){
			if(markObj != null){
				if(!smoothFollow){
					gameObject.transform.position = markObj.transform.position + offset;
				} else {
					transform.position = Vector3.Lerp(transform.position,markObj.transform.position,damping);
				}
				if (rotationToo) {
					if (smoothRotation) {
						gameObject.transform.rotation = Quaternion.Slerp (transform.rotation, markObj.transform.rotation, smoothspeed * Time.deltaTime);
					} else {
						gameObject.transform.rotation = markObj.transform.rotation;
					}
				}
			}
		}
	}
}
