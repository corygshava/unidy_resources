using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableRotation : MonoBehaviour {

	public GameObject refObject;
	public Vector3 wantedRot;

	// Update is called once per frame
	void Update () {
		transform.eulerAngles = refObject != null ? refObject.transform.eulerAngles : wantedRot;
	}
}