using System;
using System.Collections.Generic;

namespace Domain.Model.Items
{
    /// <summary>
    /// SKUコード値オブジェクト
    /// </summary>
    public class SkuCode
    {
        public string Value { get; }
        
        public SkuCode(string code)
        {
            // 値を入れる前に、文字数制限のチェックをする
            if (code.Length > 30) throw new ArgumentException("文字数制限を超えています");
            this.Value = code;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            var other = (SkuCode)obj;

            return this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
        }
    }
}
