using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class RobertoInteragir : MonoBehaviour
{
    public Rigidbody2D Roberto;
    public TMP_Text Entrar;
    public bool fadeout = false;
    bool home = false;
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
        if (home && Keyboard.current.eKey.isPressed)
        {
            Debug.Log("entra dentro da casa Roberto!!!!!!");
            home = false;
            Entrar.gameObject.SetActive(false);
            fadeout = true;
        }
    }
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
