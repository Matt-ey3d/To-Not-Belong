using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menus : MonoBehaviour
{
    public GameObject helpMenu;
    public GameObject reputationMenu;
    public GameObject inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.hKey.isPressed)
        {
            MenuAjuda();
        }
        if (Keyboard.current.qKey.isPressed)
        {
            MenuReputation();
        }
        if(Keyboard.current.escapeKey.isPressed)
        {
            CloseMenus();
        }
    }
    public void MenuAjuda()
    {
        CloseMenus();
        helpMenu.SetActive(true);
    }
    public void MenuReputation()
    {
        CloseMenus();
        reputationMenu.SetActive(true);
    }
    void CloseMenus()
    {
        helpMenu.SetActive(false);
        reputationMenu.SetActive(false);
        inventory.SetActive(false);
    }
}
