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

    public Animator camAnimator;
    public GameObject winText;
    public GameObject[] otherUiItems;


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
        scoreText.text = ("score: " + score.ToString() + "/80");
    }

    private void Update()
    {
        if (score >= 4)
        {
            camAnimator.SetBool("Won", true);
            winText.SetActive(true);
            foreach (GameObject x in otherUiItems)
            {
                x.SetActive(false);
            }
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
