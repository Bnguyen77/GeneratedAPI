using GeneratedAPI.Helpers;
using GeneratedAPI.Models;
using System.Collections.Concurrent;

namespace GeneratedAPI.Services
{
	/// <inheritdoc />
	public class ReceiptProcessor : IReceiptProcessor
	{
		private readonly ConcurrentDictionary<string, int> _storage = new ConcurrentDictionary<string, int>();
		private readonly PointCalculator _calculator = new();

		/// <inheritdoc />
		public int CalculateRewardPoint(Receipt receipt)
		{
			int rewardPoints = 0;
			rewardPoints += _calculator.RetailerAlphanumaricPoint(receipt.Retailer);
			rewardPoints += _calculator.TotalRoundDollarPoint(receipt.Total);
			rewardPoints += _calculator.TotalMultipleQuarterPoint(receipt.Total);
			rewardPoints += _calculator.ItemPairsPoint(receipt.Items.Count);
			rewardPoints += _calculator.ItemDescPoint(receipt.Items);
			rewardPoints += _calculator.OddPurchaseDatePoint(receipt.PurchaseDate);
			rewardPoints += _calculator.AfternoonPurchaseTimePoint(receipt.PurchaseTime);
			return rewardPoints;
		}

		/// <inheritdoc />
		public void StoreIdWithRewardPoints(string id, int rewardPoints)
		{
			_storage[id] = rewardPoints;
		}

		/// <inheritdoc />
		public int? GetPointsById(string id)
		{
			if (_storage.TryGetValue(id, out int points))
			{
				return points;
			}
			return null; // or throw NotFoundException if you prefer
		}


	}
}
