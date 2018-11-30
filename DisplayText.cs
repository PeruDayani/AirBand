using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script by Josh, made on Monday November 5th, to display 
 * EEG data in the virtual world through a text mesh. */
public class DisplayText : MonoBehaviour {
    TextMesh T;
    public string text_message;
    public MuseDataHandler M;

	void Start () {
		T = this.GetComponent<TextMesh>();
		T.text = "";
        text_message = "";
	}

    // Update is called once per frame
    void Update()
    {
        text_message = "Gamma: " + M.GetEEGData_gamma() + "; Blink: " + M.GetEEGData_blink() + "; Jaw : " + M.GetEEGData_jaw();
        T.text = text_message;
    }
}
