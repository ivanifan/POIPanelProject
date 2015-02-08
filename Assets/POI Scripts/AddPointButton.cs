using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AddPointButton : MonoBehaviour {

	public void onClicked(){
		List<string> sFlag = new List<string>(); //!!!! need to be implemented later when sceneflag is set
		Vector3 pos = new Vector3 (float.Parse(POI_ReferenceHub.Instance.poiInfoFields [0].value), float.Parse(POI_ReferenceHub.Instance.poiInfoFields [1].value), float.Parse(POI_ReferenceHub.Instance.poiInfoFields [2].value));
		Vector3 rot = new Vector3 (0, float.Parse(POI_ReferenceHub.Instance.poiInfoFields [3].value), 0);
		POI point = new POI (sFlag, POI_ReferenceHub.Instance.poiInfoFields [4].value, pos, rot, POI_GlobalVariables.defaultMarker);
		POI_ReferenceHub.Instance.gameObject.GetComponent<POIButtonManager>().GenerateButMarkerPair (point);
	}
}
