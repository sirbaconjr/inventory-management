using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSlot : MonoBehaviour, IDropHandler
{
    public DraggableItem item;

    public void OnDrop(PointerEventData eventData)
    {
        if (item == null)
        {
            eventData.pointerDrag.GetComponent<Transform>().position = transform.position;
            item = DraggableItem.itemBeingDragged;
            item.transform.SetParent(transform);
            item.slot = this;
        }
    }
}
