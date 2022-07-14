using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float waitSeconds = 2f;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {

        StartCoroutine(WaitForLoad("GameOver", waitSeconds));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitForLoad(string scene, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(scene);
    }
}
