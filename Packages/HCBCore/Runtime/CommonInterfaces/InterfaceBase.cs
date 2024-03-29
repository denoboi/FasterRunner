﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HCB
{
    public class InterfaceBase : MonoBehaviour, IComponent
    {
        public Component component { get { return this; } }

        public bool isDestroyed { get; set; }


        private void OnDestroy()
        {
            isDestroyed = true;
        }
    }
}
