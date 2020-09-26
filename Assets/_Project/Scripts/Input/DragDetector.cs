﻿using lisandroct.EventSystem.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RealChem.Input
{
    public class DragDetector : MonoBehaviour
    {
        private const float Distance = 50;

        [SerializeField]
        private Vector3Event _onDragEvent;
        private Vector3Event OnDragEvent => _onDragEvent;

        [Space]

        [SerializeField]
        private Camera _camera;
        private Camera Camera => _camera;

        [SerializeField]
        private LayerMask _mask;
        private LayerMask Mask => _mask;

        private bool Dragging { get; set; }
        private Vector3 LastPosition { get; set; }

        private void FixedUpdate()
        {
            if (!Dragging)
            {
                return;
            }

            if (Raycast(BaseInput.GetTouchPosition(), out var planePosition))
            {
                var delta = planePosition - LastPosition;

                OnDragEvent.Invoke(delta);

                LastPosition = planePosition;
            }
        }

        public void OnTap(Vector3 touchPosition)
        {
            Dragging = Raycast(touchPosition, out var planePosition);

            LastPosition = planePosition;
        }

        public void OnRelease()
        {
            Dragging = false;
        }
        
        private bool Raycast(Vector3 screenPosition, out Vector3 planePoint)
        {
            var ray = Camera.ScreenPointToRay(screenPosition);

            var result = Physics.Raycast(ray, out var hit, Distance, Mask);
            planePoint = hit.point;

            return result;
        }
    }
}