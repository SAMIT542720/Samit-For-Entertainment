using Microsoft.EntityFrameworkCore;
using Samit_For_Entertainment.Data.Base;
using Samit_For_Entertainment.Data.ViewModels;
using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Data.Services
{
    public class MOVIESSERVICE : EntityBaseRepository<MOVIE>, IMOVIESSERVICE
    {
        private readonly AppDbContext _context;
        public MOVIESSERVICE(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newmovie = new MOVIE()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CINAMAID = data.CINAMAID,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                PRODUCERID = data.PRODUCERID
            };
            await _context.MOVIES.AddAsync(newmovie);
            await _context.SaveChangesAsync();
            //adding movie actor
            foreach (var actorID in data.ACTORIDS)
            {
                var newActormovie = new ACTOR_MOVIE()
                {
                    MOVIEID = newmovie.ID,
                    ACTORID = actorID
                };
                await _context.ACTORS_MOVIES.AddAsync(newActormovie);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValuesAsync()
        {
            var response = new NewMovieDropdownsVM()
            {
                actors = await _context.ACTORS.OrderBy(n => n.FullName).ToListAsync(),
                cinamas = await _context.CINAMAS.OrderBy(c => c.Name).ToListAsync(),
                producers = await _context.PRODUCERS.OrderBy(c => c.FullName).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbmovie = await _context.MOVIES.FirstOrDefaultAsync(n => n.ID == data.ID);
            if (dbmovie != null)
            {

                dbmovie.Name = data.Name;
                dbmovie.Description = data.Description;
                dbmovie.Price = data.Price;
                dbmovie.ImageURL = data.ImageURL;
                dbmovie.CINAMAID = data.CINAMAID;
                dbmovie.StartDate = data.StartDate;
                dbmovie.EndDate = data.EndDate;
                dbmovie.MovieCategory = data.MovieCategory;
                dbmovie.PRODUCERID = data.PRODUCERID;
                await _context.SaveChangesAsync();
            }
            //removing existing actor
            var existingactorsdb = _context.ACTORS_MOVIES.Where(n => n.MOVIEID == data.ID).ToList();
            _context.ACTORS_MOVIES.RemoveRange(existingactorsdb);
            await _context.SaveChangesAsync();
            //adding movie actor
            foreach (var actorID in data.ACTORIDS)
            {
                var newActormovie = new ACTOR_MOVIE()
                {
                    MOVIEID = data.ID,
                    ACTORID = actorID
                };
                await _context.ACTORS_MOVIES.AddAsync(newActormovie);
                await _context.SaveChangesAsync();
            }
        }

        async Task<MOVIE> IMOVIESSERVICE.GetMovieByIdAsync(int id)
        {
            var moviedetail = _context.MOVIES
               .Include(c => c.CINAMA)
               .Include(p => p.PRODUCER)
               .Include(am => am.ACTORS_MOVIES).ThenInclude(a => a.ACTOR)
               .FirstOrDefaultAsync(n => n.ID == id);
            return await moviedetail;
        }
    }
}
