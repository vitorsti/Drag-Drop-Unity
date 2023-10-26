using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILanguage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainText;

    [SerializeField] string ptText, enText, esText;

    private void Start()
    {
        ptText = HandleText(ptText);
        enText = HandleText(enText);
        esText = HandleText(esText);

        switch (GameManager.instance.getLanguague())
        {
            case "pt":
                mainText.text = ptText;
                break;

            case "en":
                mainText.text = enText;
                break;

            case "es":
                mainText.text = esText;
                break;

            default:
                break;
        }
    }


    private string HandleText(string originalText)
    {
        string newText = originalText.Replace("espaco", "\n"); ;

        return newText;
    }
}
