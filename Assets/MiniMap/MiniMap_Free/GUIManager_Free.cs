using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager_Free : MonoBehaviour {

	//public RenderTexture MiniMapTexture;
	//public Material MiniMapMaterial;
	public GameObject compassPlane;

	public Texture compass;


	public float leftOffset = 410;
	public float topOffset = 10;
	public float mapWidth = 400;
	public float mapHeight = 400;

	public float leftOffsetCompass = 110;
	public float topOffsetCompass = 10;
	public float compassWidth = 100;
	public float compassHeight = 100;
	public float mapProportionOfScreen = 0.2f;
	public float compassProportionOfScreen = 0.06f;

	public float maxOrthographicSize = 5;

	public Camera miniMapCam;

	public GameObject avatar;
	public Text zoomLabel;

	private int zoomLevel = 10;
	private Vector2 relativeClickPostion = Vector2.zero;
	private Vector2 miniMapCenter = Vector2.zero;
	private Vector3 rayStartPostion = Vector2.zero;

	void Start()
	{
		mapWidth = Screen.width * mapProportionOfScreen - 10;
		mapHeight = Screen.height * mapProportionOfScreen - 10;
		compassWidth = Screen.width * compassProportionOfScreen - 10;
		compassHeight = Screen.height * compassProportionOfScreen - 10;
		miniMapCam.GetComponent<Camera>().pixelRect = new Rect (Screen.width - mapWidth, Screen.height - mapHeight - 30, mapWidth, mapHeight);
		compassPlane.transform.localScale = new Vector3 (miniMapCam.orthographicSize/20,miniMapCam.orthographicSize/20,miniMapCam.orthographicSize/20);
	}

	void Update(){
		miniMapCenter = new Vector2 (Screen.width - mapWidth * 0.5f, Screen.height - 0.5f * mapHeight -30);
		
		// teleport to location clicked on minimap
		if(Input.GetMouseButtonDown(0) && (Input.mousePosition.x > Screen.width - mapWidth) && (Input.mousePosition.y > Screen.height - mapHeight)){
			Debug.Log("minimap center: " + miniMapCenter);
			Debug.Log("Mouse Position: " + Input.mousePosition);
			relativeClickPostion.x = (Input.mousePosition.x - miniMapCenter.x) / mapWidth;
			relativeClickPostion.y = (Input.mousePosition.y - miniMapCenter.y) / mapHeight;
			Debug.Log("relative click: " + relativeClickPostion);
			rayStartPostion = miniMapCam.transform.position + (relativeClickPostion.x*transform.right + relativeClickPostion.y*transform.up) * miniMapCam.orthographicSize;
			RaycastHit hit = new RaycastHit();
			Physics.Raycast(rayStartPostion,Vector3.down,out hit, Mathf.Infinity);
			
			avatar.transform.position = hit.point;
			
		}
	}
	
	void OnGUI(){

		// moved to the zoom buttons and the ChangeZoom function
		/*if (GUI.Button (new Rect (Screen.width - Screen.width * mapProportionOfScreen, mapHeight, mapWidth * 0.5f, 30), "Decrease Zoom")) {
			zoomLevel -= 10;		
		}
		if (GUI.Button (new Rect (Screen.width - Screen.width * 0.5f * mapProportionOfScreen, mapHeight, mapWidth * 0.5f, 30), "Increase Zoom")) {
			zoomLevel += 10;		
		}
		if (zoomLevel > 100) {
			zoomLevel =  100;
		}*/

		// moved to zoomlabel
		//GUI.Label (new Rect (Screen.width - Screen.width * mapProportionOfScreen, topOffset + mapHeight + 30, mapWidth, 30), "Zoom Level: " + zoomLevel);




	
	}

	public void ChangeZoom(bool isIncrease)
	{
		if (isIncrease) 
		{
			zoomLevel += 10;
		} 
		else 
		{
			zoomLevel -= 10;
		}

		if (zoomLevel > 100) 
		{
			zoomLevel =  100;
		}

		// set zoom label
		zoomLabel.text = "Zoom: " + zoomLevel;
		
		// This is where we will reset the zoom of the ortho camera that is used to capture the minimap.
		float newOrthoSize = maxOrthographicSize - maxOrthographicSize * zoomLevel / 100;
		if (newOrthoSize <= 0) {
			newOrthoSize = .01f;
		}
		miniMapCam.orthographicSize = newOrthoSize;
		compassPlane.transform.localScale = new Vector3 (miniMapCam.orthographicSize/20,miniMapCam.orthographicSize/20,miniMapCam.orthographicSize/20);
	}

	public void ChangeSize(bool isIncrease)
	{
		miniMapCam.GetComponent<Camera>().pixelRect = new Rect (Screen.width - mapWidth, Screen.height - mapHeight, mapWidth, mapHeight);
	}

}
