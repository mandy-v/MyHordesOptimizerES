using MyHordesOptimizerApi.Dtos.MyHordes;

namespace MyHordesOptimizerApi.Dtos.MyHordesOptimizer
{
    public class TownDto
    {
        public int Id { get; set; }

        public MyHordesMap MyHordesMap { get; set; }

        public CitizensWrapperDto Citizens { get; set; }

        public BankWrapperDto Bank { get; set; }

        public WishListWrapperDto WishList { get; set; }
    }
}
