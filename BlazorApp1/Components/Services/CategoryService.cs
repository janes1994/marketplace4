using BlazorApp1.Components.Models;

namespace BlazorApp1.Components.Services
{   
    public class CategoryService
    {
        // public List<CategoryViewModel> CategoryViewModel { get; private set; } = new();
        public List<CategoryViewModel> CategoryViewModel = new List<CategoryViewModel>()
        {
            new CategoryViewModel
            {
                Id = "Electronics-1",
                Name = "Electronics",
                Icon = "fas fa-mobile-alt",
                Banner = "https://via.placeholder.com/800x200?text=Electronics",
                ParentCategoryId = null,
                Subcategories = new List<CategoryViewModel>
                {
                    new CategoryViewModel
                    {
                        Id = "Mobile-Phones-2",
                        Name = "Mobile Phones",
                        Icon = "fas fa-mobile-alt",
                        Banner = "https://via.placeholder.com/800x200?text=Mobile+Phones",
                        ParentCategoryId = "Electronics-1",
                        Subcategories = new List<CategoryViewModel>
                        {
                            new CategoryViewModel
                            {
                                Id = "Smartphones-1",
                                Name = "Smartphones",
                                Icon = "fas fa-mobile-alt",
                                Banner = "https://via.placeholder.com/800x200?text=Smartphones",
                                ParentCategoryId = "Mobile-Phones-2",
                                Subcategories = new List<CategoryViewModel>
                                {
                                    new CategoryViewModel
                                    {
                                        Id = "Android-1",
                                        Name = "Android",
                                        Icon = "fab fa-android",
                                        Banner = "https://via.placeholder.com/800x200?text=Android",
                                        ParentCategoryId="Smartphones-1"
                                    },
                                    new CategoryViewModel
                                    {
                                        Id = "iOS-1",
                                        Name = "iOS",
                                        Icon = "fab fa-apple",
                                        Banner = "https://via.placeholder.com/800x200?text=iOS",
                                        ParentCategoryId="Smartphones-1"
                                    }
                                }
                            },
                            new CategoryViewModel
                            {
                                Id = "Feature-Phones-1",
                                Name = "Feature Phones",
                                Icon = "fas fa-mobile-alt",
                                Banner = "https://via.placeholder.com/800x200?text=Feature+Phones",
                                ParentCategoryId="Mobile-Phones-2"
                            }
                        }
                    },
                    new CategoryViewModel
                    {
                        Id = "Tablets-1",
                        Name = "Tablets",
                        Icon = "fas fa-tablet-alt",
                        Banner = "https://via.placeholder.com/800x200?text=Tablets",
                        ParentCategoryId = "Electronics-1"
                    }
                },
            },
            new CategoryViewModel
            {
                Id = "Laptops-1",
                Name = "Laptops",
                Icon = "fas fa-laptop",
                Banner = "https://via.placeholder.com/800x200?text=Laptops",
                ParentCategoryId = null,
                Subcategories = new List<CategoryViewModel>()
                {
                    new CategoryViewModel
                    {
                        Id = "9",
                        Name = "Windows",
                        Icon = "fab fa-windows",
                        Banner = "https://via.placeholder.com/800x200?text=Windows",
                        ParentCategoryId="Laptops-1"
                    },
                    new CategoryViewModel
                    {
                        Id = "10",
                        Name = "Mac",
                        Icon = "fab fa-apple",
                        Banner = "https://via.placeholder.com/800x200?text=Mac",
                        ParentCategoryId="Laptops-1"
                    }
                }
            }
        };

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
            var existing = FindCategory(CategoryViewModel, category?.Id);
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

        public CategoryViewModel? GetCategoryById(string id)
        {
            foreach (var category in CategoryViewModel)
            {
                var found = FindCategory(category, id);
                if (found != null)
                    return found;
            }
            return null;
        }

        private CategoryViewModel? FindCategory(CategoryViewModel category, string id)
        {
            if (category.Id == id)
                return category;

            foreach (var subcategory in category.Subcategories)
            {
                var found = FindCategory(subcategory, id);
                if (found != null)
                    return found;
            }
            return null;
        }

        public List<CategoryViewModel> GetSubcategories(string parentId)
        {
            if (parentId == null)
            {
                // Return root categories (where ParentCategoryId is null)
                return CategoryViewModel.Where(c => c.ParentCategoryId == null).ToList();
            }
            else
            {
                var parentCategory = GetCategoryById(parentId);
                return parentCategory?.Subcategories ?? new List<CategoryViewModel>();
            }
        }

        private void CollectSubcategories(CategoryViewModel category, List<CategoryViewModel> subcategories)
        {
            foreach (var subcategory in category.Subcategories)
            {
                subcategories.Add(subcategory); // Add direct subcategory
                CollectSubcategories(subcategory, subcategories); // Recursively add nested subcategories
            }
        }

    }
}
