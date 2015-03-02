using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey("w"))
		{
			transform.position += transform.forward;
		}
		if(Input.GetKey("s"))
		{
			transform.position -= transform.forward;
		}
		if(Input.GetKey("d"))
		{
			transform.position += transform.right;
		}
		if(Input.GetKey("a"))
		{
			transform.position -= transform.right;
		}
		if(Input.GetKey("q"))
		{
			transform.eulerAngles -= new Vector3(0,1,0);
		}
		if(Input.GetKey("e"))
		{
			transform.eulerAngles += new Vector3(0,1,0);
		}
	
	}
}
