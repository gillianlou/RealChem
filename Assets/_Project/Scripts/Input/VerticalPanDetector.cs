//VerticalPanDetector.cs implements vertical movement capabilities for objects within the app

using lisandroct.EventSystem.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = lisandroct.EventSystem.Event;

namespace RealChem.Input
{
    public class VerticalPanDetector : MonoBehaviour
    {
        [SerializeField]
        private FloatEvent _onVerticalPanEvent;
        private FloatEvent OnVerticalPanEvent => _onVerticalPanEvent;

        [SerializeField]
        private Event _onVerticalPanEndEvent;
        private Event OnVerticalPanEndEvent => _onVerticalPanEndEvent;

        [Space]

        [SerializeField]
        //required distance before start panning 
        private float _threshold;
        private float Threshold => _threshold;

        [SerializeField]
        private float _ratio = 0.2f;
        private float Ratio => _ratio;

        private bool Valid { get; set; }

        private bool Panning { get; set; }
        private bool Rotating { get; set; }
        private float LastPosition { get; set; }

        private bool WasTouching { get; set; }

        public void Update()
        {
            var touching = BaseInput.IsTouching(true);

            if (touching)
            {
                var touch0Position = BaseInput.GetTouchPosition(0).y;
                var touch1Position = BaseInput.GetTouchPosition(1).y;
                var position = (touch0Position + touch1Position) * 0.5f;

                if (!Panning)
                {
                    if (!WasTouching)
                    {
                        Valid = Mathf.Abs(touch0Position - touch1Position) < Threshold;
                        LastPosition = position;
                    }

                    var delta = Mathf.Abs(position - LastPosition);

                    if (Valid && !Rotating && delta >= Threshold)
                    {
                        LastPosition = position;
                        Panning = true;
                    }
                }
                if (Panning)
                {
                    var delta = position - LastPosition;
                    OnVerticalPanEvent.Invoke(delta * Ratio);

                    LastPosition = position;
                }

            }

            if (!touching && Panning)
            {
                Panning = false;
                OnVerticalPanEndEvent.Invoke();
            }

            WasTouching = touching;
        }
        public void OnRotation(float delta) => Rotating = true;
        public void OnRotationEnd() => Rotating = false;
    }
}