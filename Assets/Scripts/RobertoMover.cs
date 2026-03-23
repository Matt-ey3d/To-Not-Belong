using UnityEngine;
using UnityEngine.InputSystem;

public class RobertoMover : MonoBehaviour
{
    public Rigidbody2D Roberto;

    private float forca = 0.1f;

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
}
