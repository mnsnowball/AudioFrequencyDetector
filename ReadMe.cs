using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadMe : MonoBehaviour {

    /*
     * Sample sound obtained from https://www.bensound.com/royalty-free-music/track/clear-day
     * 
     * Additional code obtained from https://medium.com/giant-scam/algorithmic-beat-mapping-in-unity-real-time-audio-analysis-using-the-unity-api-6e9595823ce4
     * I followed the above tutorial partially to help myself learn how FFTWindows work
     * 
     * This audio frequency detector uses AudioSource.GetSpectrumData to generate a number representing
     * the amount that each test frequency is represented in the audio played in the most recent frame.
     * 
     * The code calculates which "bins" to check in the samples array with the given frequency and the
     * total desired size of the array of samples. The upper and lower limits represent the number of "bins"
     * above and below the desired test freuency that are checked. Making the limit higher makes  detection easier
     * but makes it less accurate to the desired frequency.
     * 
     * To use the frequency detector, input desired test frequencies into the frequencies array, and drag and drop 
     * the corresponding boxes into the boxes array. Drag the audioSource with the music that you want to detect frequencies for
     * into the appropriate space in the inspector.
     * 
     * When clicking play, the boxes should be activated when the associated frequency has been detected in the music.
     * 
     * Also included is a TextSetter script that sets the text to the entered test frequencies, so it lets you know
     * what frequencies are being checked and which boxes represent each frequency. This script is attached to the same 
     * object as the frequencyDetector and can be deactivated or removed if needed.
     * 
     *  
     * 
     * 
     */
}
