using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderScript : MonoBehaviour
{
    public Material ShaderMaterial;
    
    void OnRenderImage(RenderTexture src, RenderTexture dst) {
        Graphics.Blit(src, dst, ShaderMaterial);
    }
}
