using lisandroct.EventSystem.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace RealChem.Input
{
    public class PlacementDetector : MonoBehaviour
    {
        [SerializeField]
        private Vector3Event _onScreenCenter;
        private Vector3Event OnScreenCenter => _onScreenCenter;
        [Space]

        [SerializeField]
        private Camera _camera;
        private Camera Camera => _camera;

        [SerializeField]
        private ARRaycastManager _raycastManager;
        private ARRaycastManager RaycastManager => _raycastManager;

        [Space]

        [SerializeField]
        private GameObject _placementIndicator;
        private GameObject PlacementIndicator => _placementIndicator;

        private List<ARRaycastHit> RaycastHits { get; } = new List<ARRaycastHit>();

        private void OnDisable()
        {
            if(PlacementIndicator != null)
            {
                PlacementIndicator.SetActive(false);
            }
        }

        private void Update()
        {
            var screenCenter = Camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

            //move placement indicator 
            if(Raycast(screenCenter, out var planePoint, out var planeRotation))
            {
                PlacementIndicator.SetActive(true);
                PlacementIndicator.transform.SetPositionAndRotation(planePoint, planeRotation);
                OnScreenCenter.Invoke(planePoint);
            }
            else
            {
                PlacementIndicator.SetActive(false);
                OnScreenCenter.Invoke(Vector3.negativeInfinity);
            }
        }

        private bool Raycast(Vector3 screenPosition, out Vector3 planePoint, out Quaternion planeRotation)
        {
            RaycastManager.Raycast(screenPosition, RaycastHits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (RaycastHits.Count == 0)
            {
                planePoint = Vector3.zero;
                planeRotation = Quaternion.identity;
                return false;
            }
            var hit = RaycastHits[0].pose;
            planePoint = hit.position;
            planeRotation = hit.rotation;
            return true;
        }
    
    }
}