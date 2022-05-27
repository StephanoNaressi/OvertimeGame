using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueScript : MonoBehaviour
{
    public PlayerControllerTileBased playerC;
    public LevelManager lvl;
    [SerializeField]
    TextMeshProUGUI textComponent;
    public List<string> dialogueLines = new List<string>();
    public float textSpeed;
    public GameObject pressZ;
    public int index;
    // Start is called before the first frame update
    void Awake()
    {
        dialogueLines.Clear();
        textComponent.text = string.Empty;
    }

    public void IncomingDialogue(string s)
    {
        pressZ.SetActive(true);
        gameObject.SetActive(true);
        insertNewLine(s);
        startDialogue();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (textComponent.text == dialogueLines[index])
            {
                playerC.canPlay = true;
                NextLine();

            }
            else
            {

                StopAllCoroutines();
                textComponent.text = dialogueLines[index];
            }
        }
        
    }
    public void insertNewLine(string s)
    {
        dialogueLines.Add(s);
    }
    public void startDialogue()
    {
        //dialogueLines.Clear();
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        if(dialogueLines.Count > 0)
        {
            foreach (char c in dialogueLines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
                print("I RUN");
            }
        }

    }

    void NextLine()
    {

        if (index < dialogueLines.Count - 1)
        {
            dialogueLines.Clear();
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueLines.Clear();
            textComponent.text = string.Empty;
            gameObject.SetActive(false);
            pressZ.SetActive(false);
        }
    }
}
