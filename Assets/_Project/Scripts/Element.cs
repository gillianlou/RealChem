using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RealChem{
    public class Element : MonoBehaviour
    {
        [SerializeField]
        private GameObject _linear;
        private GameObject Linear => _linear;


        [SerializeField]
        private GameObject _angular;
        private GameObject Angular => _angular;

        [SerializeField]
        private GameObject _trigonalPyramidal;
        private GameObject TrigonalPyramidal => _trigonalPyramidal;

        [SerializeField]
        private GameObject _tetrahedral;
        private GameObject Tetrahedral => _tetrahedral;


        [SerializeField]
        private float _radiusRatio = 0.1f;
        private float RadiusRatio => _radiusRatio;

        private ElementDefinition _definition;
        public ElementDefinition Definition
        {
            get => _definition;
            set
            {
                if (_definition != null)
                {
                    return;
                }

                _definition = value;
            }
        }

        private Spot[] Spots { get; } = new Spot[4];


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
            var radius = Definition.AtomicRadius * RadiusRatio;
            transform.position = new Vector3(transform.position.x, radius, transform.position.z);
            transform.localScale = Vector3.one * radius * 2;
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

            CreateBond(other);
            other.CreateBond(this);

            Molecule.AddElement(other);
            for(int i = 0, n = Molecule.Count; i < n; i++)
            {
                Molecule.GetElement(i).Molecule = Molecule;
            }

            return true;
        }

        private void CreateBond(Element other)
        {
            BondedElements.Add(other);
            /*count the number of valence electrons in the structure, subtract the number of valence 
             * electrons involved in a bonded atom, eight for all bonded atoms, according to the octet rule, 
             * except for H, which requires two. If there are remaining valence electrons, they must be lone 
             * pairs (LPs) around the central atom, so the remaining electrons are divided by two to come up 
             * with the number of lone pairs. Now determine what the structure is by finding the structure in 
             * the VSEPR table that has the correct number of bonding atoms and lone pairs.
             * 8-2*each bonded element/2 = # lone pairs
             * If the steric number is 4, it is sp3
             * If the steric number is 3 – sp2
             * If the steric number is 2 – sp*/

            var lonePairs = (8 - 2*BondedElementsCount)/2;
            var stericNumber = BondedElementsCount + lonePairs;

            if (!Definition.IsCenterElement || FreeSpots > 0)
            {
                return;
            }

            if(stericNumber == 2)
            {
                //sp 180
            }

            else if(stericNumber == 3)
            {
                //sp2 120
            }

            else if(stericNumber == 4)
            {
                //sp3 109.5
            }
            /*
            switch (Definition.SpotsCount) //full valence and bonded to more than one element
            {
                case 2: 
                    var stericNumber;
                    var lonePairs = 2;

                    if (lonePairs == 0) //angular
                    {
                        BondedElements[0].transform.position = AngularTransforms[0].localPosition;
                        BondedElements[1].transform.position = AngularTransforms[1].localPosition;
                    }
                    else //angular
                    {
                        BondedElements[0].transform.position = AngularTransforms[0].localPosition;
                        BondedElements[1].transform.position = AngularTransforms[1].localPosition;
                    }
                    break;
            }*/
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