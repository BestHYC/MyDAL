﻿using System.Linq;
using System.Data;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using Xunit;
using EasyDAL.Exchange.DynamicParameter;
using EasyDAL.Exchange.Reader;
using EasyDAL.Exchange.AdoNet;
using EasyDAL.Exchange.MapperX;
using EasyDAL.Exchange;
using EasyDAL.Exchange.Tests.Entities;
using EasyDAL.Exchange.Tests.Enums;

namespace EasyDAL.Exchange.Tests
{
    public class Tests : TestBase
    {

        private WhereTestModel testH = new WhereTestModel
        {
            CreatedOn = DateTime.Now.AddDays(-10),
            StartTime = DateTime.Now.AddDays(-10),
            EndTime = DateTime.Now,
            AgentLevelXX = AgentLevel.DistiAgent,
            ContainStr = "~00-d-3-1-"
        };


        [Fact]
        public async Task TestExecuteAsync()
        {
            var val = await connection.ExecuteAsync("declare @foo table(id int not null); insert @foo values(@id);", new { id = 1 }).ConfigureAwait(false);
            Assert.Equal(1, val);
        }

        [Fact]
        public void TestExecuteClosedConnAsyncInner()
        {
            var query = connection.ExecuteAsync("declare @foo table(id int not null); insert @foo values(@id);", new { id = 1 });
            var val = query.Result;
            Assert.Equal(1, val);
        }

        [Fact]
        public async Task Issue22_ExecuteScalarAsync()
        {
            int i = await connection.ExecuteScalarAsync<int>("select 123").ConfigureAwait(false);
            Assert.Equal(123, i);

            i = await connection.ExecuteScalarAsync<int>("select cast(123 as bigint)").ConfigureAwait(false);
            Assert.Equal(123, i);

            long j = await connection.ExecuteScalarAsync<long>("select 123").ConfigureAwait(false);
            Assert.Equal(123L, j);

            j = await connection.ExecuteScalarAsync<long>("select cast(123 as bigint)").ConfigureAwait(false);
            Assert.Equal(123L, j);

            int? k = await connection.ExecuteScalarAsync<int?>("select @i", new { i = default(int?) }).ConfigureAwait(false);
            Assert.Null(k);
        }

        /***************************************************************************************************************/


        // 删除一个已有对象
        [Fact]
        public async Task DeleteAsyncTest()
        {
            var xx0 = "";

            // where 
            var Id = Guid.Parse("1fbd8a41-c75b-45c0-9186-016544284e2e");
            var res1 = await Conn
                .Deleter<BodyFitRecord>()
                .Where(it => it.Id == Id)
                .DeleteAsync();

            var xx1 = "";

            // where and
            var path = "~00-c-1-2-1-1-1-1-1-4-1-1-1-4-1-2-1-7";
            var level = 2;
            var res2 = await Conn
                .Deleter<Agent>()
                .Where(it => it.PathId == path)
                .And(it => it.AgentLevel == (AgentLevel)level)
                .DeleteAsync();

            var xx2 = "";

            // where or
            var res3 = await Conn
                .Deleter<Agent>()
                .Where(it => it.PathId == path)
                .Or(it => it.AgentLevel == (AgentLevel)level)
                .DeleteAsync();

            var xx3 = "";

            // where and or
            var res4 = await Conn
                .Deleter<Agent>()
                .Where(it => it.PathId == path)
                .And(it => it.AgentLevel == (AgentLevel)level)
                .Or(it => it.CreatedOn >= testH.StartTime)
                .DeleteAsync();

            var xx = "";
        }

        // 创建一个新对象
        [Fact]
        public async Task CreateAsyncTest()
        {
            var m = new BodyFitRecord
            {
                Id = Guid.Parse("1fbd8a41-c75b-45c0-9186-016544284e2e"),
                CreatedOn = DateTime.Now,
                UserId = Guid.NewGuid(),
                BodyMeasureProperty = "{xxx:yyy,mmm:nnn}"
            };
            var res = await Conn
                .Creater<BodyFitRecord>()
                .CreateAsync(m);

            var xx = "";
        }

        // 修改一个已有对象
        [Fact]
        public async Task UpdateAsyncTest()
        {
            // DB data
            var m = new BodyFitRecord
            {
                Id = Guid.Parse("1fbd8a41-c75b-45c0-9186-016544284e2e"),
                CreatedOn = DateTime.Now,   // new value
                UserId = Guid.NewGuid(),
                BodyMeasureProperty = "{xxx:yyy,mmm:nnn,zzz:aaa}"   // new value
            };

            var xx0 = "";

            // where
            var res1 = await Conn
                .Updater<BodyFitRecord>()
                .Set(it => it.CreatedOn == m.CreatedOn)
                .Set(it => it.BodyMeasureProperty == m.BodyMeasureProperty)
                .Where(it => it.Id == m.Id)
                .UpdateAsync();

            var xx = "";
        }

