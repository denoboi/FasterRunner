using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoadLayout
{
    public Transform Parent;
    public Transform StartPoint;
    public Transform EndPoint;

    public RoadLayout(Transform startPoint, Transform endPoint, Transform parent)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
        Parent = parent;
    }
    
    
    
    
}
