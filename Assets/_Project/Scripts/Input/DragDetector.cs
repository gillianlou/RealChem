//DragDetector.cs implements horizontal (planar) movement capabilities for objects within the app

using lisandroct.EventSystem.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

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
        private ARRaycastManager _raycastManager;
        private ARRaycastManager RaycastManager => _raycastManager;

        private List<ARRaycastHit> RaycastHits { get; } = new List<ARRaycastHit>();

        private bool Dragging { get; set; }
        private Vector3 LastPosition { get; set; }

        private void Update()
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
            RaycastManager.Raycast(screenPosition, RaycastHits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (RaycastHits.Count ==0)
            {
                planePoint = Vector3.zero;
                return false;
            }

            planePoint = RaycastHits[0].pose.position;
            return true;
        }
    }
}
