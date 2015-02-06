using UnityEngine;
using System.Collections;

public class NewPoint : MonoBehaviour {

	public void clicked(){
		POI_ReferenceHub.POIEditWindow.gameObject.SetActive(true);
		POI_ReferenceHub.POIEditWindow.FindChild("AddPoint").gameObject.SetActive(true);
		POI_ReferenceHub.POIEditWindow.FindChild("SaveChanges").gameObject.SetActive(false);
	}
}
