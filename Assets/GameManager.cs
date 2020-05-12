using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> levels;
    private int currentLevel = 0;
    public GameObject loadingScreen;
    public GameObject canvas;
    public Slider slider;
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("health");
        canvas.SetActive(false);
        StartCoroutine(LoadAsync(levels[0]));
        PlayerPrefs.SetInt("ez", 0);

    }
    public void StartEasy()
    {
        PlayerPrefs.SetFloat("health",1000);
        canvas.SetActive(false);
        StartCoroutine(LoadAsync(levels[0]));
        PlayerPrefs.SetInt("ez", 1);
    }

    public void NextLevel()
    {
        PlayerPrefs.Save();
        currentLevel++;

        StartCoroutine(LoadAsync(levels[currentLevel]));
    }

    public void StartMinigame()
    {
        StartCoroutine(LoadAsync("MiniGame"));
    }

    public void EndGame(bool win)
    {
        if (win && PlayerPrefs.GetInt("ez") !=1)
        {
            PlayerPrefs.SetInt("wins", PlayerPrefs.GetInt("wins",0)+1);
        }
        else
        {
            PlayerPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths", 0) + 1);
        }

        StartCoroutine(LoadAsync("MainMenu"));

        currentLevel = 0;

    }
    
    IEnumerator LoadAsync(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }


        loadingScreen.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
