using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour {

    private AudioSource audio;

    private void Awake() {
        audio = GetComponent<AudioSource>();
        audio.pitch = 0.8f + Random.Range(0f, 0.2f);
        audio.Play();
    }

}
