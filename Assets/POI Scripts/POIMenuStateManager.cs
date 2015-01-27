using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class POIMenuStateManager : MonoBehaviour {

	public List<MonoBehaviour> disableWhileMenuOpen = new List<MonoBehaviour> ();

	private static bool editModeState = false;

	public static bool EditModeState{
		get{

			return editModeState; //default of bool is faulse, no need to initialize

		}
		set{
			editModeState = value;
		}
	}

	void Update ()
	{
		if (!editModeState)
			Time.timeScale = 1;
		else
			Time.timeScale = 0;


		foreach(MonoBehaviour mono in disableWhileMenuOpen)
		{
			mono.enabled = !editModeState;
		}
	}
}
