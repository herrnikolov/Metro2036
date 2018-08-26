namespace Metro2036.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Services.Interfaces;
    using Metro2036.Web.Areas.Admin.Models.Train;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TrainService : BaseService, ITrainService
    {
        private Metro2036DbContext _context;

        public TrainService(Metro2036DbContext context)
        {
            _context = context;
        }

        //Get ALL | Index
        IEnumerable<Train> ITrainService.GetAll()
        {
            return _context
                .Trains.OrderBy(t => t.Id)
                .Include(t => t.Route);
        }

        public Train Add(Train route)
        {
            throw new System.NotImplementedException();
        }

        public Train Delete(Train route)
        {
            throw new System.NotImplementedException();
        }

        public Train Get(int id)
        {
            throw new System.NotImplementedException();
        }
        public Train Update(Train route)
        {
            throw new System.NotImplementedException();
        }
    }
}
