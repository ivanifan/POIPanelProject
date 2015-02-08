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
		activeButton = POI_ReferenceHub.Instance.POIMenu.GetComponent<POIActiveButtonManager> ().activeButton;
		POI newPoint = new POI ();

		newPoint.sceneFlag.Add (Application.loadedLevelName);
		newPoint.buttonName = POI_ReferenceHub.Instance.poiInfoFields [4].value;
		newPoint.position = new Vector3(float.Parse (POI_ReferenceHub.Instance.poiInfoFields[0].value),float.Parse(POI_ReferenceHub.Instance.poiInfoFields[1].value),float.Parse(POI_ReferenceHub.Instance.poiInfoFields[2].value));
		newPoint.rotation = new Vector3(0,float.Parse(POI_ReferenceHub.Instance.poiInfoFields[3].value),0);

		//the UpdatePoint() also change the point in POIinfo pointing to the newPoint instance
		POIButtonManager.editHandler.UpdatePoint (activeButton.GetComponent<POIInfo> ().Point, newPoint);

		activeButton.GetComponentInChildren<Text> ().text = newPoint.buttonName;

	}

}
