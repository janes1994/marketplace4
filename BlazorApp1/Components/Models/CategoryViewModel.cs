using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Components.Models;

public class CategoryViewModel
{
    public string? Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Icon is required")]
    public string Icon { get; set; } = string.Empty;

    [Required(ErrorMessage = "Banner is required")]
    public string Banner { get; set; } = string.Empty;

    public bool IsSelected = false;

    public string? ParentCategoryId { get; set; }

    public CategoryViewModel? ParentCategory { get; set; }

    public List<CategoryViewModel> Subcategories { get; set; } = [];
}

public class CategorySimple
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public CategoryViewModel categoryViewModel { get; set; } = new();
}