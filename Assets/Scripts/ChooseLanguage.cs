using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLanguage : MonoBehaviour
{
    public void Language(string language)
    {
        GameManager.instance.setLanguague(language);
    }
}
