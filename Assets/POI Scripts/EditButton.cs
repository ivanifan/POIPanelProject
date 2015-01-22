using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditButton : MonoBehaviour {
	public RectTransform POIEditWindow;
	public RectTransform POIMenu;
	public RectTransform ApplyButton;
	public RectTransform CancelButton;

	public void EditClicked(){

		POIMenuStateManager.EditModeState = true;
		//show the edit window
		POIEditWindow.gameObject.SetActive (true);
		//change the color of the POImenu
		POIMenu.gameObject.GetComponent<Image>().color = Color.black;

		//show the apply and cancel button
		ApplyButton.gameObject.SetActive(true);
		CancelButton.gameObject.SetActive(true);

		//pause the game
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0.02f * Time.timeScale; // fixed update is 50fps, which is 0.02s when time scale is 1


		//hide the edit button
		gameObject.SetActive(false);
	}


}
