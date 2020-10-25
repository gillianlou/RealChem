using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RealChem.UI{
    public class ElementIcon : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        private Image Image => _image;

        [SerializeField]
        private Text _symbol;
        private Text Symbol => _symbol;

        [SerializeField]
        private Text _name;
        private Text Name => _name;

        [Space]

        [SerializeField]
        private Element _prefab;
        private Element Prefab => _prefab;

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

        public Vector3 ScreenCenter { get; set; }

        private void Start()
        {
            Image.color = Definition.Color;
            Symbol.text = Definition.Symbol;
            Name.text = Definition.name;
        }
        public void AddElementToWorld(){

            if(float.IsInfinity(ScreenCenter.x) || float.IsInfinity(ScreenCenter.y) || float.IsInfinity(ScreenCenter.z))
            {
                return;
            }

            var element = Instantiate(Prefab, ScreenCenter, Quaternion.identity);
            element.Definition = Definition;
        }

    }
}

