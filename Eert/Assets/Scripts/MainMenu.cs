using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public GameObject menuButtons;
    public GameObject creditPage;
    public AudioSource menuMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (menuButtons) menuButtons.SetActive(true);
        if (creditPage) creditPage.SetActive(false);
        if (menuMusic) menuMusic.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && creditPage.activeSelf)
        {
            HideCredits();
        }

        if (!menuButtons.activeSelf && !creditPage.activeSelf)
        {
            StopMusic();
        }
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        menuButtons.SetActive(false);

    }

    public void ShowCredits()
    {
        creditPage.SetActive(true);
        menuButtons.SetActive(false);

    }

    public void HideCredits()
    {
        creditPage.SetActive(false);
        menuButtons.SetActive(true);
    }

    private void StopMusic()
    {
        menuMusic.Stop();
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
