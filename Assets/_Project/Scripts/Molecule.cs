using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RealChem
{
    public class Molecule
    {
        public int Count => Elements.Count;
        private HashSet<Element> Set {get;} = new HashSet<Element>();
        private List<Element> Elements { get; } = new List<Element>();

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
                if(Elements[i].IsFull())
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
                //Debug.Log(smiles);
            }
            //Debug.Log(smiles);
            return smiles;
        }

        public Transform GetParent() => Elements[0].transform;
    }
}
