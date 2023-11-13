using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject howToMenu;

    public AudioSource sound;



    public void onPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void onOptionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void onOptionsExitButton()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void onMainExitButton()
    {
        Application.Quit();
    }

    public void onHowToExitButton()
    {
        howToMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void onHowToButton()
    {
        mainMenu.SetActive(false);
        howToMenu.SetActive(true);
    }

    public void onButtonClicked()
    {
        sound.Stop();
        sound.Play();
    }
}
