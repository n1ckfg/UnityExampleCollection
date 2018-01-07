using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    public bool isVisited = false;
    public Color visitedColor;
    public Renderer ren;
    public Light light;

    private Color origColor;
    
	private void Start () {
        light.enabled = false;
        origColor = ren.material.GetColor("_Color");
	}

    private void OnTriggerEnter(Collider col) {
        doIsVisited();
    }

    public void doIsVisited() {
        isVisited = true;
        light.color = visitedColor;
        light.enabled = true;
        ren.material.SetColor("_Color", visitedColor);
    }

    public void reset() {
        isVisited = false;
        light.enabled = false;
        ren.material.SetColor("_Color", origColor);
    }

}
