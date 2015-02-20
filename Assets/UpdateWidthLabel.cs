using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateWidthLabel : MonoBehaviour {

	public Camera miniMapCam;

	private Text mapWidthLabel;

	void Start()
	{
		mapWidthLabel = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		mapWidthLabel.text = "Minimap Width (Ft): " + (miniMapCam.orthographicSize * 2 * 3.28f);
	}
}
