using FuncLayer;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Func Func = new();
        [TestMethod]
        public void TestMethod1()
        {
            var a = Func.BestillingsList;
        }
    }
}