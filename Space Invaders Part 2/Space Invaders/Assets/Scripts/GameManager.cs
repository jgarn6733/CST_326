using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource bgMusicSrc;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
        bgMusicSrc.Play();
    }
    public void StartCredits()
    {
        bgMusicSrc.Stop();
        SceneManager.LoadScene("Credits");
        StartCoroutine(WaitThenMenu());
        
    }

    IEnumerator WaitThenMenu()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        SceneManager.LoadScene("Main Menu");
    }
}
