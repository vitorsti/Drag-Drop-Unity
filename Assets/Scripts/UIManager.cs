using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private DragDrop dd;

    [Header("UI Texts")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI rightsText;
    [SerializeField] private TextMeshProUGUI congratulationsText;
    [SerializeField] private TextMeshProUGUI tryAgainText;
    [SerializeField] private TextMeshProUGUI restartButtonText;
    [SerializeField] private TextMeshProUGUI nextButtonText;
    [SerializeField] private TextMeshProUGUI checkButtonText;
    [SerializeField] private TextMeshProUGUI exitButtonText;
    [SerializeField] private TextMeshProUGUI showButtonText;

    [Header("UI Buttons")]
    [SerializeField] Button checkButton;
    [SerializeField] Button showButton;
    [SerializeField] Button nextLevelButton;
    [SerializeField] Button restartButton;

    //string values
    private string timerString = "Time: ";
    private string lifeString = "Lives: ";
    private string rightsString = "Rights: ";

    private void Awake()
    {
        UpdateLanguageText();
    }

    private void Start()
    {
        dd = GetComponent<DragDrop>();
        
        UpdateLose(false);
        UpdateWin(false);
    }

    private void Update()
    {
        //check Button
        checkButton.interactable = dd.CheckDrop();

        //timer
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(dd.GetTime());
        string formattedTime = string.Format("{0:mm\\:ss}", timeSpan);
        timerText.text = timerString + formattedTime;
    }

    public void UpdateUI(int life, int rights)
    {
        lifeText.text = lifeString + life;
        rightsText.text = rightsString + rights;
    } 

    public void UpdateWin(bool state)
    {
        nextLevelButton.gameObject.SetActive(state);
        congratulationsText.gameObject.SetActive(state);
    }

    public void UpdateLose(bool state)
    {
        restartButton.gameObject.SetActive(state);
        tryAgainText.gameObject.SetActive(state);
        showButton.interactable = state;

    }

    private void UpdateLanguageText()
    {
        switch (GameManager.instance.getLanguague())
        {
            case "pt":
                timerString = "Tempo: ";
                lifeString = "Vidas: ";
                rightsString = "Acertos: ";
                congratulationsText.text = "Parabéns, você acertou todas!";
                tryAgainText.text = "Você terá que tentar novamente...";
                restartButtonText.text = "Reiniciar";
                nextButtonText.text = "Continuar";
                checkButtonText.text = "Verificar";
                exitButtonText.text = "Sair";
                showButtonText.text = "Mostrar";
                break;

            case "en":
                timerString = "Time: ";
                lifeString = "Lives: ";
                rightsString = "Rights: "; 
                congratulationsText.text = "Congratulations!! You got'em all!!";
                tryAgainText.text = "You'll have to try again...";
                restartButtonText.text = "Restart";
                nextButtonText.text = "Continue";
                checkButtonText.text = "Check";
                exitButtonText.text = "Exit";
                showButtonText.text = "Show";
                break;

            case "es":
                timerString = "Tiempo: ";
                lifeString = "Vidas: ";
                rightsString = "Golpes: ";
                congratulationsText.text = "¡Felicitaciones, los entendiste bien!";
                tryAgainText.text = "Tendrás que intentarlo de nuevo...";
                restartButtonText.text = "Reiniciar";
                nextButtonText.text = "Continuar";
                checkButtonText.text = "Verificar";
                exitButtonText.text = "Salir";
                showButtonText.text = "Mostrar";
                break;

            default:
                break;
        }
    }

    public void ShowErrorMessage()
    {
        tryAgainText.gameObject.SetActive(true);
    }
}
