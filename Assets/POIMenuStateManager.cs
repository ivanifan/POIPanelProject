using UnityEngine;
using System.Collections;

public class POIMenuStateManager : MonoBehaviour {

	public static bool editModeState = false;

	public void ToggleEditMode()
	{
		editModeState = !editModeState;
	}
}
