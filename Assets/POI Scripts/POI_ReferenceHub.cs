using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class POI_ReferenceHub{

	public  static RectTransform POIMenu = new RectTransform();
	public  static RectTransform POIEditWindow = new RectTransform();
	public  static RectTransform ApplyBut = new RectTransform();
	public  static RectTransform CancelBut = new RectTransform();
	public  static RectTransform EditBut = new RectTransform();
	public  static List<InputField> poiInfoFields = new List<InputField>();

	static POI_ReferenceHub(){
		try{

			POIMenu = GameObject.Find("POIMenu").GetComponent<RectTransform>();

			POIEditWindow = GameObject.Find("POIEditWindow").GetComponent<RectTransform>();

			ApplyBut = POIMenu.FindChild("Apply").GetComponent<RectTransform>();
			CancelBut = POIMenu.FindChild("Cancel").GetComponent<RectTransform>();
			EditBut = POIMenu.FindChild("EditButton").GetComponent<RectTransform>();
			if(poiInfoFields.Count != 5 ){
				poiInfoFields = new List<InputField>();
				poiInfoFields.Add(POIEditWindow.FindChild("XPosField").GetComponent<InputField>());
				poiInfoFields.Add(POIEditWindow.FindChild("YPosField").GetComponent<InputField>());
				poiInfoFields.Add(POIEditWindow.FindChild("ZPosField").GetComponent<InputField>());
				poiInfoFields.Add(POIEditWindow.FindChild("YRotField").GetComponent<InputField>());
				poiInfoFields.Add(POIEditWindow.FindChild("NameField").GetComponent<InputField>());
			}
		}
		catch(UnityException ex){  //try to catch the situation when GameObject.Find returns null
			Debug.LogError(ex.Message);
		}
		catch(Exception ex){
			Debug.LogError(ex.Message);
		}
	}
}
