using UnityEngine;
using UnityEngine.InputSystem;

public class RobertoMover : MonoBehaviour
{
    public Rigidbody2D Roberto;

    private float forca = 5f;
    private bool voar = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            Roberto.AddForce(Vector2.left * forca);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            Roberto.AddForce(Vector2.right * forca);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("SALTA ROBERTO O CHÃO É LAVA");
        if (collision.collider.CompareTag("Floor") && Keyboard.current.wKey.isPressed)
        {
            Debug.Log("PULINHO");
            Roberto.AddForce(Vector2.up * forca);
        }
    }
}
