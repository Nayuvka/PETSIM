using UnityEngine;
using System;

public class Poop : MonoBehaviour
{
    public Action OnCleanedUp;

    private bool isDragging = false;
    private bool isOverBin = false;

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        if (isOverBin)
        {
            OnCleanedUp?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bin"))
        {
            isOverBin = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bin"))
        {
            isOverBin = false;
        }
    }
}
