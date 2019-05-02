using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour {

    public Text[] theTexts;
    AudioFrequencyDetector theDetector;
	// Use this for initialization
	void Start () {
        theDetector = GetComponent <AudioFrequencyDetector>();
        for (int i = 0; i < theDetector.testFrequencies.Length; i++)
        {
            theTexts[i].text = theDetector.testFrequencies[i].ToString() + " Hz";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
