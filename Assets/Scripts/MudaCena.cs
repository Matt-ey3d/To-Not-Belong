using System.Collections;   
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    // Update is called once per frame
    /*
    IEnumerator OnCollisionEnter(Collision other)
    {
        float fadeTime = GameObject.Find("Roberto teste libresprite").GetComponent<RobertoInteragir>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(1);
    }
    */
}
