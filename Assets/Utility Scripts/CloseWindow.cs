using UnityEngine;
using System.Collections;

//this script should be attached to the window that needs to be closed
public class CloseWindow : MonoBehaviour {

	public void clicked(){
		gameObject.SetActive(false);
	}
}
