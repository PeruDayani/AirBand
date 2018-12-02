using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject AimCube;
    public MuseDataHandler MuseData;
    public Transform[] GuitarStrings;
    public Material AimCubeSelected;
    public Material AimCubeUnSelected;
    public ScoreManager scoreManager;
    public AudioSource audioSource;

    private int CurrentString;
    private float AimCubeSize = 0;

	// Use this for initialization
	void Start () {
        CurrentString = 0;
        audioSource = this.GetComponent<AudioSource>();
        AimCube.transform.position = GuitarStrings[CurrentString].position;
        InvokeRepeating("OutputTime", 1f, 0.2f);  //1s delay, repeat every 1s
        audioSource.PlayDelayed(4.55f);
    }

    void OutputTime()
    {
        if (MuseData.GetEEGData_blink() == 1 && MuseData.GetEEGData_jaw() == 0)
        {
            CurrentString = (CurrentString + 1) % 4;
            AimCube.transform.position = GuitarStrings[CurrentString].position;
        }
        if (MuseData.GetEEGData_jaw() == 1)
        {
            AimCube.GetComponent<Renderer>().material = AimCubeSelected;
            Debug.Log("Taking a shot");
            scoreManager.Shoot(CurrentString);
            //Debug.Log("Selected");
        }
        if (MuseData.GetEEGData_jaw() == 0)
        {
            AimCube.GetComponent<Renderer>().material = AimCubeUnSelected;
            //Debug.Log("Unselected");
        }

    }

    // Update is called once per frame
    void Update () {
        AimCubeSize = MuseData.GetEEGData_gamma();
        AimCube.transform.localScale = new Vector3(AimCubeSize, AimCubeSize, 0.002f);
    }
}
