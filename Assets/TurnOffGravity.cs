using UnityEngine;
using System.Collections;

public class TurnOffGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TP_Motor.Instance.gravityOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(TP_Motor.Instance.gravityOn){
			TP_Motor.Instance.gravityOn = false;
		}
	}
}

