using AutoMapper;
using MyHordesOptimizerApi.Dtos.MyHordes;
using MyHordesOptimizerApi.Dtos.MyHordesOptimizer;
using MyHordesOptimizerApi.Providers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyHordesOptimizerApi.MappingProfiles.Resolvers
{
    public class TownCitizensResolver : IValueResolver<MyHordesMap, TownDto, CitizensWrapperDto>
    {
        protected IUserInfoProvider UserInfoProvider { get; set; }
        protected IMapper Mapper { get; set; }


        public TownCitizensResolver(IUserInfoProvider userInfoProvider, IMapper mapper)
        {
            UserInfoProvider = userInfoProvider;
            Mapper = mapper;
        }

        public CitizensWrapperDto Resolve(MyHordesMap source, TownDto destination, CitizensWrapperDto destMember, ResolutionContext context)
        {
            var dictionary = source.Citizens.ToDictionary(citizen => citizen.Name, citizen => citizen);
            var wrapper = new CitizensWrapperDto(Mapper.Map<Dictionary<string,CitizenDto>>(dictionary));
            wrapper.LastUpdateInfo = UserInfoProvider.GenerateLastUpdateInfo();
            return wrapper;
        }
    }
}
