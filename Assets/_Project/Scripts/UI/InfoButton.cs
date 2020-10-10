using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RealChem.UI
{
    public class InfoButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        private Button Button => _button;

        private Element Selected { get; set; }
        public void OpenInfo()
        {
            if (Selected == null)
            {
                return;
            }
            var molecule = Selected.Molecule;

            if (molecule.IsValid())
            {
                Application.OpenURL($"http://www.chemspider.com/Search.aspx?q={molecule.GetSmiles()}");
            }
            else
            {
                Debug.Log("Invalid molecule");
            }
        }
        public void OnSelection(Element element)
        {
            Selected = element;

            Button.interactable = Selected != null;
        }
    }
}
