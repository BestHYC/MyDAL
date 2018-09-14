﻿using EasyDAL.Exchange.Tests.Entities.EasyDal_Exchange;
using EasyDAL.Exchange.Tests.Enums;
using System.Threading.Tasks;
using Xunit;

namespace EasyDAL.Exchange.Tests
{
    public class _15_OrderByTest : TestBase
    {

        [Fact]
        public async Task OrderByXTest()
        {
            var xx1 = "";

            // order by
            var res1 = await Conn.OpenDebug()
                .Selecter<Agent>()
                .Where(it => it.AgentLevel == (AgentLevel)128)
                .OrderBy(it=>it.PathId)
                .ThenOrderBy(it=>it.Name, OrderByEnum.Asc)
                .QueryPagingListAsync(1,10);

            var tuple1 = (XDebug.SQL, XDebug.Parameters);

            var xx2 = "";

            // key
            var res2 = await Conn.OpenDebug()
                .Selecter<Agent>()
                .Where(it => it.AgentLevel == (AgentLevel)2)
                .QueryPagingListAsync(1, 10);

            var tuple2 = (XDebug.SQL, XDebug.Parameters);

            var xx3 = "";

            // none key
            var res3 = await Conn.OpenDebug()
                .Selecter<WechatPaymentRecord>()
                .Where(it => it.Amount > 1)
                .QueryPagingListAsync(1,10);

            var tuple3 = (XDebug.SQL, XDebug.Parameters);

            var xx = "";
        }

    }
}
