using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RealChem.AR
{
    public class PlaneMaterialSwapper : MonoBehaviour
    {
        [SerializeField]
        private Material _worldMaterial;
        private Material WorldMaterial => _worldMaterial;

        [SerializeField]
        private Material _drawerMaterial;
        private Material DrawerMaterial => _drawerMaterial;

        private MeshRenderer MeshRenderer { get; set; }

        private void Awake()
        {
            MeshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            OnDrawer(false);
        }

        public void OnDrawer(bool drawer)
        {
            MeshRenderer.material = drawer ? DrawerMaterial : WorldMaterial;
        }
    }
}