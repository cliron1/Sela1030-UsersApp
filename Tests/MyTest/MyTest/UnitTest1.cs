using Entities;
using NUnit.Framework;

namespace MyTest {
	public class Tests {
		[SetUp]
		public void Setup() {
		}

		[Test]
		public void MyMath_Add_Should_OK() {
			// Arrange
			var myMath = new MyMath();

			// Act
			var result = myMath.Add(1,2);

			// Assert
			Assert.AreEqual(3, result);
		}
		[Test]
		public void Test2() {
			Assert.Pass();
		}
	}
	public class Test2 {
		[SetUp]
		public void Setup() {
		}

		[Test]
		public void Test1() {
			Assert.Pass();
		}
	}
}