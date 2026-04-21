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
    public Texture2D fadeOutTexture;
    public float fadeSpeed;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;
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
                Debug.Log("entra dentro da casa Roberto!!!!!!");
                Roberto.GetComponent<MudaCena>().ChangeScene();
                home = false;
                Texto.gameObject.SetActive(false);
                fadeout = true;
            }
            else if (goOutside)
            {
                Debug.Log("sai para fora da casa Roberto!!!!!!");
                Roberto.GetComponent<MudaCena>().ChangeScene();
                goOutside = false;
                Texto.gameObject.SetActive(false);
                fadeout = true;
            }
        }
    }
    /*
    public void OnGUI()
    {
        if (fadeout)
        {
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
        }
    }
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
    void OnLevelWasLoaded()
    {
        alpha = 1;
        BeginFade(-1);
    }
    */
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Home")
        {
            home = true;
            Texto.text = "[E] Entrar";
            Texto.gameObject.SetActive(true);
        }
        else if (collider.name == "Door")
        {
            goOutside = true;
            Texto.text = "[E] Sair";
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
    }
}
