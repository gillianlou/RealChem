using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RealChem{
    public class Element : MonoBehaviour
    {
        [SerializeField]
        private float _radiusRatio = 0.1f;
        private float RadiusRatio => _radiusRatio;

        [SerializeField]
        private float _yPosition = 0.1f;
        private float YPosition => _yPosition;

        private ElementDefinition _definition;
        public ElementDefinition Definition
        {
            private get => _definition;
            set
            {
                if (_definition != null)
                {
                    return;
                }

                _definition = value;
            }
        }

        public int BondedElementsCount => BondedElements.Count;

        public Molecule Molecule { get; private set; } = new Molecule();

        private List<Element> CollidingElements { get; } = new List<Element>();

        private List<Element> BondedElements { get; } = new List<Element>();

        public int FreeSpots => Definition.SpotsCount - BondedElements.Count;

        private bool Selected { get; set; }

        private void Start()
        {
            ChangeSize();
            ChangeColor();

            Molecule.AddElement(this);
        }

        private void ChangeSize()
        {
            transform.position = new Vector3(transform.position.x, YPosition, transform.position.z);
            transform.localScale = Vector3.one * Definition.AtomicRadius * RadiusRatio;
        }

        private void ChangeColor()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            var material = meshRenderer.material;

            material.SetColor("_BaseColor", Definition.Color);
        }

        public void SetSelected(bool value)
        {
            Selected = value;
            for (int i=0, n = Molecule.Count; i < n; i++)
            {
                Molecule.GetElement(i).Selected = value;

            }
        }

        public void Release()
        {
            if(FreeSpots<= 0)
            {
                return;
            }
            for(int i=0, n=CollidingElements.Count; i<n; i++)
            {
                var other = CollidingElements[i];
                if (Bond(other))
                {
                    if (FreeSpots <= 0)
                    {
                        break;
                    }
                }
            }

        }
        private bool Bond(Element other)
        {
            if(FreeSpots<= 0 || other.FreeSpots <= 0) //no free spots
            {
                return false;
            }

            if (BondedElements.Contains(other)) //already connected
            {
                return false;
            }

            for (int i =0, n=BondedElements.Count; i<n; i++)
            {
                if (BondedElements[i].BondedElements.Contains(other))
                {
                    return false;
                }
            }

            BondedElements.Add(other);
            other.BondedElements.Add(this);

            Molecule.AddElement(other);
            for(int i = 0, n = Molecule.Count; i < n; i++)
            {
                Molecule.GetElement(i).Molecule = Molecule;
            }

            return true;
        }

        public Element GetBondedElement(int index) => BondedElements[index];

        private void OnTriggerEnter(Collider other)
        {
            var otherElement = other.GetComponent<Element>();
            if (otherElement == null)
            {
                return;
            }

            CollidingElements.Add(otherElement);
        }

        private void OnTriggerExit(Collider other)
        {
            var otherElement = other.GetComponent<Element>();
            if (otherElement == null)
            {
                return;
            }

            CollidingElements.Remove(otherElement);
        }

        public void OnDrag(Vector3 delta)
        {
            if (!Selected)
            {
                return;
            }
            transform.position += delta;
        }
    }
}