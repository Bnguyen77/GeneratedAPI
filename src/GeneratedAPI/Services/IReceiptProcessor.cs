using GeneratedAPI.Models;

namespace GeneratedAPI.Services
{
	/// <summary>
	/// Processes receipts and manages reward point logic.
	/// </summary>
	public interface IReceiptProcessor
	{
		/// <summary>
		/// Calculates reward points for the given receipt based on business rules.
		/// </summary>
		/// <param name="receipt">The receipt containing items, total, and metadata to evaluate.</param>
		/// <returns>The total number of reward points awarded for the receipt.</returns>
		int CalculateRewardPoint(Receipt receipt);

		/// <summary>
		/// Store id and rewardPoints as kvp into mock storage.
		/// </summary>
		/// <param name="id">associated key id string, generated from defining class </param>
		/// <param name="rewardpoints">associated value rewardPoints int, calculated by CalculateRewardPoint() </param>
		void StoreIdWithRewardPoints(string id, int rewardpoints);

		/// <summary>
		/// Retrieve rewardPoints from the storage by Id
		/// </summary>
		/// <param name="id">key value in storage instant</param>
		/// <returns>
		/// The total number of reward points, or <c>null</c> if the receipt ID does not exist.
		/// </returns>
		int? GetPointsById(string id);
	}
}