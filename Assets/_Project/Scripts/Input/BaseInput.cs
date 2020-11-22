using UnityEngine;
using UnityEngine.EventSystems;

namespace RealChem.Input
{

    public static class BaseInput
    {
        public static bool IsTouching(bool multiTouch = false)
        {

#if UNITY_EDITOR
            var mouse = UnityEngine.Input.GetMouseButton(0);
            var emulated = UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.LeftShift);
            var touching = multiTouch
                ? mouse && emulated
                : mouse && !emulated;

#else
            var touching = multiTouch 
                ? UnityEngine.Input.touchCount ==2 
                : UnityEngine.Input.touchCount == 1;

#endif
            return touching && !EventSystem.current.IsPointerOverGameObject();


        }
        public static Vector3 GetTouchPosition(int index = 0) 
        {
#if UNITY_EDITOR
            if(index == 0)
            {
                return UnityEngine.Input.mousePosition;
            }

            if (UnityEngine.Input.GetKey(KeyCode.LeftControl))
            {
                return UnityEngine.Input.mousePosition - Vector3.left * 100;
            }

            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
                return UnityEngine.Input.mousePosition;
            }
            throw new UnityException("Only one or two fingers allowed");

#else
            return UnityEngine.Input.GetTouch(index).position;

#endif
        }
    }
}
