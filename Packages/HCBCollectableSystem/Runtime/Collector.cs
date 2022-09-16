using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HCB.CollectableSystem
{
    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            ICollectable collectable = other.GetComponentInParent<ICollectable>();
            if (collectable != null)
            {
                collectable.Collect(this);
                OnCollect(collectable);
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            ICollectable collectable = collision.collider.GetComponentInParent<ICollectable>();
            if (collectable != null)
            {
                collectable.Collect(this);
                OnCollect(collectable);
            }
        }

        protected virtual void OnCollect(ICollectable collectable)
        {
            
        }
    }
}
