using NUnit.Framework;
using System;
using Domain.Model.Items;

namespace Domain.Test.Model.Items
{
    [TestFixture()]
    public class ValidTermTest
    {
        [Test()]
        public void 七日と出ること()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 8));

            Assert.AreEqual(7, term.Days());
        }

        [Test()]
        public void 三六六日と出ること()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2019, 10, 2));

            Assert.AreEqual(366, term.Days());

        }

        [Test()]
        [ExpectedException(typeof(ArgumentException))]
        public void 日付が逆転しているエラーが出ること()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 3), new DateTime(2018, 10, 2));
        }

        [Test()]
        public void 期間がゼロ日と出ること()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 2), new DateTime(2018, 10, 2));

            Assert.AreEqual(0, term.Days());
        }

        [Test()]
        public void 値が等価であること()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 31));
            var term2 = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 31));

            Assert.IsTrue(term.Equals(term2));
        }

        [Test()]
        public void 値が不等価であること()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 30));
            var term2 = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 31));

            Assert.IsFalse(term.Equals(term2));
        }

        [Test()]
        public void 期間が重なっているか()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 30));
            var term2 = new ValidTerm(new DateTime(2018, 10, 30), new DateTime(2018, 11, 30));

            Assert.IsTrue(term.IsOverrap(term2));
        }

        [Test()]
        public void 期間が重なっているか2()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 30));
            var term2 = new ValidTerm(new DateTime(2018, 9, 9), new DateTime(2018, 10, 1));

            Assert.IsTrue(term.IsOverrap(term2));
        }

        [Test()]
        public void 期間が重なっているか3()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 30));
            var term2 = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 30));

            Assert.IsTrue(term.IsOverrap(term2));
        }

        [Test()]
        public void 期間が重なっていないか()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 30));
            var term2 = new ValidTerm(new DateTime(2018, 10, 31), new DateTime(2018, 11, 30));

            Assert.IsFalse(term.IsOverrap(term2));
        }

        [Test()]
        public void 期間が重なっていないか2()
        {
            var term = new ValidTerm(new DateTime(2018, 10, 1), new DateTime(2018, 10, 30));
            var term2 = new ValidTerm(new DateTime(2018, 9, 1), new DateTime(2018, 9, 30));

            Assert.IsFalse(term.IsOverrap(term2));
        }
    }
}
