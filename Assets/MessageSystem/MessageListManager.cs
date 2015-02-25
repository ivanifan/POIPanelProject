using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.EventSystems;

public class MessageListManager : MonoBehaviour {

	// configuration variables
	public string listName;
	public GameObject messagePrefab;
	public int defaultTime = 5, defaultMessageHeight = 50, defaultFontSize = 14, defaultMargin = 0;
	public Color defaultFontColor = Color.white, defaultBackgroundColor = Color.black;
	public FontStyle defaultFontStyle = FontStyle.Normal;
	public TextAnchor defaultTextAnchor = TextAnchor.UpperLeft;
	public bool fillFromTopDown = false;
	public bool writeToLogFile = false;
	public string logFilePath = null;

	public GameObject messageMaskRef = null;
	public GameObject messageListRef = null;
	public GameObject messageScrollbarRef = null;

	private bool scrollBarSelected = false;
	private float timeLastSave = 0;


	// Use this for initialization
	void Awake () {
		if(logFilePath == null || logFilePath == "")
			logFilePath =  Application.persistentDataPath + "/" + listName + "_Log.txt";
		MessageHandler.RegisterList(listName, this.gameObject);
	}

	public void ToggleScrollbarSelected()
	{
		scrollBarSelected = !scrollBarSelected;
		MessageHandler.Message("System", "scroll bar clicked");
	}

	void Update()
	{
		messageScrollbarRef.SetActive(messageMaskRef.GetComponent<RectTransform>().sizeDelta.y < messageListRef.GetComponent<RectTransform>().sizeDelta.y || scrollBarSelected);
	}
}
