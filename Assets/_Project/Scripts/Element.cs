using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RealChem{
    public class Element : MonoBehaviour
    {
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

        private List<Element> CollidingElements { get; } = new List<Element>();

        private List<Element> BondedElements { get; } = new List<Element>();

        private void Start()
        {
            var meshRenderer = GetComponent<MeshRenderer>();
            var material = meshRenderer.material;

            material.SetColor("_BaseColor", Definition.Color);
        }
        public void Release()
        {
 
        }

      
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
    }
}