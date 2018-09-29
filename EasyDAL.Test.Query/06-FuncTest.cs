﻿using MyDAL;
using MyDAL.Test.Entities.EasyDal_Exchange;
using System.Threading.Tasks;
using Xunit;

namespace MyDAL.Test.Query
{
    public class _06_FuncTest : TestBase
    {

        [Fact]
        public async Task FuncTest()
        {

            /*
             *char_length
             */
            /************************************************************************************************************************/

            var xx1 = "";

            // .Where(a => a.Name.Length > 0)
            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.Name.Length > 2)
                .QueryListAsync();

            var tuple1 = (XDebug.SQL, XDebug.Parameters);

            var xxR1 = "";

            // .Where(a => a.Name.Length > 0)
            var resR1 = await Conn
                .Selecter<Agent>()
                .Where(it => 2 < it.Name.Length)
                .QueryListAsync();
            Assert.True(res1.Count == resR1.Count);
            Assert.True(res1.Count == 22660);

            var tupleR1 = (XDebug.SQL, XDebug.Parameters);

            /************************************************************************************************************************/

            var xx2 = "";

            // .Where(a => a.Name.Length > 0)
            var res2 = await Conn
                .Joiner<Agent, AgentInventoryRecord>(out var agent, out var record)
                .From(() => agent)
                .InnerJoin(() => record)
                .On(() => agent.Id == record.AgentId)
                .Where(() => agent.Name.Length > 2)
                .QueryListAsync<Agent>();
            Assert.True(res2.Count == 574);

            var tuple2 = (XDebug.SQL, XDebug.Parameters);

            /*
             *count
             */
            /************************************************************************************************************************/

            var xx3 = "";

            // count(id)  like "陈%"
            var res3 = await Conn
                .Selecter<Agent>()
                .Where(it => it.Name.Contains(LikeTest.百分号))
                .Count(it => it.Id)
                .QuerySingleValueAsync<long>();
            Assert.True(res3 == 1421);

            var tuple3 = (XDebug.SQL, XDebug.Parameters);

            /************************************************************************************************************************/

            var xx4 = "";

            // count(id)  like "陈%"
            var res4 = await Conn
                .Selecter<Agent>()
                .Where(it => it.Name.Contains(LikeTest.百分号))
                .CountAsync(it => it.Id);
            Assert.True(res4 == 1421);

            var tuple4 = (XDebug.SQL, XDebug.Parameters);

            var xx42 = "";

            var res42 = await Conn
                .Selecter<Agent>()
                .Where(it => it.Name.Contains(LikeTest.百分号))
                .CountAsync();
            Assert.True(res42 == 1421);

            var tuple42 = (XDebug.SQL, XDebug.Parameters);

            /************************************************************************************************************************/

            var xx = "";
        }


    }
}
