using AutoMapper;
using MyHordesOptimizerApi.Dtos.MyHordes;
using MyHordesOptimizerApi.Dtos.MyHordes.MyHordesOptimizer;
using MyHordesOptimizerApi.Dtos.MyHordesOptimizer;
using MyHordesOptimizerApi.Providers.Interfaces;
using MyHordesOptimizerApi.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyHordesOptimizerApi.MappingProfiles.Resolvers
{
    public class TownBankResolver : IValueResolver<MyHordesMap, TownDto, BankWrapperDto>
    {
        protected IMyHordesOptimizerDatabaseRepository FirebaseRepository { get; set; }
        protected IUserInfoProvider UserInfoProvider { get; set; }
        protected IMapper Mapper { get; set; }

        public TownBankResolver(IMyHordesOptimizerDatabaseRepository firebaseRepository,
            IUserInfoProvider userInfoProvider,
            IMapper mapper)
        {
            FirebaseRepository = firebaseRepository;
            UserInfoProvider = userInfoProvider;
            Mapper = Mapper;
        }

        public BankWrapperDto Resolve(MyHordesMap source, TownDto destination, BankWrapperDto destMember, ResolutionContext context)
        {
            var wrapper = new BankWrapperDto();
            var items = Mapper.Map<List<ItemDto>>(FirebaseRepository.GetItems());
            foreach (var bankItem in source.City.Bank)
            {
                var item = items.First(x => x.XmlId == bankItem.Id);
                var destinationBankItem = new BankItemDto()
                {
                    Item = item,
                    Count = bankItem.Count
                };
                wrapper.Bank[item.XmlId.ToString()] = destinationBankItem;
            }
            wrapper.LastUpdateInfo = UserInfoProvider.GenerateLastUpdateInfo();
            return wrapper;
        }
    }
}
