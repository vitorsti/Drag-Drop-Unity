using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string language;

    public static GameManager instance;

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void setLanguague(string language)
    {
        this.language = language;
    }

    public string getLanguague()
    {
        return language;
    }
}
