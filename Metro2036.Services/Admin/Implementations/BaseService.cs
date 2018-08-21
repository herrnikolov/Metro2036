namespace Metro2036.Services.Admin.Implementations
{
    using AutoMapper;
    using Metro2036.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class BaseService
    {
        public Metro2036DbContext DbContext { get; private set; }

        public IMapper Mapper { get; private set; }

        public BaseService(Metro2036DbContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }
    }
}
