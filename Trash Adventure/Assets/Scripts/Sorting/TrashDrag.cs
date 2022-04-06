using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDrag : MonoBehaviour
{
    private bool IsDragActive = false;
    private Vector2 ScreenPosition;
    private Vector3 WorldPosition;
    private Draggable LastDragged;

    void Awake()
    {
        TrashDrag[] controllers = FindObjectsOfType<TrashDrag>();
        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(IsDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            ScreenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            ScreenPosition = Input.GetTouch(0).position;
        }
        else 
        {
            return;
        }

        WorldPosition = Camera.main.ScreenToWorldPoint(ScreenPosition);

        if(IsDragActive)
        {
            Drag();
        }
        else 
        {
            RaycastHit2D hit = Physics2D.Raycast(WorldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    LastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        IsDragActive = true;
    }

    void Drag()
    {
        if(LastDragged != null)
        {
            LastDragged.transform.position = new Vector2(WorldPosition.x, WorldPosition.y);
        }
    }

    void Drop()
    {
        IsDragActive = false;
    }
}