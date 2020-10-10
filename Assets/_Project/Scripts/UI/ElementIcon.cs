using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RealChem.UI{
    public class ElementIcon : MonoBehaviour
    {
        private static readonly Vector2 Min = new Vector2(-2.25f, -1);
        private static readonly Vector2 Max = new Vector2(2.25f, 8);

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

        private void Start()
        {
            Image.color = Definition.Color;
            Symbol.text = Definition.Symbol;
            Name.text = Definition.name;
        }
        public void AddElementToWorld(){
            var x = Random.Range(Min.x, Max.x);
            var z = Random.Range(Min.y, Max.y);
            var position = new Vector3(x, 0.5f, z);

            var element = Instantiate(Prefab, position, Quaternion.identity);
            element.Definition = Definition;
        }

    }
}

