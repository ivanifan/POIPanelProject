using UnityEngine;
using System.Collections;

public class NewPoint : MonoBehaviour {

	public void clicked(){
		POI_ReferenceHub.Instance.POIEditWindow.gameObject.SetActive(true);
		POI_ReferenceHub.Instance.POIEditWindow.FindChild("AddPoint").gameObject.SetActive(true);
		POI_ReferenceHub.Instance.POIEditWindow.FindChild("SaveChanges").gameObject.SetActive(false);
	}
}
