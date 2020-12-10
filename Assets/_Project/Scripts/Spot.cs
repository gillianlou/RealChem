//Spot.cs defines the placement indicators that appear when two elments with available bonding spots collide

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RealChem
{
    public class Spot : MonoBehaviour
    {
        private const float AtomicRadius = 20;

        [SerializeField]
        private MeshRenderer _meshRenderer;

        [SerializeField]
        private Element _element;
        public Element Element => _element;
        private MeshRenderer MeshRenderer => _meshRenderer;

        private Spot BondedSpot { get; set; }

        public Element BondedElement => BondedSpot != null ? BondedSpot.Element : null;

        public Vector3 Position => transform.position;

        public Vector3 ElementPosition => Element.transform.position;

        public void Initialize()
        {
            transform.SetParent(Element.transform, true);

            SetRenderer(false);
            Highlight(false);
        }

        public void SetRenderer(bool active)
        {
            MeshRenderer.enabled = active;
        }

        public void Highlight(bool highlight)
        {
            var multiplier = highlight ? 1.2f : 1;
            var one = Vector3.one * multiplier;
            transform.localScale = one * (AtomicRadius / Element.Definition.AtomicRadius);
        }

        public void Bond(Spot spot)
        {
            if (BondedSpot != null) return;
            if (spot.BondedSpot != null) return;

            BondedSpot = spot;
            gameObject.SetActive(false);

            spot.BondedSpot = this;
            spot.gameObject.SetActive(false);
        }
    }
}
