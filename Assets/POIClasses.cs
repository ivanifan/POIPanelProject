using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class POI
{
    [XmlElement("SceneFlag")]
    public string sceneFlag;

    [XmlElement("Name")]
    public string buttonName;

    [XmlElement("Position")]
    public Vector3 position;

    [XmlElement("Rotation")]
    public Vector3 rotation;

    public POI()
    {
    }

    public POI(string sFlag, string bName, Vector3 pos, Vector3 rot)
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
    [XmlArrayItem("ScenePOIs")]
    public List<List<POI>> projectPOIs;

    public void AddPoint(POI point)
    {
        // check if an existing list has the scene flag
        // if not, create a new list for the point
        bool matchesExisting = false;
        
        foreach (List<POI> sceneList in projectPOIs)
        {
            if (sceneList[0].sceneFlag == point.sceneFlag)
            {
                sceneList.Add(point);
                matchesExisting = true;
                break;
            }
        }

        if(!matchesExisting)
        {
            List<POI> newList = new List<POI>();
            newList.Add(point);
            projectPOIs.Add(newList);
        }

    }

    public POIHandler()
    {
        projectPOIs = new List<List<POI>>();
    }
}