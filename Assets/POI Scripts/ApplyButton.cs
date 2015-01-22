using UnityEngine;
using System.Collections;

public class ApplyButton : MonoBehaviour {

	public void applyChangesToXML(){
		XmlIO.Save(POIButtonManager.originalHandler, POI_GlobalVariables.XMLpath);

	}
}
