using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;

    GameObject[] pauseMode;
    GameObject[] resumeMode;

    int score = 0;
    int level = 1;
    int sThreshold = 3;

    // Start is called before the first frame update
    void Start()
    {
        pauseMode = GameObject.FindGameObjectsWithTag("Pause");
        resumeMode = GameObject.FindGameObjectsWithTag("Resume");


        foreach (GameObject g in pauseMode)
            g.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (score >= sThreshold)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    public void LoadScene(string scenename)
    {
        {
            SceneManager.LoadScene(scenename);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        foreach (GameObject g in resumeMode)
            g.SetActive(false);

        foreach (GameObject g in pauseMode)
            g.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;

        
        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in resumeMode)
            g.SetActive(true);

    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int value)
    {
        scoreText.text = score.ToString("Score: " + score);
        score += value;

    }

}
