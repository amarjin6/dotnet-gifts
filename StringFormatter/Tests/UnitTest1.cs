using Core;

namespace Tests
{
	public class Tests
	{
		class User
		{
			public string FirstName { get; }
			public string LastName { get; }
			public int Age { get; }
			public string University { get; }

			public User(string firstName, string lastName, int age, string university)
			{
				FirstName = firstName;
				LastName = lastName;
				Age = age;
				University = university;
			}

			public string GetGreeting()
			{
				return StringFormatter.Shared.Format("Hello, {FirstName} {LastName}!", this);
			}

			public string GetOrderString()
			{
				return StringFormatter.Shared.Format("{FirstName} {LastName} your age is - {Age}", this);
			}

			public string GetUniversity()
			{
                		return StringFormatter.Shared.Format("Your university is - {University}", this);
            		}

		}

		class CheckSizeTest
		{
			private int size;
			public bool isSize = false;
			public string StrSize { get; set; }
			

			public CheckSizeTest(int size)
			{
				this.size = size;

			}

			public void SetStrSize()
			{
				StrSize = StringFormatter.Shared.Format("{{size}}  {isSize}", this);
			}
		}

		[Test]
		public void PublicStringTest()
		{
			var user = new User("Alexander", "Marjin", 19, "BSUIR");

			var fullName = user.GetOrderString();

			Assert.That(fullName, Is.EqualTo("Alexander Marjin your age is - 19"));
		}


		[Test]
		public void PublicPropertyAccessTest()
		{
			var user = new User("Alexander", "Marjin", 10, "BNTU");

			var result = user.GetGreeting();

			Assert.That(result, Is.EqualTo("Hello, Alexander Marjin!"));
		}

        [Test]
        public void PublicUniversityTest()
        {
            var user = new User("Alexander", "Marjin", 20, "BSUIR");

			var result = user.GetUniversity();

            Assert.That(result, Is.EqualTo("Your university is - BSUIR"));
        }

        [Test]
		public void FieldAccessTest()
		{
			var test = new CheckSizeTest(10);

			string result = StringFormatter.Shared.Format("size is {size}", test);

			Assert.That(result, Is.EqualTo("size is 10"));
		}

		[Test]
		public void InvalidSyntaxTest1()
		{
			var test = new CheckSizeTest(10);

			Assert.Throws<FormatException>(() => StringFormatter.Shared.Format("size is {{size} or {size}}", test));
		}

		[Test]
		public void CommentTest()
		{
			var test = new CheckSizeTest(10);

			var result = StringFormatter.Shared.Format("{{size}}  {size}", test);

			Assert.That(result, Is.EqualTo("{size}  10"));
		}

		[Test]
		public void MultiThreadTest()
		{
			var test = new CheckSizeTest(10);
			var test2 = new CheckSizeTest(15) { isSize = true };
			string a = StringFormatter.Shared.Format("{{size}}  {size}", test);
			string thread1Str = "";
			string thread2Str = "";

			var thread1 = new Thread(() =>
			{
				thread1Str = StringFormatter.Shared.Format("{{size}}  {size}", test);

				test.SetStrSize();
			});

			var thread2 = new Thread(() =>
			{
				thread2Str = StringFormatter.Shared.Format("{{size}}  {size}", test2);

				test2.SetStrSize();
			});

			thread1.Start();
			thread2.Start();
			thread1.Join();
			thread2.Join();
			Assert.Multiple(() =>
			{
				Assert.That(a, Is.EqualTo("{size}  10"));
				Assert.That(thread1Str, Is.EqualTo("{size}  10"));
				Assert.That(thread2Str, Is.EqualTo("{size}  15"));
				Assert.That(test.StrSize, Is.EqualTo("{size}  False"));
				Assert.That(test2.StrSize, Is.EqualTo("{size}  True"));
			});
		}
	}
}
