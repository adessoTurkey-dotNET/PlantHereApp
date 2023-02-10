using MediatR;
using Microsoft.EntityFrameworkCore;
using PlantHere.Domain.Aggregate.BasketAggregate.Entities;
using PlantHere.Domain.Aggregate.CategoryAggregate;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations;
using System.Reflection;

namespace PlantHere.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public AppDbContext(DbContextOptions dbContextOptions, IMediator mediator) : base(dbContextOptions)
        {
            _mediator = mediator;
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Basket> Basket { get; set; }

        public DbSet<BasketItem> BasketItem { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            await _mediator.DispatchDomainEventsAsync(this);
            return await base.SaveChangesAsync(cancellationToken); ;
        }

        public override int SaveChanges()
        {
            var response = base.SaveChanges();
            _mediator.DispatchDomainEvents(this);
            return response;
        }

    }
}
