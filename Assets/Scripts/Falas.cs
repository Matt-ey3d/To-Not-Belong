using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Falas : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text falatexto;
    public string[] dialogueRui;
    private int index = 0;
    public float Speed;
    public TMP_Text Enter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (falatexto.text == dialogueRui[index])
        {
            Enter.gameObject.SetActive(true);
        }
        if (Keyboard.current.enterKey.isPressed)
        {
            PróximaLinha();
        }
    }
    public void Diálogo()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            SemTexto();
        }
        else
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }
    public void SemTexto()
    {
        falatexto.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach (char letter in dialogueRui[index].ToCharArray())
        {
            falatexto.text += letter;
            yield return new WaitForSeconds(Speed);
        }
    }
    public void PróximaLinha()
    {
        Enter.gameObject.SetActive(false);
        if (index < dialogueRui.Length - 1)
        {
            index++;
            falatexto.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            SemTexto();
        }
    }
}
