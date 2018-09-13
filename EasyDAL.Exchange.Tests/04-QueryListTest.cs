﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyDAL.Exchange.Tests.Entities;
using EasyDAL.Exchange.Tests.Entities.EasyDal_Exchange;
using EasyDAL.Exchange.Tests.Enums;
using EasyDAL.Exchange.Tests.ViewModels;
using Xunit;

namespace EasyDAL.Exchange.Tests
{
    public class QueryListTest:TestBase
    {

        [Fact]
        public async Task Test01()
        {

            /********************************************************************************************************************************/

            var xx1 = "";

            // >= obj.DateTime
            var res1 = await Conn.OpenDebug()
                .Selecter<BodyFitRecord>()
                .Where(it => it.CreatedOn >= WhereTest.CreatedOn)
                .QueryListAsync();

            var tuple1 = (XDebug.SQL, XDebug.Parameters);

            var resR1 = await Conn.OpenDebug()
                .Selecter<BodyFitRecord>()
                .Where(it => WhereTest.CreatedOn <= it.CreatedOn)
                .QueryListAsync();
            Assert.True(res1.Count == resR1.Count);
            Assert.True(res1.Count == 1);

            var tupleR1 = (XDebug.SQL, XDebug.Parameters);

            /********************************************************************************************************************************/
            
            var xx2 = "";

            var start = WhereTest.CreatedOn.AddDays(-10);
            // >= variable(DateTime)
            var res2 = await Conn.OpenDebug()
                .Selecter<BodyFitRecord>()
                .Where(it => it.CreatedOn >= start)
                .QueryListAsync();

            var tuple2 = (XDebug.SQL, XDebug.Parameters);

            var resR2 = await Conn.OpenDebug()
                .Selecter<BodyFitRecord>()
                .Where(it => start <= it.CreatedOn)
                .QueryListAsync();
            Assert.True(res2.Count == resR2.Count);
            Assert.True(res2.Count == 1);

            var tupleR2 = (XDebug.SQL, XDebug.Parameters);

            /********************************************************************************************************************************/

            var xx3 = "";

            // <= DateTime
            var res3 = await Conn.OpenDebug()
                .Selecter<BodyFitRecord>()
                .Where(it => it.CreatedOn <= DateTime.Now)
                .QueryListAsync();

            var tuple3 = (XDebug.SQL, XDebug.Parameters);

            var resR3 = await Conn.OpenDebug()
                .Selecter<BodyFitRecord>()
                .Where(it => DateTime.Now >= it.CreatedOn)
                .QueryListAsync();
            Assert.True(res3.Count == resR3.Count);
            Assert.True(res3.Count == 1);

            var tupleR3 = (XDebug.SQL, XDebug.Parameters);

            /********************************************************************************************************************************/
            
            var testQ = new WhereTestModel
            {
                CreatedOn = DateTime.Now.AddDays(-30),
                DateTime_大于等于 = DateTime.Now.AddDays(-30),
                DateTime_小于等于 = DateTime.Now,
                AgentLevelXX = AgentLevel.DistiAgent,
                ContainStr = "~00-d-3-1-"
            };

            var xx4 = "";

            var res4 = await Conn.OpenDebug()
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= testQ.DateTime_大于等于)
                .QueryListAsync();
            Assert.True(res4.Count == 28619);

            var tuple4 = (XDebug.SQL, XDebug.Parameters);

            /********************************************************************************************************************************/

            var xx5 = "";

            var res5 = await Conn.OpenDebug()
                .Selecter<Agent>()
                .Where(it => it.AgentLevel == testQ.AgentLevelXX)
                .QueryListAsync();
            Assert.True(res5.Count == 555);

            var tuple5 = (XDebug.SQL, XDebug.Parameters);

            /********************************************************************************************************************************/

            var xx6 = "";

            var res6 = await Conn.OpenDebug()
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= testQ.DateTime_大于等于)
                .QueryListAsync<AgentVM>();
            Assert.True(res6.Count == 28619);
            Assert.NotNull(res6.First().Name);
            Assert.Null(res6.First().XXXX);

            var tuple6 = (XDebug.SQL, XDebug.Parameters);

            /********************************************************************************************************************************/

            var xx = "";

        }


    }
}
