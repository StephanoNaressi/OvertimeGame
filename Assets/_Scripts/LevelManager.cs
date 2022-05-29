using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
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

    public ScriptableScore s;
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
    IEnumerator GoNextScene()
    {
        yield return new WaitForSeconds(4f);
       
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            Destroy(gameObject);
        }
        
    }
    private void FixedUpdate()
    {
        scoreHolder.text = Mathf.RoundToInt(s.SScore).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
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
                    s.SScore += timeRemaining;
                    minnieImg.GetComponent<Image>().sprite = minniSprites[1];
                    playerC.canPlay = false;
                    timeIsRunning = false;
                    
                    SendDialogue(DialogueAssets.CorrectChoice);
                    StartCoroutine(GoNextScene());
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
            if(timerText!= null)
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
                StartCoroutine(GoNextScene());
            }
        }
        else
        {
            if(timerText != null)
            {
                timerText.SetActive(false);
            }
            
        }
    }
    void DisplayTimer(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (timerText != null) {
            timerText.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
    }
    void SendDialogue(string s)
    {
        dia.IncomingDialogue(s);
    }
}
