using System.Collections;   
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class MudaCena : MonoBehaviour
{
    public Image fadeOut;
    float alpha = 0.01f;
    Scene scene;
    Color currentColor;
    bool fading = false;
    float timeInicio;
    bool RemoveFadeOut = false;
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
            if (currentColor.a >= 1)
            {
                ChangeScene();
            }
            else if(currentColor.a == 0 && fading == true)
            {
                fading = false;
                GetComponent<RobertoInteragir>().fadeout = false;
            }
        }
        if(RemoveFadeOut)
        {
            fadeOut.color -= new Color(0, 0, 0, alpha);
            if (fadeOut.color.a <= 0)
                RemoveFadeOut = false;
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

    //Teste *seta pra baixo*
    void OnEnable()
    {
        // Inscreve-se no evento que avisa quando qualquer cena termina de carregar
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Remove a inscrição para evitar vazamento de memória
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fadeOut.color = new Color(0, 0, 0, 1);
        currentColor = fadeOut.color;
        RemoveFadeOut = true;
    }
}
