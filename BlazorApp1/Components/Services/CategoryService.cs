using BlazorApp1.Components.Models;

namespace BlazorApp1.Components.Services
{   
    public class CategoryService
    {
        // public List<CategoryViewModel> CategoryViewModel { get; private set; } = new();
        // public List<CategoryViewModel> CategoryViewModel = new List<CategoryViewModel>()
        // {
        //     new CategoryViewModel
        //     {
        //         Id = "Electronics-1",
        //         Name = "Electronics",
        //         Icon = "fas fa-mobile-alt",
        //         Banner = "https://via.placeholder.com/800x200?text=Electronics",
        //         ParentCategoryId = null,
        //         Subcategories = new List<CategoryViewModel>
        //         {
        //             new CategoryViewModel
        //             {
        //                 Id = "Mobile-Phones-2",
        //                 Name = "Mobile Phones",
        //                 Icon = "fas fa-mobile-alt",
        //                 Banner = "https://via.placeholder.com/800x200?text=Mobile+Phones",
        //                 ParentCategoryId = "Electronics-1",
        //                 Subcategories = new List<CategoryViewModel>
        //                 {
        //                     new CategoryViewModel
        //                     {
        //                         Id = "Smartphones-1",
        //                         Name = "Smartphones",
        //                         Icon = "fas fa-mobile-alt",
        //                         Banner = "https://via.placeholder.com/800x200?text=Smartphones",
        //                         ParentCategoryId = "Mobile-Phones-2",
        //                         Subcategories = new List<CategoryViewModel>
        //                         {
        //                             new CategoryViewModel
        //                             {
        //                                 Id = "Android-1",
        //                                 Name = "Android",
        //                                 Icon = "fab fa-android",
        //                                 Banner = "https://via.placeholder.com/800x200?text=Android",
        //                                 ParentCategoryId="Smartphones-1"
        //                             },
        //                             new CategoryViewModel
        //                             {
        //                                 Id = "iOS-1",
        //                                 Name = "iOS",
        //                                 Icon = "fab fa-apple",
        //                                 Banner = "https://via.placeholder.com/800x200?text=iOS",
        //                                 ParentCategoryId="Smartphones-1"
        //                             }
        //                         }
        //                     },
        //                     new CategoryViewModel
        //                     {
        //                         Id = "Feature-Phones-1",
        //                         Name = "Feature Phones",
        //                         Icon = "fas fa-mobile-alt",
        //                         Banner = "https://via.placeholder.com/800x200?text=Feature+Phones",
        //                         ParentCategoryId="Mobile-Phones-2"
        //                     }
        //                 }
        //             },
        //             new CategoryViewModel
        //             {
        //                 Id = "Tablets-1",
        //                 Name = "Tablets",
        //                 Icon = "fas fa-tablet-alt",
        //                 Banner = "https://via.placeholder.com/800x200?text=Tablets",
        //                 ParentCategoryId = "Electronics-1"
        //             }
        //         },
        //     },
        //     new CategoryViewModel
        //     {
        //         Id = "Laptops-1",
        //         Name = "Laptops",
        //         Icon = "fas fa-laptop",
        //         Banner = "https://via.placeholder.com/800x200?text=Laptops",
        //         ParentCategoryId = null,
        //         Subcategories = new List<CategoryViewModel>()
        //         {
        //             new CategoryViewModel
        //             {
        //                 Id = "9",
        //                 Name = "Windows",
        //                 Icon = "fab fa-windows",
        //                 Banner = "https://via.placeholder.com/800x200?text=Windows",
        //                 ParentCategoryId="Laptops-1"
        //             },
        //             new CategoryViewModel
        //             {
        //                 Id = "10",
        //                 Name = "Mac",
        //                 Icon = "fab fa-apple",
        //                 Banner = "https://via.placeholder.com/800x200?text=Mac",
        //                 ParentCategoryId="Laptops-1"
        //             }
        //         }
        //     }
        // };

