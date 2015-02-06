using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class POIInfo : MonoBehaviour {
    
    public List<string> sceneName;
    public string buttonName;
    public Vector3 position;
    public Vector3 rotation;
	public string marker;

	private POI point = new POI();


//returns the POI by references, be aware of the implication of this when developing
    public POI Point{
     get{

         point.sceneFlag = sceneName;
         point.buttonName = buttonName;
         point.position = position;
         point.rotation = rotation;
			point.markerPrefab = marker;
         return point;
     }

        set
        {
            point = value;
            sceneName = point.sceneFlag;
            buttonName = point.buttonName;
            position = point.position;
            rotation = point.rotation;
			marker = point.markerPrefab;
        }
    }

   
}
