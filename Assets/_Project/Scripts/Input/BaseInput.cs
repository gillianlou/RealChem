using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RealChem.Input
{

    public static class BaseInput
    {
        public static bool IsTouching() => UnityEngine.Input.GetMouseButton(0) || UnityEngine.Input.touchCount == 1;

        public static Vector3 GetTouchPosition() => UnityEngine.Input.mousePosition;
    }
}
