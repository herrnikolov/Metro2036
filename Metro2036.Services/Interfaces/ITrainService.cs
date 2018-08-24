namespace Metro2036.Services.Interfaces
{
    using Metro2036.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrainService
    {
        Task<IEnumerable<TModel>> GetAll<TModel>() where TModel : class;

        Train Get(int id);

        Train Add(Train route);

        Train Update(Train route);

        Train Delete(Train route);
    }
}
