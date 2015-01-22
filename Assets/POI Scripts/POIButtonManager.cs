using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

public class POIButtonManager : MonoBehaviour {
	
    public static POIHandler editHandler = new POIHandler();

    // variable to hold the initial button and poi data when the application starts
    // will have an option in the poi menu to restore the original values
    public static POIHandler originalHandler = new POIHandler();
    public RectTransform POIList;
    public Object buttonPrefab;
    public int NumOfButtons = 0;
    public float POIlistHeight = 7.0f;

	// Use this for initialization
	void Start () {
	
		Debug.Log(POI_GlobalVariables.XMLpath);
	    if (File.Exists(POI_GlobalVariables.XMLpath))
	    {
	        foreach (Transform child in POIList.transform)
	        {
	            Destroy(child.gameObject);
	        }
	        originalHandler = XmlIO.Load(POI_GlobalVariables.XMLpath, typeof(POIHandler)) as POIHandler;
	        
				originalHandler.projectPOIs.Where(scenePOILists => scenePOILists.Count > 0)
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

									// The following line adds the POIClicked function as a listener to the EventTrigger on the button we instantiated.
									trigger.AddListener((eventData)=>GetComponent<POIActiveButtonManager>().POIClicked (newButton));

									// The next line adds the entry we created to the Event Trigger of the instantiated button.
									// The entry consists of two parts, the listener we set up earlier, and the EventTriggerType.
									// The EventTriggerType tells the EventTrigger when to send out the message that the event has occured.
									// We use PointerClick so we know when the used has clicked on a button.
									EventTrigger.Entry entry = new EventTrigger.Entry(){callback = trigger, eventID = EventTriggerType.PointerClick}; 
									eTrigger.delegates.Add(entry);
	                       }
	                       POIList.sizeDelta = new Vector2(POIList.sizeDelta.x , POIlistHeight);
	                       POIList.localPosition = Vector3.zero;
	                   }
	               });
	    }
	    else
	    {
	        foreach (Transform child in POIList.transform)
	        {
				POI pointToAdd = child.GetComponent<POIInfo>().Point;
	            originalHandler.AddPoint(pointToAdd);
	        }

	        XmlIO.Save(originalHandler, POI_GlobalVariables.XMLpath);
	    }

		// make a copy of the original poi information
		// all of the modifications will be done with handler, leaving originalHandler unchanged
		editHandler = originalHandler;
	}// start
}
