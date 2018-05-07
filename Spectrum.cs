using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour {
    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 5f;
    public GameObject[] cubes;
    public int height = 30;
    //public float maxScale;

    // Use this for initialization
    void Start() {
        for (int i = 0; i < numberOfObjects; i++) {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
        }
        cubes = GameObject.FindGameObjectsWithTag("Cubes");

    }
	// Update is called once per frame
	void Update () {
        float[] spectrum = new float[1024];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 previousScale = cubes[i].transform.localScale;
            previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * height, Time.deltaTime * 30);
            //previousScale = new Vector3(10, (MicrophoneInput.samples[i] * maxScale) + 2, 10);
            cubes[i].transform.localScale = previousScale;
        }
	}
}
