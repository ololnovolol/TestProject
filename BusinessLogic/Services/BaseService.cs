using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class BaseService
    {
        #region DataMembers

        protected readonly IMapper Mapper;
        protected readonly DbContext DataContext;

        #endregion

        #region Constructors

        public BaseService(DbContext context, IMapper mapper)
        {
            DataContext = context;
            Mapper = mapper;
        }

        #endregion
    }
}
