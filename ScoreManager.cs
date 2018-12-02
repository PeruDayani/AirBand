using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public GameObject[] hitPositions;
    public AudioClip[] NoteAudioClips;
    public GameObject Player;
    public TextMesh ScoreText;
    public TextMesh HitText;
    public float score;

    private AudioSource audioManager;

	// Use this for initialization
	void Start () {
        score = 0.0f;
        audioManager = this.GetComponent<AudioSource>();
        audioManager.loop = false;
	}
    public void Shoot(int position)
    {
        GameObject current_hit_trigger = hitPositions[position];
        Hit_position_triggers collision_info = hitPositions[position].GetComponent<Hit_position_triggers>();
        if (collision_info.collision_occuring())
        {
            Debug.Log("Good Trigger");
            int iteration_score = 0;
            GameObject col = collision_info.collision_gameobject();
            float distance = Vector3.Distance(col.transform.position, current_hit_trigger.transform.position);
            int calc_score_dist = Calculate_Score_Distance(distance);
            //Debug.Log("Dist Score: " + calc_score_dist);
            iteration_score += calc_score_dist;

            float scale_diff = Mathf.Abs(Player.transform.localScale.x - col.transform.localScale.x - 0.05f) ;
            int calc_score_scale = Calculate_Score_Scale(scale_diff);
            //Debug.Log("Scale Score: " + calc_score_scale);
            iteration_score += calc_score_scale;

            int clip_to_play = col.GetComponent<NoteInfo>().note;
            audioManager.PlayOneShot(NoteAudioClips[clip_to_play]);
            Destroy(col);
            UpdateScore(iteration_score);
        }
        else
        {
            Debug.Log("Faulty trigger");
            UpdateScore(0);

        }

    }

    public void UpdateScore(float iteration_score)
    {
        score += iteration_score;
        ScoreText.text = ("Score: " + score.ToString());


        if (iteration_score == 0)
        {
            HitText.text = " :( ";
        }
        if(iteration_score == 2 || iteration_score == 3)
        {
            HitText.text = "Good job!";
        }
        if (iteration_score == 4 || iteration_score == 5)
        {
            HitText.text = "Awesome!";
        }
        if (iteration_score == 6)
        {
            HitText.text = "PERFECT!";
        }
    }

    public int Calculate_Score_Scale(float diff)
    {
        int score = 0;

        if (diff < 0.02)
        {
            score = 3;
        }
        else if (diff < 0.06)
        {
            score = 2;
        }
        else
        {
            score = 1;
        }

        return score;
    }

    public int Calculate_Score_Distance(float distance)
    {
        int score = 0;

        if(distance < 0.04)
        {
            score = 3;
        }else if(distance < 0.08)
        {
            score = 2;
        }
        else
        {
            score = 1;
        }

        return score;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("q"))
        {
            Shoot(0);
        }
        if (Input.GetKeyDown("w"))
        {
            Shoot(1);
        }
        if (Input.GetKeyDown("e"))
        {
            Shoot(2);
        }
        if (Input.GetKeyDown("r"))
        {
            Shoot(3);
        }
    }
}
