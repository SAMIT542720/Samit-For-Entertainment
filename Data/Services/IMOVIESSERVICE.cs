using Samit_For_Entertainment.Data.Base;
using Samit_For_Entertainment.Data.ViewModels;
using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Data.Services
{
    public interface IMOVIESSERVICE : IEntityBaseReprository<MOVIE>
    {
        Task<MOVIE> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValuesAsync();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
