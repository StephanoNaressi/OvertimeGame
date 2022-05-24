using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTileBased : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spr;
    [SerializeField]
    Sprite[] sprImg;
    Vector3 playerOldPos;
    [SerializeField]
    GameObject ColCheck;
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
            ColCheck.transform.position = gameObject.transform.position +  Vector3.up;
            spr.sprite = sprImg[3];
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveTile(Vector3.down);
            ColCheck.transform.position = gameObject.transform.position +  Vector3.down;
            spr.sprite = sprImg[2];
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spr.sprite = sprImg[0];
            ColCheck.transform.position = gameObject.transform.position + Vector3.left;
            moveTile(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spr.sprite = sprImg[1];
            ColCheck.transform.position = gameObject.transform.position + Vector3.right;
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
