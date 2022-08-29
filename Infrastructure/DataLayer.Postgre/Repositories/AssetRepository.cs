using DataLayer.Postgre.Common;
using Domain.Asset;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Postgre.Repositories
{
    public class AssetRepository : EfRepository<Asset>, IAssetRepository
    {
        ApplicationContext _dbContext;
        public AssetRepository(ApplicationContext DbContext) : base(DbContext)
        {
            _dbContext = DbContext;
        }

    }
}
