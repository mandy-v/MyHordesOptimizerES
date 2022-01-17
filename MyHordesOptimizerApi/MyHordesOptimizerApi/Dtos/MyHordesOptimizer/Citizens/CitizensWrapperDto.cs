using System.Collections.Generic;

namespace MyHordesOptimizerApi.Dtos.MyHordesOptimizer
{
    public class CitizensWrapperDto
    {
        public LastUpdateInfoDto LastUpdateInfo { get; set; }

        public Dictionary<string, CitizenDto> Citizens { get; set; }

        public CitizensWrapperDto(IDictionary<string, CitizenDto> dictionary)
        {
            Citizens = new Dictionary<string, CitizenDto>(dictionary);
        }

        public CitizensWrapperDto()
        {
            Citizens = new Dictionary<string, CitizenDto>();
        }
    }
}
