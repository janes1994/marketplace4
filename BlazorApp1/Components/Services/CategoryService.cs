using System;
using static BlazorApp1.Components.Pages.FirstCategory;
using static BlazorApp1.Components.Pages.SecondCategory;
using static BlazorApp1.Components.Pages.ThirdCategory;

namespace BlazorApp1.Components.Services;

public class CategoryService
{
    public List<FirstCategoryView> FirstCategory { get; private set; } = [];
    public List<SecondCategoryView> SecondCategory { get; private set; } = [];
    public List<ThirdCategoryView> ThirdCategory { get; private set; } = [];

    public event Action? OnFirstCategoryChanged;
    public event Action? OnSecondCategoryChanged;
    public event Action? OnThirdCategoryChanged;

    public void SetCategory(List<FirstCategoryView> firstcategory)
    {
        FirstCategory = firstcategory;
        OnFirstCategoryChanged?.Invoke();
    }

    public void SetSecondCategory(List<SecondCategoryView> secondcategory)
    {
        SecondCategory = secondcategory;
        OnSecondCategoryChanged?.Invoke();
    }

    public void SetThirdCategory(List<ThirdCategoryView> thirdcategory)
    {
        ThirdCategory = thirdcategory;
        OnThirdCategoryChanged?.Invoke();
    }
}
