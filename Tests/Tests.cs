using Cryptography;

namespace Tests
{
	[TestFixture, Parallelizable]
	internal class Tests
	{
		static string StringForTests = "string for tests";

		[Test]
		public void TestPass()
		{
			Assert.Pass();
		}

		[Test]
		public void HMACTest()
		{
			Assert.AreEqual(
				HMAC.SHA256toBase64(StringForTests, StringForTests),
				"Iiv5SlTNzkJ4HTJIhE80jCUPvfqv3eTIF3sbPsMaUdU=");
		}

		[Test]
		public void MD5Test()
		{
			Assert.AreEqual(
				MD5.Compute(StringForTests),
				"0d1087f225917e069af42119f81bfdbd");
		}

		[Test]
		public void SHA256Test()
		{
			Assert.AreEqual(
				SHA.SHA256(StringForTests),
				"027B23DC863EBDBB680AE94ECD83CD4232E519EF7C263F332CA9A32DD9B54C21");
		}

		[Test]
		public void SHA512Test()
		{
			Assert.AreEqual(
				SHA.SHA512(StringForTests),
				"F3DED6C1254A6E901B121A85957312A967F2DCBC40D6CE2F7E70C86B48749CB58CD0C6832DC8A735AC7551EDE60F0D99C667A7A9572095178C46E435A55FD58A");
		}


		[Test]
		public void AesTest()
		{
			var key = MD5.Compute(StringForTests);
			var EncToBase64 = Aes.EncryptFromStringToBase64(StringForTests, key);
			var DecFromBase64 = Aes.DecryptFromBase64ToString(EncToBase64, key);

			Assert.AreEqual(DecFromBase64, StringForTests);
		}





	}
}
