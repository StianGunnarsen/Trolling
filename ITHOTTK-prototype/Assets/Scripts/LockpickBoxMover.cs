using UnityEngine;

public class LockpicBoxMover : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;

    private float speed;
    public float topY = 3f;
    public float bottomY = -3f;
    private bool goingUp = true;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (goingUp)
            pos.y += speed * Time.deltaTime;
        else
            pos.y -= speed * Time.deltaTime;

        if (pos.y >= topY) goingUp = false;
        if (pos.y <= bottomY) goingUp = true;

        transform.position = pos;
    }
}
