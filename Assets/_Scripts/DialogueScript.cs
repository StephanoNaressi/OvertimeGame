using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textComponent;
    public List<string> dialogueLines = new List<string>();
    public float textSpeed;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(textComponent.text == dialogueLines[index])
            {
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
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in dialogueLines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if(index < dialogueLines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            gameObject.SetActive(false);
        }
    }
}
