using eShopPanel.Infrastructure.Models;
using System;

namespace eShopPanel.Areas.Panel.ProductCategories.Models
{
    public record ProductCategoryLocale(
        Guid CategoryId,
        string Locale,
        string Name
    ) : BaseEntity
    {
        public ProductCategory Category { get; init; }
    }
}
