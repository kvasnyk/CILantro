using System.Collections.Generic;

namespace CILantroTestManager.ViewModels.Categories
{
    public class CategoriesIndexViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}