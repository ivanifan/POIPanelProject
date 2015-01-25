using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveChangesButton : MonoBehaviour {

	private GameObject activeButton = null;

	public List<InputField> poiInfoFields = new List<InputField>();
	
	void Start(){

		if(poiInfoFields.Count != 5 ){
			poiInfoFields = new List<InputField>();
			poiInfoFields.Add(transform.parent.FindChild("XPosField").GetComponent<InputField>());
			poiInfoFields.Add(transform.parent.FindChild("YPosField").GetComponent<InputField>());
			poiInfoFields.Add(transform.parent.FindChild("ZPosField").GetComponent<InputField>());
			poiInfoFields.Add(transform.parent.FindChild("YRotField").GetComponent<InputField>());
			poiInfoFields.Add(transform.parent.FindChild("NameField").GetComponent<InputField>());
		}
	}

	// this function will need to construct a poi from the info in the edit menu, and then call updatepoint in the edithandler
	// it also needs to update the poiinfo script on the button and the text on the button, might want to just redraw the button
	public void SaveChanges()
	{
		activeButton = POI_ReferenceHub.POIMenu.GetComponent<POIActiveButtonManager> ().activeButton;
		POI newPoint = new POI ();

		newPoint.sceneFlag.Add (Application.loadedLevelName);
		newPoint.buttonName = poiInfoFields [4].value;
		newPoint.position = new Vector3(float.Parse (poiInfoFields[0].value),float.Parse(poiInfoFields[1].value),float.Parse(poiInfoFields[2].value));
		newPoint.rotation = new Vector3(0,float.Parse(poiInfoFields[3].value),0);

		POIButtonManager.editHandler.UpdatePoint (activeButton.GetComponent<POIInfo> ().Point, newPoint);
		activeButton.GetComponent<POIInfo> ().Point = newPoint;
		activeButton.GetComponentInChildren<Text> ().text = newPoint.buttonName;

	}

}
