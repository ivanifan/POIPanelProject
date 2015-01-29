using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveChangesButton : MonoBehaviour {

	private GameObject activeButton = null;

	// this function will need to construct a poi from the info in the edit menu, and then call updatepoint in the edithandler
	// it also needs to update the poiinfo script on the button and the text on the button, might want to just redraw the button
	public void SaveChanges()
	{
		activeButton = POI_ReferenceHub.POIMenu.GetComponent<POIActiveButtonManager> ().activeButton;
		POI newPoint = new POI ();

		newPoint.sceneFlag.Add (Application.loadedLevelName);
		newPoint.buttonName = POI_ReferenceHub.poiInfoFields [4].text;
		newPoint.position = new Vector3(float.Parse (POI_ReferenceHub.poiInfoFields[0].text),float.Parse(POI_ReferenceHub.poiInfoFields[1].text),float.Parse(POI_ReferenceHub.poiInfoFields[2].text));
		newPoint.rotation = new Vector3(0,float.Parse(POI_ReferenceHub.poiInfoFields[3].text),0);

		POIButtonManager.editHandler.UpdatePoint (activeButton.GetComponent<POIInfo> ().Point, newPoint);
		activeButton.GetComponent<POIInfo> ().Point = newPoint;
		activeButton.GetComponentInChildren<Text> ().text = newPoint.buttonName;

	}

}
