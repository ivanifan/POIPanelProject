using UnityEngine;
using System.Collections;

public class POIMenuStateManager : MonoBehaviour {

	public bool editModeState = false;

	public void ToggleEditMode()
	{
		editModeState = !editModeState;
	}
}
