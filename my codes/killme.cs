using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killme : MonoBehaviour
{
	public GameObject tokill;
	public float m_TimeOut = 1.0f;

	[Header("switches")]
	public bool m_DetachChildren = false;
	public bool RunOnAwake = false;
	public bool RunIt = false;
	public bool itsme = true;

	private void Start(){
		if(itsme){
			tokill = itsme ? gameObject : tokill;
		}

		if(RunOnAwake){
			Doit();
		}
	}

	void Update(){
		if(RunIt){
			Doit();
		}
	}

	private void DestroyNow(){
		if (m_DetachChildren){
			tokill.transform.DetachChildren();
		}
		DestroyObject(tokill);
	}

	public void Doit(){
		Invoke("DestroyNow", m_TimeOut);
	}
}
