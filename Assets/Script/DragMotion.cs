using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMotion : MonoBehaviour
{
    //Vector3 dragOffset = new Vector3(0, -0.4f, 0);

    private Camera cam;
    private SpriteRenderer spriteRenderer;

    private Vector3 oldPosition;
    //private int oldSortingOrder;

    public bool isDragging = false;

    public void startDrag()
    {
        //     Debug.Log(this.name);

        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        oldPosition = this.transform.position;
        //oldSortingOrder = spriteRenderer.sortingOrder;

        isDragging = true;
        spriteRenderer.sortingOrder += 1;
    }

    public void dragging()
    {
        //     Debug.Log("You are dragging");

        if (!isDragging)
        {
            return;
        }
        //+ dragOffset
        Vector3 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        this.transform.position = newPosition;
    }

    public void finishDrag()
    {
   //     Debug.Log(this.name);

        if (!isDragging)
        {
            return;
        }

        this.transform.position = oldPosition;
        //spriteRenderer.sortingOrder = oldSortingOrder;

        isDragging = false;
        spriteRenderer.sortingOrder -= 1;
    }
}
