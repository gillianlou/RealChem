using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RealChem
{
    public class Spot : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer _meshRenderer;
        private MeshRenderer MeshRenderer => _meshRenderer;

        private Element Element { get; set; }

        private Spot BondedSpot { get; set; }

        private Element BondedElement => BondedSpot != null ? BondedSpot.Element : null;

        private void Awake()
        {
            SetRenderer(false);
        }

        private void SetRenderer(bool active)
        {
            MeshRenderer.enabled = active;
        }
    }
}
