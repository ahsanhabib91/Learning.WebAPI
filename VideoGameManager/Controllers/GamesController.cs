using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameManagerV6.DataAccess;

namespace VideoGameManagerV6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly VideoGameDataContext context;

        public GamesController(VideoGameDataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Game> GetAllGames()
        {
            return context.Games;
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public Game GetGameById(int id) => context.Games.FirstOrDefault(x => x.Id == id);

        [HttpPost]
        public async Task<Game> AddGame([FromBody]Game game)
        {
            context.Games.Add(game);
            await context.SaveChangesAsync();
            return game;
        }
    }
}
