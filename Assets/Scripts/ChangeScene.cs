using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string scene;

    public void GoToScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("ChooseLanguageOs");
    }

    public void ChangeNameScene(string scene)
    {
        this.scene = scene;
    }

    public void GoToSceneByLanguage(string sceneName)
    {
        string languageSelected = GameManager.instance.getLanguague();

        string newScene = sceneName + " " + languageSelected;

        SceneManager.LoadScene(newScene);
    }

    public void GoToSceneByname(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
