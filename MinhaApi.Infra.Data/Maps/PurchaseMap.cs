using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApi.Domain.Entitites;

namespace MinhaApi.Infra.Data.Maps
{
	public class PurchaseMap : IEntityTypeConfiguration<Purchase>
	{
		public void Configure(EntityTypeBuilder<Purchase> builder)
		{
			builder.ToTable("compra");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id)
				.HasColumnName("idcompra")
				.UseIdentityColumn();

			builder.Property(c => c.PersonId)
				.HasColumnName("idpessoa");

			builder.Property(c => c.ProductId)
				.HasColumnName("idproduto");

			builder.Property(c => c.Date)
				.HasColumnName("datacompra");

			builder.HasOne(c => c.Person)
				.WithMany(p => p.Purchases);
				//.HasForeignKey(c => c.PersonId);

			builder.HasOne(c => c.Product)
				.WithMany(p => p.Purchases);
				//.HasForeignKey(c => c.ProductId);
		}
	}
}
