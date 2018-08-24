namespace Metro2036.Services.Interfaces
{
    using Metro2036.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPointService
    {
        Task<IEnumerable<TModel>> GetAll<TModel>() where TModel : class;

        Point Get(int id);

        Point Add(Point route);

        Point Update(Point route);

        Point Delete(Point route);
    }
}
