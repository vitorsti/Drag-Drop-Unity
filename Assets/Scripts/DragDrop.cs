using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    [Header("Panels & Objects")]
    [SerializeField] PanelSettings[] AllPanels;
    [SerializeField] ObjectSettings[] AllObjects;
    [SerializeField] string[] PanelAnswers;
    [SerializeField] float delayBetweenOperations = 0.5f;

    //score
    private int rights;

    //timer 
    [Header("Timer Settings")]
    [SerializeField] private float timer;
    [SerializeField] private float timerScale = 1;
    [SerializeField] private bool canReduceTime;
    [SerializeField] private float initialTimerValue;

    //life
    [Header("Life Settings")]
    [SerializeField] private bool infinityLife;
    [SerializeField] private int playerLife;
    [SerializeField] private int playerCurrentLife;


    //otherComponents
    private UIManager uiMan;
    private ChangeScene cs;
    private PlayAudio pa;

    private void Start()
    {
        pa = FindObjectOfType<PlayAudio>();
        uiMan = GetComponent<UIManager>();
        cs = GetComponent<ChangeScene>();
        timer = initialTimerValue;
        playerCurrentLife = playerLife;
        uiMan.UpdateUI(playerCurrentLife, rights);
        canReduceTime = true;
    }

    void Update()
    {
        //timer
        if (canReduceTime)
        {
            timer -= Time.deltaTime * timerScale;
            if (timer <= 0) RestartGame();
        }
        
    }

    public void CheckAnswers()
    {
        
        for(int i = 0; i < PanelAnswers.Length; i++)
        {
            //Debug.Log("Painel " + i + " tem " + AllObjects[int.Parse(DragDropManager.GetPanelObject(i.ToString()))].gameObject.tag + " e a resposta é " + PanelAnswers[i].ToString());
            //Debug.Log("Painel " + i + " tem objeto com id " + DragDropManager.GetPanelObject((i).ToString()) + "e tag: " + AllObjects[int.Parse(DragDropManager.GetPanelObject((i).ToString()))].gameObject.tag + " e a resposta é " + PanelAnswers[i].ToString());

            //pega o objeto no painel
            //pega a tag dele a partir do id 

            if (PanelAnswers[i].ToString() == AllObjects[int.Parse(DragDropManager.GetPanelObject(i.ToString()))].gameObject.tag )
            {
                rights++;
            }
        }


        CheckWin();
    }

    private void PrintDebug()
    {
        
        for (int i = 1; i < AllObjects.Length + 1; i++)
        {
            Debug.Log("Objeto " + AllObjects[i - 1].GetComponent<ObjectSettings>().Id.ToString() + " está no painel " + DragDropManager.GetObjectPanel(AllObjects[i - 1].GetComponent<ObjectSettings>().Id.ToString()) + " e a resposta para este painel é " + PanelAnswers[int.Parse(DragDropManager.GetObjectPanel(AllObjects[i - 1].GetComponent<ObjectSettings>().Id.ToString()))-1]);
        }
        
    }

    public void CheckWin()
    {
        Debug.Log("Acertos : " + rights);
        if(rights >= PanelAnswers.Length)
        {
            pa.PlaySFX(3);
            uiMan.UpdateLose(false);
            uiMan.UpdateWin(true);
            canReduceTime = false;
            uiMan.UpdateUI(playerCurrentLife, rights);
        }

        else
        {
            if(playerCurrentLife > 1)
            {
                uiMan.ShowErrorMessage();
                LoseLife();
            }
            else
            {
                LoseLife();
                RestartGame();
            }
        }

        rights = 0;
    }

    public bool CheckDrop()
    {
        int counter = 0;

        foreach (ObjectSettings obj in AllObjects)
        {
            if (obj.Dropped)
            {
                counter++;
            }
        }

        return counter >= PanelAnswers.Length;
    }

    private void LoseLife()
    {
        pa.PlaySFX(1);
        if (!infinityLife)
        {
            playerCurrentLife--;
            
        }
        uiMan.UpdateUI(playerCurrentLife, rights);
    }

    private void RestartGame()
    {
        canReduceTime = false;
        uiMan.UpdateLose(true);
    }

    public float GetTime()
    {
        return timer;
    }

    public void ShowAnswers()
    {
        StartCoroutine(ShowDelayedAnwers());
    }

    private IEnumerator ShowDelayedAnwers()
    {
        yield return new WaitForSeconds(delayBetweenOperations);
        AIManager.AIDragDrop("1", "panel1");
        yield return new WaitForSeconds(delayBetweenOperations);
        AIManager.AIDragDrop("2", "panel2");
        yield return new WaitForSeconds(delayBetweenOperations);
        AIManager.AIDragDrop("3", "panel3");
        yield return new WaitForSeconds(delayBetweenOperations);
        AIManager.AIDragDrop("4", "panel4");
    }
}
