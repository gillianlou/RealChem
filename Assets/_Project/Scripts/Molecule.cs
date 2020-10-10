using System.Collections.Generic;

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

            for(int i = 0, n = element.BondedElementsCount; i<n; i++)
            {
                AddElement(element.GetBondedElement(i));
            }
        }

        public Element GetElement(int index) => Elements[index];

        public string GetSmiles()
        {
            return "HOH";
        }
    }
}