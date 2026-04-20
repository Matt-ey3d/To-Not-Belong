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
        SceneManager.LoadScene(1);
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
