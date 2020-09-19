using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RealChem.UI{
    public class ElementIcon : MonoBehaviour
    {
        [SerializeField]
        private string elementName;
        public void AddElement(){
              Debug.Log($"Add element {elementName} to the world");  
        }

    }
}

