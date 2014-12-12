using UnityEngine;
using System.Collections;

public class EditButton : MonoBehaviour {
	public RectTransform POIEditWindow;
	public RectTransform POIMenu;

	public void EditClicked(){
		POIEditWindow.gameObject.SetActive (true);
		POIMenuStateManager.editModeState = true;

	}
}
