/*
The MIT License (MIT)
Copyright (c) 2007 - 2021 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Microting.eFormInventoryBase.Unit.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using eForm.Infrastructure.Constants;
    using Infrastructure.Const;
    using Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    public class InventoryItemUTest : DbTestFixture
    {
        [Test]
        public async Task InventoryItem_Save_DoesSave()
        {
            // Arrange
            var itemType = new ItemType
            {
                Name = Guid.NewGuid().ToString(),
                BaseUnitOfMeasure = Guid.NewGuid().ToString(),
                Comment = Guid.NewGuid().ToString(),
                CostingMethod = CostingMethod.Lifo,
                Description = Guid.NewGuid().ToString(),
                EformId = 1,
                CreatedByUserId = 1,
                GrossWeight = 1,
                GtinEanUpc = Guid.NewGuid().ToString(),
                LastPhysicalInventoryDate = new DateTime(2050, 1, 1, 1, 1, 1),
                NetWeight = 1,
                No = Guid.NewGuid().ToString(),
                ProfitPercent = 1,
                Region = 1,
                RiskDescription = Guid.NewGuid().ToString(),
                SalesUnitOfMeasure = UnitOfMeasure.Liter,
                StandardCost = 1,
                Usage = Guid.NewGuid().ToString(),
                UpdatedByUserId = 1,
                UnitVolume = 1,
                UnitPrice = 1,
                UnitCost = 1,
            };

            await itemType.Create(DbContext);

            var item = new Item
            {
                SN = Guid.NewGuid().ToString(),
                CreatedByUserId = 1,
                UpdatedByUserId = 1,
                Available = true,
                ExpirationDate = new DateTime(2050, 1, 1, 1, 1, 1),
                Location = Guid.NewGuid().ToString(),
                CustomerId = 1,
                ItemTypeId = itemType.Id,
            };

            // Act
            await item.Create(DbContext);


            var items = DbContext.Items
                .AsNoTracking()
                .ToList();

            var itemVersions = DbContext.ItemVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(item.CreatedByUserId, items[0].CreatedByUserId);
            Assert.AreEqual(item.UpdatedByUserId, items[0].UpdatedByUserId);
            Assert.AreEqual(item.Available, items[0].Available);
            Assert.AreEqual(item.ItemTypeId, items[0].ItemTypeId);
            Assert.AreEqual(item.CustomerId, items[0].CustomerId);
            Assert.AreEqual(item.Location, items[0].Location);
            Assert.AreEqual(item.ExpirationDate, items[0].ExpirationDate);
            Assert.AreEqual(item.SN, items[0].SN);
            Assert.AreEqual(1, items[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, items[0].WorkflowState);
            Assert.AreEqual(item.WorkflowState, items[0].WorkflowState);


            // versions
            Assert.AreEqual(1, itemVersions.Count);
            Assert.AreEqual(item.CreatedByUserId, itemVersions[0].CreatedByUserId);
            Assert.AreEqual(item.UpdatedByUserId, itemVersions[0].UpdatedByUserId);
            Assert.AreEqual(item.CreatedByUserId, itemVersions[0].CreatedByUserId);
            Assert.AreEqual(item.UpdatedByUserId, itemVersions[0].UpdatedByUserId);
            Assert.AreEqual(item.Available, itemVersions[0].Available);
            Assert.AreEqual(item.ItemTypeId, itemVersions[0].ItemTypeId);
            Assert.AreEqual(item.CustomerId, itemVersions[0].CustomerId);
            Assert.AreEqual(item.Location, itemVersions[0].Location);
            Assert.AreEqual(item.ExpirationDate, itemVersions[0].ExpirationDate);
            Assert.AreEqual(item.SN, itemVersions[0].SN);
            Assert.AreEqual(item.Id, itemVersions[0].ItemTypeId);
            Assert.AreEqual(item.WorkflowState, itemVersions[0].WorkflowState);
            Assert.AreEqual(1, itemVersions[0].Version);
        }

        [Test]
        public async Task InventoryItem_Update_DoesUpdate()
        {
            // Arrange
            var itemType = new ItemType
            {
                Name = Guid.NewGuid().ToString(),
                BaseUnitOfMeasure = Guid.NewGuid().ToString(),
                Comment = Guid.NewGuid().ToString(),
                CostingMethod = CostingMethod.Lifo,
                Description = Guid.NewGuid().ToString(),
                EformId = 1,
                CreatedByUserId = 1,
                GrossWeight = 1,
                GtinEanUpc = Guid.NewGuid().ToString(),
                LastPhysicalInventoryDate = new DateTime(2050, 1, 1, 1, 1, 1),
                NetWeight = 1,
                No = Guid.NewGuid().ToString(),
                ProfitPercent = 1,
                Region = 1,
                RiskDescription = Guid.NewGuid().ToString(),
                SalesUnitOfMeasure = UnitOfMeasure.Liter,
                StandardCost = 1,
                Usage = Guid.NewGuid().ToString(),
                UpdatedByUserId = 1,
                UnitVolume = 1,
                UnitPrice = 1,
                UnitCost = 1,
            };

            await itemType.Create(DbContext);

            var item = new Item
            {
                SN = Guid.NewGuid().ToString(),
                CreatedByUserId = 1,
                UpdatedByUserId = 1,
                Available = true,
                ExpirationDate = new DateTime(2050, 1, 1, 1, 1, 1),
                Location = Guid.NewGuid().ToString(),
                CustomerId = 1,
                ItemTypeId = itemType.Id,
            };

            // Act
            await item.Create(DbContext);

            var oldInventoryItemFromDb = DbContext.Items
                .AsNoTracking()
                .First();

            item.Available = false;
            item.CustomerId = 0;
            item.SN = Guid.NewGuid().ToString();
            item.ItemTypeId = null;

            await item.Update(DbContext);


            var inventoryItemFromDb = DbContext.Items
                .AsNoTracking()
                .First();

            var inventoryItemVersions = DbContext.ItemVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.AreEqual(item.CreatedByUserId, inventoryItemFromDb.CreatedByUserId);
            Assert.AreEqual(item.UpdatedByUserId, inventoryItemFromDb.UpdatedByUserId);
            Assert.AreEqual(item.Available, inventoryItemFromDb.Available);
            Assert.AreEqual(item.ItemTypeId, inventoryItemFromDb.ItemTypeId);
            Assert.AreEqual(item.CustomerId, inventoryItemFromDb.CustomerId);
            Assert.AreEqual(item.Location, inventoryItemFromDb.Location);
            Assert.AreEqual(item.ExpirationDate, inventoryItemFromDb.ExpirationDate);
            Assert.AreEqual(item.SN, inventoryItemFromDb.SN);
            Assert.AreEqual(2, inventoryItemFromDb.Version);
            Assert.AreEqual(item.WorkflowState, inventoryItemFromDb.WorkflowState);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemFromDb.WorkflowState);

            // versions
            Assert.AreEqual(2, inventoryItemVersions.Count);
            Assert.AreEqual(oldInventoryItemFromDb.CreatedByUserId, inventoryItemVersions[0].CreatedByUserId);
            Assert.AreEqual(oldInventoryItemFromDb.UpdatedByUserId, inventoryItemVersions[0].UpdatedByUserId);
            Assert.AreEqual(oldInventoryItemFromDb.Available, inventoryItemVersions[0].Available);
            Assert.AreEqual(oldInventoryItemFromDb.ItemTypeId, inventoryItemVersions[0].ItemTypeId);
            Assert.AreEqual(oldInventoryItemFromDb.CustomerId, inventoryItemVersions[0].CustomerId);
            Assert.AreEqual(oldInventoryItemFromDb.Location, inventoryItemVersions[0].Location);
            Assert.AreEqual(oldInventoryItemFromDb.ExpirationDate, inventoryItemVersions[0].ExpirationDate);
            Assert.AreEqual(oldInventoryItemFromDb.SN, inventoryItemVersions[0].SN);
            Assert.AreEqual(oldInventoryItemFromDb.WorkflowState, inventoryItemVersions[0].WorkflowState);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemVersions[0].WorkflowState);
            Assert.AreEqual(1, inventoryItemVersions[0].Version);

            Assert.AreEqual(item.CreatedByUserId, inventoryItemVersions[1].CreatedByUserId);
            Assert.AreEqual(item.UpdatedByUserId, inventoryItemVersions[1].UpdatedByUserId);
            Assert.AreEqual(item.Available, inventoryItemVersions[1].Available);
            Assert.AreEqual(item.ItemTypeId, inventoryItemVersions[1].ItemTypeId);
            Assert.AreEqual(item.Location, inventoryItemVersions[1].Location);
            Assert.AreEqual(item.CustomerId, inventoryItemVersions[1].CustomerId);
            Assert.AreEqual(item.ExpirationDate, inventoryItemVersions[1].ExpirationDate);
            Assert.AreEqual(item.SN, inventoryItemVersions[1].SN);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemVersions[1].WorkflowState);
            Assert.AreEqual(item.WorkflowState, inventoryItemVersions[1].WorkflowState);
            Assert.AreEqual(2, inventoryItemVersions[1].Version);
        }

        [Test]
        public async Task InventoryItem_Delete_DoesDelete()
        {
            // Arrange
            var itemType = new ItemType
            {
                Name = Guid.NewGuid().ToString(),
                BaseUnitOfMeasure = Guid.NewGuid().ToString(),
                Comment = Guid.NewGuid().ToString(),
                CostingMethod = CostingMethod.Lifo,
                Description = Guid.NewGuid().ToString(),
                EformId = 1,
                CreatedByUserId = 1,
                GrossWeight = 1,
                GtinEanUpc = Guid.NewGuid().ToString(),
                LastPhysicalInventoryDate = new DateTime(2050, 1, 1, 1, 1, 1),
                NetWeight = 1,
                No = Guid.NewGuid().ToString(),
                ProfitPercent = 1,
                Region = 1,
                RiskDescription = Guid.NewGuid().ToString(),
                SalesUnitOfMeasure = UnitOfMeasure.Liter,
                StandardCost = 1,
                Usage = Guid.NewGuid().ToString(),
                UpdatedByUserId = 1,
                UnitVolume = 1,
                UnitPrice = 1,
                UnitCost = 1,
            };

            await itemType.Create(DbContext);

            var item = new Item
            {
                SN = Guid.NewGuid().ToString(),
                CreatedByUserId = 1,
                UpdatedByUserId = 1,
                Available = true,
                ExpirationDate = new DateTime(2050, 1, 1, 1, 1, 1),
                Location = Guid.NewGuid().ToString(),
                CustomerId = 1,
                ItemTypeId = itemType.Id,
            };

            // Act
            await item.Create(DbContext);

            var oldInventoryItemFromDb = DbContext.Items
                .AsNoTracking()
                .First();

            await item.Delete(DbContext);

            var inventoryItemFromDb = DbContext.Items
                .AsNoTracking()
                .First();

            var inventoryItemVersions = DbContext.ItemVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.AreEqual(item.CreatedByUserId, inventoryItemFromDb.CreatedByUserId);
            Assert.AreEqual(item.UpdatedByUserId, inventoryItemFromDb.UpdatedByUserId);
            Assert.AreEqual(item.Available, inventoryItemFromDb.Available);
            Assert.AreEqual(item.ItemTypeId, inventoryItemFromDb.ItemTypeId);
            Assert.AreEqual(item.CustomerId, inventoryItemFromDb.CustomerId);
            Assert.AreEqual(item.Location, inventoryItemFromDb.Location);
            Assert.AreEqual(item.ExpirationDate, inventoryItemFromDb.ExpirationDate);
            Assert.AreEqual(item.SN, inventoryItemFromDb.SN);
            Assert.AreEqual(2, inventoryItemFromDb.Version);
            Assert.AreEqual(item.WorkflowState, inventoryItemFromDb.WorkflowState);
            Assert.AreEqual(Constants.WorkflowStates.Removed, inventoryItemFromDb.WorkflowState);

            // versions
            Assert.AreEqual(2, inventoryItemVersions.Count);
            Assert.AreEqual(oldInventoryItemFromDb.CreatedByUserId, inventoryItemVersions[0].CreatedByUserId);
            Assert.AreEqual(oldInventoryItemFromDb.UpdatedByUserId, inventoryItemVersions[0].UpdatedByUserId);
            Assert.AreEqual(oldInventoryItemFromDb.Available, inventoryItemVersions[0].Available);
            Assert.AreEqual(oldInventoryItemFromDb.ItemTypeId, inventoryItemVersions[0].ItemTypeId);
            Assert.AreEqual(oldInventoryItemFromDb.CustomerId, inventoryItemVersions[0].CustomerId);
            Assert.AreEqual(oldInventoryItemFromDb.Location, inventoryItemVersions[0].Location);
            Assert.AreEqual(oldInventoryItemFromDb.ExpirationDate, inventoryItemVersions[0].ExpirationDate);
            Assert.AreEqual(oldInventoryItemFromDb.SN, inventoryItemVersions[0].SN);
            Assert.AreEqual(oldInventoryItemFromDb.WorkflowState, inventoryItemVersions[0].WorkflowState);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemVersions[0].WorkflowState);
            Assert.AreEqual(1, inventoryItemVersions[0].Version);

            Assert.AreEqual(item.CreatedByUserId, inventoryItemVersions[1].CreatedByUserId);
            Assert.AreEqual(item.UpdatedByUserId, inventoryItemVersions[1].UpdatedByUserId);
            Assert.AreEqual(item.Available, inventoryItemVersions[1].Available);
            Assert.AreEqual(item.ItemTypeId, inventoryItemVersions[1].ItemTypeId);
            Assert.AreEqual(item.Location, inventoryItemVersions[1].Location);
            Assert.AreEqual(item.CustomerId, inventoryItemVersions[1].CustomerId);
            Assert.AreEqual(item.ExpirationDate, inventoryItemVersions[1].ExpirationDate);
            Assert.AreEqual(item.SN, inventoryItemVersions[1].SN);
            Assert.AreEqual(Constants.WorkflowStates.Removed, inventoryItemVersions[1].WorkflowState);
            Assert.AreEqual(item.WorkflowState, inventoryItemVersions[1].WorkflowState);
            Assert.AreEqual(2, inventoryItemVersions[1].Version);
        }
    }
}