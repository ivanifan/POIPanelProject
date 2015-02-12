using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

public class SerlializeBookmarks : MonoBehaviour
{

		public string fileLocation = null;

		public void SaveBookmarks ()
		{
				if (fileLocation == null || fileLocation == "")
						fileLocation = Application.persistentDataPath + "/Bookmarks.xml";
				List<GameObject> bookmarks = new List<GameObject> ();

				for (int i = 0; i < transform.childCount; i++)
						bookmarks.Add (transform.GetChild (i).gameObject);
				XmlSerializer xmlSerial = new XmlSerializer (typeof(List<GameObject>));
				FileStream stream = new FileStream (fileLocation, FileMode.Create);
				xmlSerial.Serialize (stream, bookmarks);
				Debug.Log ("saved to : " + fileLocation);
		}

}
