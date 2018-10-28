using System;
namespace Domain.Model.Items
{
    public interface IItemRepository
    {
        void Save(Item item);
        Item Find(SkuCode code);
    }
}
