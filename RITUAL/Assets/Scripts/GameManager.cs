using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TMP_Text scoreText;

    public int score;

    [SerializeField]
    private GameObject[] tiles;
    private bool stillEmptyTiles;


    public GameObject helpScreen;

    public void helpScreenToggle()
    {
        helpScreen.SetActive(!helpScreen.activeSelf);
    }

    private void Start()
    {
        score = 0;
        updateScore(0);

    }

    public void updateScore(int newScore)
    {
        score += newScore;
        scoreText.text = ("score: " + score.ToString() + "/50");
    }

    private void Update()
    {
        if (score >= 50)
        {
            SceneManager.LoadScene(2);
        }

        checkForFailure();
    }

    private void checkForFailure()
    {
        stillEmptyTiles = false;

        foreach (GameObject x in tiles)
        {
            if (x.GetComponent<CellObject>().empty == true)
            {
                stillEmptyTiles = true;
                break;
            }
        }

        if (stillEmptyTiles == false)
        {
            SceneManager.LoadScene(3);
        }
    }

}
