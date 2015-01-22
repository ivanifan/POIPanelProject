using UnityEngine;
using System.Collections;

public class POIMenuStateManager : MonoBehaviour {


	public static bool EditModeState{
		get{
			return EditModeState; //default of bool is false, no need to initialize
		}
		set{
			EditModeState = value;
		}
	}



}
