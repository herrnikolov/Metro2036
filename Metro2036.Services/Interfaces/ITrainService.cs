namespace Metro2036.Services.Interfaces
{
    using Metro2036.Models;
    using Metro2036.Web.Areas.Admin.Models.Train;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrainService
    {
        IEnumerable<Train> GetAll();

        Train Get(int id);

        Train Add(Train route);

        Train Update(Train route);

        Train Delete(Train route);
    }
}
