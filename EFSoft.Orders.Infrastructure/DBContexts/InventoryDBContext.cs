﻿namespace EFSoft.Orders.Infrastructure.DBContexts;

    public class InventoryDBContext : DbContext
{
    public InventoryDBContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProductInventory> Inventories { get; set; }
}