        public List<CategoryViewModel> CategoryViewModel = new List<CategoryViewModel>
        {
            new CategoryViewModel
            {
                Id = "Electronics-1",
                Name = "Electronics",
                Icon = "fas fa-mobile-alt",
                Banner = "https://via.placeholder.com/800x200?text=Electronics",
                ParentCategoryId = null
            },
            new CategoryViewModel
            {
                Id = "Mobile-Phones-2",
                Name = "Mobile Phones",
                Icon = "fas fa-mobile-alt",
                Banner = "https://via.placeholder.com/800x200?text=Mobile+Phones",
                ParentCategoryId = "Electronics-1"
            },
            new CategoryViewModel
            {
                Id = "Smartphones-1",
                Name = "Smartphones",
                Icon = "fas fa-mobile-alt",
                Banner = "https://via.placeholder.com/800x200?text=Smartphones",
                ParentCategoryId = "Mobile-Phones-2"
            },
            new CategoryViewModel
            {
                Id = "Android-1",
                Name = "Android",
                Icon = "fab fa-android",
                Banner = "https://via.placeholder.com/800x200?text=Android",
                ParentCategoryId = "Smartphones-1"
            },
            new CategoryViewModel
            {
                Id = "iOS-1",
                Name = "iOS",
                Icon = "fab fa-apple",
                Banner = "https://via.placeholder.com/800x200?text=iOS",
                ParentCategoryId = "Smartphones-1"
            },
            new CategoryViewModel
            {
                Id = "Feature-Phones-1",
                Name = "Feature Phones",
                Icon = "fas fa-mobile-alt",
                Banner = "https://via.placeholder.com/800x200?text=Feature+Phones",
                ParentCategoryId = "Mobile-Phones-2"
            },
            new CategoryViewModel
            {
                Id = "Tablets-1",
                Name = "Tablets",
                Icon = "fas fa-tablet-alt",
                Banner = "https://via.placeholder.com/800x200?text=Tablets",
                ParentCategoryId = "Electronics-1"
            },
            new CategoryViewModel
            {
                Id = "Laptops-1",
                Name = "Laptops",
                Icon = "fas fa-laptop",
                Banner = "https://via.placeholder.com/800x200?text=Laptops",
                ParentCategoryId = null
            },
            new CategoryViewModel
            {
                Id = "9",
                Name = "Windows",
                Icon = "fab fa-windows",
                Banner = "https://via.placeholder.com/800x200?text=Windows",
                ParentCategoryId = "Laptops-1"
            },
            new CategoryViewModel
            {
                Id = "10",
                Name = "Mac",
                Icon = "fab fa-apple",
                Banner = "https://via.placeholder.com/800x200?text=Mac",
                ParentCategoryId = "Laptops-1"
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

                    CategoryViewModel.Add(category);
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

        public List<CategoryViewModel> BuildCategoryTree(List<CategoryViewModel> flatList)
        {
            // Mapping Id ke Category untuk akses cepat
            var lookup = flatList.ToDictionary(c => c.Id, c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Icon = c.Icon,
                Banner = c.Banner,
                ParentCategoryId = c.ParentCategoryId,
                Subcategories = new List<CategoryViewModel>()
            });

            List<CategoryViewModel> roots = new();

            foreach (var category in lookup.Values)
            {
                if (string.IsNullOrEmpty(category.ParentCategoryId))
                {
                    // Root category
                    roots.Add(category);
                }
                else if (lookup.TryGetValue(category.ParentCategoryId, out var parent))
                {
                    parent.Subcategories.Add(category);
                }
            }

            return roots;
        }


        public List<CategoryViewModel> BuildNestedParentsWithSiblings(CategoryViewModel selectedCategory, List<CategoryViewModel> allCategories)
        {
            var parents = GetAllParents(selectedCategory, allCategories);
            var categoryTrees = BuildCategoryTree(allCategories);

            foreach (var root in categoryTrees)
            {
                MarkSelectedPath(root, parents);
            }

            return categoryTrees;
        }

        private void MarkSelectedPath(CategoryViewModel currentNode, List<CategoryViewModel> selectedPath)
        {
            var match = selectedPath.FirstOrDefault(c => c.Id == currentNode.Id);
            if (match != null)
            {
                currentNode.IsSelected = true;
            }

            foreach (var sub in currentNode.Subcategories)
            {
                MarkSelectedPath(sub, selectedPath);
            }
        }


        public List<CategoryViewModel> GetAllParents(CategoryViewModel category, List<CategoryViewModel> allCategories)
        {
            var parents = new List<CategoryViewModel>();
            var current = category;

            while (!string.IsNullOrEmpty(current.ParentCategoryId))
            {
                var parent = allCategories.FirstOrDefault(c => c.Id == current.ParentCategoryId);
                if (parent == null) break;

                parents.Add(parent);
                current = parent;
            }

            parents.Reverse(); // supaya dari root ke bawah
            parents.Add(category); // terakhir adalah kategori yang dipilih
            return parents;
        }

        public void AddCategoryRow(CategoryViewModel category, string parentPath, List<CategorySimple> rows)
        {
            string fullPath = string.IsNullOrEmpty(parentPath) ? category.Name : $"{parentPath}/{category.Name}";

            var temp = new CategorySimple
            {
                Id = category.Id,
                Name = fullPath,
                categoryViewModel = category
            };

            rows.Add(temp);

            foreach (var subcategory in category.Subcategories)
            {
                AddCategoryRow(subcategory, fullPath, rows);
            }
        }

        public string GetCategoryFullPath(string id)
        {
            CategoryViewModel? categoryVM = GetCategoryById(id);
            List<CategorySimple> categorySimples = new();
            List<CategoryViewModel> categoryModel = BuildCategoryTree(CategoryViewModel);
            foreach (var category in categoryModel)
            {
                AddCategoryRow(category, "", categorySimples);
            }

            CategorySimple? result = categorySimples.Where(i => i.Id == categoryVM.Id).FirstOrDefault();
            string result2 = result.Name;
            return result2;
        }
    }
}
