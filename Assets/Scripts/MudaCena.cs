using System.Collections;   
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MudaCena : MonoBehaviour
{
    //https://stackoverflow.com/questions/31184731/how-to-show-an-image-in-unity-by-code
    public Texture2D fadeOutTexture;
    public GameObject fadeOut;
    float alpha = 0.2f;
    Scene scene;
    Color currentColor;
    bool fading = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        if (GetComponent<RobertoInteragir>().fadeout == true)
        {
            if (fading == false)
            {
                fading = true;
                scene = SceneManager.GetActiveScene();
            }
            if (scene == SceneManager.GetActiveScene())
            {
                fadeOutTexture.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, alpha);
                currentColor = fadeOutTexture.GetComponent<SpriteRenderer>().color;
            }
            else
            {
                fadeOutTexture.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, alpha);
                currentColor = fadeOutTexture.GetComponent<SpriteRenderer>().color;
            }
            if (currentColor.a == 1)
            {
                ChangeScene();
            }
            else if(currentColor.a == 0 && fading == true)
            {
                fading = false;
                GetComponent<RobertoInteragir>().fadeout = false;
            }
        }
    }
    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
