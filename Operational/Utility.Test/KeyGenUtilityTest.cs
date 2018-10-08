using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElementIoT.Particle.Operational.Utility.Test
{
    [TestClass]
    public class KeyGenUtilityTest
    {
        [TestMethod]
        public void GenerateBase64Key()
        {
            string key = KeyGenUtility.GenerateBase64Key();

            System.Diagnostics.Debug.WriteLine("THe KEY IS: " + key);

            Assert.IsFalse(string.IsNullOrWhiteSpace(key));
        }
    }
}
