﻿using RealEstate.Rentals;

namespace MongoMvcDriver2.Models
{
	using System.Collections.Generic;
	using System.Linq;
	using MongoDB.Bson;
	using MongoDB.Bson.Serialization.Attributes;

	public class Rental
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string Description { get; set; }
		public int NumberOfRooms { get; set; }
		public List<string> Address = new List<string>();

		[BsonRepresentation(BsonType.Double)]
		public decimal Price { get; set; }

		public List<PriceAdjustment> Adjustments = new List<PriceAdjustment>(); 

		public Rental()
		{
		}

		public Rental(PostRental postRental)
		{
			Description = postRental.Description;
			NumberOfRooms = postRental.NumberOfRooms;
			Price = postRental.Price;
			Address = (postRental.Address ?? string.Empty).Split('\n').ToList();
		}

		public void AdjustPrice(AdjustPrice adjustPrice)
		{
			var adjustment = new PriceAdjustment(adjustPrice, Price);
			Adjustments.Add(adjustment);
			Price = adjustPrice.NewPrice;
		}
	}
}