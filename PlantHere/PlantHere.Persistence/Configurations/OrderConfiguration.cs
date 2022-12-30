using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantHere.Domain.Aggregate.OrderAggregate.Entities;

namespace PlantHere.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "ordering");
            builder.Navigation(e => e.OrderItems).UsePropertyAccessMode(PropertyAccessMode.Field).HasField("_orderItems");
            builder.OwnsOne(o => o.Address).WithOwner();
        }
    }
}
