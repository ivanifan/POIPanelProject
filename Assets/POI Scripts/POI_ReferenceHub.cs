using UnityEngine;
using System.Collections;
using System;

public class POI_ReferenceHub{

	public  static RectTransform POIMenu = new RectTransform();
	public  static RectTransform POIEditWindow = new RectTransform();
	public  static RectTransform ApplyBut = new RectTransform();
	public  static RectTransform CancelBut = new RectTransform();
	public  static RectTransform EditBut = new RectTransform();

	static POI_ReferenceHub(){
		try{

			POIMenu = GameObject.Find("POIMenu").GetComponent<RectTransform>();
			Debug.Log("POIEditWindow: " + POIEditWindow);
			POIEditWindow = GameObject.Find("POIEditWindow").GetComponent<RectTransform>();
			Debug.Log("POIEditWindow: " + POIEditWindow);
			ApplyBut = POIMenu.FindChild("Apply").GetComponent<RectTransform>();
			CancelBut = POIMenu.FindChild("Cancel").GetComponent<RectTransform>();
			EditBut = POIMenu.FindChild("EditButton").GetComponent<RectTransform>();
		}
		catch(UnityException ex){  //try to catch the situation when GameObject.Find returns null
			Debug.Log(ex.Message);
		}
		catch(Exception ex){
			Debug.Log(ex.Message);
		}
	}
}
