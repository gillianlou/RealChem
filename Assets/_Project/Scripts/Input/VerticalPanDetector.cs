//VerticalPanDetector.cs implements vertical movement capabilities for objects within the app

using lisandroct.EventSystem.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Event = lisandroct.EventSystem.Event;

namespace RealChem.Input
{
    public class VerticalPanDetector : MonoBehaviour
    {

#if UNITY_EDITOR
        private const float Ratio = 0.01f;
#else
        private const float Ratio = 0.001f;
#endif
        [FormerlySerializedAs("_onVerticalPanEvent")] [SerializeField]
        private Vector3Event _onDragEvent;
        private Vector3Event OnDragEvent => _onDragEvent;

        [SerializeField]
        private Event _onReleaseEvent;
        private Event OnReleaseEvent => _onReleaseEvent;

        [Space]

        [SerializeField]
        //required distance before start panning 
        private float _threshold;
        private float Threshold => _threshold;

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
                        LastPosition = position;
                    }

                    var delta = Mathf.Abs(position - LastPosition);

                    if (!Rotating && delta >= Threshold)
                    {
                        LastPosition = position;
                        Panning = true;
                    }
                }
                if (Panning)
                {
                    var delta = position - LastPosition;
                    OnDragEvent.Invoke(Vector3.up * (delta * Ratio));

                    LastPosition = position;
                }

            }

            if (!touching && Panning)
            {
                Panning = false;
                OnReleaseEvent.Invoke();
            }

            WasTouching = touching;
        }
        public void OnRotation(float delta) => Rotating = true;
        public void OnRotationEnd() => Rotating = false;
    }
}