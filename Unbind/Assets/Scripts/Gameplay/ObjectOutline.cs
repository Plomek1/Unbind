using System.Collections.Generic;
using UnityEngine;

namespace Unbind
{
    public class ObjectOutline : MonoBehaviour
    {
        [HideInInspector] [SerializeField] private Shader outlineShader;
        [SerializeField] private MeshRenderer meshRenderer;

        private List<Material> outlineMaterials;

        private void Start()
        {
            foreach (Material mat in meshRenderer.materials)
                if (mat.shader == outlineShader)
                {
                    mat.SetInt("unity_GUIZTestMode", (int)UnityEngine.Rendering.CompareFunction.Always);
                    Debug.Log(mat.name);
                }
        }

        public void Activate()
        {
            
        }

        public void Deactivate() 
        { 
        
        }
    }
}
