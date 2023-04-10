using Localisation.Models;
using Data.Ingredients;
using UnityEngine.UI;
using Localisation;
using UnityEngine;
using System;

public class SandwichIngredientBehaviour : MonoBehaviour
{
    public event Action<int> IngredientSelected;
    
    [SerializeField] private Button _selectButton;
    [SerializeField] private Text _description;
    [SerializeField] private Image _image;

    private SandwichIngredient _sandwichIngredient;
    private int _index;

    private void Awake()
    {
        _selectButton.onClick.AddListener(OnSelectButtonClicked);
        OnLanguageSelected(LocalisationModel.CurrentLanguage);
        LocalisationModel.LanguageSelected += OnLanguageSelected;
    }

    private void OnLanguageSelected(Language language)
    {
        var description = language switch
        {
            Language.Ukrainian => _sandwichIngredient?.Name._ukrainianName ?? string.Empty,
            Language.English => _sandwichIngredient?.Name._englishName ?? string.Empty,
            _ => string.Empty
        };
        _description.text = description;
    }

    private void OnSelectButtonClicked() => IngredientSelected?.Invoke(_index);

    public void SetSandwichIngredient(int index, SandwichIngredient sandwichIngredient)
    {
        _image.sprite = sandwichIngredient.IngredientSprite;
        _sandwichIngredient = sandwichIngredient;
        _index = index;

        OnLanguageSelected(LocalisationModel.CurrentLanguage);
    }
    
    private void OnDestroy()
    {
        _selectButton.onClick.RemoveListener(OnSelectButtonClicked);
    }
}
