using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;

public class Reputação : MonoBehaviour
{
    public DadosPrimos[] characters;
    public CartãoPrimo cardPrefab;
    public Transform gridParent;
    public int columns = 4;
    public int rows = 2;    
    public Image detailPortrait;
    public TMPro.TextMeshProUGUI detailName;
    public TMPro.TextMeshProUGUI detailRep;
    public TextMeshProUGUI pageLabel;
    public Button prevPageButton;
    public Button nextPageButton;
    List<CartãoPrimo> _cards = new();
    int _selectedIndex = 0;
    int _currentPage = 0;
    int _cardsPerPage;
    int _totalPages;

    void Start()
    {
        _cardsPerPage = columns * rows;
        _totalPages = (characters.Length + _cardsPerPage - 1) / _cardsPerPage;
        if (prevPageButton) prevPageButton.onClick.AddListener(GoToPrevPage);
        if (nextPageButton) nextPageButton.onClick.AddListener(GoToNextPage);
        LoadPage(_currentPage);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) TryMove(-1, 0);
        if (Input.GetKeyDown(KeyCode.D)) TryMove(1, 0);
        if (Input.GetKeyDown(KeyCode.W)) TryMove(0, -1);
        if (Input.GetKeyDown(KeyCode.S)) TryMove(0, 1);
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ConfirmSelection();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) GoToPrevPage();
        if (Input.GetKeyDown(KeyCode.RightArrow)) GoToNextPage();
    }
    void LoadPage(int page)
    {
        foreach (var card in _cards)
            Destroy(card.gameObject);
        _cards.Clear();
        int startIndex = page * _cardsPerPage;
        int endIndex = Mathf.Min(startIndex + _cardsPerPage, characters.Length);
        for (int i = startIndex; i < endIndex; i++)
        {
            var card = Instantiate(cardPrefab, gridParent);
            card.Init(characters[i], OnCardClicked);
            _cards.Add(card);
        }
        _selectedIndex = 0;
        Select(_selectedIndex);
        UpdatePageLabel();
        UpdatePageButtons();
    }
    void GoToPrevPage()
    {
        if (_currentPage <= 0) return;
        _currentPage--;
        LoadPage(_currentPage);
    }
    void GoToNextPage()
    {
        if (_currentPage >= _totalPages - 1) return;
        _currentPage++;
        LoadPage(_currentPage);
    }
    void UpdatePageLabel()
    {
        if (pageLabel)
            pageLabel.text = $"Page {_currentPage + 1} / {_totalPages}";
    }
    void UpdatePageButtons()
    {
        if (prevPageButton) prevPageButton.interactable = _currentPage > 0;
        if (nextPageButton) nextPageButton.interactable = _currentPage < _totalPages - 1;
    }
    void TryMove(int dx, int dy)
    {
        int col = _selectedIndex % columns;
        int row = _selectedIndex / columns;
        int newCol = col + dx;
        int newRow = row + dy;
        if (newCol < 0 || newCol >= columns) return;
        int newIndex = newRow * columns + newCol;
        if (newIndex < 0 || newIndex >= _cards.Count) return;
        Select(newIndex);
    }
    public void ChangeReputation()
    {
        string characterName = GetComponent<RobertoInteragir>().primo;
        characterName.reputationPoints += 20;
        Select(_selectedIndex);
        return;
    }
    void Select(int index)
    {
        _cards[_selectedIndex].SetHighlight(false);
        _selectedIndex = index;
        _cards[_selectedIndex].SetHighlight(true);
        int globalIndex = (_currentPage * _cardsPerPage) + index;
        if (globalIndex >= characters.Length) return;
        var data = characters[globalIndex];
        if (detailPortrait) detailPortrait.sprite = data.portrait;
        if (detailName) detailName.text = data.characterName;
        if (detailRep) detailRep.text = $"Reputation: {data.reputationPoints}";
    }
    void OnCardClicked(CartãoPrimo card)
    {
        int index = _cards.IndexOf(card);
        Select(index);
        ConfirmSelection();
    }
    void ConfirmSelection()
    {
        int globalIndex = _currentPage * _cardsPerPage + _selectedIndex;
        Debug.Log($"Selected: {characters[_selectedIndex].characterName}");
    }
}