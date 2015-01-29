using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class POIActiveButtonManager : MonoBehaviour {

	public Color defaultColor = Color.white;
	public Color activeColor = Color.red;

	public InputField xPosField, yPosField, zPosField, yRotField, nameField;

	public GameObject activeButton = null;

	private GameObject avatar;

	void Start()
	{
		POIMenuStateManager.MenuStateChange += resetActiveButton;
	}

	// This function is called whenver a button is clicked.  
	// The EventTrigger and Listener were set up when the button was instantiated in POIButtonManager.cs.
	public void POIClicked(GameObject clicked)
	{
		if(POIMenuStateManager.EditModeState)
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
			xPosField.text = clickedPOI.position.x.ToString();
			yPosField.text = clickedPOI.position.y.ToString();
			zPosField.text = clickedPOI.position.z.ToString();
			yRotField.text = clickedPOI.rotation.y.ToString();
			nameField.text = clickedPOI.buttonName;
		}
		else
		{
			// teleport to the poi
			avatar = GameObject.FindWithTag("Player");
			Debug.Log("found gameobject with player tag: " + avatar.name);
			avatar.transform.position = clicked.GetComponent<POIInfo>().position;
			avatar.transform.eulerAngles = clicked.GetComponent<POIInfo>().rotation;
		}
	}// poiclicked

	public void resetActiveButton()
	{
		if(activeButton != null)
		{
			activeButton.GetComponent<Image>().color = defaultColor;
			activeButton = null;
		}
	}

}
