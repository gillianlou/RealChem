using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RealChem.UI
{
    public class DrawerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject closeDrawerButton;
        private RectTransform RectTransform => transform as RectTransform;
        public void Open() {
            closeDrawerButton.SetActive(true);
            RectTransform.anchoredPosition = new Vector2(RectTransform.anchoredPosition.x, 800);
        }

        public void Close(){
            closeDrawerButton.SetActive(false);
            RectTransform.anchoredPosition = new Vector2(RectTransform.anchoredPosition.x, 0);
        }
        
    }
}
