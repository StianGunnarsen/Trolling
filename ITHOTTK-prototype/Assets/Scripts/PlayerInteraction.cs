using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public LockpickController lockpickUI;
    private bool canInteract = false;
    private GameObject currentLock;

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            var lockable = currentLock.GetComponent<LockableObject>();
            if (lockable != null)
            {
                lockpickUI.StartMinigame(lockable);
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lockable"))
        {
            canInteract = true;
            currentLock = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Lockable"))
        {
            canInteract = false;
            currentLock = null;
        }
    }
}
