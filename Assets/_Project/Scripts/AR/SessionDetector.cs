using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Event = lisandroct.EventSystem.Event;

namespace RealChem.AR
{
    public class SessionDetector : MonoBehaviour
    {
        [SerializeField]
        private Event _onARReadyEvent;
        private Event OnARReadyEvent => _onARReadyEvent;

        private void OnEnable()
        {
            ARSession.stateChanged += OnState;
        }

        private void OnDisable()
        {
            ARSession.stateChanged -= OnState;
        }

#if UNITY_EDITOR
        private void Start()
        {
            OnState(new ARSessionStateChangedEventArgs(ARSessionState.SessionTracking));
        }
#endif

        private void OnState(ARSessionStateChangedEventArgs args)
        {
            var state = args.state;

            if(state == ARSessionState.SessionTracking)
            {
                OnARReadyEvent.Invoke();
            }
        }
    }
}
