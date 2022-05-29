using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MovableScript : MonoBehaviour
{
    public LevelManager lvl;
    public PushableInstance push;
    [SerializeField]
    DialogueScript dia;
    [SerializeField]
    Sprite[] sprites;
    public bool isMovable;
    
    private void Start()
    {
        setSprite();
        setText();
        isMovable = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if(collision.tag == "Interactable")
        {
            
            //Here you would send the value of the object that is being inserted to the correct method for the level management
            //Send dialogue
            if (push.isCorrect)
            {
                lvl.DialogueState = LevelManager.LevelState.CorrectChoice;
            }
            else
            {
                int f = Random.Range(1, 3);
                switch (f)
                {
                    case 1:
                        lvl.DialogueState = LevelManager.LevelState.WrongChoice1;
                        break;
                    case 2:
                        lvl.DialogueState = LevelManager.LevelState.WrongChoice2;
                        break;
                    case 3:
                        lvl.DialogueState = LevelManager.LevelState.WrongChoice3;
                        break;
                }
            }
        }
    }
    public void MoveTile(Vector3 v)
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position + v, transform.TransformDirection(v), 0.2f);
        if (hit.collider != null)
        {
            print(gameObject.name + " says: There is something in my way");
        }
        else
        {
            if (isMovable)
            {
                
                gameObject.transform.Translate(v, Space.World);
            }
            
        }
           
    }
    void setSprite()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
    void setText()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = push.boxText;
    }
}
