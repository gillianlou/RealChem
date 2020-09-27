using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RealChem{
    public class Element : MonoBehaviour
    {
        [SerializeField]
        private string symbol;
        private string Symbol => symbol;

        [Space]

        [SerializeField]
        private GameObject _h2o;
        private GameObject H2O => _h2o;

        private List<Element> CollidingElements { get; } = new List<Element>();

        public void Release()
        {
            if (CreateH2O())
            {
                Instantiate(H2O, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            //else if(... check for other 2 molecules)
        }

        private bool CreateH2O()
        {
            switch (Symbol)
            {
                case "O":
                    {
                        var firstHIndex = CollidingElements.FindIndex(element => element.Symbol == "H");
                        var secondHIndex = CollidingElements.FindIndex(firstHIndex + 1, element => element.Symbol == "H");
                        
                        if(firstHIndex >= 0 && secondHIndex >= 0)
                        {
                            var firstH = CollidingElements[firstHIndex];
                            var secondH = CollidingElements[secondHIndex];

              
                            Destroy(firstH.gameObject);
                            Destroy(secondH.gameObject);
                            
                            return true;
                        }

                        break;
                    }

                /*case "H":
                    {
                        var o;
                        var h;
                    }*/
            }
            return false;
        }

        private void OnTriggerEnter(Collider other)
        {
            var otherElement = other.GetComponent<Element>();
            if (otherElement == null)
            {
                return;
            }

            CollidingElements.Add(otherElement);
        }

        private void OnTriggerExit(Collider other)
        {
            var otherElement = other.GetComponent<Element>();
            if (otherElement == null)
            {
                return;
            }

            CollidingElements.Remove(otherElement);
        }
    }
}