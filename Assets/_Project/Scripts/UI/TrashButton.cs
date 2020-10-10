using lisandroct.EventSystem.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RealChem.UI
{
    public class TrashButton : MonoBehaviour
    {
        [SerializeField]
        private ElementEvent _onSelectionEvent;
        private ElementEvent OnSelectionEvent => _onSelectionEvent;

        [Space]

        [SerializeField]
        private Button _button;
        private Button Button => _button;

        private Element Selected { get; set; }
        public void RemoveSelection()
        {
            if (Selected == null)
            {
                return;
            }
            var molecule = Selected.Molecule;
            for(int i = 0, n = molecule.Count; i < n; i++)
            {
                var elementGO = molecule.GetElement(i).gameObject;
                Destroy(elementGO);
            }

            OnSelectionEvent.Invoke(null);
        }
        public void OnSelection(Element element)
        {
            Selected = element;

            Button.interactable = Selected != null;
        }
    }
}
