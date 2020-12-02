using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RealChem
{
    public class Spot : MonoBehaviour
    {
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
            transform.localScale = Vector3.one / (Element.Radius * 2 * multiplier);
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
