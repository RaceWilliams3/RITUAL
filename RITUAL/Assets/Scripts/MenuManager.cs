using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject howToMenu;
    public AudioMixer mixer;

    public AudioSource sound;

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

    public void SetSfxLevel(float sliderValue)
    {
        mixer.SetFloat("SFX", Mathf.Log10(sliderValue)*40);
    }

    public void SetAmbienceLevel(float sliderValue)
    {
        mixer.SetFloat("Ambience", Mathf.Log10(sliderValue)*40);
    }


    private void Update()
    {
        if (Input.anyKeyDown && howToMenu.activeSelf == true)
        {
            SceneManager.LoadScene(1);
        }
    }
}
