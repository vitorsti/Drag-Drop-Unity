using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILanguage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainText;

    [SerializeField] string ptText, enText, esText;

    [SerializeField] private TextMeshProUGUI TitleText;

    [SerializeField] string ptTitleText, enTitleText, esTitleText;

    [SerializeField] private TextMeshProUGUI StartText;
                        
    [SerializeField] string ptStartText, enStartText, esStartText;

    private void Start()
    {
        ptText = HandleText(ptText);
        enText = HandleText(enText);
        esText = HandleText(esText);

        switch (GameManager.instance.getLanguague())
        {
            case "pt":
                mainText.text = ptText;
                TitleText.text = ptTitleText;
                StartText.text = ptStartText;
                break;
           case "en":
                mainText.text = enText;
                TitleText.text = enTitleText;
                StartText.text = enStartText;
                break;

            case "es":
                mainText.text = esText;
                TitleText.text = esTitleText;
                StartText.text = esStartText;
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
