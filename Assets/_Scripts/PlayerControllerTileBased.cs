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
    public bool canMove;
    Vector3 lookingDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canMove = GetComponentInChildren<ChildCollider>().canMove;
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                lookingDir = Vector3.up;
                moveTile(Vector3.up);
                //ColCheck.transform.position = gameObject.transform.position + Vector3.up;
                spr.sprite = sprImg[3];
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                lookingDir = Vector3.down;
                moveTile(Vector3.down);
                //ColCheck.transform.position = gameObject.transform.position + Vector3.down;
                spr.sprite = sprImg[2];
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                lookingDir = Vector3.left;
                spr.sprite = sprImg[0];
                //ColCheck.transform.position = gameObject.transform.position + Vector3.left;
                moveTile(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                lookingDir = Vector3.right;
                spr.sprite = sprImg[1];
               // ColCheck.transform.position = gameObject.transform.position + Vector3.right;
                moveTile(Vector3.right);
            }
        }
        else
        {
            switch (lookingDir)
            {
                //looking up
                case Vector3 v when v.Equals(Vector3.up):
                    moveTile(Vector3.down);
                    GetComponentInChildren<ChildCollider>().canMove = true;
                    break;
                //looking down
                case Vector3 v when v.Equals(Vector3.down):
                    moveTile(Vector3.up);
                    GetComponentInChildren<ChildCollider>().canMove = true;
                    break;
                //looking left
                case Vector3 v when v.Equals(Vector3.left):
                    moveTile(Vector3.right);
                    GetComponentInChildren<ChildCollider>().canMove = true;
                    break;
                //looking right
                case Vector3 v when v.Equals(Vector3.right):
                    moveTile(Vector3.left);
                    GetComponentInChildren<ChildCollider>().canMove = true;
                    break;
            }
        }


    }
    private void moveTile(Vector3 v)
    {
        playerOldPos = gameObject.transform.position;
       
        gameObject.transform.Translate(v , Space.World);
    }
}
