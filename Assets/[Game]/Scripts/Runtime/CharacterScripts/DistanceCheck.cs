using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour
{
    private Vector3 _lastPosition ;
    private float _totalDistance ;
 
    private void Start()
    {
        _lastPosition = transform.position ;
    }
 
    private void Update()
    {
        float distance = Vector3.Distance( _lastPosition, transform.position ) ;
        _totalDistance += distance ;
        _lastPosition = transform.position;
    }
 
    private void OnDestroy()
    {
        Debug.Log("Total distance travelled:" + _totalDistance ) ;
    }

}
