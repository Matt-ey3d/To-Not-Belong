using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using NUnit.Framework;

public class RobertoInteragir : MonoBehaviour
{
    public Rigidbody2D Roberto;
    public TMP_Text Texto;
    public bool fadeout = false;
    bool home = false;
    bool goOutside = false;
    bool cousin = false;
    public string primo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.isPressed)
        {
            if (home)
            {
                Debug.Log("entra em casa Roberto!!!!!!");
                home = false;
                Texto.gameObject.SetActive(false);
                fadeout = true;
            }
            else if (goOutside)
            {
                Debug.Log("sai de casa Roberto!!!!!!");
                goOutside = false;
                Texto.gameObject.SetActive(false);
                fadeout = true;
            }
            else if (cousin)
            {
                Debug.Log("fala com os teus primos Roberto!!!!!!!!!!!!!");
                Roberto.GetComponent<Falas>().Diálogo();
                cousin = false;
                Texto.gameObject.SetActive(false);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Home")
        {
            home = true;
            Texto.gameObject.SetActive(true);
        }
        else if (collider.name == "Door")
        {
            goOutside = true;
            Texto.gameObject.SetActive(true);
        }
        else if (collider.tag == "Cousin")
        {
            primo = collider.name;
            cousin = true;
            Texto.gameObject.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Home")
        {
            home = false;
            Texto.gameObject.SetActive(false);
        }
        else if (collider.name == "Door")
        {
            goOutside = false;
            Texto.gameObject.SetActive(false);
        }
        else if (collider.tag == "Cousin")
        {
            cousin = false;
            Texto.gameObject.SetActive(false);
        }
    }
}
