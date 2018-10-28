using System;
namespace Domain.Model.Items
{
    /// <summary>
    /// 生存期間 値オブジェクト
    /// </summary>
    public class ValidTerm
    {
        public DateTime FromDate { get; }
        public DateTime ToDate { get; }

        public ValidTerm(DateTime fromdate, DateTime todate)
        {
            if (fromdate > todate) throw new ArgumentException("開始日付が終了日付より上回っています");

            this.FromDate = fromdate;
            this.ToDate = todate;
        }

        // 期間を表示
        public int Days()
        {
            return (ToDate - FromDate).Days;
        }

        // 期間が同じか
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            ValidTerm other = (ValidTerm)obj;

            return this.FromDate == other.FromDate && this.ToDate == other.ToDate;
        }

        // 期間が重なっているか
        public bool IsOverrap(ValidTerm other)
        {
            return other.FromDate <= this.ToDate && other.ToDate >= this.FromDate;
        }

        public override int GetHashCode()
        {
            var hashCode = -1138604303;
            hashCode = hashCode * -1521134295 + FromDate.GetHashCode();
            hashCode = hashCode * -1521134295 + ToDate.GetHashCode();
            return hashCode;
        }
    }
}
