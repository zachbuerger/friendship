using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour {
    AudioSource audioSource;
    public static float[] samples = new float[1024];

	// Use this for initialization
	void Start () {

        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = Microphone.Start(null, true, 10, 44100);
        //audioSource.loop = true; // Set the AudioClip to loop
        //audioSource.mute = true; // Mute the sound, we don't want the player to hear it
        //while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the recording has started
        //audioSource.Play(); // Play the audio source!
    }
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
	}

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
}
