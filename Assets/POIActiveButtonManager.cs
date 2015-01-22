using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class POIActiveButtonManager : MonoBehaviour {

	public Color defaultColor = Color.white;
	public Color activeColor = Color.red;

	public InputField xPosField, yPosField, zPosField, yRotField, nameField;

	private GameObject activeButton = null;

	// This function is called whenver a button is clicked.  
	// The EventTrigger and Listener were set up when the button was instantiated in POIButtonManager.cs.
	public void POIClicked(GameObject clicked)
	{
		// If there is already an active button, we will need to change its color back to the default before we set the new active button.
		if(activeButton != null)
		{
			activeButton.GetComponent<Image>().color = defaultColor;
		}

		activeButton = clicked;
		clicked.GetComponent<Button>().image.color = activeColor;

		// Here we get the POI from the POIInfo script that is attached to the activeButton.
		// We then use this info to populate the edit menu fields.
		POI clickedPOI = activeButton.GetComponent<POIInfo>().Point;
		xPosField.value = clickedPOI.position.x.ToString();
		yPosField.value = clickedPOI.position.y.ToString();
		zPosField.value = clickedPOI.position.z.ToString();
		yRotField.value = clickedPOI.rotation.y.ToString();
		nameField.value = clickedPOI.buttonName;
	}// poiclicked
}
