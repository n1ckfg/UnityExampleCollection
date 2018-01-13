// https://github.com/demonixis/Unity-toolbox

using UnityEngine;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
public class CRT_Effect : PostEffectsBase {

    public float Distortion = 0.1f;
    public float InputGamma = 2.4f;
    public float OutputGamma = 2.2f;
    public float TextureSize = 768f;

    private Material mat;

    private void OnRenderImage(RenderTexture source, RenderTexture dest) {
        if (mat == null) {
            mat = new Material(Shader.Find("Custom/CRT"));
        } else { 
            mat.SetFloat("_Distortion", Distortion);
            mat.SetFloat("_InputGamma", InputGamma);
            mat.SetFloat("_OutputGamma", OutputGamma);
            mat.SetVector("_TextureSize", new Vector2(TextureSize, TextureSize));
            Graphics.Blit(source, dest, mat);
        }
    }

}
