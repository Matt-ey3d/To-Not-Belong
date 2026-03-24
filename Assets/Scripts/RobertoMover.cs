using UnityEngine;
using UnityEngine.InputSystem;

public class RobertoMover : MonoBehaviour
{
    public Rigidbody2D Roberto;

    public float forca = 2f;
    public float salto = 10f;
    private bool noChão;
    public BoxCollider2D floor;
    public LayerMask layerfloor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Roberto = GetComponent<Rigidbody2D>();
        noChão = true;
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
        if (Input.GetKeyDown(KeyCode.W) && noChão)
        {
            Roberto.linearVelocity = new Vector2(Roberto.linearVelocityX, salto);
            noChão = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (layerfloor == (1 << collision.gameObject.layer))
        {
            noChão = true;
        }
    }
}
