using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

public class POIButtonManager : MonoBehaviour {

    public static POIHandler handler = new POIHandler();

    // variable to hold the initial button and poi data when the application starts
    // will have an option in the poi menu to restore the original values
    public POIHandler restoreHandler = new POIHandler();
    public RectTransform POIList;
    public Object buttonPrefab;
    public int NumOfButtons = 0;
    public float POIlistHeight = 7.0f;

	// Use this for initialization
	void Start () {
        
        // load the POIs from the xml file given by the path variable into the POIHandler member
        string path = Application.dataPath + "/POIHandler.xml";

        if (Application.isEditor)
        {
            if (File.Exists(path))
            {
                foreach (Transform child in POIList.transform)
                {
                    Destroy(child.gameObject);
                }
                handler = XmlIO.Load(path, typeof(POIHandler)) as POIHandler;
                
                handler.projectPOIs.Where(scenePOILists => scenePOILists.Count > 0)
                       .ToList()
                       .ForEach(sceneList => {
                           if(sceneList[0].sceneFlag == Application.loadedLevelName)
                           {
                               foreach (POI point in sceneList)
                               {
                                   GameObject newButton = Instantiate(buttonPrefab) as GameObject;
                                   RectTransform buttonRectTransform = newButton.transform as RectTransform;
                                   buttonRectTransform.parent = POIList;
                                   buttonRectTransform.localPosition = new Vector3(7.0f, -7.0f + NumOfButtons * (-buttonRectTransform.rect.height - 7.0f), 0.0f);
                                   
                                   newButton.GetComponent<POIInfo>().Point = point;
                                   newButton.transform.GetComponentInChildren<Text>().text = point.buttonName;
                                   NumOfButtons++;
                                   POIlistHeight += buttonRectTransform.rect.height + 7.0f;

									// code to add a listener to the button OnClicked() event
									EventTrigger eTrigger = newButton.GetComponent<EventTrigger>();
									EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
									trigger.AddListener((eventData)=>POIClicked (newButton));
									EventTrigger.Entry entry = new EventTrigger.Entry(){callback = trigger, eventID = EventTriggerType.PointerClick}; 
									eTrigger.delegates.Add(entry);
                               }
                               POIList.sizeDelta = new Vector2(POIList.sizeDelta.x , POIlistHeight);
                               POIList.localPosition = Vector3.zero;
                           }
                       });
                // make a copy of the original poi information
                // all of the modifications will be done with handler, leaving restoreHandler unchanged
                restoreHandler = handler;
            }
            else
            {
                foreach (Transform child in POIList.transform)
                {
                    handler.AddPoint(child.GetComponent<POIInfo>().Point);
                }

                XmlIO.Save(handler, path);
            }
        }
	}// start

	void POIClicked(GameObject clicked)
	{
		clicked.GetComponent<Button>().image.color = Color.red;
	}


}
