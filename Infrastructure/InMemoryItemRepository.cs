using System;
using System.Collections.Generic;
using Domain.Model.Items;

namespace Infrastructure
{
    public class InMemoryItemRepository : IItemRepository
    {
        private Dictionary<>

        public InMemoryItemRepository()
        {
        }

        public Item Find(SkuCode code)
        {
            throw new NotImplementedException();
        }

        public void Save(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
