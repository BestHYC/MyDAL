﻿using EasyDAL.Exchange.Enums;
using EasyDAL.Exchange.Tests.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using EasyDAL.Exchange.Extensions;

namespace EasyDAL.Exchange.Tests
{
    public class UpdateTest:TestBase
    {

        // 修改一个已有对象
        [Fact]
        public async Task UpdateAsyncTest()
        {
            var xx0 = "";

            // 造数据 
            var Id = Guid.Parse("1fbd8a41-c75b-45c0-9186-016544284e2e");
            var res1 = await Conn
                .Deleter<BodyFitRecord>()
                .Where(it => it.Id == Id)
                .DeleteAsync();           
            var m = new BodyFitRecord
            {
                Id = Guid.Parse("1fbd8a41-c75b-45c0-9186-016544284e2e"),
                CreatedOn = DateTime.Now,
                UserId = Guid.NewGuid(),
                BodyMeasureProperty = "{xxx:yyy,mmm:nnn}"
            };
            var res2 = await Conn
                .Creater<BodyFitRecord>()
                .CreateAsync(m);

            var xx2 = "";

            // DB data
            var m1 = new BodyFitRecord
            {
                Id = Guid.Parse("1fbd8a41-c75b-45c0-9186-016544284e2e"),
                CreatedOn = DateTime.Now,   // new value
                UserId = Guid.NewGuid(),
                BodyMeasureProperty = "{xxx:yyy,mmm:nnn,zzz:aaa}"   // new value
            };
            
            // 修改
            // where set 
            var res3 = await Conn
                .Updater<BodyFitRecord>()      
                .Set(it => it.CreatedOn, m1.CreatedOn)
                .Set(it => it.BodyMeasureProperty, m1.BodyMeasureProperty)
                .Where(it => it.Id == m.Id)
                .UpdateAsync();

            var xx3 = "";

            var m2 = 10;
            var id2 = Guid.Parse("0ce552c0-2f5e-4c22-b26d-01654443b30e");
            // where change and 
            var res4 = await Conn
                .Updater<AgentInventoryRecord>()
                .Change(it => it.LockedCount, m2, ChangeEnum.Add)
                .Where(it => it.AgentId == id2)
                .And(it => it.ProductId == Guid.Parse("85ce17c1-10d9-4784-b054-016551e5e109"))
                .UpdateAsync();

            var xx4 = "";

            // where set or 
            var res5 = await Conn
                .Updater<AgentInventoryRecord>()
                .Set(it => it.LockedCount, 100)
                .Where(it => it.AgentId == id2)
                .Or(it => it.CreatedOn == Convert.ToDateTime("2018-08-19 11:34:42.577074"))
                .UpdateAsync();

            var xx = "";

            // 清理数据
            var resd = await Conn
                .Deleter<BodyFitRecord>()
                .Where(it => it.Id == Id)
                .DeleteAsync();
        }

    }
}
