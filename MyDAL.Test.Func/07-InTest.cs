﻿using MyDAL.Test.Entities.EasyDal_Exchange;
using MyDAL.Test.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MyDAL.Test.Func
{
    public class _07_InTest : TestBase
    {
        private List<AgentLevel?> EnumList { get; set; }
        private AgentLevel?[] EnumArray { get; set; }
        private List<string> StringList { get; set; }
        private string[] StringArray { get; set; }
        private async Task PereValue()
        {
            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => it.Id == Guid.Parse("03f0a7b4-acd3-4003-b686-01654436e906"))
                .FirstOrDefaultAsync();
            var res2 = await Conn
                .Updater<Agent>()
                .Set(it => it.DirectorStarCount, 10)
                .Where(it => it.Id == res1.Id)
                .UpdateAsync();
            var res3 = await Conn
                .Selecter<Agent>()
                .Where(it => it.Id == Guid.Parse("03fc18e2-4b1e-4aa2-832b-0165443388bd"))
                .FirstOrDefaultAsync();
            var res4 = await Conn
                .Updater<Agent>()
                .Set(it => it.DirectorStarCount, 5)
                .Where(it => it.Id == res3.Id)
                .UpdateAsync();
        }

        [Fact]
        public async Task ListT_Enum_Test()
        {

            /*******************************************************************************************************************/

            var xx1 = "";

            var enums = new List<AgentLevel?>
            {
                AgentLevel.CityAgent,
                AgentLevel.DistiAgent
            };
            // where in  --  variable  List<enum>  
            var res1 = await Conn
                .Selecter<Agent>()
                .Where(it => enums.Contains(it.AgentLevel))
                .ListAsync();
            Assert.True(res1.Count == 555);

            var tuple1 = (XDebug.SQL, XDebug.Parameters,XDebug.SqlWithParams);

            /*******************************************************************************************************************/

            var xx2 = "";

            // where in -- obj.prop List<enum>
            var res2 = await Conn
                .Selecter<Agent>()
                .Where(it => WhereTest.In_List_枚举.Contains(it.AgentLevel))
                .ListAsync();

            var tuple2 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx3 = "";

            EnumList = enums;
            // where in -- this.prop List<enum>
            var res3 = await Conn
                .Selecter<Agent>()
                .Where(it => EnumList.Contains(it.AgentLevel))
                .ListAsync();

            var tuple3 = (XDebug.SQL, XDebug.Parameters);

            Assert.True(res1.Count == res2.Count);
            Assert.True(res2.Count == res3.Count);
            Assert.True(res1.Count == 555);

            /*******************************************************************************************************************/

            var xx4 = "";

            var names = new List<string>
            {
                "黄银凤",
                "刘建芬"
            };
            // where in  --  variable  List<string>  
            var res4 = await Conn
                .Selecter<Agent>()
                .Where(it => names.Contains(it.Name))
                .ListAsync();

            var tuple4 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx5 = "";

            // where in -- obj.prop List<string>
            var res5 = await Conn
                .Selecter<Agent>()
                .Where(it => WhereTest.In_List_String.Contains(it.Name))
                .ListAsync();

            var tuple5 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx6 = "";

            StringList = names;
            // where in -- this.prop List<string>
            var res6 = await Conn
                .Selecter<Agent>()
                .Where(it => StringList.Contains(it.Name))
                .ListAsync();

            var tuple6 = (XDebug.SQL, XDebug.Parameters);

            Assert.True(res4.Count == res5.Count);
            Assert.True(res5.Count == res6.Count);
            Assert.True(res4.Count == 2);

            /*******************************************************************************************************************/


            await PereValue();

            /*******************************************************************************************************************/

            var xx7 = "";

            // where in -- List<int>  init 
            var res7 = await Conn
                .Selecter<Agent>()
                .Where(it => new List<int> { 5, 10 }.Contains(it.DirectorStarCount))
                .ListAsync();

            var tuple7 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx8 = "";

            // where in -- List<long> init
            var res8 = await Conn
                .Selecter<Agent>()
                .Where(it => new List<long> { 5, 10 }.Contains(it.DirectorStarCount))
                .ListAsync();

            var tuple8 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx9 = "";

            // where in -- List<short> init
            var res9 = await Conn
                .Selecter<Agent>()
                .Where(it => new List<short> { 5, 10 }.Contains((short)(it.DirectorStarCount)))
                .ListAsync();

            var tuple9 = (XDebug.SQL, XDebug.Parameters);

            Assert.True(res7.Count == res8.Count);
            Assert.True(res8.Count == res9.Count);
            Assert.True(res7.Count == 2);

            /*******************************************************************************************************************/

            var xx10 = "";

            // where in -- List<string> init
            var res10 = await Conn
                .Selecter<Agent>()
                .Where(it => new List<string> { "黄银凤", "刘建芬" }.Contains(it.Name))
                .ListAsync();
            Assert.True(res10.Count == 2);

            var tuple10 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx11 = "";

            // where in -- List<enum> init
            var res11 = await Conn
                .Selecter<Agent>()
                .Where(it => new List<AgentLevel?> { AgentLevel.CityAgent, AgentLevel.DistiAgent }.Contains(it.AgentLevel))
                .ListAsync();
            Assert.True(res11.Count == 555);

            var tuple11 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx12 = "";

            var enumArray = new AgentLevel?[]
            {
                AgentLevel.CityAgent,
                AgentLevel.DistiAgent
            };
            // where in  --  variable  enum[]  
            var res12 = await Conn
                .Selecter<Agent>()
                .Where(it => enumArray.Contains(it.AgentLevel))
                .ListAsync();

            var tuple12 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx13 = "";

            // where in -- obj.prop enum[]
            var res13 = await Conn
                .Selecter<Agent>()
                .Where(it => WhereTest.In_Array_枚举.Contains(it.AgentLevel))
                .ListAsync();

            var tuple13 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx14 = "";

            EnumArray = enumArray;
            // where in -- this.prop enum[]
            var res14 = await Conn
                .Selecter<Agent>()
                .Where(it => EnumArray.Contains(it.AgentLevel))
                .ListAsync();

            var tuple14 = (XDebug.SQL, XDebug.Parameters);

            Assert.True(res12.Count == res13.Count);
            Assert.True(res13.Count == res14.Count);
            Assert.True(res12.Count == 555);

            /*******************************************************************************************************************/

            var xx15 = "";

            var nameArray = new string[]
            {
                "黄银凤",
                "刘建芬"
            };
            // where in  --  variable  string[]  
            var res15 = await Conn
                .Selecter<Agent>()
                .Where(it => nameArray.Contains(it.Name))
                .ListAsync();

            var tuple15 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx16 = "";

            // where in -- obj.prop string[]
            var res16 = await Conn
                .Selecter<Agent>()
                .Where(it => WhereTest.In_Array_String.Contains(it.Name))
                .ListAsync();

            var tuple16 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx17 = "";

            StringArray = nameArray;
            // where in -- this.prop string[]
            var res17 = await Conn
                .Selecter<Agent>()
                .Where(it => StringArray.Contains(it.Name))
                .ListAsync();

            var tuple17 = (XDebug.SQL, XDebug.Parameters);

            Assert.True(res15.Count == res16.Count);
            Assert.True(res16.Count == res17.Count);
            Assert.True(res15.Count == 2);

            /*******************************************************************************************************************/

            await PereValue();

            /*******************************************************************************************************************/

            var xx18 = "";

            // where in -- int[]  init 
            var res18 = await Conn
                .Selecter<Agent>()
                .Where(it => new int[] { 5, 10 }.Contains(it.DirectorStarCount))
                .ListAsync();

            var tuple18 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx19 = "";

            // where in -- long[] init
            var res19 = await Conn
                .Selecter<Agent>()
                .Where(it => new long[] { 5L, 10L }.Contains(it.DirectorStarCount))
                .ListAsync();

            var tuple19 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx20 = "";

            // where in -- short[] init
            var res20 = await Conn
                .Selecter<Agent>()
                .Where(it => new short[] { 5, 10 }.Contains((short)(it.DirectorStarCount)))
                .ListAsync();

            var tuple20 = (XDebug.SQL, XDebug.Parameters);

            Assert.True(res18.Count == res19.Count);
            Assert.True(res19.Count == res20.Count);
            Assert.True(res18.Count == 2);

            /*******************************************************************************************************************/

            var xx21 = "";

            // where in -- string[] init
            var res21 = await Conn
                .Selecter<Agent>()
                .Where(it => new string[] { "黄银凤", "刘建芬" }.Contains(it.Name))
                .ListAsync();
            Assert.True(res21.Count == 2);

            var tuple21 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx22 = "";

            // where in -- enum[] init
            var res22 = await Conn
                .Selecter<Agent>()
                .Where(it => new AgentLevel?[] { AgentLevel.CityAgent, AgentLevel.DistiAgent }.Contains(it.AgentLevel))
                .ListAsync();
            Assert.True(res22.Count == 555);

            var tuple22 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx23 = "";

            // where in -- enum[] init
            var res23 = await Conn
                .Joiner<Agent, AgentInventoryRecord>(out var agent, out var record)
                .From(() => agent)
                .InnerJoin(() => record)
                .On(() => agent.Id == record.AgentId)
                .Where(() => new AgentLevel?[] { AgentLevel.CityAgent, AgentLevel.DistiAgent }.Contains(agent.AgentLevel))
                .ListAsync<Agent>();
            Assert.True(res23.Count == 574);

            var tuple23 = (XDebug.SQL, XDebug.Parameters);

            /*******************************************************************************************************************/

            var xx24 = "";

            var guid241 = Guid.Parse("0048793b-ca61-457e-a2b4-0165442f3684");
            var guid242 = Guid.Parse("004f4290-9576-43b9-903f-01654434da0f");
            // where in -- string[] init
            var res24 = await Conn
                .Selecter<Agent>()
                .Where(it => new string[] { "黄银凤", "刘建芬" }.Contains(it.Name) || new List<Guid> { guid241, guid242 }.Contains(it.Id))
                .ListAsync();
            Assert.True(res24.Count == 4);

            var tuple24 = (XDebug.SQL, XDebug.Parameters, XDebug.SqlWithParams);

            /*******************************************************************************************************************/

            var xx25 = "";
            
            // where in -- string[] init
            var res25 = await Conn
                .Selecter<Agent>()
                .Where(it => new string[] {"刘建芬" }.Contains(it.Name))
                .ListAsync();
            Assert.True(res25.Count == 1);

            var tuple25 = (XDebug.SQL, XDebug.Parameters, XDebug.SqlWithParams);

            /*******************************************************************************************************************/

            var xx26 = "";

            // where in -- string[] init
            var res26 = await Conn
                .Selecter<Agent>()
                .Where(it => new string[] { "刘建芬" }.Contains(it.Name) || new List<Guid> { guid241 }.Contains(it.Id))
                .ListAsync();
            Assert.True(res26.Count == 2);

            var tuple26 = (XDebug.SQL, XDebug.Parameters, XDebug.SqlWithParams);

            /*******************************************************************************************************************/

            var xx27 = "";

            try
            {
                // where in -- string[] init
                var res27 = await Conn
                    .Selecter<Agent>()
                    .Where(it => new List<Guid> { }.Contains(it.Id))
                    .ListAsync();
            }
            catch(Exception ex)
            {
                Assert.True(ex.Message.Equals("【new List`1() {}.Contains(it.Id)】 中 集合为空!!!", StringComparison.OrdinalIgnoreCase));
            }
            
            /*******************************************************************************************************************/

            var xx = "";
        }

    }
}
