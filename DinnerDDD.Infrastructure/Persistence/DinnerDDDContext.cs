﻿using DinnerDDD.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DinnerDDD.Infrastructure.Persistence;

public class DinnerDDDContext : DbContext
{
    public DinnerDDDContext(DbContextOptions<DinnerDDDContext> options) : base(options)
    {
    }

    public DbSet<Menu> Menu { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DinnerDDDContext).Assembly);
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}