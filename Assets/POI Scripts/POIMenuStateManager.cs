using UnityEngine;
using System.Collections;

public class POIMenuStateManager : MonoBehaviour {

	private static bool editModeState = false;

	public static bool EditModeState{
		get{
			return editModeState; //default of bool is faulse, no need to initialize
		}
		set{
			editModeState = value;
		}
	}



}
