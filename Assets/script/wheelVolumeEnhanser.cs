using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class wheelVolumeEnhanser : MonoBehaviour {
    public AudioSource audiosource;
    public AudioMixer mix;

    // Use this for initialization
    void Start ()
    {
        mix.SetFloat("wheelVolume", 0);
    }

	// Update is called once per frame
	void Update ()
    {

    }

    public void wheelVolumeMaximum()
    {
        mix.SetFloat("wheelVolume", 0);
    }

    public void wheelVolumeMin()
    {
        mix.SetFloat("wheelVolume", -80);
    }
}
