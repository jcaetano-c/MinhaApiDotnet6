using System;
using MinhaApi.Domain.Validations;

namespace MinhaApi.Domain.Entitites
{
	public class Purchase
	{
		public int Id { get; private set; }
		public int ProductId { get; private set; }
		public int PersonId { get; private set; }
		public DateTime Date { get; private set; }
		public Person Person { get; set; }
		public Product Product { get; set; }

		public Purchase(int productId, int personId)
		{
			Validation(productId, personId);
			CreatePurchase(productId, personId);
		}
		public Purchase(int id, int productId, int personId)
		{
			DomainValidationException.When(id < 0, "Invalid Purchase ID.");
			Id = id;
			Validation(productId, personId);
			CreatePurchase(productId, personId);
		}
		private void Validation(int productId, int personId)
		{
			DomainValidationException.When(productId < 0, "Invalid productId.");
			DomainValidationException.When(personId < 0, "Invalid personId.");
		}

		private void CreatePurchase(int productId, int personId)
		{
			ProductId = productId;
			PersonId = personId;
			Date = DateTime.Now;
		}

	}
}
