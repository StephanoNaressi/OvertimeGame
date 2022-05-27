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
            print("Im where im supposed to be");
            //Here you would send the value of the object that is being inserted to the correct method for the level management
            //Send dialogue
            if (push.isCorrect)
            {
                lvl.DialogueState = LevelManager.LevelState.CorrectChoice;
            }
            else
            {
                
                lvl.DialogueState = LevelManager.LevelState.WrongChoice1;
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
