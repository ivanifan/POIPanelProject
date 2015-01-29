using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CancelChangesButton : MonoBehaviour {

	public void CancelClicked()
	{
		GameObject activeButton = POI_ReferenceHub.POIMenu.GetComponent<POIActiveButtonManager> ().activeButton;
		POI activePoint = activeButton.GetComponent<POIInfo> ().Point;
		POI_ReferenceHub.poiInfoFields[0].text = activePoint.position.x.ToString();
		POI_ReferenceHub.poiInfoFields[1].text = activePoint.position.y.ToString();
		POI_ReferenceHub.poiInfoFields[2].text = activePoint.position.z.ToString();
		POI_ReferenceHub.poiInfoFields[3].text = activePoint.rotation.y.ToString();
		POI_ReferenceHub.poiInfoFields[4].text = activePoint.buttonName;
	}
}
