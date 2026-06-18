using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class Falas : MonoBehaviour
{
    public TMP_Text falatexto;
    public TMP_Text whoDis;
    public GameObject speechBubble;
    public string[] dialogueRui;
    public string[] dialogueRoberson;
    public string[] currentDialogue;
    int index = 0;
    public float Speed;
    public bool canClickEnter = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.enterKey.isPressed && canClickEnter)
        {
            PróximaLinha();
            canClickEnter = false;
        }
    }
    public void Diálogo()
    {
        whoDis.text = GetComponent<RobertoInteragir>().primo;
        switch (whoDis.text)
        {
            case "Rui":
                currentDialogue = dialogueRui;
                break;
            case "Roberson":
                currentDialogue = dialogueRoberson;
                break;
        }
        speechBubble.SetActive(true);
        StartCoroutine(Typing());
    }
    public void NoText()
    {
        falatexto.text = "";
        whoDis.text = "";
        index = 0;
        speechBubble.SetActive(false);
    }
    IEnumerator Typing()
    {
        char[] fala = currentDialogue[index].ToCharArray();
        foreach (char letter in fala)
        {
            falatexto.text += letter;
            yield return new WaitForSeconds(Speed);
        }
        canClickEnter = true;
    }
    void AddReputation()
    {
        GetComponent<Reputação>().ChangeReputation();
    }
    public void PróximaLinha()
    {
        if (index < currentDialogue.Length - 1)
        {
            index++;
            falatexto.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            AddReputation();
            NoText();
        }
    }
}
