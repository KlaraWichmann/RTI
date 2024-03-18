using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector3 mousePositionOffset;
    bool isDragging = false;
    ImagePositionLogger positionLogger;
    Vector3 initialPosition;
    bool isEnlarged = false;
    Vector3 originalScale;
    SpriteRenderer spriteRenderer;
    float dragStartTime;

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Start()
    {
        isDragging = false;
        positionLogger = GameObject.FindObjectOfType<ImagePositionLogger>();
        initialPosition = transform.position;
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    private void Update()
    {
        if (isDragging)
        {
            spriteRenderer.sortingOrder = 1; // Set the sorting order higher to overlay other images while dragging
        }
        else
        {
            spriteRenderer.sortingOrder = 0; // Restore the original sorting order if not dragging
        }

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ToggleEnlargement();
        }
    }

    private void OnMouseDown()
    {
        mousePositionOffset = transform.position - GetMouseWorldPosition();
        isDragging = true;
        dragStartTime = Time.time; // Record the start time of the drag
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        float dragDuration = Time.time - dragStartTime; // Calculate the drag duration
        if (dragDuration > 0.1f) { //check if user actually dragged image or just clicked it
          LogPosition(transform.position, dragDuration); // Pass drag duration to LogPosition method
        }
    }


    private void LogPosition(Vector3 position, float dragDuration)
    {
        // Log the position of the dropped image using ImagePositionLogger
        if (positionLogger != null)
        {
            positionLogger.LogImagePosition(transform, gameObject.name, dragDuration);
        }
    }

    private void ToggleEnlargement()
    {
        isEnlarged = !isEnlarged;
        if (isEnlarged)
        {
            transform.localScale *= 3f; // Increase scale by 3 times
            transform.position = new Vector3(transform.position.x, transform.position.y, -1f); // Set the Z position to ensure it appears on top
        }
        else
        {
            transform.localScale = originalScale; // Restore original scale
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f); // Restore original Z position
        }
    }
}
