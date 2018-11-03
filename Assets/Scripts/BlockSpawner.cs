using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawner : MonoBehaviour {

    public GameObject Block;
    public Transform[] SpawnPoints;
    public float timebtwWaves = 1f;
    private float timetoSpawn = 2f;

    [SerializeField]
    public int score =0 ;

    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HIGHSCORE", 0).ToString();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();   //resets Highscore
    }

    // Use this for initialization
    void Update () {
        
        if (Time.time >= timetoSpawn)
        {
            SpawnBlocks();
            timetoSpawn = Time.time + timebtwWaves;
            score++;
            //Debug.Log(score);
            scoreText.text = score.ToString();

            if(score > PlayerPrefs.GetInt("HIGHSCORE",0))
            {
                PlayerPrefs.SetInt("HIGHSCORE", score);
                highScoreText.text = score.ToString();
            }
        }
        
	}
	
	void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, SpawnPoints.Length);

        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            //spawn blocks
            if (randomIndex != i)
            {
                Instantiate(Block, SpawnPoints[i].position, Quaternion.identity);
                
            }
        }
        
        
    }
}
