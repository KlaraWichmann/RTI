/*using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector3 mousePositionOffset;
    bool isDragging = false;
    ImagePositionLogger positionLogger;
    Vector3 initialPosition;
    bool isEnlarged = false;
    Vector3 originalScale;
    SpriteRenderer spriteRenderer;

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
            // No need to log position during dragging
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
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        LogPosition(transform.position);
    }

    private void LogPosition(Vector3 position)
    {
        // Log the position of the dropped image using ImagePositionLogger
        if (positionLogger != null)
        {
            positionLogger.LogImagePosition(transform, gameObject.name);
        }
    }

    private void ToggleEnlargement()
    {
        isEnlarged = !isEnlarged;
        if (isEnlarged)
        {
            transform.localScale *= 3f; // Increase scale by 3 times
            spriteRenderer.sortingOrder = 1; // Set the sorting order higher to overlay other images
        }
        else
        {
            transform.localScale = originalScale; // Restore original scale
            spriteRenderer.sortingOrder = 0; // Restore the original sorting order
        }
    }
}*/


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
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        LogPosition(transform.position);
    }

    private void LogPosition(Vector3 position)
    {
        // Log the position of the dropped image using ImagePositionLogger
        if (positionLogger != null)
        {
            positionLogger.LogImagePosition(transform, gameObject.name);
        }
    }

    private void ToggleEnlargement()
    {
        isEnlarged = !isEnlarged;
        if (isEnlarged)
        {
            transform.localScale *= 3f; // Increase scale by 3 times
            spriteRenderer.sortingOrder = 1; // Set the sorting order higher to overlay other images
        }
        else
        {
            transform.localScale = originalScale; // Restore original scale
            spriteRenderer.sortingOrder = 0; // Restore the original sorting order
        }
    }
}
