using System.Collections.Generic;

namespace MyHordesOptimizerApi.Dtos.MyHordesOptimizer
{
    public class BankWrapperDto
    {
        public Dictionary<string, BankItemDto> Bank { get; set; }
        public LastUpdateInfoDto LastUpdateInfo { get; set; }

        public BankWrapperDto()
        {
            Bank = new Dictionary<string, BankItemDto>();
        }
    }
}
