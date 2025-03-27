using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {

	public GameObject refObj;
	public GameObject toChange;

	public float smoothTime = 0.4f;
	public bool smoothChange = true;
	public bool itsme;

	[Header("rotation values")]
	[SerializeField] Vector3 myn;
	[SerializeField] Vector3 other;
	[SerializeField] Vector3 multiplier;
	[SerializeField] Vector3 wantedRot;

	[Header("Rotation controls")]
	public bool lockX = true;
	public bool lockY = true;
	public bool lockZ = true;

	void Start() {
		if(itsme){toChange = gameObject;}

		if(refObj == null){
			refObj = new GameObject($"{gameObject.name} rotation reference");
			refObj.transform.eulerAngles = transform.eulerAngles;
		}
	}

	// Update is called once per frame
	void Update () {
		myn = transform.eulerAngles;
		other = refObj.transform.eulerAngles;

		Vector3 temp = Vector3.zero;

		temp.x = lockX ? other.x * multiplier.x : myn.x;
		temp.y = lockY ? other.y * multiplier.y : myn.y;
		temp.z = lockZ ? other.z * multiplier.z : myn.z;

		wantedRot = new Vector3 (temp.x, temp.y, temp.z);

		toChange.transform.eulerAngles = wantedRot;
	}
}