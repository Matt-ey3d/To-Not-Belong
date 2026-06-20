using TMPro;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class CartãoPrimo : MonoBehaviour
{
    public Image portraitImage;
    public TextMeshProUGUI cousinName;
    public TextMeshProUGUI reputation;
    public Image highlightBorder;
    DadosPrimos _data;
    System.Action<CartãoPrimo> _onSelected; //tell the menu when I'm clicked
    public void Init(DadosPrimos data, System.Action<CartãoPrimo> onSelected)
    {
        _data = data;
        _onSelected = onSelected;
        portraitImage.sprite = data.portrait;
        cousinName.text = data.characterName;
        reputation.text = $"{data.reputationPoints}";
        SetHighlight(false);
    }
    public void SetHighlight(bool active)
    {
        if (highlightBorder != null)
        {
            highlightBorder.enabled = active;
        }
    }
    public void OnClick()
    {
        _onSelected?.Invoke(this);//?. = only call this if it isn't null
    }
}