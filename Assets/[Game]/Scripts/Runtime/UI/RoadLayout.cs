using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoadLayout
{
    
    public Transform StartPoint;
    public Transform EndPoint;

    public RoadLayout(Transform startPoint, Transform endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
       
    }
    
    
    
    
}
