using UnityEngine;
using System.Collections;

public class CompassManager : MonoBehaviour {

	public GameObject avatar;

	private bool rotateCompass = true;
	// Update is called once per frame
	void Update () {

		// manages rotation of the compass plane
		if(Input.GetKeyDown("r"))
		{
			rotateCompass = !rotateCompass;
		}
		
		if(rotateCompass)
		{
			transform.localEulerAngles = new Vector3(0,180-avatar.transform.eulerAngles.y,0);
		}
		else
		{
			transform.localEulerAngles = new Vector3(0,180,0);
		}
	}// update
}
