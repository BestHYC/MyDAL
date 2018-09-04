﻿using EasyDAL.Exchange.Core.Sql;
using EasyDAL.Exchange.Tests.Entities;
using EasyDAL.Exchange.Tests.Enums;
using EasyDAL.Exchange.Tests.ViewModels;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EasyDAL.Exchange.Tests
{
    public class QueryTest : TestBase
    {       

        // 查询一个已存在对象 单条件
        [Fact]
        public async Task QueryFirstOrDefaultAsyncTest()
        {
            var m = new BodyFitRecord
            {
                Id = Guid.Parse("1fbd8a41-c75b-45c0-9186-016544284e2e"),
                CreatedOn = Convert.ToDateTime("2018-08-23 13:36:58"),
                UserId = Guid.NewGuid(),
                BodyMeasureProperty = "xxxx"
            };
            // 造数据
            var resc = await Conn
                .Creater<BodyFitRecord>()
                .CreateAsync(m);

            var xx0 = "";

            //  == Guid
            var res = await Conn
                .Selecter<BodyFitRecord>()
                .Where(it => it.Id == Guid.Parse("1fbd8a41-c75b-45c0-9186-016544284e2e"))
                .QueryFirstOrDefaultAsync();

            var xx1 = "";

            // == DateTime
            var res2 = await Conn
                .Selecter<BodyFitRecord>()
                .Where(it => it.CreatedOn == Convert.ToDateTime("2018-08-23 13:36:58"))
                .QueryFirstOrDefaultAsync();

            var xx2 = "";

            // == string
            var res3 = await Conn
                .Selecter<BodyFitRecord>()
                .Where(it => it.BodyMeasureProperty == "xxxx")
                .QueryFirstOrDefaultAsync();

            var xx4 = "";

            // >= obj.DateTime
            var res5 = await Conn
                .Selecter<BodyFitRecord>()
                .Where(it => it.CreatedOn >= WhereTest.CreatedOn)
                .QueryFirstOrDefaultAsync();

            var xx5 = "";

            var start = DateTime.Now.AddDays(-10);
            // >= variable(DateTime)
            var res6 = await Conn
                .Selecter<BodyFitRecord>()
                .Where(it => it.CreatedOn >= start)
                .QueryFirstOrDefaultAsync();

            var xx6 = "";

            // <= DateTime
            var res7 = await Conn.OpenDebug()
                .Selecter<BodyFitRecord>()
                .Where(it => it.CreatedOn <= DateTime.Now)
                .QueryFirstOrDefaultAsync();

            var tuple = (XDebug.SQL, XDebug.Parameters);

            var xx = "";

            // 清理数据
            var resd = await Conn
                .Deleter<BodyFitRecord>()
                .Where(it => it.Id == m.Id)
                .DeleteAsync();
        }

        // 查询一个已存在对象 多条件
        [Fact]
        public async Task QueryFirstOrDefaultAsyncTest2()
        {
            var xx1 = "";

            // where and
            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= WhereTest.DateTime_大于等于)
                .And(it => it.Id == Guid.Parse("000c1569-a6f7-4140-89a7-0165443b5a4b"))
                .QueryFirstOrDefaultAsync();

            var xx2 = "";

            var xx = "";
        }

        [Fact]
        public async Task QueryFirstOrDefaultAsyncVMTest()
        {
            var xx1 = "";

            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.Id == Guid.Parse("000c1569-a6f7-4140-89a7-0165443b5a4b"))
                .QueryFirstOrDefaultAsync<AgentVM>();

            var xx = "";
        }

        // 查询多个已存在对象 单条件
        [Fact]
        public async Task QueryListAsyncTest()
        {
            var testQ = new WhereTestModel
            {
                CreatedOn = DateTime.Now.AddDays(-30),
                DateTime_大于等于 = DateTime.Now.AddDays(-30),
                DateTime_小于等于 = DateTime.Now,
                AgentLevelXX = AgentLevel.DistiAgent,
                ContainStr = "~00-d-3-1-"
            };

            var xx1 = "";

            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= testQ.DateTime_大于等于)
                .QueryListAsync();

            var xx2 = "";

            var res2 = await Conn
                .Selecter<Agent>()
                .Where(it => it.AgentLevel == testQ.AgentLevelXX)
                .QueryListAsync();

            var xx3 = "";

            // .Where(a => a.Name.Length > 0)
            var res3 = await Conn.OpenDebug()
                .Selecter<Agent>()
                .Where(it => it.Name.Length > 2)
                .QueryListAsync();

            var tuple3 = (XDebug.SQL, XDebug.Parameters);

            var xx = "";
        }

        [Fact]
        public async Task QueryListAsyncVMTest()
        {
            var testQ = new WhereTestModel
            {
                CreatedOn = DateTime.Now.AddDays(-30),
                DateTime_大于等于 = DateTime.Now.AddDays(-30),
                DateTime_小于等于 = DateTime.Now,
                AgentLevelXX = AgentLevel.DistiAgent,
                ContainStr = "~00-d-3-1-"
            };

            var xx1 = "";

            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= testQ.DateTime_大于等于)
                .QueryListAsync<AgentVM>();
            
            var xx = "";
        }

        // 查询 是否存在
        [Fact]
        public async Task ExistAsyncTest()
        {
            var xx1 = "";

            var res1 = await Conn.OpenDebug()
                .Selecter<Agent>()
                .Where(it => it.Id == Guid.Parse("000c1569-a6f7-4140-89a7-0165443b5a4b"))
                .ExistAsync();

            var tuple = (XDebug.SQL, XDebug.Parameters);

            var xx = "";
        }

        // 查询 所有
        [Fact]
        public async Task QueryAllAsyncTest()
        {
            var xx1 = "";

            var res1 = await Conn.OpenDebug()
                .Selecter<Agent>()
                .QueryAllAsync();

            var tuple = (XDebug.SQL, XDebug.Parameters);

            var xx = "";
        }

        [Fact]
        public async Task QueryAllAsyncVMTest()
        {
            var xx1 = "";

            var res1 = await Conn.OpenDebug()
                .Selecter<Agent>()
                .QueryAllAsync<AgentVM>();

            var tuple = (XDebug.SQL, XDebug.Parameters);

            var xx = "";
        }

    }
}
