using System.Collections.Generic;

namespace CILantroTestManager.ViewModels.Tags
{
    public class TagsIndexViewModel
    {
        public IEnumerable<TagViewModel> Tags { get; set; } = new List<TagViewModel>();
    }
}