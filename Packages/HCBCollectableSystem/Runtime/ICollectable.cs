
using UnityEngine;

namespace HCB.CollectableSystem
{
    public interface ICollectable
    {
        Transform T { get; }
        void Collect(Collector collector);
        
    }
}
