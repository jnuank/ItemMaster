using System;
namespace Domain.Model.Items
{
    /// <summary>
    /// 商品エンティティ
    /// </summary>
    public class Item
    {
        // サロゲートキーを想定
        private string id;
        private SkuCode code;
        private ValidTerm validTerm;

        public SkuCode Code { get; }
        public ValidTerm Term { get; }

        public Item(SkuCode code, ValidTerm validTerm)
        {
            this.id = Guid.NewGuid().ToString();
            this.code = code;
            this.validTerm = validTerm;
        }

        // SKUコードの変更
        public void ChangeSkuCode(SkuCode newSkuCode)
        {
            this.code = newSkuCode;
        }

        // 生存期間の変更
        public void ChangeValidTerm(ValidTerm newTerm)
        {
            this.validTerm = newTerm;
        }
    }
}
