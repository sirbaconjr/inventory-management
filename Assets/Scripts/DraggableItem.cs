using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] CanvasGroup canvasGroup;

    public static DraggableItem itemBeingDragged;
    
    public Vector3 startPosition;
    public DragSlot startSlot;
    public DragSlot slot;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startSlot = slot;

        if (slot != null)
        {
            slot.item = null;
        }

        itemBeingDragged = this;
        startPosition = transform.position;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        canvasGroup.blocksRaycasts = true;

        if (slot == startSlot)
        {
            transform.position = startPosition;
        }

        startSlot = null;
    }
}
