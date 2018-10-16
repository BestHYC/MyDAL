using MyDAL.Test.Entities.EasyDal_Exchange;
using System.Threading.Tasks;
using Xunit;
using Yunyong.DataExchange;

namespace MyDAL.Test.Func
{
    public class _01_Char_LengthTest : TestBase
    {

        [Fact]
        public async Task Char_LengthTest()
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
            Assert.True(res1.Count == 22660);

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
            Assert.True(res2.Count == 457);

            var tuple2 = (XDebug.SQL, XDebug.Parameters);

            /************************************************************************************************************************/

            var xx = "";
        }


    }
}
