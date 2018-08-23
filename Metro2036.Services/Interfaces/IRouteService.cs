namespace Metro2036.Services.Interfaces
{
    using Metro2036.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRouteService
    {
        //IEnumerable<Route> GetAll();
        Task<IEnumerable<TModel>> GetAll<TModel>() where TModel : class;

        Route Get(int id);

        Route Add(Route route);

        Route Update(Route route);

        Route Delete(Route route);
    }
}
