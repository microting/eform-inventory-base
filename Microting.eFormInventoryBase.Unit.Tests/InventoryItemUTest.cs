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
            Assert.That(items.Count, Is.EqualTo(1));
            Assert.That(items[0].CreatedByUserId, Is.EqualTo(item.CreatedByUserId));
            Assert.That(items[0].UpdatedByUserId, Is.EqualTo(item.UpdatedByUserId));
            Assert.That(items[0].Available, Is.EqualTo(item.Available));
            Assert.That(items[0].ItemTypeId, Is.EqualTo(item.ItemTypeId));
            Assert.That(items[0].CustomerId, Is.EqualTo(item.CustomerId));
            Assert.That(items[0].Location, Is.EqualTo(item.Location));
            Assert.That(items[0].ExpirationDate, Is.EqualTo(item.ExpirationDate));
            Assert.That(items[0].SN, Is.EqualTo(item.SN));
            Assert.That(items[0].Version, Is.EqualTo(1));
            Assert.That(items[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(items[0].WorkflowState, Is.EqualTo(item.WorkflowState));


            // versions
            Assert.That(itemVersions.Count, Is.EqualTo(1));
            Assert.That(itemVersions[0].CreatedByUserId, Is.EqualTo(item.CreatedByUserId));
            Assert.That(itemVersions[0].UpdatedByUserId, Is.EqualTo(item.UpdatedByUserId));
            Assert.That(itemVersions[0].Available, Is.EqualTo(item.Available));
            Assert.That(itemVersions[0].ItemTypeId, Is.EqualTo(item.ItemTypeId));
            Assert.That(itemVersions[0].CustomerId, Is.EqualTo(item.CustomerId));
            Assert.That(itemVersions[0].Location, Is.EqualTo(item.Location));
            Assert.That(itemVersions[0].ExpirationDate, Is.EqualTo(item.ExpirationDate));
            Assert.That(itemVersions[0].SN, Is.EqualTo(item.SN));
            Assert.That(itemVersions[0].ItemTypeId, Is.EqualTo(item.Id));
            Assert.That(itemVersions[0].WorkflowState, Is.EqualTo(item.WorkflowState));
            Assert.That(itemVersions[0].Version, Is.EqualTo(1));
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
            Assert.That(inventoryItemFromDb.CreatedByUserId, Is.EqualTo(item.CreatedByUserId));
            Assert.That(inventoryItemFromDb.UpdatedByUserId, Is.EqualTo(item.UpdatedByUserId));
            Assert.That(inventoryItemFromDb.Available, Is.EqualTo(item.Available));
            Assert.That(inventoryItemFromDb.ItemTypeId, Is.EqualTo(item.ItemTypeId));
            Assert.That(inventoryItemFromDb.CustomerId, Is.EqualTo(item.CustomerId));
            Assert.That(inventoryItemFromDb.Location, Is.EqualTo(item.Location));
            Assert.That(inventoryItemFromDb.ExpirationDate, Is.EqualTo(item.ExpirationDate));
            Assert.That(inventoryItemFromDb.SN, Is.EqualTo(item.SN));
            Assert.That(inventoryItemFromDb.Version, Is.EqualTo(2));
            Assert.That(inventoryItemFromDb.WorkflowState, Is.EqualTo(item.WorkflowState));
            Assert.That(inventoryItemFromDb.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));

            // versions
            Assert.That(inventoryItemVersions.Count, Is.EqualTo(2));
            Assert.That(inventoryItemVersions[0].CreatedByUserId, Is.EqualTo(oldInventoryItemFromDb.CreatedByUserId));
            Assert.That(inventoryItemVersions[0].UpdatedByUserId, Is.EqualTo(oldInventoryItemFromDb.UpdatedByUserId));
            Assert.That(inventoryItemVersions[0].Available, Is.EqualTo(oldInventoryItemFromDb.Available));
            Assert.That(inventoryItemVersions[0].ItemTypeId, Is.EqualTo(oldInventoryItemFromDb.ItemTypeId));
            Assert.That(inventoryItemVersions[0].CustomerId, Is.EqualTo(oldInventoryItemFromDb.CustomerId));
            Assert.That(inventoryItemVersions[0].Location, Is.EqualTo(oldInventoryItemFromDb.Location));
            Assert.That(inventoryItemVersions[0].ExpirationDate, Is.EqualTo(oldInventoryItemFromDb.ExpirationDate));
            Assert.That(inventoryItemVersions[0].SN, Is.EqualTo(oldInventoryItemFromDb.SN));
            Assert.That(inventoryItemVersions[0].WorkflowState, Is.EqualTo(oldInventoryItemFromDb.WorkflowState));
            Assert.That(inventoryItemVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemVersions[0].Version, Is.EqualTo(1));

            Assert.That(inventoryItemVersions[1].CreatedByUserId, Is.EqualTo(item.CreatedByUserId));
            Assert.That(inventoryItemVersions[1].UpdatedByUserId, Is.EqualTo(item.UpdatedByUserId));
            Assert.That(inventoryItemVersions[1].Available, Is.EqualTo(item.Available));
            Assert.That(inventoryItemVersions[1].ItemTypeId, Is.EqualTo(item.ItemTypeId));
            Assert.That(inventoryItemVersions[1].Location, Is.EqualTo(item.Location));
            Assert.That(inventoryItemVersions[1].CustomerId, Is.EqualTo(item.CustomerId));
            Assert.That(inventoryItemVersions[1].ExpirationDate, Is.EqualTo(item.ExpirationDate));
            Assert.That(inventoryItemVersions[1].SN, Is.EqualTo(item.SN));
            Assert.That(inventoryItemVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemVersions[1].WorkflowState, Is.EqualTo(item.WorkflowState));
            Assert.That(inventoryItemVersions[1].Version, Is.EqualTo(2));
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
            Assert.That(inventoryItemFromDb.CreatedByUserId, Is.EqualTo(item.CreatedByUserId));
            Assert.That(inventoryItemFromDb.UpdatedByUserId, Is.EqualTo(item.UpdatedByUserId));
            Assert.That(inventoryItemFromDb.Available, Is.EqualTo(item.Available));
            Assert.That(inventoryItemFromDb.ItemTypeId, Is.EqualTo(item.ItemTypeId));
            Assert.That(inventoryItemFromDb.CustomerId, Is.EqualTo(item.CustomerId));
            Assert.That(inventoryItemFromDb.Location, Is.EqualTo(item.Location));
            Assert.That(inventoryItemFromDb.ExpirationDate, Is.EqualTo(item.ExpirationDate));
            Assert.That(inventoryItemFromDb.SN, Is.EqualTo(item.SN));
            Assert.That(inventoryItemFromDb.Version, Is.EqualTo(2));
            Assert.That(inventoryItemFromDb.WorkflowState, Is.EqualTo(item.WorkflowState));
            Assert.That(inventoryItemFromDb.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));

            // versions
            Assert.That(inventoryItemVersions.Count, Is.EqualTo(2));
            Assert.That(inventoryItemVersions[0].CreatedByUserId, Is.EqualTo(oldInventoryItemFromDb.CreatedByUserId));
            Assert.That(inventoryItemVersions[0].UpdatedByUserId, Is.EqualTo(oldInventoryItemFromDb.UpdatedByUserId));
            Assert.That(inventoryItemVersions[0].Available, Is.EqualTo(oldInventoryItemFromDb.Available));
            Assert.That(inventoryItemVersions[0].ItemTypeId, Is.EqualTo(oldInventoryItemFromDb.ItemTypeId));
            Assert.That(inventoryItemVersions[0].CustomerId, Is.EqualTo(oldInventoryItemFromDb.CustomerId));
            Assert.That(inventoryItemVersions[0].Location, Is.EqualTo(oldInventoryItemFromDb.Location));
            Assert.That(inventoryItemVersions[0].ExpirationDate, Is.EqualTo(oldInventoryItemFromDb.ExpirationDate));
            Assert.That(inventoryItemVersions[0].SN, Is.EqualTo(oldInventoryItemFromDb.SN));
            Assert.That(inventoryItemVersions[0].WorkflowState, Is.EqualTo(oldInventoryItemFromDb.WorkflowState));
            Assert.That(inventoryItemVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemVersions[0].Version, Is.EqualTo(1));

            Assert.That(inventoryItemVersions[1].CreatedByUserId, Is.EqualTo(item.CreatedByUserId));
            Assert.That(inventoryItemVersions[1].UpdatedByUserId, Is.EqualTo(item.UpdatedByUserId));
            Assert.That(inventoryItemVersions[1].Available, Is.EqualTo(item.Available));
            Assert.That(inventoryItemVersions[1].ItemTypeId, Is.EqualTo(item.ItemTypeId));
            Assert.That(inventoryItemVersions[1].Location, Is.EqualTo(item.Location));
            Assert.That(inventoryItemVersions[1].CustomerId, Is.EqualTo(item.CustomerId));
            Assert.That(inventoryItemVersions[1].ExpirationDate, Is.EqualTo(item.ExpirationDate));
            Assert.That(inventoryItemVersions[1].SN, Is.EqualTo(item.SN));
            Assert.That(inventoryItemVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(inventoryItemVersions[1].WorkflowState, Is.EqualTo(item.WorkflowState));
            Assert.That(inventoryItemVersions[1].Version, Is.EqualTo(2));
        }
    }
}