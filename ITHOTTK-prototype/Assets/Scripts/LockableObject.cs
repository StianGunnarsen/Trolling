using UnityEngine;

public class LockableObject : MonoBehaviour
{
    public LockpickController lockpickController;
    public GameObject doorToDestroy; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (lockpickController != null)
            {
                lockpickController.StartMinigame(this);
            }
        }
    }

    public void OnUnlockSuccess()
    {
        Debug.Log("Door unlocked");

        if (doorToDestroy != null)
        {
            Destroy(doorToDestroy);
        }
        else
        {
            Debug.LogWarning("No door?");
        }
    }

    public void OnUnlockFail()
    {
        Debug.Log("Lockpicking failed.");
    }
}
