//allows tapped game objects to be 'selected'

using lisandroct.EventSystem.Events;
using UnityEngine;

namespace RealChem
{

    public class Selector : MonoBehaviour
    {
        private const float Distance = 50;

        [SerializeField]
        private ElementEvent _onSelectionEvent;
        private ElementEvent OnSelectionEvent => _onSelectionEvent;

        [SerializeField] private Camera _camera;
        private Camera Camera => _camera;

        [SerializeField] private LayerMask _mask;
        private LayerMask Mask => _mask;

        private Element Selected { get; set; }


        public void OnTap(Vector3 touchPosition)
        {

            var ray = Camera.ScreenPointToRay(touchPosition);

            if(Selected != null)
            {
                Selected.SetSelected(false);
            }

            Selected = Physics.Raycast(ray, out var hit, Distance, Mask) ? hit.collider.GetComponent<Element>() : null;

            if(Selected != null)
            {
                Selected.SetSelected(true);
            }

            OnSelectionEvent.Invoke(Selected);
        }
        
        public void OnRelease()
        {
            if(Selected == null)
            {
                return;
            }
            Selected.Release();

            OnSelectionEvent.Invoke(Selected);
        }

    }
}