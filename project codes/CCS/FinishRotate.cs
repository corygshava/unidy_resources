using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRotate : MonoBehaviour {

	public bool special;
	public bool userControlled;
	public bool custom;
	public float speed;
	public float factor;

	float rate;

	// Update is called once per frame
	void Update () {
		if (custom) {
			rate = speed;
		} else {
			rate = 1.0f;
		}

		if (!userControlled) {
			if (special) {
				transform.Rotate (rate * factor, 0, 0, Space.World);
			} else {
				transform.Rotate (0, rate, 0, Space.World);
			}
		} else {
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (0, -rate, 0, Space.World);
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (0, rate, 0, Space.World);
			}
		}

		if (custom) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				speedControl (1);
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				speedControl (0);
			}
		}
	}

	public void autoRotate(bool uc){
		userControlled = uc;
	}

	public void ToggleRotate(){
		if (userControlled) {
			userControlled = false;
		} else {
			userControlled = true;
		}
	}

	public void speedControl(int num){
		if (num == 1) {
			if (speed <= 5) {
				speed += 0.5f;
			}
		} else {
			if (speed >= 1) {
				speed -= 0.5f;
			}
		}
	}
}
