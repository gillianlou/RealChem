using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RealChem
{

    public class Selector : MonoBehaviour
    {
        private const float Distance = 50;

        [SerializeField] private Camera _camera;
        private Camera Camera => _camera;

        [SerializeField] private LayerMask _mask;
        private LayerMask Mask => _mask;

        private GameObject Selected { get; set; }


        public void OnTap(Vector3 touchPosition)
        {

            var ray = Camera.ScreenPointToRay(touchPosition);

            Selected = Physics.Raycast(ray, out var hit, Distance, Mask) ? hit.collider.gameObject : null;
        }

        public void OnDrag(Vector3 delta)
        {
            if(Selected == null)
            {
                return;
            }
            Selected.transform.position += delta;
        }
    }
}