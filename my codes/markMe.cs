// last updated on 19/01/2025 at 4:16pm

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markMe : MonoBehaviour {

	public enum updateType{Fixed,Late,Normal};
	public GameObject markObj;
	public updateType updateMode = updateType.Normal;

	[Header("Position tracking")]
	public Vector3 offset;
	public bool smoothFollow;
	public float damping;

	[Header("Position multiplier")]
	public Vector3 positionMultiplier;
	public bool useMultiplier = false;

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
			markMeCode();
		}
	}

	void FixedUpdate() {
		if(updateMode == updateType.Fixed){
			markMeCode();
		}
	}

	void LateUpdate() {
		if(updateMode == updateType.Late){
			markMeCode();
		}
	}

	void markMeCode(){
		if(markObj != null){
			Vector3 thepos = transform.position;

			if(!smoothFollow){
				thepos = markObj.transform.position + offset;
			} else {
				thepos = Vector3.Lerp(transform.position,markObj.transform.position,damping);
			}

			if(useMultiplier){
				thepos = cm.multiplyVector3(positionMultiplier,thepos);
			}

			transform.position = thepos;

			if (rotationToo) {
				if (smoothRotation) {
					gameObject.transform.rotation = Quaternion.Slerp (transform.rotation, markObj.transform.rotation, smoothspeed * Time.deltaTime);
				} else {
					gameObject.transform.rotation = markObj.transform.rotation;
				}
			}
		}
	}

	public void setfocus(GameObject theObj) {
		markObj = theObj;
	}
}
