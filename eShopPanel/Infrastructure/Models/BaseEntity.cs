using System;

namespace eShopPanel.Infrastructure.Models
{
    public record BaseEntity
    {
        public Guid Id { get; init; }
    }
}
