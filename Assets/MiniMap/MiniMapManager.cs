using UnityEngine;
using System.Collections;

public class MiniMapManager : MonoBehaviour {

	public GameObject MiniMapBase;
	public GameObject CompassPlane;
	public GameObject Avatar;

	private bool isMiniActive = true;
	private bool rotateCompass = true;

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown("m"))
		{
			isMiniActive = !isMiniActive;
			MiniMapBase.SetActive(isMiniActive);
		}
		if(Input.GetKeyDown("r"))
		{
			rotateCompass = !rotateCompass;
		}

		if(rotateCompass)
		{
			CompassPlane.transform.localEulerAngles = new Vector3(0,180-Avatar.transform.eulerAngles.y,0);
		}
		else
		{
			CompassPlane.transform.localEulerAngles = new Vector3(0,180,0);
		}
	}
}
