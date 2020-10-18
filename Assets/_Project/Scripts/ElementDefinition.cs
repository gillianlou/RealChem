using UnityEngine;
using UnityEngine.Serialization;

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

        [FormerlySerializedAs("_radius")]
        [SerializeField]
        private float _atomicRadius;
        public float AtomicRadius => _atomicRadius;

        public int SpotsCount //number of elements need to bond to
        {
            get
            {
                if (ElectronsCount <= 2)
                {
                    return 2 - ElectronsCount;
                }
                if (ElectronsCount <= 10)
                {
                    return 10 - ElectronsCount;
                }
                if (ElectronsCount <= 28)
                {
                    return 28 - ElectronsCount;
                }
                return 60 - ElectronsCount;
            }
        }
    }
}
