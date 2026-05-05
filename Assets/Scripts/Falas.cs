using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Falas : MonoBehaviour
{
    public TMP_Text falatexto;
    public string[] dialogueRui;
    public string[] dialogueRoberson;
    //public string[,] dialogue; maybe??
    public string[] currentDialogue;
    private int index = 0;
    public float Speed;
    public TMP_Text Enter;
    public bool canClickEnter = true;
    int contar = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (falatexto.text == currentDialogue[index])
        {
            Enter.gameObject.SetActive(true);
        }
        if (Keyboard.current.enterKey.isPressed && canClickEnter)
        {
            PróximaLinha();
            canClickEnter = false;
        }
    }
    public void Diálogo()
    {
        switch(GetComponent<RobertoInteragir>().primo)
        {
            case "Rui":
                currentDialogue = dialogueRui;
                break;
            case "Roberson":
                currentDialogue = dialogueRoberson;
                break;
        }
        StartCoroutine(Typing());
    }
    public void SemTexto()
    {
        falatexto.text = "";
        index = 0;
    }
    IEnumerator Typing()
    {
        contar++;
        char[] fala = currentDialogue[index].ToCharArray();
        Debug.Log(contar);
        foreach (char letter in fala)
        {
            falatexto.text += letter;
            yield return new WaitForSeconds(Speed);
        }
        canClickEnter = true;
    }
    public void PróximaLinha()
    {
        Enter.gameObject.SetActive(false);
        if (index < currentDialogue.Length - 1)
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
