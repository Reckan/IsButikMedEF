using FuncLayer;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Func Func = new();
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestOpretIsNoName()
        {
            var a = Func.BestillingsList;
            Func.OpretIs("", 15, "TEST");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestBestilVare()
        {
            Func.Bestil(null, 5, "");
        }
    }
}