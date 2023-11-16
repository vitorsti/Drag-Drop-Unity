using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILanguage2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] orientationText;

    [SerializeField] string[] ptText, enText, esText;


    private void Start()
    {


        HandleTextArray(ptText);
        HandleTextArray(enText);
        HandleTextArray(esText);

        string languageSelected = GameManager.instance.getLanguague();
        for(int i = 0; i < orientationText.Length; i++)
        {
            switch (GameManager.instance.getLanguague())
            {
                case "pt":
                    orientationText[i].text = ptText[i];
                    break;
                case "en":
                    orientationText[i].text = enText[i];
                    break;

                case "es":
                    orientationText[i].text = esText[i];
                    break;

                default:
                    break;
            }
        }
        
    }


    private void HandleTextArray(string[] array_)
    {
        for (int i = 0; i < array_.Length; i++)
        {
            array_[i] = HandleText(array_[i]);
        }
    }

    private string HandleText(string originalText)
    {
        string newText = originalText.Replace("espaco", "\n"); ;

        return newText;
    }
}
