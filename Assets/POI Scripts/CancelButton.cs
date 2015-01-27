using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CancelButton : MonoBehaviour {

	public void cancelClicked(){
		POIButtonManager.editHandler = POIButtonManager.originalHandler;
		POIButtonManager.instance.LoadAndGenerateButs();

		POIMenuStateManager.EditModeState = false;

		POI_ReferenceHub.POIEditWindow.gameObject.SetActive(false);
		POI_ReferenceHub.POIMenu.GetComponent<Image>().color = Color.white;
		POI_ReferenceHub.EditBut.gameObject.SetActive(true);
		POI_ReferenceHub.ApplyBut.gameObject.SetActive (false);
		POI_ReferenceHub.CancelBut.gameObject.SetActive(false);
	}
}
