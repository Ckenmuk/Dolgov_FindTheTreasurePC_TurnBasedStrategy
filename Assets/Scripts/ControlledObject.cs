using System;
using UnityEngine;

namespace Quest
{
    public abstract class ControlledObject : MonoBehaviour
    {
        public abstract void Activate();

        public abstract void Deactivate();
    }
}