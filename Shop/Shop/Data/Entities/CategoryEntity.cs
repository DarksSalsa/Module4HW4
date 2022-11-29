﻿namespace Shop.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public bool Active { get; set; }
        public virtual List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
