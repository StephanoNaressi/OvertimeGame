using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public DialogueChoiceObject DialogueAssets;
    public LevelState DialogueState; 
    LevelState previousState;
    public DialogueScript dia;
    public PlayerControllerTileBased playerC;
    public GameObject minnieImg;
    public Sprite[] minniSprites;

    public GameObject timerText;
    bool timeIsRunning = false;
    public float timeRemaining = 15f;

    public GameObject scoreText;
    TextMeshProUGUI scoreHolder;
    public enum LevelState
    {
        baseState,
        CorrectChoice,
        WrongChoice1,
        WrongChoice2,
        WrongChoice3,
        Conclusion,
        Introduction,
        Question
    }
    private void Awake()
    {
        previousState = DialogueState;
        
    }
    private void Start()
    {
        StartCoroutine(startSequence());
        scoreHolder = scoreText.GetComponent<TextMeshProUGUI>();
    }
    IEnumerator startSequence()
    {
        
        StartCoroutine(Introduction());
        yield return new WaitForSeconds(1f);
        StartCoroutine(BaseState());
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Introduction()
    {
        DialogueState = LevelState.Introduction;
        yield return new WaitForSeconds(1f);
    }
    IEnumerator BaseState()
    {
        DialogueState = LevelState.baseState;
        yield return new WaitForSeconds(1f);
    }
    // Update is called once per frame
    void Update()
    {
        scoreHolder.text = Mathf.RoundToInt(ScoreManager.Instance.score).ToString();
        StartTimer();
        if(DialogueState != previousState)
        {
            switch (DialogueState)
            {
                case LevelState.baseState:
                    minnieImg.GetComponent<Image>().sprite = minniSprites[3];
                    timeIsRunning = true;
                    break;
                case LevelState.Introduction:
                    minnieImg.GetComponent<Image>().sprite = minniSprites[1];
                    playerC.canPlay = false;
                    SendDialogue(DialogueAssets.Introduction+" "+DialogueAssets.Question);
                    break;
                case LevelState.WrongChoice1:
                    minnieImg.GetComponent<Image>().sprite = minniSprites[0];
                    playerC.canPlay = false;
                    SendDialogue(DialogueAssets.WrongChoice1);
                    break;
                case LevelState.WrongChoice2:
                    minnieImg.GetComponent<Image>().sprite = minniSprites[2];
                    playerC.canPlay = false;
                    SendDialogue(DialogueAssets.WrongChoice2);
                    break;
                case LevelState.WrongChoice3:
                    minnieImg.GetComponent<Image>().sprite = minniSprites[2];
                    playerC.canPlay = false;
                    SendDialogue(DialogueAssets.WrongChoice3);
                    break;
                case LevelState.Conclusion:
                    minnieImg.GetComponent<Image>().sprite = minniSprites[1];
                    SendDialogue(DialogueAssets.Conclusion);
                    break;
                case LevelState.CorrectChoice:
                    minnieImg.GetComponent<Image>().sprite = minniSprites[1];
                    playerC.canPlay = false;
                    timeIsRunning = false;
                    ScoreManager.Instance.score += timeRemaining;
                    SendDialogue(DialogueAssets.CorrectChoice);
                    break;
                case LevelState.Question:
                    minnieImg.GetComponent<Image>().sprite = minniSprites[4];
                    SendDialogue(DialogueAssets.Question);
                    break;

            }
            previousState = DialogueState;
        }
        
    }
    void StartTimer()
    {
        if (timeIsRunning)
        {
            timerText.SetActive(true);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTimer(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timeIsRunning = false;
                //Move onto the next level?
            }
        }
        else
        {
            timerText.SetActive(false);
        }
    }
    void DisplayTimer(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void SendDialogue(string s)
    {
        dia.IncomingDialogue(s);
    }
}
