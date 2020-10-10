using UnityEngine;
using UnityEngine.EventSystems;

namespace RealChem.Input
{

    public static class BaseInput
    {
        public static bool IsTouching() => (UnityEngine.Input.GetMouseButton(0) || UnityEngine.Input.touchCount == 1) && !EventSystem.current.IsPointerOverGameObject();

        public static Vector3 GetTouchPosition() => UnityEngine.Input.mousePosition;
    }
}
