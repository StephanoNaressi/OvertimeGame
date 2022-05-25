using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableScript : MonoBehaviour
{
    [SerializeField]
    DialogueScript dia;
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if(collision.tag == "Interactable")
        {
            print("Im where im supposed to be");
            //Here you would send the value of the object that is being inserted to the correct method for the level management
            dia.gameObject.SetActive(true);
            dia.dialogueLines.Clear();
            dia.insertNewLine("Hey, thats cool");
            dia.startDialogue();
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
            gameObject.transform.Translate(v, Space.World);
        }
           
    }
}
