using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BookmarkCurrLocButton : MonoBehaviour {

	public void ToggleBookmarkCurrentWindow()
	{
		POI_ReferenceHub.Instance.BookmarkCurrentLocationWindow.gameObject.SetActive (!POI_ReferenceHub.Instance.BookmarkCurrentLocationWindow.gameObject.activeSelf);
		POI_ReferenceHub.Instance.BookmarkCurrentLocationNameField.GetComponent<InputField> ().value = "";
	}
}
