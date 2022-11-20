using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragUnits : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Vector2 endValue;
    private Vector2 starttValue;
    private Vector2 diffValue;

    public LineRenderer lr;

    private bool dragging;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragging = true;
        lr.enabled = true;
        lr.positionCount = 2;
        lr.SetPosition(0, starttValue);
        lr.useWorldSpace = true;
        lr.SetPosition(1, eventData.position);

        Debug.Log("dragging");
        Debug.Log(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        starttValue = eventData.position;
        Debug.Log(starttValue);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        endValue = eventData.position;
        lr.enabled = false;
    }

    
}
