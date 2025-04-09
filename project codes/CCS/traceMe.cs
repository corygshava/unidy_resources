// last modified on 25/01/24 at 12:05PM

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traceMe : MonoBehaviour {

	public enum updateType{Fixed,Late,Normal};

	[Header("essential data")]
	public updateType updateMode = updateType.Normal;

	public bool trace = true;
	[Tooltip("the thing to focus on")]
	public GameObject traced;
	[Tooltip("the thing that will look at the traced item, if null the code assumes its the current GameObject")]
	public GameObject traceObject;
	[SerializeField] bool imTheTracer = true;
	[Tooltip("only at the start")]
	public bool OnlyOnce;

	[Header("for smooth tracing")]
	[Tooltip("snap or smooth transition")]
	public bool smoothTrace;
	[Tooltip("how fast: 0 = dont , 1 = snap")]
	[Range(0f,1f)]public float traceSpeed = 0.7f;
	private GameObject refObj;

	// Use this for initialization
	void Start () {
		if(trace){
			imTheTracer = traceObject == null;
			refHandler();

			if(traced != null){
				GameObject temptrace;
				temptrace = imTheTracer ? gameObject : traceObject;

				temptrace.transform.LookAt(traced.transform.position);
			}
		}
	}

	void Update () {
		if(updateMode == updateType.Normal){
			traceMeCode();
		}
	}

	void FixedUpdate() {
		if(updateMode == updateType.Fixed){
			traceMeCode();
		}
	}

	void LateUpdate() {
		if(updateMode == updateType.Late){
			traceMeCode();
		}
	}

	// Update is called once per frame
	void traceMeCode () {
		if(trace){
			imTheTracer = traceObject == null;
			refHandler();

			if(!OnlyOnce){
				if(traced != null){
					GameObject temptrace,totrace;
					temptrace = imTheTracer ? gameObject : traceObject;
					totrace = smoothTrace ? refObj : traced;

					temptrace.transform.LookAt(totrace.transform.position);
				}
			}
		}
	}

	void refHandler(){
		if(smoothTrace){
			if(refObj == null){
				refObj = new GameObject($"TMP_{this} : traceme reference");
			} else {
				refObj.transform.position = Vector3.Lerp(refObj.transform.position,traced.transform.position,traceSpeed);
			}
		} else {
			if(refObj != null){
				Destroy(refObj);
			}
		}
	}

	public void setfocus(GameObject item) {
		traced = item;
	}

	public void setLooker(GameObject item) {
		traceObject = item;
	}

	public void clearfocus () {
		traced = null;
	}

	public void clearLooker(){
		traceObject = null;
	}

	public void doyourjob (bool doit) {
		trace = doit;
	}
}
