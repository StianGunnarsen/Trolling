using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject pebblePrefab;
    public float shootForce = 10f;
    public KeyCode fireKey = KeyCode.Mouse0; // Left-click

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            ShootPebble();
        }
    }

    void ShootPebble()
    {
        Vector2 shootDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        GameObject pebble = Instantiate(pebblePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = pebble.GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
    }
}