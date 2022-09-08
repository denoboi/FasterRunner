
using UnityEngine;

public class SpeedUpgraderClicker : MonoBehaviour
{
   private float _clickCount;
   private float _speed;

   public float Speed { get; set; }
   
   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         Speed += 2 * Time.deltaTime;
      }
   }
}
