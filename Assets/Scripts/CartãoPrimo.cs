using TMPro;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour
{
    [Header("UI References")]
    public Image portraitImage;
    public TextMeshProUGUI cousinName;
    public TextMeshProUGUI reputation;
    public Image highlightBorder;
    CharacterData _data;
    System.Action<CharacterCard> _onSelected; //tell the menu when I'm clicked
    public void Init(CharacterData data, System.Action<CharacterCard> onSelected)
    {
        _data = data;
        _onSelected = onSelected;
        portraitImage.sprite = data.portrait;
        cousinName.text = data.characterName;
        reputation.text = $"{data.reputationPoints} pts";
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