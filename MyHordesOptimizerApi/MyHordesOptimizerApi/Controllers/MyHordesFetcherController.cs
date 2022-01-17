using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyHordesOptimizerApi.Controllers.Abstract;
using MyHordesOptimizerApi.Dtos.MyHordes.MyHordesOptimizer;
using MyHordesOptimizerApi.Dtos.MyHordesOptimizer;
using MyHordesOptimizerApi.Providers.Interfaces;
using MyHordesOptimizerApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyHordesOptimizerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyHordesFetcherController : AbstractMyHordesOptimizerControllerBase
    {

        private readonly IMyHordesFetcherService _myHordesFetcherService;

        public MyHordesFetcherController(ILogger<MyHordesFetcherController> logger,
            IMyHordesFetcherService myHordesFetcherService,
            IUserInfoProvider userKeyProvider) : base(logger, userKeyProvider)
        {
            _myHordesFetcherService = myHordesFetcherService;
        }

        [HttpGet]
        [Route("Town")]
        public ActionResult<TownDto> GetTown(string userKey)
        {
            if (string.IsNullOrWhiteSpace(userKey))
            {
                return BadRequest($"{nameof(userKey)} cannot be empty");
            }
            UserKeyProvider.UserKey = userKey;
            var town = _myHordesFetcherService.GetTown();
            return town;
        }

        [HttpGet]
        [Route("Items")]
        public ActionResult<IEnumerable<ItemDto>> GetItems(string userKey)
        {
            if (string.IsNullOrWhiteSpace(userKey))
            {
                return BadRequest($"{nameof(userKey)} cannot be empty");
            }
            UserKeyProvider.UserKey = userKey;
            var items = _myHordesFetcherService.GetItems().ToList();
            return items;
        }

        [HttpGet]
        [Route("Me")]
        public ActionResult<SimpleMeDto> GetMe(string userKey)
        {
            if (string.IsNullOrWhiteSpace(userKey))
            {
                return BadRequest($"{nameof(userKey)} cannot be empty");
            }
            UserKeyProvider.UserKey = userKey;
            var me = _myHordesFetcherService.GetSimpleMe();
            return me;
        }

        [HttpGet]
        [Route("HeroSkills")]
        public ActionResult<IEnumerable<HeroSkillDto>> GetHeroSkills()
        {      
            var heroSkills = _myHordesFetcherService.GetHeroSkills().ToList();
            return heroSkills;
        }

        [HttpGet]
        [Route("Recipes")]
        public ActionResult<IEnumerable<ItemRecipeDto>> GetRecipes()
        {
            var heroSkills = _myHordesFetcherService.GetRecipes().ToList();
            return heroSkills;
        }

        [HttpGet]
        [Route("Bank")]
        public ActionResult<BankWrapperDto> GetBank(string userKey)
        {
            if (string.IsNullOrWhiteSpace(userKey))
            {
                return BadRequest($"{nameof(userKey)} cannot be empty");
            }
            UserKeyProvider.UserKey = userKey;
            var bank = _myHordesFetcherService.GetBank();
            return bank;
        }


        [HttpGet]
        [Route("Citizens")]
        public ActionResult<CitizensWrapperDto> GetCitizens(string userKey)
        {
            if (string.IsNullOrWhiteSpace(userKey))
            {
                return BadRequest($"{nameof(userKey)} cannot be empty");
            }
            UserKeyProvider.UserKey = userKey;
            var citizens = _myHordesFetcherService.GetCitizens();
            return citizens;
        }
    }
}
