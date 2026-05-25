using UnityEngine;
using UnityEngine.EventSystems;

public class BotãoAjuda : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool botaoPressionado;
    public Rigidbody2D Roberto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        botaoPressionado = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        botaoPressionado = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (botaoPressionado)
        {
            Roberto.GetComponent<Menus>().MenuAjuda();
        }
    }

}
