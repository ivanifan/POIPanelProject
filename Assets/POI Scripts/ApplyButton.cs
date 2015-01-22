using UnityEngine;
using System.Collections;

public class ApplyButton : MonoBehaviour {

	public void applyChangesToXML(){
		XmlIO.Save(POIButtonManager.editHandler, POI_GlobalVariables.XMLpath);

	}
}
