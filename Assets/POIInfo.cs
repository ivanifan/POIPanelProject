using UnityEngine;
using System.Collections;

public class POIInfo : MonoBehaviour {
    
    public string sceneName;
    public string buttonName;
    public Vector3 position;
    public Vector3 rotation;

    public POI Point{
     get{

         point.sceneFlag = sceneName;
         point.buttonName = buttonName;
         point.position = position;
         point.rotation = rotation;
         return point;
     }

        set
        {
            point = value;
            sceneName = point.sceneFlag;
            buttonName = point.buttonName;
            position = point.position;
            rotation = point.rotation;
        }
    }

    private POI point;
}
