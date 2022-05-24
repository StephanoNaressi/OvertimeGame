using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour
{
    public bool canMove;
    private void Start()
    {
        canMove = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pushableObject")
        {
            collision.transform.Translate(Vector3.up, Space.World);
            canMove = false;
        }
        else if (collision.tag == "Collider")
        {
           
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }
}
