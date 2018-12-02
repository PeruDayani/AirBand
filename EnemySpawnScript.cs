using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour {

    public GameObject NotePrefab;
    public Transform[] SpawnPostions;
    public float difficulty;

    private int length;

	// Use this for initialization
	void Start () {
        difficulty = 2.0f;
        length = SpawnPostions.Length;
        //InvokeRepeating("Spawn", 1f, 3.0f);
        StartCoroutine(Test_Song());
    }

    void Spawn()
    {
        //Debug.Log("Spawning");
        int selectString = Random.Range(0, length);
        float radius = Random.Range(0.08f, 0.15f);
        float velocity = 0.5f; // Random.Range(1.0f, difficulty);
        Vector3 SpawnPosition = SpawnPostions[selectString].position;
        GameObject newNote = Instantiate(NotePrefab, SpawnPosition, Quaternion.identity);
        newNote.transform.localScale = new Vector3(radius, radius, radius);
        newNote.GetComponent<Rigidbody>().velocity = new Vector3(-velocity, 0, 0);
    }

    void SpawnSpecific(int clip, int pos)
    {
        int selectString = pos;
        float radius = Random.Range(0.08f, 0.15f);
        float velocity = 0.5f; // Random.Range(1.0f, difficulty);
        Vector3 SpawnPosition = SpawnPostions[selectString].position;
        GameObject newNote = Instantiate(NotePrefab, SpawnPosition, Quaternion.identity);
        newNote.transform.localScale = new Vector3(radius, radius, radius);
        newNote.GetComponent<Rigidbody>().velocity = new Vector3(-velocity, 0, 0);
        newNote.GetComponent<NoteInfo>().note = clip;
    }

    IEnumerator Test_Song()
    {
        SpawnSpecific(3, 0);
        Debug.Log(Time.time);
        yield return new WaitForSeconds(1);
        SpawnSpecific(4,0);
        Debug.Log(Time.time);
        yield return new WaitForSeconds(2.5f);
        SpawnSpecific(4,1);
        Debug.Log(Time.time);
        yield return new WaitForSeconds(0.5f);
        SpawnSpecific(3,1);
        Debug.Log(Time.time);
        yield return new WaitForSeconds(1);
        SpawnSpecific(4,1);
        yield return new WaitForSeconds(2);
        SpawnSpecific(5,2);
        yield return new WaitForSeconds(1);
        SpawnSpecific(6,2);
        yield return new WaitForSeconds(2);
        SpawnSpecific(5,3)  ;
        yield return new WaitForSeconds(2);
        SpawnSpecific(4,3);
        yield return new WaitForSeconds(1.5f);
        SpawnSpecific(4,1);
        yield return new WaitForSeconds(0.5f);
        SpawnSpecific(4,1);
        yield return new WaitForSeconds(1);
        SpawnSpecific(4,2);

        yield return new WaitForSeconds(1);
        SpawnSpecific(3,2);
        Debug.Log(Time.time);
        yield return new WaitForSeconds(1);
        SpawnSpecific(4,2);
        yield return new WaitForSeconds(2.5f);
        SpawnSpecific(4,2);
        yield return new WaitForSeconds(0.5f);
        SpawnSpecific(0,2);
        yield return new WaitForSeconds(6);
        SpawnSpecific(1,3);
        yield return new WaitForSeconds(1 );
        SpawnSpecific(3,0);
        yield return new WaitForSeconds(1 );
        SpawnSpecific(4,1 );
        yield return new WaitForSeconds(4);
        SpawnSpecific(5,3);
        yield return new WaitForSeconds(3);
        SpawnSpecific(0,3);

        yield return new WaitForSeconds(1);
        SpawnSpecific(8,3);
        Debug.Log(Time.time);
        yield return new WaitForSeconds(2);
        SpawnSpecific(7,3);
        yield return new WaitForSeconds(1);
        SpawnSpecific(6,0);
        yield return new WaitForSeconds(0.5f);
        SpawnSpecific(5,0);
        yield return new WaitForSeconds(2.5f);
        SpawnSpecific(6,3);
        yield return new WaitForSeconds(1);
        SpawnSpecific(5,3);
        yield return new WaitForSeconds(1 );
        SpawnSpecific(6,3);
        yield return new WaitForSeconds(2);
        SpawnSpecific(5,1);
        yield return new WaitForSeconds(1);
        SpawnSpecific(4,1);

        yield return new WaitForSeconds(1);
        SpawnSpecific(3,2);
        Debug.Log(Time.time);
        yield return new WaitForSeconds(1);
        SpawnSpecific(4,2);
        yield return new WaitForSeconds(2.5f);
        SpawnSpecific(3,2);
        yield return new WaitForSeconds(0.5f);
        
        

    }



}
