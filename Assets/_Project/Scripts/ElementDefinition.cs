using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RealChem
{
    [CreateAssetMenu(fileName = "New Element", menuName ="RealChem/New Element")]
    public class ElementDefinition : ScriptableObject
    {
        [SerializeField]
        private string _symbol;
        public string Symbol => _symbol;

        [SerializeField]
        private Color _color;
        public Color Color => _color;

        [Space]

        [SerializeField]
        private int _electronsCount;
        public int ElectronsCount => _electronsCount;

        [SerializeField]
        private float _mass;
        public float Mass => _mass > 0 ? _mass : ElectronsCount * 2; //manually set mass when not close to 2xelectron#

    }
}
