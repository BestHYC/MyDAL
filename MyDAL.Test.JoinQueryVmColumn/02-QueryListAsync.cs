﻿using MyDAL.Test.Entities.EasyDal_Exchange;
using MyDAL.Test.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MyDAL.Test.JoinQueryVmColumn
{
    public class _02_QueryListAsync:TestBase
    {
        [Fact]
        public async Task test()
        {

            var xx12 = "";

            var res12 = await Conn
                .Joiner<Agent, AgentInventoryRecord>(out var agent12, out var record12)
                .From(() => agent12)
                    .InnerJoin(() => record12)
                        .On(() => agent12.Id == record12.AgentId)
                .Where(() => record12.CreatedOn >= WhereTest.CreatedOn)
                .QueryListAsync(() => new AgentVM
                {
                    nn = agent12.PathId,
                    yy = record12.Id,
                    xx = agent12.Id,
                    zz = agent12.Name,
                    mm = record12.LockedCount
                });
            Assert.True(res12.Count == 574);

            var tuple12 = (XDebug.SQL, XDebug.Parameters);
            var yy2 = res12.First().nn;

            /*************************************************************************************************************************/

        }
    }
}
