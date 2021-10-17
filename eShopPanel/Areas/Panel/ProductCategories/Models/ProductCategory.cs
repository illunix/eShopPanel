using eShopPanel.Infrastructure.Models;
using System.Collections.Generic;

namespace eShopPanel.Areas.Panel.ProductCategories.Models
{
    public record ProductCategory(
        string Name
    ) : BaseEntity
    {
        public IList<ProductCategoryLocale> Locales { get; init; }
    } 
}
