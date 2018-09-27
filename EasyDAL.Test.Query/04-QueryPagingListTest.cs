﻿using MyDAL;
using MyDAL.Test.Entities.EasyDal_Exchange;
using MyDAL.Test.Enums;
using MyDAL.Test.ViewModels;
using System.Threading.Tasks;
using Xunit;
using static MyDAL.Test.Query._08_WhereObjTest;

namespace MyDAL.Test.Query
{
    public class _04_QueryPagingListTest : TestBase
    {

        // 分页查询 m
        [Fact]
        public async Task QueryPagingListAsyncTest()
        {

            /*************************************************************************************************************************/

            var xx1 = "";

            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= WhereTest.CreatedOn)
                .QueryPagingListAsync(1, 10);

            var tuple1 = (XDebug.SQL, XDebug.Parameters);

            var resR1 = await Conn
                .Selecter<Agent>()
                .Where(it => WhereTest.CreatedOn <= it.CreatedOn)
                .QueryPagingListAsync(1, 10);
            Assert.True(res1.TotalCount == resR1.TotalCount);
            Assert.True(res1.TotalCount == 28619);

            var tupleR1 = (XDebug.SQL, XDebug.Parameters);


            /*************************************************************************************************************************/

            var xx2 = "";

            var res2 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= WhereTest.CreatedOn)
                .QueryPagingListAsync<AgentVM>(1, 10);

            var tuple2 = (XDebug.SQL, XDebug.Parameters);

            var resR2 = await Conn
                .Selecter<Agent>()
                .Where(it => WhereTest.CreatedOn <= it.CreatedOn)
                .QueryPagingListAsync<AgentVM>(1, 10);
            Assert.True(res2.TotalCount == resR2.TotalCount);
            Assert.True(res2.TotalCount == 28619);

            var tupleR2 = (XDebug.SQL, XDebug.Parameters);


            /*************************************************************************************************************************/

            var xx3 = "";

            var res3 = await Conn
                .Selecter<Agent>()
                .QueryAllPagingListAsync(1, 10);
            Assert.True(res3.TotalCount == 28620);

            var tuple3 = (XDebug.SQL, XDebug.Parameters);

            /*************************************************************************************************************************/

            var xx4 = "";

            var res4 = await Conn
                .Selecter<Agent>()
                .QueryAllPagingListAsync<AgentVM>(1, 10);
            Assert.True(res4.TotalCount == 28620);

            var tuple4 = (XDebug.SQL, XDebug.Parameters);

            /*************************************************************************************************************************/

            var xx5 = "";

            var res5 = await Conn
                .Joiner<Agent, AgentInventoryRecord>(out var agent5, out var record5)
                .From(() => agent5)
                .InnerJoin(() => record5)
                .On(() => agent5.Id == record5.AgentId)
                .Where(() => agent5.AgentLevel == AgentLevel.DistiAgent)
                .QueryPagingListAsync<Agent>(1, 10);
            Assert.True(res5.TotalCount == 574);

            /*************************************************************************************************************************/

            var xx6 = "";

            var res6 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= WhereTest.CreatedOn)
                .QueryPagingListAsync(1, 10, agent => new AgentVM
                {
                    XXXX = agent.Name,
                    YYYY = agent.PathId
                });

            var tuple6 = (XDebug.SQL, XDebug.Parameters);

            /*************************************************************************************************************************/

            var xx7 = "";

            var res7 = await Conn
                .Joiner<Agent, AgentInventoryRecord>(out var agent7, out var record7)
                .From(() => agent7)
                .InnerJoin(() => record7)
                .On(() => agent7.Id == record7.AgentId)
                .Where(() => agent7.AgentLevel == AgentLevel.DistiAgent)
                .QueryPagingListAsync(1, 10, () => new AgentVM
                {
                    XXXX = agent7.Name,
                    YYYY = agent7.PathId
                });
            Assert.True(res7.TotalCount == 574);

            var tuple7 = (XDebug.SQL, XDebug.Parameters);

            /*************************************************************************************************************************/

            var xx8 = "";

            var option8 = new AgentQueryOption();
            option8.AgentLevel = AgentLevel.DistiAgent;
            var res8 = await Conn
                .Joiner<Agent, AgentInventoryRecord>(out var agent8, out var record8)
                .From(() => agent8)
                .InnerJoin(() => record8)
                .On(() => agent8.Id == record8.AgentId)
                .Where(() => agent8.AgentLevel == AgentLevel.DistiAgent)
                .QueryPagingListAsync(option8, () => new AgentVM
                {
                    XXXX = agent8.Name,
                    YYYY = agent8.PathId
                });
            Assert.True(res8.TotalCount == 574);

            var tuple8 = (XDebug.SQL, XDebug.Parameters);

            /*************************************************************************************************************************/

            var xx9 = "";

            var option9 = new AgentQueryOption();
            option9.AgentLevel = AgentLevel.DistiAgent;
            option9.PageIndex = 5;
            option9.PageSize = 10;
            var res9 = await Conn
                .Joiner<Agent, AgentInventoryRecord>(out var agent9, out var record9)
                .From(() => agent9)
                .InnerJoin(() => record9)
                .On(() => agent9.Id == record9.AgentId)
                .Where(() => agent9.AgentLevel == AgentLevel.DistiAgent)
                .QueryPagingListAsync(option9, () => new AgentVM
                {
                    XXXX = agent9.Name,
                    YYYY = agent9.PathId
                });
            Assert.True(res9.TotalCount == 574);
            Assert.True(res9.PageSize == 10);
            Assert.True(res9.PageIndex == 5);
            Assert.True(res9.Data.Count == 10);

            var tuple9 = (XDebug.SQL, XDebug.Parameters);

            /*************************************************************************************************************************/

            var xx = "";
        }

    }
}
