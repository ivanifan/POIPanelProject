using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

public class POIButtonManager : MonoBehaviour {

	public static POIButtonManager instance{get; set;}
    public static POIHandler editHandler = new POIHandler();
    // variable to hold the initial button and poi data when the application starts
    // will have an option in the poi menu to restore the original values
    public static POIHandler originalHandler = new POIHandler();
    public RectTransform POIList;
    public Object buttonPrefab;
    public int NumOfButtons = 0;    //
    public float POIlistHeight = 7.0f;

	// Use this for initialization
	void Start () {
	
		if(POIButtonManager.instance ==null){
			POIButtonManager.instance = this;
		}else{
			Debug.LogError("More than one instance of POIButtonManager!");
		}

		Debug.Log("loading POIs from: " + POI_GlobalVariables.XMLpath);

		if(Application.isEditor){
			if (File.Exists(POI_GlobalVariables.XMLpath))
			{
				mergeEditorButsIntoXML(grabButtonsFromEditor(), POI_GlobalVariables.XMLpath);
				GenerateButs(originalHandler);
			}
			else
			{
				SaveButsToXML();
			}
		}
		else{
		    if (File.Exists(POI_GlobalVariables.XMLpath))
		    {
				LoadAndGenerateButs();
	        }
			else
			{
				SaveButsToXML();
			}
		}

		// make a copy of the original poi information
		// all of the modifications will be done with handler, leaving originalHandler unchanged
		editHandler = originalHandler;
        
	}// start

	//load the xml from specified path into the handler
	public void loadButsFromXML(string XMLpath, ref POIHandler handler){
		if (File.Exists(XMLpath))
		{
			//load the POIHandler.xml, the saved button files
			handler = XmlIO.Load(XMLpath, typeof(POIHandler)) as POIHandler;
		}
		else
		{
			Debug.Log("saved buttons not found! need to generate saved button files based on current project.");
		}
	}

	public void GenerateButs(POIHandler handler){
		//clear current buttons in the menu
		foreach (Transform child in POIList.transform)
		{
			Destroy(child.gameObject);
		}
		NumOfButtons = 0;

		//generate new buttons
		foreach(POI point in handler.projectPOIs){
			foreach(string sFlag in point.sceneFlag){
				if(sFlag == Application.loadedLevelName)
				{
					CreateNewButton(point);
					POIList.sizeDelta = new Vector2(POIList.sizeDelta.x , POIlistHeight);
					POIList.localPosition = Vector3.zero;
				}
			}
		}

	}

	//this is the combination of function loadButsFromXML and GenerateButs
	public void LoadAndGenerateButs(){
		if (File.Exists(POI_GlobalVariables.XMLpath))
		{
			//clear current buttons in the menu
			foreach (Transform child in POIList.transform)
			{
				Destroy(child.gameObject);
			}
			NumOfButtons = 0;
			
			//load the POIHandler.xml, the saved button files
			originalHandler = XmlIO.Load(POI_GlobalVariables.XMLpath, typeof(POIHandler)) as POIHandler;

			//generate new buttons
			foreach(POI point in originalHandler.projectPOIs){
						foreach(string sFlag in point.sceneFlag){
							if(sFlag == Application.loadedLevelName)
							{
								CreateNewButton(point);
								POIList.sizeDelta = new Vector2(POIList.sizeDelta.x , POIlistHeight);
								POIList.localPosition = Vector3.zero;
							}
						}
			}
		}
		else{
			Debug.Log("saved buttons not found! need to generate saved button files based on current project.");
		}
	}


	public void CreateNewButton(POI point)
	{
		GameObject newButton = Instantiate(buttonPrefab) as GameObject;
		RectTransform buttonRectTransform = newButton.transform as RectTransform;
		buttonRectTransform.SetParent(POIList);
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

	//comments here
	public void RemoveButton(GameObject buttonToRemove)
	{
		float yThreshhold = buttonToRemove.transform.position.y;
		for(int i = 0; i < NumOfButtons; i++)
		{
			if(buttonToRemove.transform.parent.GetChild(i).position.y < yThreshhold)
			{
				buttonToRemove.transform.parent.GetChild(i).position += new Vector3(0,37,0);
			}
		}
		GameObject.Destroy(buttonToRemove);
		NumOfButtons--;
	}


	public void SaveButsToXML(){
		Debug.Log("generating saved button files based on current project");
		foreach (Transform child in POIList.transform)
		{
			POI pointToAdd = child.GetComponent<POIInfo>().Point;
			originalHandler.AddPoint(pointToAdd);
		}
		
		XmlIO.Save(originalHandler, POI_GlobalVariables.XMLpath);
	}

	//find all buttons in POIList and return them in a List
	private List<POI> grabButtonsFromEditor(){

		List<POI> butsInEditor = new List<POI>();
		foreach(RectTransform but in POIList){ 
			butsInEditor.Add(but.GetComponent<POIInfo>().Point);
		}
		return butsInEditor;
	}

	//merge the buttons in editor with the existing XML file
	private void mergeEditorButsIntoXML(List<POI> butsInEditor, string XMLpath){
		loadButsFromXML(XMLpath,ref originalHandler);
		for(int i =0; i < butsInEditor.Count; i++){
			bool match = false;
			foreach(POI point in originalHandler.projectPOIs){
				if(IsPointSame(point,butsInEditor[i])){
					match = true;
					break;
				}
			}
			if(!match){
				originalHandler.AddPoint (butsInEditor[i]);
			}
		}
	}

	//return true if two points are the same
	private bool IsPointSame(POI pointA, POI pointB){
		if(pointA.buttonName != pointB.buttonName){
			return false;
		}

		if(!pointA.sceneFlag.SequenceEqual(pointB.sceneFlag)){
			return false;
		}

		if(pointA.position != pointB.position){
			return false;
		}

		if(pointA.rotation != pointB.rotation){
			return false;
		}

		return true;
	}

}
