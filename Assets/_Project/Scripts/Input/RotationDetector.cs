﻿//RotationDetector.cs implements rotational movement capabilities for objects within the app

using lisandroct.EventSystem.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = lisandroct.EventSystem.Event;

namespace RealChem.Input
{
    public class RotationDetector : MonoBehaviour
    {
        [SerializeField]
        private FloatEvent _onRotationEvent;
        private FloatEvent OnRotationEvent => _onRotationEvent;

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
        private float LastAngle { get; set; }

        private bool WasTouching { get; set; }

        public void Update()
        {
            var touching = BaseInput.IsTouching(true);

            if (touching)
            {
                var touch0Position = BaseInput.GetTouchPosition(0);
                var touch1Position = BaseInput.GetTouchPosition(1);
                var angle = CalculateAngle(touch0Position, touch1Position);

                if (!Rotating)
                {
                    if (!WasTouching)
                    {
                        LastAngle = angle;
                    }

                    var delta = angle - LastAngle;
                    if(!Panning && Mathf.Abs(delta) >= Threshold)
                    {
                        LastAngle = angle;
                        Rotating = true;
                    }
                }
                if (Rotating)
                {
                    var delta = angle - LastAngle;
                    OnRotationEvent.Invoke(delta);

                    LastAngle = angle;
                }

            }

            if (!touching && Rotating)
            {
                Rotating = false;
                OnReleaseEvent.Invoke();
            }

            WasTouching = touching;
        }

        public void OnPanningStart() => Panning = true;
        public void OnPanningEnd() => Panning = false;

        private static float CalculateAngle(Vector2 a, Vector2 b)
        {
            var vector = a - b;

            var angle = Vector2.Angle(vector, Vector2.up);
            if(vector.x > 0)
            {
                angle = 360 - angle;
            }
            return angle;
        }
    }
}