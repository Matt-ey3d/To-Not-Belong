using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class RobertoInteragir : MonoBehaviour
{
    public Rigidbody2D Roberto;
    public TMP_Text Entrar;
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
            Debug.Log("entra dentro da casa Roberto!!!!!!");
            home = false;
            Entrar.gameObject.SetActive(false);
            fadeout = true;
        }
        if (fadeout)
        {
            FindAnyObjectByType<Fadeout>().OnGUI();
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
            Entrar.gameObject.SetActive(false);
        }
    }
}
