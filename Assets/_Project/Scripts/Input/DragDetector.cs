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

        [SerializeField]
        private Camera _camera;
        private Camera Camera => _camera;

        [SerializeField]
        private Vector3Event _onDragEvent;
        private Vector3Event OnDragEvent => _onDragEvent;

        private Element Selected { get; set; }
        private bool Dragging { get; set; }
        private Vector3 LastPosition { get; set; }


        private void Update()
        {
            if (!Dragging || Selected == null)
            {
                return;
            }

            if (Raycast(BaseInput.GetTouchPosition(), out var planePosition))
            {
                var delta = planePosition - LastPosition;

                if(Mathf.Approximately(delta.x, 0) && Mathf.Approximately(delta.y, 0) && Mathf.Approximately(delta.z, 0))
                {
                    return;
                }

                OnDragEvent.Invoke(delta);

                LastPosition = planePosition;
            }
        }


        public void OnSelection(Element element)
        {
            Selected = element;

            OnTap(BaseInput.GetTouchPosition());
        }

        public void OnTap(Vector3 touchPosition)
        {
            if (Selected != null)
            {
                Dragging = Raycast(touchPosition, out var planePosition);

                LastPosition = planePosition;
            }
        }

        public void OnRelease()
        {
            Dragging = false;
        }
        
        private bool Raycast(Vector3 screenPosition, out Vector3 planePoint)
        {
            var ray = Camera.ScreenPointToRay(screenPosition);
            var plane = new Plane(Vector3.up, Selected.transform.position);
            
            if (plane.Raycast(ray, out var t)){
                planePoint = ray.GetPoint(t);
                return true;
            }

            planePoint = Vector3.zero;
            return false;
        }
    }
}
