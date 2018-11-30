using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Created by Josh. Handles EEG Data recieved from MuseIO.
 *
 *
 * INSTRUCTIONS to set up environment (FOR MAC):
 * 1. Go to http://developer.choosemuse.com/tools/mac-tools/muselab and download and install MuseIO and MuseLab.
 * 2. Connect Muse headband to computer via bluetooth.
 * 3. Run this command in terminal: muse-io --device Muse-XXXX --osc osc.udp://localhost:5000, where Muse-XXXX is your muse device name.
 * 4. Add '/' to the beginning of every address if it isn't already in the form '/muse/.....'
 * 5. In OSC under private static int ExtractMessages, change the first character switch case from 'm' to '/' if it is not already '/'.
 * 6. DON'T open port 5000 on MuseLab or else it will interfere with the OSC server generated here. Simply run this code, and the server
 *    should be recieving the EEG data.
 *    
 * INSTRUCTIONS to set up environment FOR WINDOWS:
 * 1. Go to the Microsoft Store and install Muse Direct.
 * 2. Connect Muse headband to computer via bluetooth.
 * 3. On Muse direct, create a new output UDP channel through port 5000 and make the name "muse".
 * 4. Delete '/' fromm the beginning of every address if it isn't in the form 'muse/.....'
 * 5. In OSC under private static int ExtractMessages, change the first character switch case from '/' to 'm' if it is not already 'm'.
 * 6. DON'T open port 5000 on MuseLab or else it will interfere with the OSC server generated here. Simply run this code, and the server
 *    should be recieving the EEG data.
 */

public class MuseDataHandler : MonoBehaviour {

	public OSC osc;
    static float museDataVar = 0;
    static float museDataBlink = 0;
    static float museDataJaw = 0;
    static float museDataGamma = 0;
	static float normalizedMuseDataVar = 0;

	private static float maxVal = 1000f;
	private static float minVal = 0;


	void Start () {
		// Currently listens for general eeg data values.
		// Other data can be listened to through addresses found here: http://developer.choosemuse.com/tools/available-data
		osc.SetAddressHandler("muse/elements/gamma_relative", OnReceiveEEG_gamma);
        //osc.SetAddressHandler("muse/elements/beta_relative", OnReceiveEEG_gamma);
        osc.SetAddressHandler("muse/elements/blink", OnReceiveEEG_blink);
        osc.SetAddressHandler("muse/elements/jaw_clench", OnReceiveEEG_jaw);
    }

    void OnReceiveEEG_blink(OscMessage message)
    {
        // Get EEG data from message
        museDataBlink = message.GetInt(0);

        //Debug.Log("Blink: " + museDataBlink);
    }

    void OnReceiveEEG_jaw(OscMessage message)
    {
        // Get EEG data from message
        museDataJaw = message.GetInt(0);

        //Debug.Log("Jaw: " + museDataJaw);
    }

    void OnReceiveEEG_gamma(OscMessage message)
    {
        // Get EEG data from message
        museDataGamma = (message.GetFloat(0) + message.GetFloat(1) + message.GetFloat(2) + message.GetFloat(3)) / 4f;

        Debug.Log("Gamma: " + museDataGamma);
    }

    public float GetEEGData_blink()
    {
        return museDataBlink;
    }

    public float GetEEGData_jaw()
    {
        return museDataJaw;
    }

    public float GetEEGData_gamma()
    {
        return museDataGamma;
    }


    /*
     OLD STUFF
    void OnReceiveEEG(OscMessage message) {
		// Get EEG data from message
		
		museDataVar = (message.GetFloat(0) + message.GetFloat(1) + message.GetFloat(2) + message.GetFloat(3)) / 4f;
	
        Debug.Log("Gamma: " + museDataVar);
		// Update min and max values if needed
		if (museDataVar < minVal) {
			minVal = museDataVar;
		}
		if (museDataVar > maxVal) {
			maxVal = museDataVar;
		}

		// Set normalized data variable
		normalizedMuseDataVar = Normalize(museDataVar, minVal, maxVal);
	}

    Normalizes input EEG data to spit out a number between 1 and 0 
	float Normalize (float val, float min, float max) {
		return (val - min) / (max - min);
	}

	public float GetEEGData() {
		return museDataVar;
	}

    public float GetNormalizedEEGData()
    {
        return normalizedMuseDataVar;
    }

    */


}