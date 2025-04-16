using UnityEngine;
using TMPro;

public class PetController : MonoBehaviour
{
    public Animator petAnimator;
    private Vector3 destination;
    public float speed;

    public TextMeshProUGUI nameTag;           // The UI text component
    public RectTransform nameTagRect;         // The RectTransform of the UI text
    public Canvas canvas;                     // The canvas the nameTag is on

    private string petName = "My Pet";

    private void Update()
    {
        // Move the pet
        if (Vector3.Distance(transform.position, destination) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }

        UpdateNameTagPosition();
    }

    private void UpdateNameTagPosition()
    {
        if (nameTag == null || nameTagRect == null || canvas == null) return;

        // Convert world position above the pet to screen point
        Vector3 worldPosition = transform.position + Vector3.up * 2f;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);

        // Convert screen point to UI canvas local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPoint,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out Vector2 localPoint
        );

        nameTagRect.anchoredPosition = localPoint;
    }

    public void Move(Vector3 destination)
    {
        destination.y = transform.position.y;
        destination.z = transform.position.z;
        this.destination = destination;
    }

    public void SetPetName(string newName)
    {
        petName = newName;
        if (nameTag != null)
        {
            nameTag.text = petName;
        }
    }

    public void Happy() => petAnimator.SetTrigger("Happy");
    public void Sad() => petAnimator.SetTrigger("Sad");
    public void Hungry() => petAnimator.SetTrigger("Hungry");
    public void Eat() => petAnimator.SetTrigger("Eat");
}
