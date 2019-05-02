using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFrequencyDetector : MonoBehaviour {
    public int boxesToCheckBelow = 2;
    public int boxesToCheckAbove = 2;
    public int[] testFrequencies;
    public GameObject[] boxes;
    public AudioSource theSource;

    public float[] samples;
    public int channel = 0;
    private float foundCutoff = 0.045f;

    Color black;
    Color white;
    Material newMaterial;
    GameObject currentBox;

    bool frequencyFound = false;

    // Use this for initialization
    void Start () {
        black = Color.black;
        white = Color.white;
        newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.color = black;
        
        if (testFrequencies.Length != boxes.Length)
        {
            Debug.LogError("There are more desired frequencies than there are boxes. Please either make more frequencies to choose from or make more boxes");
        }

        for (int i = 0; i < boxes.Length; i++) //disable all the boxes to start
        {
            boxes[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {

        samples = new float[1024];
        theSource.GetSpectrumData(samples, channel, FFTWindow.BlackmanHarris);
        for (int k = 0; k < testFrequencies.Length; k++)
        {
            currentBox = boxes[k];
            int targetFrequency = testFrequencies[k];
            int hertzPerBin = AudioSettings.outputSampleRate / 2 / 1024;
            int targetIndex = targetFrequency / hertzPerBin;

            frequencyFound = false;
            if (!frequencyFound)
            {
                for (int i = targetIndex - boxesToCheckBelow; i <= targetIndex + boxesToCheckAbove; i++)
                {

                    if (samples[i] >= foundCutoff)
                    {
                        Debug.Log("Frequency found: " + targetFrequency);
                        frequencyFound = true;
                        if (!currentBox.activeSelf) //if it's off then toggle it on
                        {
                            ToggleBox();
                        }

                    }
                    else
                    {
                        if (currentBox.activeSelf) //if we don't check to see if it's already off, then it will turn it on again
                        {
                            ToggleBox();
                        }

                    }
                }
            }
            

            
        }
        
	}

    void ToggleBox()
    {
        currentBox.SetActive(!currentBox.activeSelf);
    }
}



/*
 * This code below was obtained from https://medium.com/giant-scam/algorithmic-beat-mapping-in-unity-real-time-audio-analysis-using-the-unity-api-6e9595823ce4
 *  and is used in this solution:

    if (audioSource.time >= 128f && audioSource.time < 129f) {
	float[] curSpectrum = new float[1024];
	audioSource.GetSpectrumData (curSpectrum, 0, FFTWindow.BlackmanHarris);

	float targetFrequency = 234f;
	float hertzPerBin = (float)AudioSettings.outputSampleRate / 2f / 1024;
	int targetIndex = targetFrequency / hertzPerBin;

	string outString = "";
	for (int i = targetIndex - 3; i <= targetIndex + 3; i++) {
		outString += string.Format("| Bin {0} : {1}Hz : {2} |   ", i, i * hertzPerBin, curSpectrum[i]);
	}

	Debug.Log (outString);
}
     
     
     
     */
