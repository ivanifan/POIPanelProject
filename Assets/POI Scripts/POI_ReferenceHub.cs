using UnityEngine;
using System.Collections;
using System;

public class POI_ReferenceHub {

	public static RectTransform POIMenu;
	public static RectTransform POIEditWindow;

	static POI_ReferenceHub(){
		try{
			/*
			POIMenu = GameObject.Find("POIMenu") as RectTransform;
			POIEditWindow = GameObject.Find("POIEditWindow") as RectTransform;
			*/
		}
		catch(UnityException ex){  //try to catch the situation when GameObject.Find returns null
			Debug.Log(ex.Message);
		}
		catch(Exception ex){
			Debug.Log(ex.Message);
		}
	}
}
