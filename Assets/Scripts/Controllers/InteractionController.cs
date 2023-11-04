using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
    void Interact();
    void StopInteract();
}

public class Door : MonoBehaviour, IInteractable
{
    [Tooltip("Door open state")]
    private bool isOpen = false;

    [Tooltip("Speed of door opening/closing")]
    public float speed = 2.0f;

    public void Interact()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            StartCoroutine(OpenDoor());
        }
        else
        {
            StartCoroutine(CloseDoor());
        }
    }

    public void StopInteract()
    {
        // Stop the door from opening/closing
        StopAllCoroutines();
    }

    private IEnumerator OpenDoor()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 90, 0);

        for (float t = 0; t < 1; t += Time.deltaTime * speed)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
    }

    private IEnumerator CloseDoor()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 0, 0);

        for (float t = 0; t < 1; t += Time.deltaTime * speed)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}

public class Container : MonoBehaviour, IInteractable
{
    // Similar to Door class, implement Interact(), StopInteract(), and IsOpen() methods here
    // You can also implement OpenContainer() and CloseContainer() coroutines similar to OpenDoor() and CloseDoor()
}

public class InteractionController : MonoBehaviour
{
    [Tooltip("Event triggered when interaction occurs")]
    private UnityEvent onInteract = new UnityEvent();

    public void AddOnInteractListener(UnityAction action)
    {
        onInteract.AddListener(action);
    }

    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact();
            onInteract.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.StopInteract();
        }
    }
}
