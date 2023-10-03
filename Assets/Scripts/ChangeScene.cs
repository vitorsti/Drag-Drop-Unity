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

    public void ChangeNameScene(string scene)
    {
        this.scene = scene;
    }
}
