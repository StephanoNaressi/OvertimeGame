using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public DialogueChoiceObject DialogueAssets;
    public LevelState DialogueState; 
    LevelState previousState;
    public DialogueScript dia;
    public PlayerControllerTileBased playerC;

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
        for (int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                //
            }
           else if (i == 1)
            {
                //
            }  
        }
        StartCoroutine(startSequence());
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
        if(DialogueState != previousState)
        {
            switch (DialogueState)
            {
                case LevelState.baseState:
                    
                    break;
                case LevelState.Introduction:
                
                    playerC.canPlay = false;
                    SendDialogue(DialogueAssets.Introduction+" "+DialogueAssets.Question);
                    break;
                case LevelState.WrongChoice1:
                    
                    playerC.canPlay = false;
                    SendDialogue(DialogueAssets.WrongChoice1);
                    break;
                case LevelState.WrongChoice2:
                   
                    playerC.canPlay = false;
                    SendDialogue(DialogueAssets.WrongChoice2);
                    break;
                case LevelState.WrongChoice3:
               
                    playerC.canPlay = false;
                    SendDialogue(DialogueAssets.WrongChoice3);
                    break;
                case LevelState.Conclusion:
                    SendDialogue(DialogueAssets.Conclusion);
                    break;
                case LevelState.CorrectChoice:
               
                    playerC.canPlay = false;
                    SendDialogue(DialogueAssets.CorrectChoice);
                    break;
                case LevelState.Question:
                    SendDialogue(DialogueAssets.Question);
                    break;

            }
            previousState = DialogueState;
        }
        
    }
    void SendDialogue(string s)
    {
        dia.IncomingDialogue(s);
    }
}
