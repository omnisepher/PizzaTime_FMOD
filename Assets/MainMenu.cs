using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject infoTab;
    public GameObject menuTab;
    public GameObject mainCanvas;
    public GameObject endLevelCanvas;

    private void Awake()
    {
        menuTab.SetActive(false);
        mainCanvas.SetActive(true);
        endLevelCanvas.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.levelClear || GameManager.levelLose)
        {
            menuTab.SetActive(false);
            mainCanvas.SetActive(false);
            endLevelCanvas.SetActive(true);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Info()
    {
        infoTab.active = !infoTab.active;

    }
    public void Exit()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
            Application.Quit();
#elif (UNITY_WEBGL)
            Application.OpenURL("https://www.omnisepher.com");
#endif
    }

    public void OpenMenu()
    {
        menuTab.active = !menuTab.active;
        mainCanvas.active = !mainCanvas.active;
        Time.timeScale = menuTab.active ? 0f : 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
