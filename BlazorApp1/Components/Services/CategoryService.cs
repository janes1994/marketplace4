using BlazorApp1.Components.Models;

namespace BlazorApp1.Components.Services
{   
    public class CategoryService
    {
        public List<CategoryViewModel> CategoryViewModel { get; private set; } = new();
        public event Action? OnAction;

        public void AddCategory(CategoryViewModel category)
        {
            if (string.IsNullOrEmpty(category.ParentCategoryId))
            {
                // Adding a root category
                category.Id = Guid.NewGuid().ToString();
                CategoryViewModel.Add(category);
            }
            else
            {
                // Adding a subcategory
                var parent = FindCategory(CategoryViewModel, category.ParentCategoryId);
                if (parent != null)
                {
                    category.Id = Guid.NewGuid().ToString();
                    category.ParentCategory = parent;
                    parent.Subcategories.Add(category);
                }
            }
            OnAction?.Invoke();
        }

        public void UpdateCategory(CategoryViewModel category)
        {
            var existing = FindCategory(CategoryViewModel, category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
                existing.Icon = category.Icon;
                existing.Banner = category.Banner;
                OnAction?.Invoke();
            }
        }

        public void RemoveCategory(CategoryViewModel category)
        {
            if (category.ParentCategory == null)
            {
                // Removing a root category
                CategoryViewModel.RemoveAll(c => c.Id == category.Id);
            }
            else
            {
                // Removing a subcategory
                category.ParentCategory.Subcategories.RemoveAll(c => c.Id == category.Id);
            }
            OnAction?.Invoke();
        }

        private CategoryViewModel? FindCategory(List<CategoryViewModel> categories, string id)
        {
            foreach (var category in categories)
            {
                if (category.Id == id)
                    return category;

                var found = FindCategory(category.Subcategories, id);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}
