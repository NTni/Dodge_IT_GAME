using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public float slowness = 10f;

	public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        
        Time.timeScale = 1f/slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime/slowness;

        //FindObjectOfType<Player>();//for destroy block 

       
        Debug.Log("The_End");

        yield return new WaitForSeconds(1f/slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime*slowness;

        //wait for 1 sec to restart

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
