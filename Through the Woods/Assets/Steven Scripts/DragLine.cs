using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Camera camera;
    public LineRenderer lr;
    bool dragging;
    GameObject character;
    bool colliderBlock;
    float characterRadius = 1f;

    Vector3 camOffset = new Vector3(0, 0, 10);

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        
        if (Input.GetMouseButtonDown(0))
        {
            

            if(hit.collider != null && hit.transform.tag == "Character")
            {
                lr.enabled = true;
                lr.positionCount = 2;
                startPos = hit.transform.GetComponent<Renderer>().bounds.center;
                lr.SetPosition(0, startPos);
                character = hit.transform.gameObject;
                lr.useWorldSpace = true;
                dragging = true;
            }
            
            
        }

        

        if (dragging)
        {
            if (Input.GetMouseButton(0))
            {
                

                if(colliderBlock)
                {
                    //show red
                }

                

                endPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;


                lr.SetPosition(1, endPos);
            }

            if (Physics2D.CircleCast(endPos, characterRadius, Vector2.zero, 0))
            {
                colliderBlock = true;
            }
            else
            {
                colliderBlock = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                lr.enabled = false;
                dragging = false;

                if (!colliderBlock)
                {
                    character.transform.position = endPos;
                }
                Debug.Log(Vector2.Distance(startPos, endPos));
            }
        }

        
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(endPos, 1f);
    //}
}
