using UnityEngine;
using System.Collections;

public class DeletePoint : MonoBehaviour {

	public void RemovePointFromMenuAndHandler()
	{
		GameObject activePOIButton = POI_ReferenceHub.POIMenu.GetComponent<POIActiveButtonManager>().activeButton;
		POIButtonManager.editHandler.RemovePoint(activePOIButton.GetComponent<POIInfo>().Point);
		POI_ReferenceHub.POIMenu.GetComponent<POIButtonManager>().RemoveButton(activePOIButton);
	}
}