        // 查询一个已存在对象 单条件
        [Fact]
        public async Task QueryFirstOrDefaultAsyncTest()
        {
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
                .Where(it => it.CreatedOn == Convert.ToDateTime("2018-08-23 13:36:58.981016"))
                .QueryFirstOrDefaultAsync();

            var xx2 = "";

            // == string
            var res3 = await Conn
                .Selecter<BodyFitRecord>()
                .Where(it => it.BodyMeasureProperty == "xxxx")
                .QueryFirstOrDefaultAsync();

            var xx3 = "";

            // like string
            var res4 = await Conn
                .Selecter<BodyFitRecord>()
                .Where(it => it.BodyMeasureProperty.Contains("xx"))
                .QueryFirstOrDefaultAsync();

            var xx4 = "";

            // >= obj.DateTime
            var res5 = await Conn
                .Selecter<BodyFitRecord>()
                .Where(it => it.CreatedOn >= testH.CreatedOn)
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
            var res7 = await Conn
                .Selecter<BodyFitRecord>()
                .Where(it => it.CreatedOn <= DateTime.Now)
                .QueryFirstOrDefaultAsync();



            var xx = "";
        }

        // 查询一个已存在对象 多条件
        [Fact]
        public async Task QueryFirstOrDefaultAsyncTest2()
        {
            var xx0 = "";

            // where and
            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= testH.StartTime)
                .And(it => it.Id == Guid.Parse("000c1569-a6f7-4140-89a7-0165443b5a4b"))
                .QueryFirstOrDefaultAsync();

            var xx = "";
        }

        // 查询多个已存在对象 单条件
        [Fact]
        public async Task QueryListAsyncTest()
        {
            var testQ = new WhereTestModel
            {
                CreatedOn = DateTime.Now.AddDays(-10),
                StartTime = DateTime.Now.AddDays(-10),
                EndTime = DateTime.Now,
                AgentLevelXX = AgentLevel.DistiAgent,
                ContainStr = "~00-d-3-1-"
            };

            var xx0 = "";

            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= testQ.StartTime)
                .QueryListAsync();

            var xx1 = "";

            var res2 = await Conn
                .Selecter<Agent>()
                .Where(it => it.AgentLevel == testQ.AgentLevelXX)
                .QueryListAsync();

            var xx = "";
        }

        // 分页查询 单条件
        [Fact]
        public async Task QueryPagingListAsyncTest()
        {
            var xx0 = "";

            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= testH.StartTime)
                .SetPageIndex(1)
                .SetPageSize(10)
                .QueryPagingListAsync();

            var xx = "";
        }


        // 分页查询 多条件
        [Fact]
        public async Task QueryPagingListAsyncTest2()
        {
            var testQ = new WhereTestModel
            {
                CreatedOn = DateTime.Now.AddDays(-10),
                StartTime = DateTime.Now.AddDays(-10),
                EndTime = DateTime.Now,
                AgentLevelXX = AgentLevel.DistiAgent,
                ContainStr = "~00-d-3-1-"
            };


            var xx0 = "";

            // where and like 
            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= testH.StartTime)
                .And(it => it.PathId.Contains(testH.ContainStr))   
                .SetPageIndex(1)
                .SetPageSize(10)
                .QueryPagingListAsync();

            var xx1 = "";

            // where and like 
            var res2 = await Conn
                .Selecter<Agent>()
                .Where(it => it.CreatedOn >= testH.StartTime)
                .And(it => it.PathId.Contains("~00-d-3-1-"))
                .SetPageIndex(1)
                .SetPageSize(10)
                .QueryPagingListAsync();

            var xx = "";
        }

        /****************************************************************************/



        [Fact]
        public async Task TestSupportForDynamicParametersOutputExpressionsAsync()
        {
            {
                var bob = new Person { Name = "bob", PersonId = 1, Address = new Address { PersonId = 2 } };

                var p = new DynamicParameters(bob);
                p.Output(bob, b => b.PersonId);
                p.Output(bob, b => b.Occupation);
                p.Output(bob, b => b.NumberOfLegs);
                p.Output(bob, b => b.Address.Name);
                p.Output(bob, b => b.Address.PersonId);

                await connection.ExecuteAsync(@"
SET @Occupation = 'grillmaster' 
SET @PersonId = @PersonId + 1 
SET @NumberOfLegs = @NumberOfLegs - 1
SET @AddressName = 'bobs burgers'
SET @AddressPersonId = @PersonId", p).ConfigureAwait(false);

                Assert.Equal("grillmaster", bob.Occupation);
                Assert.Equal(2, bob.PersonId);
                Assert.Equal(1, bob.NumberOfLegs);
                Assert.Equal("bobs burgers", bob.Address.Name);
                Assert.Equal(2, bob.Address.PersonId);
            }
        }

        [Fact]
        public async Task TestSupportForDynamicParametersOutputExpressions_ScalarAsync()
        {
            var bob = new Person { Name = "bob", PersonId = 1, Address = new Address { PersonId = 2 } };

            var p = new DynamicParameters(bob);
            p.Output(bob, b => b.PersonId);
            p.Output(bob, b => b.Occupation);
            p.Output(bob, b => b.NumberOfLegs);
            p.Output(bob, b => b.Address.Name);
            p.Output(bob, b => b.Address.PersonId);

            var result = (int)(await connection.ExecuteScalarAsync(@"
SET @Occupation = 'grillmaster' 
SET @PersonId = @PersonId + 1 
SET @NumberOfLegs = @NumberOfLegs - 1
SET @AddressName = 'bobs burgers'
SET @AddressPersonId = @PersonId
select 42", p).ConfigureAwait(false));

            Assert.Equal("grillmaster", bob.Occupation);
            Assert.Equal(2, bob.PersonId);
            Assert.Equal(1, bob.NumberOfLegs);
            Assert.Equal("bobs burgers", bob.Address.Name);
            Assert.Equal(2, bob.Address.PersonId);
            Assert.Equal(42, result);
        }


    }
}
