using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTileBased : MonoBehaviour
{
    Vector3 playerOldPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveTile(Vector3.up);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveTile(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveTile(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveTile(Vector3.right);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Collider")
        {
            
            gameObject.transform.position = playerOldPos;
         
        }
    }
    private void moveTile(Vector3 v)
    {
        playerOldPos = gameObject.transform.position;
       
        gameObject.transform.Translate(v , Space.World);
    }
}
