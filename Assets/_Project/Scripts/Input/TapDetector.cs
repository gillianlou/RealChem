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

        [Space]

        [SerializeField]
        private float _delay = 0.5f;
        private float Delay => _delay;


        private bool WasTouching { get; set; }
        private bool Tapping { get; set; }

        public void Update()
        {
            var touching = BaseInput.IsTouching();

            if (touching && !WasTouching)
            {
                StartCoroutine(StartTap());
            }

            if (!touching && Tapping)
            {
                Tapping = false;
                OnReleaseEvent.Invoke();
            }
            WasTouching = touching;
        }

        private IEnumerator StartTap()
        {
            yield return new WaitForSeconds(Delay);

            var touching = BaseInput.IsTouching();
            if (touching)
            {
                Tapping = true;
                OnTapEvent.Invoke(BaseInput.GetTouchPosition());
            }
        }

    }
}
