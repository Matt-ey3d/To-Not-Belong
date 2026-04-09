using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class RobertoInteragir : MonoBehaviour
{
    public Rigidbody2D Roberto;
    public TMP_Text Entrar;
    public GameObject blackScreen;
    public bool fadeout = false;
    bool home = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (home && Keyboard.current.eKey.isPressed)
        {
            Debug.Log("nigga");
            home = false;
            Entrar.gameObject.SetActive(false);
            fadeout = true;
        }
        if (fadeout)
        {
            blackScreen.GetComponent<SpriteRenderer>().material.color += new Color(1.0f, 1.0f, 1.0f, 0.1f);
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Home")
        {
            home = true;
            Entrar.gameObject.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Home")
        {
            home = false;
        }
    }
}
