//Element.cs defines elements with fields for color, size, number of available bonding spots, and bond angles, as well as methods to move
//elements around (ie rotate, drag vertical, drag horizontal)

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RealChem{
    public class Element : MonoBehaviour
    {
        #if UNITY_EDITOR
        private const float RadiusRatio = 0.02f;
        #else
        private const float RadiusRatio = 0.002f;
        #endif

        private static readonly int BaseColorProperty = Shader.PropertyToID("_BaseColor");
        private static readonly int SelectedProperty = Shader.PropertyToID("_Selected");

        [SerializeField]
        private Transform _linear;
        private Transform Linear => _linear;


        [SerializeField]
        private Transform _angular;
        private Transform Angular => _angular;

        [SerializeField]
        private Transform _trigonalPyramidal;
        private Transform TrigonalPyramidal => _trigonalPyramidal;

        [SerializeField]
        private Transform _tetrahedral;
        private Transform Tetrahedral => _tetrahedral;

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

        private Material Material { get; set; }

        private Spot[] Spots { get; } = new Spot[4];


        public Molecule Molecule { get; private set; } = new Molecule();

        private List<Spot> CollidingSpots { get; } = new List<Spot>();


        private bool Selected { get; set; }

        public Vector3 Position => transform.position;

        public float Radius => Definition.AtomicRadius * RadiusRatio;

        private void Start()
        {
            Material = GetComponent<MeshRenderer>().material;

            ChangeSize();
            ChangeColor();

            InitializeSpots();

            Molecule.AddElement(this);
        }

        private void ChangeSize()
        {
            transform.position += Vector3.up * Radius;
            transform.localScale = Vector3.one * Radius * 2;
        }

        private void ChangeColor()
        {
            Material.SetColor(BaseColorProperty, Definition.Color);
        }

        private void InitializeSpots()
        {
            Debug.Log(Definition.SpotsCount);
            Transform geometry;
            switch (Definition.SpotsCount)
            {
                case 1:
                    geometry = Linear;
                    break;
                case 2:
                    geometry = Angular;
                    break;
                case 3:
                    geometry = TrigonalPyramidal;
                    break;
                case 4:
                    geometry = Tetrahedral;
                    break;
                default:
                    throw new UnityException("Geometry not defined");
            }

            for(int i = 0, n = geometry.childCount; i < n; i++)
            {
                var child = geometry.GetChild(i);
                var spot = child.GetComponent<Spot>();
                Spots[i] = spot;
            }

            for (int i = 0, n = Spots.Length; i < n; i++)
            {
                var spot = Spots[i];
                if (spot == null) continue;
                spot.Initialize();
            }
            Destroy(Linear.gameObject);
            Destroy(Angular.gameObject);
            Destroy(TrigonalPyramidal.gameObject);
            Destroy(Tetrahedral.gameObject);
        }

        private bool IsFree()
        {
            for(int i = 0, n = Spots.Length; i < n; i++)
            {
                var spot = Spots[i];
                if (spot != null && Spots[i].BondedElement != null)
                {
                    return false;
                }
            }
            return true;
        }

        public void SetSelected(bool value)
        {
            Selected = value;

            Material.SetInt(SelectedProperty, value ? 1 : 0);
        }

        public void Release()
        {
            if(CollidingSpots.Count <= 0)
            {
                return;
            }

            if (!IsFree())
            {
                return;
            }

            var collidingSpot = CollidingSpots[0];
            var collidingElement = collidingSpot.Element;

            var collidingSpotPosition = collidingSpot.Position;
            var collidingElementPosition = collidingElement.Position;
            var direction = (collidingSpotPosition - collidingElementPosition).normalized;
            var distance = (collidingElement.Radius + Radius) * 0.8f;
            var position = collidingElementPosition + direction * distance;


            transform.position = position;
            transform.LookAt(collidingSpot.ElementPosition, Vector3.up);

            collidingSpot.Bond(Spots[0]);

            transform.SetParent(collidingElement.transform, true);

            Molecule = collidingSpot.Element.Molecule;
            Molecule.AddElement(this);
        }

        public bool IsFull()
        {
            for (int i = 0, n = Spots.Length; i < n; i++)
            {
                var spot = Spots[i];
                if (spot == null) continue;
                if (spot.BondedElement == null)
                {
                    return false;
                }
            }
            return true;
        }
        

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

            /*var lonePairs = (8 - 2*BondedElementsCount)/2;
            var stericNumber = BondedElementsCount + lonePairs;*/

        private void OnTriggerEnter(Collider other)
        {
            var spot = other.GetComponent<Spot>();
            if (spot == null)
            {
                return;
            }

            CollidingSpots.Add(spot);
            if (Selected)
            {
                spot.SetRenderer(true);
                spot.Highlight(CollidingSpots.Count == 1);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var spot = other.GetComponent<Spot>();
            if (spot == null)
            {
                return;
            }

            CollidingSpots.Remove(spot);
            if (Selected)
            {
                spot.SetRenderer(false);
                spot.Highlight(false);

                if (CollidingSpots.Count > 0)
                {
                    CollidingSpots[0].Highlight(true);
                }
            }

        }

        public void OnDrag(Vector3 delta)
        {
            if (!Selected)
            {
                return;
            }
            var parent = Molecule.GetParent();

            parent.position += delta;
        }

        public void OnVerticalPan(float delta)
        {
            if (!Selected)
            {
                return;
            }
            var parent = Molecule.GetParent();

            parent.position += Vector3.up * delta;
        }

        public void OnRotation(float delta)
        {
            if (!Selected)
            {
                return;
            }

            var parent = Molecule.GetParent();

            parent.RotateAround(transform.position, Vector3.up, delta);
        }
    }
}