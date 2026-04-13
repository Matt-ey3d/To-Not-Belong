using UnityEngine;
using System.Collections;   

public class Fadeout : MonoBehaviour
{
    public static Texture2D Fade;
    public bool fadingOut = false;
    public float alphaFadeValue = 1;
    public float fadeSpeed = 2;
    public Texture2D blackscreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnGUI()
    {
        alphaFadeValue -= Mathf.Clamp01(Time.deltaTime / 5);
        GUI.color = new Color(0, 0, 0, alphaFadeValue);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackscreen);
    }
}
