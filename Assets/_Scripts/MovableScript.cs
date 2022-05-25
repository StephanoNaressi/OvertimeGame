using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableScript : MonoBehaviour
{
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
