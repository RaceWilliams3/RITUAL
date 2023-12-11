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
    public GameObject loseText;
    public GameObject[] otherUiItems;

    private float timeOfEnd;
    private float returnToScreenDelay = 1f;


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
        if (score >= 80 && timeOfEnd == 0)
        {
            camAnimator.SetBool("Won", true);
            winText.SetActive(true);
            timeOfEnd = Time.time;
            foreach (GameObject x in otherUiItems)
            {
                x.SetActive(false);
            }
        }

        checkForFailure();

        if (winText.activeSelf == true || loseText.activeSelf == true)
        {
            if (Input.anyKey && Time.time - timeOfEnd > returnToScreenDelay)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
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

        if (stillEmptyTiles == false && timeOfEnd == 0)
        {
            camAnimator.SetBool("Won", true);
            loseText.SetActive(true);
            timeOfEnd = Time.time;
            foreach (GameObject x in otherUiItems)
            {
                x.SetActive(false);
            }
        }
    }

}
