using System.Collections;   
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;

public class MudaCena : MonoBehaviour
{
    public Image fadeOut;
    float alpha = 0.1f;
    Scene scene;
    Color currentColor;
    bool fading = false;
    float timeInicio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        //GetComponent<SpriteRenderer>(). se der merda
        if (GetComponent<RobertoInteragir>().fadeout == true)
        {
            if (fading == false)
            {
                fading = true;
                timeInicio = Time.time;
                scene = SceneManager.GetActiveScene();
            }
            if (scene == SceneManager.GetActiveScene())
            {
                fadeOut.color += new Color(0, 0, 0, alpha);
                currentColor = fadeOut.color;
            }
            else
            {
                fadeOut.color -= new Color(0, 0, 0, alpha);
                currentColor = fadeOut.color;
            }
            if (currentColor.a == 1 && Time.time > timeInicio + 500000)
            {
                Debug.Log(timeInicio);
                Debug.Log(Time.time);
                /*while (Time.time < timeInicio + 500000f)
                { }*/
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
