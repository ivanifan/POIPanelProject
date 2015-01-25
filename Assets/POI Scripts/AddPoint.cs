using UnityEngine;
using System.Collections.Generic;

public class AddPoint : MonoBehaviour {
	
	public string defaultName;
	public Vector3 defaultPosition;
	public float defaultRotation;

	public void AddNewPoint()
	{
		List<string> sceneFlag = new List<string>();
		sceneFlag.Add(Application.loadedLevelName);
		POI pointToAdd = new POI(sceneFlag, defaultName, defaultPosition,new Vector3(0, defaultRotation, 0));
		POIButtonManager.originalHandler.AddPoint(pointToAdd);
		POI_ReferenceHub.POIMenu.GetComponent<POIButtonManager>().CreateNewButton(pointToAdd);
	}
}
