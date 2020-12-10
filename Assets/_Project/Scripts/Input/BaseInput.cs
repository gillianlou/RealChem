//BaseInput keeps track of user inputs to the app (mouse clicks or screen taps)

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
            return touching && !EventSystem.current.IsPointerOverGameObject() && !EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject(1);


        }
        public static Vector2 GetTouchPosition(int index = 0) 
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
                var mousePosition = (Vector2)UnityEngine.Input.mousePosition;
                var screenCenter = new Vector2(Screen.width, Screen.height) * 0.5f;

                var direction = mousePosition - screenCenter;

                return screenCenter - direction;
            }
            throw new UnityException("Only one or two fingers allowed");

#else
            return UnityEngine.Input.GetTouch(index).position;

#endif
        }
    }
}
