using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ApplyButton : MonoBehaviour {

	public void applyChangesToXML(){

		XmlIO.Save(POIButtonManager.editHandler, POI_GlobalVariables.XMLpath);
		POIButtonManager.originalHandler = POIButtonManager.editHandler;

		POIMenuStateManager.EditModeState = false;

		//restoring the original window
		POI_ReferenceHub.POIMenu.gameObject.GetComponent<Image>().color = Color.white;
		POI_ReferenceHub.POIEditWindow.gameObject.SetActive(false);
		POI_ReferenceHub.EditBut.gameObject.SetActive(true);
		POI_ReferenceHub.CancelBut.gameObject.SetActive(false);
		POI_ReferenceHub.ApplyBut.gameObject.SetActive(false); 
		//don't put code after this line
	}
}
