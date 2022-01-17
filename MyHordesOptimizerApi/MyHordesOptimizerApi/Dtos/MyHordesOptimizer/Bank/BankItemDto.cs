using MyHordesOptimizerApi.Attributes.Firebase;
using MyHordesOptimizerApi.Dtos.MyHordes.MyHordesOptimizer;

namespace MyHordesOptimizerApi.Dtos.MyHordesOptimizer
{
    public class BankItemDto
    {
        public ItemDto Item { get; set; }
        public int Count { get; set; }
        [FirebaseSerializeIgnore]
        public int WishListCount { get; set; }
    }
}
