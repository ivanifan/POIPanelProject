using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PullCurrentTransform : MonoBehaviour {

    public Transform characterTransform = null;
    public List<InputField> poiTransformFields = new List<InputField>();

	//called by the button On Click event.
    public void GatherCurrentTransform()
    {
        poiTransformFields[0].value = characterTransform.position.x.ToString();
        poiTransformFields[1].value = characterTransform.position.y.ToString();
        poiTransformFields[2].value = characterTransform.position.z.ToString();
        poiTransformFields[3].value = characterTransform.rotation.x.ToString();
        poiTransformFields[4].value = characterTransform.rotation.y.ToString();
        poiTransformFields[5].value = characterTransform.rotation.z.ToString();
        
    }
}
