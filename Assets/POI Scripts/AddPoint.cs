using UnityEngine;
using System.Collections;

public class AddPoint : MonoBehaviour {
	
	public string defaultName;
	public Vector3 defaultPosition;
	public float defaultRotation;

	public void AddNewPoint()
	{

		POI pointToAdd = new POI();
		pointToAdd.sceneFlag = Application.loadedLevelName;
		pointToAdd.buttonName = defaultName;
		pointToAdd.position = defaultPosition;
		pointToAdd.rotation = new Vector3(0,defaultRotation,0);
		POIButtonManager.originalHandler.AddPoint(pointToAdd);
		POI_ReferenceHub.POIMenu.GetComponent<POIButtonManager>().CreateNewButton(pointToAdd);
	}
}
