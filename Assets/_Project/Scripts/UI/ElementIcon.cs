using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RealChem.UI{
    public class ElementIcon : MonoBehaviour
    {
        private static readonly Vector2 Min = new Vector2(-2.5f, -1.5f);
        private static readonly Vector2 Max = new Vector2(2.5f, 8);
        [SerializeField]
        private Element element;
        public void AddElement(){
            var x = Random.Range(Min.x, Max.x);
            var z = Random.Range(Min.y, Max.y);
            var position = new Vector3(x, 0.5f, z);

            Instantiate(element, position, Quaternion.identity);
        }

    }
}

