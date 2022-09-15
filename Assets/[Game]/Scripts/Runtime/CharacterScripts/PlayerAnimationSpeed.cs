using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSpeed : MonoBehaviour
{
    
    public float CurrentSpeed { get; private set; }

        private Vector3 _oldPosition;
        private void Update()
        {
            CalculateSpeed();
        }

        private void CalculateSpeed() 
        {
            CurrentSpeed = Vector3.Distance(transform.position, _oldPosition) / Time.deltaTime;
            _oldPosition = transform.position;        
        }
        
        
    
}
