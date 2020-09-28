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

        [SerializeField]
        private GameObject _co2;
        private GameObject CO2 => _co2;

        [SerializeField]
        private GameObject _c2h4;
        private GameObject C2H4 => _c2h4;

        private List<Element> CollidingElements { get; } = new List<Element>();

        public void Release()
        {
            if (CreateH2O())
            {
                Instantiate(H2O, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (CreateCO2())
            {
                Instantiate(CO2, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (CreateC2H4())
            {
                Instantiate(C2H4, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
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

                case "H":
                    {
                        var hIndex = CollidingElements.FindIndex(element => element.Symbol == "H");
                        var oIndex = CollidingElements.FindIndex(element => element.Symbol == "O");

                        if (hIndex >= 0 && oIndex >= 0)
                        {
                            var h = CollidingElements[hIndex];
                            var o = CollidingElements[oIndex];


                            Destroy(h.gameObject);
                            Destroy(o.gameObject);

                            return true;
                        }

                        break;
                    }
            }
            return false;
        }

        private bool CreateCO2()
        {
            switch (Symbol)
            {
                case "O":
                    {
                        var cIndex = CollidingElements.FindIndex(element => element.Symbol == "C");
                        var oIndex = CollidingElements.FindIndex(element => element.Symbol == "O");

                        if (cIndex >= 0 && oIndex >= 0)
                        {
                            var c = CollidingElements[cIndex];
                            var o = CollidingElements[oIndex];


                            Destroy(c.gameObject);
                            Destroy(o.gameObject);

                            return true;
                        }

                        break;
                    }
                case "C":
                    {
                        var firstOIndex = CollidingElements.FindIndex(element => element.Symbol == "O");
                        var secondOIndex = CollidingElements.FindIndex(firstOIndex + 1, element => element.Symbol == "O");

                        if (firstOIndex >= 0 && secondOIndex >= 0)
                        {
                            var firstO = CollidingElements[firstOIndex];
                            var secondO = CollidingElements[secondOIndex];


                            Destroy(firstO.gameObject);
                            Destroy(secondO.gameObject);

                            return true;
                        }

                        break;
                    }

            }
            return false;
        }

        private bool CreateC2H4()
        {
            switch (Symbol)
            {
                case "C":
                    {
                        var cIndex = CollidingElements.FindIndex(element => element.Symbol == "C");
                        var firstHIndex = CollidingElements.FindIndex(element => element.Symbol == "H");
                        var secondHIndex = CollidingElements.FindIndex(firstHIndex + 1, element => element.Symbol == "H");
                        var thirdHIndex = CollidingElements.FindIndex(secondHIndex + 1, element => element.Symbol == "H");
                        var fourthHIndex = CollidingElements.FindIndex(thirdHIndex + 1, element => element.Symbol == "H");

                        if (cIndex >= 0 && firstHIndex >= 0 && secondHIndex >= 0 && thirdHIndex >= 0 && fourthHIndex >= 0)
                        {
                            var c = CollidingElements[cIndex];
                            var firsth = CollidingElements[firstHIndex];
                            var secondh = CollidingElements[secondHIndex];
                            var thirdh = CollidingElements[thirdHIndex];
                            var fourthh = CollidingElements[fourthHIndex];


                            Destroy(c.gameObject);
                            Destroy(firsth.gameObject);
                            Destroy(secondh.gameObject);
                            Destroy(thirdh.gameObject);
                            Destroy(fourthh.gameObject);

                            return true;
                        }

                        break;
                    }
                case "H":
                    {
                        var cIndex = CollidingElements.FindIndex(element => element.Symbol == "C");
                        var secondCIndex = CollidingElements.FindIndex(cIndex + 1, element => element.Symbol == "C");
                        var secondHIndex = CollidingElements.FindIndex(element => element.Symbol == "H");
                        var thirdHIndex = CollidingElements.FindIndex(secondHIndex + 1, element => element.Symbol == "H");
                        var fourthHIndex = CollidingElements.FindIndex(thirdHIndex + 1, element => element.Symbol == "H");

                        if (cIndex >= 0 && secondCIndex >= 0 && secondHIndex >= 0 && thirdHIndex >= 0 && fourthHIndex >= 0)
                        {
                            var c = CollidingElements[cIndex];
                            var secondC = CollidingElements[secondCIndex];
                            var secondh = CollidingElements[secondHIndex];
                            var thirdh = CollidingElements[thirdHIndex];
                            var fourthh = CollidingElements[fourthHIndex];

                            Destroy(c.gameObject);
                            Destroy(secondC.gameObject);
                            Destroy(secondh.gameObject);
                            Destroy(thirdh.gameObject);
                            Destroy(fourthh.gameObject);

                            return true;
                        }

                        break;
                    }

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