using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class InvertTest : MonoBehaviour {

	private Material mat;

	void Awake() {
		mat = new Material(Shader.Find("StereoRendering/InvertTest"));
	}

	void OnRenderImage(RenderTexture source, RenderTexture dest) {
		Graphics.Blit(source, dest, mat);
	}

}


