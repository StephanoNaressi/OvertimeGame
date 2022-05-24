using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTileBased : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spr;
    [SerializeField]
    Sprite[] sprImg;
    //Vector3 playerOldPos;
    [SerializeField]
    float rayDist;
    public Vector3 lookingDir;
    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                lookingDir = Vector3.up;
                raycastCheck(Vector3.up);
                spr.sprite = sprImg[3];
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                lookingDir = Vector3.down;
                raycastCheck(Vector3.down);
                spr.sprite = sprImg[2];
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                lookingDir = Vector3.left;
                raycastCheck(Vector3.left);
                spr.sprite = sprImg[0];
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                lookingDir = Vector3.right;
                raycastCheck(Vector3.right);
                spr.sprite = sprImg[1];
            }
    }
    void raycastCheck(Vector3 v)
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position+v, transform.TransformDirection(v), 0.2f);
        //Debug.DrawRay(gameObject.transform.position+v, transform.TransformDirection(-v)*1f, Color.red,1f);
        if(hit.collider != null)
        {
            if (hit.collider.tag == "Collider")
            {
               // print(hit.collider.name);
            }
            else if (hit.collider.tag == "pushableObject")
            {
                switch (lookingDir)
                {
                    //looking up
                    case Vector3 z when z.Equals(Vector3.up):
                        print("ASD");
                        hit.collider.transform.Translate(Vector3.up, Space.World);
                        break;
                    //looking down
                    case Vector3 z when z.Equals(Vector3.down):
                        hit.collider.transform.Translate(Vector3.down, Space.World);
                        break;
                    //looking left
                    case Vector3 z when z.Equals(Vector3.left):
                        hit.collider.transform.Translate(Vector3.left, Space.World);
                        break;
                    //looking right
                    case Vector3 z when z.Equals(Vector3.right):
                        hit.collider.transform.Translate(Vector3.right, Space.World);
                        break;
                
                }
                
            }
        }
        else
        {
            moveTile(v);
        }

    }
    private void moveTile(Vector3 v)
    {
        //playerOldPos = gameObject.transform.position;
        gameObject.transform.Translate(v, Space.World);
    }
}
