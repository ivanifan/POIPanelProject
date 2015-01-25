﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class POI
{
    [XmlArray("SceneFlagList")]
	[XmlArrayItem("SceneFlag")]
    public List<string> sceneFlag = new List<string>();

    [XmlElement("Name")]
    public string buttonName;

    [XmlElement("Position")]
    public Vector3 position;

    [XmlElement("Rotation")]
    public Vector3 rotation;

    public POI()
    {
    }

    public POI(List<string> sFlag, string bName, Vector3 pos, Vector3 rot)
    {
        sceneFlag = sFlag;
        buttonName = bName;
        position = pos;
        rotation = rot;
    }
}
[XmlRoot]
public class POIHandler
{
    [XmlArray("ProjectPOIs")]
    [XmlArrayItem("POI")]
    public List<POI> projectPOIs;

	public POIHandler()
	{
		projectPOIs = new List<POI>();
	}

    public void AddPoint(POI point)
    {
		projectPOIs.Add(point);
    }

	public void RemovePoint(POI point)
	{
		projectPOIs.Remove(point);
	}

	public void UpdatePoint(POI oldPoint, POI newPoint)
	{
		for(int i = 0; i< projectPOIs.Count; i++)
		{
			if(projectPOIs[i] == oldPoint){
				projectPOIs[i] = newPoint;
			}
		}
	}

}