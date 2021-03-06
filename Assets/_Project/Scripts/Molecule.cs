//Molecule.cs implements the bonding of individual elements, storing bonded elements in a list. This is how molecules are created

using System.Collections.Generic;
using UnityEngine;

namespace RealChem
{
    public class Molecule
    {
        public int Count => Elements.Count;
        private HashSet<Element> Set {get;} = new HashSet<Element>();
        private List<Element> Elements { get; } = new List<Element>();

        private Element Selected { get; set; }

        public void AddElement(Element element)
        {
            if (Set.Contains(element))
            {
                return;
            }
            Elements.Add(element);
            Set.Add(element);
        }

        public Element GetElement(int index) => Elements[index];

        public bool IsValid()
        {
            for(int i = 0, n = Elements.Count; i < n; i++)
            {
                if(!Elements[i].IsFull())
                {
                    return false;
                }
            }
            return true;
        }
        
        public string GetSmiles()
        {
            string smiles = "";

            for (int i = 0, n = Elements.Count; i < n; i++)
            {
                smiles += Elements[i].Definition.Symbol;
            }
            return smiles;
        }

        public Transform GetParent() => Elements[0].transform;
    }
}
