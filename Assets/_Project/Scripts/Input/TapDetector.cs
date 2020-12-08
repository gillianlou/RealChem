//Detects taps and their position on screen

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lisandroct.EventSystem.Events;
using Event = lisandroct.EventSystem.Event;

namespace RealChem.Input
{
    public class TapDetector : MonoBehaviour
    {
        [SerializeField]
        private Vector3Event _OnTapEvent;
        private Vector3Event OnTapEvent => _OnTapEvent;

        [SerializeField]
        private Event _OnReleaseEvent;
        private Event OnReleaseEvent => _OnReleaseEvent;

        private bool WasTouching { get; set; }

        public void Update()
        {
            var touching = BaseInput.IsTouching();

            if (touching && !WasTouching)
            {
                OnTapEvent.Invoke(BaseInput.GetTouchPosition());
            }

            if (!touching && WasTouching)
            {
                OnReleaseEvent.Invoke();
            }

            WasTouching = touching;
        }

    }
}




