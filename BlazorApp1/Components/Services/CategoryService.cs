using System;
using static BlazorApp1.Components.Pages.FirstCategory;
using static BlazorApp1.Components.Pages.SecondCategory;
using static BlazorApp1.Components.Pages.ThirdCategory;

namespace BlazorApp1.Components.Services;

public class CategoryService
{
    public List<FirstCategoryView> FirstCategory { get; private set; } =
    [
        new() { Id = "1", Name = "Computer", Icon = "Computer Icon", Banner = "Computer Banner"},   
        new() { Id = "2", Name = "Phone", Icon = "Phone Icon", Banner = "Phone Banner"}
    ];
    public List<SecondCategoryView> SecondCategory { get; private set; } =
    [
        new() { Id = "1", Name = "Desktop", FirstCategory = new FirstCategoryView { Id = "1", Name = "Computer", Banner = "banner", Icon = "icon" }, Icon = "Computer Icon", Banner = "Computer Banner"},
        new() { Id = "2", Name = "Laptop", FirstCategory = new FirstCategoryView { Id = "1", Name = "Computer", Banner = "banner", Icon = "icon" }, Icon = "Phone Icon", Banner = "Phone Banner"}
    ];
    public List<ThirdCategoryView> ThirdCategory { get; private set; } =
    [
        new() 
        { 
            Id = "1", 
            Name = "Lenovo",
            Banner = "Banner",
            Icon = "Icon", 
            FirstCategory = new FirstCategoryView 
            {
                Id = "1", 
                Name = "Computer", 
                Banner = "banner", 
                Icon = "Icon"
            },
            SecondCategory = new SecondCategoryView
            {
                Id = "1",
                Name = "Desktop",
                Banner = "Banner",
                Icon = "Icon",
                FirstCategory = new FirstCategoryView()
                {
                    Id = "1", 
                    Name = "Computer", 
                    Banner = "banner", 
                    Icon = "Icon"
                }
            } 
        }   
    ];

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
