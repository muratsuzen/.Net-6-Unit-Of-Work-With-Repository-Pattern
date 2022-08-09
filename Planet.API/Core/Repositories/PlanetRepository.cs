using Planet.API.Core.IRepositories;
using Planet.API.Data;

namespace Planet.API.Core.Repositories
{
    public class PlanetRepository : GenericRepository<Models.Planet>,IPlanetRepository
    {
        public PlanetRepository(DefaultContext context) : base(context)
        {
        }
    }
}
