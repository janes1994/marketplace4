using System;
using static BlazorApp1.Components.Pages.Product;

namespace BlazorApp1.Components.Services;

public class ProductService
{
    public List<ProductView> ProductViews { get; set; } = [];
    public event Action? ProductViewsAction;
    public void SetProduct(List<ProductView> param)
    {
        ProductViews = param;
        ProductViewsAction?.Invoke();
    }
}
