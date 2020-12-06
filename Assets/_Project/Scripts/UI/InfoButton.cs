//InfoButton.cs gives the 'i' button in the app functionality, so that when a user clicks it, it takes them to a chemSpider page telling more about their
// molecule if they have created a valid molecule, or becoming grayed out and nonfunctional if there are no valid molecules selected

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
