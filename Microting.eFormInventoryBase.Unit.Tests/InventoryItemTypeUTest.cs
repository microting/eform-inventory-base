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

    public class InventoryItemTypeUTest : DbTestFixture
    {
        [Test]
        public async Task InventoryItemType_Save_DoesSave()
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

            // Act
            await itemType.Create(DbContext);

            var itemTypes = DbContext.ItemTypes
                .AsNoTracking()
                .ToList();

            var itemTypeVersions = DbContext.ItemTypeVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.That(itemTypes.Count, Is.EqualTo(1));
            Assert.That(itemTypes[0].CreatedByUserId, Is.EqualTo(itemType.CreatedByUserId));
            Assert.That(itemTypes[0].UpdatedByUserId, Is.EqualTo(itemType.UpdatedByUserId));
            Assert.That(itemTypes[0].Name, Is.EqualTo(itemType.Name));
            Assert.That(itemTypes[0].BaseUnitOfMeasure, Is.EqualTo(itemType.BaseUnitOfMeasure));
            Assert.That(itemTypes[0].Comment, Is.EqualTo(itemType.Comment));
            Assert.That(itemTypes[0].CostingMethod, Is.EqualTo(itemType.CostingMethod));
            Assert.That(itemTypes[0].Description, Is.EqualTo(itemType.Description));
            Assert.That(itemTypes[0].EformId, Is.EqualTo(itemType.EformId));
            Assert.That(itemTypes[0].GrossWeight, Is.EqualTo(itemType.GrossWeight));
            Assert.That(itemTypes[0].GtinEanUpc, Is.EqualTo(itemType.GtinEanUpc));
            Assert.That(itemTypes[0].LastPhysicalInventoryDate, Is.EqualTo(itemType.LastPhysicalInventoryDate));
            Assert.That(itemTypes[0].NetWeight, Is.EqualTo(itemType.NetWeight));
            Assert.That(itemTypes[0].No, Is.EqualTo(itemType.No));
            Assert.That(itemTypes[0].ProfitPercent, Is.EqualTo(itemType.ProfitPercent));
            Assert.That(itemTypes[0].Region, Is.EqualTo(itemType.Region));
            Assert.That(itemTypes[0].RiskDescription, Is.EqualTo(itemType.RiskDescription));
            Assert.That(itemTypes[0].SalesUnitOfMeasure, Is.EqualTo(itemType.SalesUnitOfMeasure));
            Assert.That(itemTypes[0].StandardCost, Is.EqualTo(itemType.StandardCost));
            Assert.That(itemTypes[0].Usage, Is.EqualTo(itemType.Usage));
            Assert.That(itemTypes[0].UnitVolume, Is.EqualTo(itemType.UnitVolume));
            Assert.That(itemTypes[0].UnitPrice, Is.EqualTo(itemType.UnitPrice));
            Assert.That(itemTypes[0].UnitCost, Is.EqualTo(itemType.UnitCost));
            Assert.That(itemTypes[0].Version, Is.EqualTo(1));
            Assert.That(itemTypes[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(itemTypes[0].WorkflowState, Is.EqualTo(itemType.WorkflowState));


            // versions
            Assert.That(itemTypeVersions.Count, Is.EqualTo(1));
            Assert.That(itemTypeVersions[0].CreatedByUserId, Is.EqualTo(itemType.CreatedByUserId));
            Assert.That(itemTypeVersions[0].UpdatedByUserId, Is.EqualTo(itemType.UpdatedByUserId));
            Assert.That(itemTypeVersions[0].Name, Is.EqualTo(itemType.Name));
            Assert.That(itemTypeVersions[0].BaseUnitOfMeasure, Is.EqualTo(itemType.BaseUnitOfMeasure));
            Assert.That(itemTypeVersions[0].Comment, Is.EqualTo(itemType.Comment));
            Assert.That(itemTypeVersions[0].CostingMethod, Is.EqualTo(itemType.CostingMethod));
            Assert.That(itemTypeVersions[0].Description, Is.EqualTo(itemType.Description));
            Assert.That(itemTypeVersions[0].EformId, Is.EqualTo(itemType.EformId));
            Assert.That(itemTypeVersions[0].GrossWeight, Is.EqualTo(itemType.GrossWeight));
            Assert.That(itemTypeVersions[0].GtinEanUpc, Is.EqualTo(itemType.GtinEanUpc));
            Assert.That(itemTypeVersions[0].LastPhysicalInventoryDate, Is.EqualTo(itemType.LastPhysicalInventoryDate));
            Assert.That(itemTypeVersions[0].NetWeight, Is.EqualTo(itemType.NetWeight));
            Assert.That(itemTypeVersions[0].No, Is.EqualTo(itemType.No));
            Assert.That(itemTypeVersions[0].ProfitPercent, Is.EqualTo(itemType.ProfitPercent));
            Assert.That(itemTypeVersions[0].Region, Is.EqualTo(itemType.Region));
            Assert.That(itemTypeVersions[0].RiskDescription, Is.EqualTo(itemType.RiskDescription));
            Assert.That(itemTypeVersions[0].SalesUnitOfMeasure, Is.EqualTo(itemType.SalesUnitOfMeasure));
            Assert.That(itemTypeVersions[0].StandardCost, Is.EqualTo(itemType.StandardCost));
            Assert.That(itemTypeVersions[0].Usage, Is.EqualTo(itemType.Usage));
            Assert.That(itemTypeVersions[0].UnitVolume, Is.EqualTo(itemType.UnitVolume));
            Assert.That(itemTypeVersions[0].UnitPrice, Is.EqualTo(itemType.UnitPrice));
            Assert.That(itemTypeVersions[0].UnitCost, Is.EqualTo(itemType.UnitCost));
            Assert.That(itemTypeVersions[0].ItemTypeId, Is.EqualTo(itemType.Id));
            Assert.That(itemTypeVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(itemTypeVersions[0].WorkflowState, Is.EqualTo(itemType.WorkflowState));
            Assert.That(itemTypeVersions[0].Version, Is.EqualTo(1));
        }

        [Test]
        public async Task InventoryItemType_Update_DoesUpdate()
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

            // Act
            await itemType.Create(DbContext);

            var oldInventoryItemTypeFromDb = DbContext.ItemTypes
                .AsNoTracking()
                .First();

            itemType.Name = Guid.NewGuid().ToString();
            itemType.BaseUnitOfMeasure = Guid.NewGuid().ToString();
            itemType.Comment = Guid.NewGuid().ToString();
            itemType.CostingMethod = CostingMethod.Lifo;
            itemType.Description = Guid.NewGuid().ToString();
            itemType.EformId = 1;
            itemType.CreatedByUserId = 1;
            itemType.UpdatedByUserId = 1;
            itemType.GrossWeight = 1;
            itemType.GtinEanUpc = Guid.NewGuid().ToString();
            itemType.LastPhysicalInventoryDate = new DateTime(2051, 1, 1, 1, 1, 1);
            itemType.NetWeight = 1;
            itemType.No = Guid.NewGuid().ToString();
            itemType.ProfitPercent = 1;
            itemType.Region = 1;
            itemType.RiskDescription = Guid.NewGuid().ToString();
            itemType.SalesUnitOfMeasure = UnitOfMeasure.Liter;
            itemType.StandardCost = 1;
            itemType.Usage = Guid.NewGuid().ToString();
            itemType.UpdatedByUserId = 1;
            itemType.UnitVolume = 1;
            itemType.UnitPrice = 1;
            itemType.UnitCost = 1;

            await itemType.Update(DbContext);


            var inventoryItemTypeFromDb = DbContext.ItemTypes
                .AsNoTracking()
                .ToList();

            var inventoryItemTypeVersions = DbContext.ItemTypeVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.That(inventoryItemTypeFromDb.Count, Is.EqualTo(1));
            Assert.That(inventoryItemTypeFromDb[0].CreatedByUserId, Is.EqualTo(itemType.CreatedByUserId));
            Assert.That(inventoryItemTypeFromDb[0].UpdatedByUserId, Is.EqualTo(itemType.UpdatedByUserId));
            Assert.That(inventoryItemTypeFromDb[0].Name, Is.EqualTo(itemType.Name));
            Assert.That(inventoryItemTypeFromDb[0].BaseUnitOfMeasure, Is.EqualTo(itemType.BaseUnitOfMeasure));
            Assert.That(inventoryItemTypeFromDb[0].Comment, Is.EqualTo(itemType.Comment));
            Assert.That(inventoryItemTypeFromDb[0].CostingMethod, Is.EqualTo(itemType.CostingMethod));
            Assert.That(inventoryItemTypeFromDb[0].Description, Is.EqualTo(itemType.Description));
            Assert.That(inventoryItemTypeFromDb[0].EformId, Is.EqualTo(itemType.EformId));
            Assert.That(inventoryItemTypeFromDb[0].GrossWeight, Is.EqualTo(itemType.GrossWeight));
            Assert.That(inventoryItemTypeFromDb[0].GtinEanUpc, Is.EqualTo(itemType.GtinEanUpc));
            Assert.That(inventoryItemTypeFromDb[0].LastPhysicalInventoryDate, Is.EqualTo(itemType.LastPhysicalInventoryDate));
            Assert.That(inventoryItemTypeFromDb[0].NetWeight, Is.EqualTo(itemType.NetWeight));
            Assert.That(inventoryItemTypeFromDb[0].No, Is.EqualTo(itemType.No));
            Assert.That(inventoryItemTypeFromDb[0].ProfitPercent, Is.EqualTo(itemType.ProfitPercent));
            Assert.That(inventoryItemTypeFromDb[0].Region, Is.EqualTo(itemType.Region));
            Assert.That(inventoryItemTypeFromDb[0].RiskDescription, Is.EqualTo(itemType.RiskDescription));
            Assert.That(inventoryItemTypeFromDb[0].SalesUnitOfMeasure, Is.EqualTo(itemType.SalesUnitOfMeasure));
            Assert.That(inventoryItemTypeFromDb[0].StandardCost, Is.EqualTo(itemType.StandardCost));
            Assert.That(inventoryItemTypeFromDb[0].Usage, Is.EqualTo(itemType.Usage));
            Assert.That(inventoryItemTypeFromDb[0].UnitVolume, Is.EqualTo(itemType.UnitVolume));
            Assert.That(inventoryItemTypeFromDb[0].UnitPrice, Is.EqualTo(itemType.UnitPrice));
            Assert.That(inventoryItemTypeFromDb[0].UnitCost, Is.EqualTo(itemType.UnitCost));
            Assert.That(inventoryItemTypeFromDb[0].Version, Is.EqualTo(2));
            Assert.That(inventoryItemTypeFromDb[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemTypeFromDb[0].WorkflowState, Is.EqualTo(itemType.WorkflowState));

            // versions
            Assert.That(inventoryItemTypeVersions.Count, Is.EqualTo(2));
            Assert.That(inventoryItemTypeVersions[0].CreatedByUserId, Is.EqualTo(oldInventoryItemTypeFromDb.CreatedByUserId));
            Assert.That(inventoryItemTypeVersions[0].UpdatedByUserId, Is.EqualTo(oldInventoryItemTypeFromDb.UpdatedByUserId));
            Assert.That(inventoryItemTypeVersions[0].Name, Is.EqualTo(oldInventoryItemTypeFromDb.Name));
            Assert.That(inventoryItemTypeVersions[0].BaseUnitOfMeasure, Is.EqualTo(oldInventoryItemTypeFromDb.BaseUnitOfMeasure));
            Assert.That(inventoryItemTypeVersions[0].Comment, Is.EqualTo(oldInventoryItemTypeFromDb.Comment));
            Assert.That(inventoryItemTypeVersions[0].CostingMethod, Is.EqualTo(oldInventoryItemTypeFromDb.CostingMethod));
            Assert.That(inventoryItemTypeVersions[0].Description, Is.EqualTo(oldInventoryItemTypeFromDb.Description));
            Assert.That(inventoryItemTypeVersions[0].EformId, Is.EqualTo(oldInventoryItemTypeFromDb.EformId));
            Assert.That(inventoryItemTypeVersions[0].GrossWeight, Is.EqualTo(oldInventoryItemTypeFromDb.GrossWeight));
            Assert.That(inventoryItemTypeVersions[0].GtinEanUpc, Is.EqualTo(oldInventoryItemTypeFromDb.GtinEanUpc));
            Assert.That(inventoryItemTypeVersions[0].LastPhysicalInventoryDate, Is.EqualTo(oldInventoryItemTypeFromDb.LastPhysicalInventoryDate));
            Assert.That(inventoryItemTypeVersions[0].NetWeight, Is.EqualTo(oldInventoryItemTypeFromDb.NetWeight));
            Assert.That(inventoryItemTypeVersions[0].No, Is.EqualTo(oldInventoryItemTypeFromDb.No));
            Assert.That(inventoryItemTypeVersions[0].ProfitPercent, Is.EqualTo(oldInventoryItemTypeFromDb.ProfitPercent));
            Assert.That(inventoryItemTypeVersions[0].Region, Is.EqualTo(oldInventoryItemTypeFromDb.Region));
            Assert.That(inventoryItemTypeVersions[0].RiskDescription, Is.EqualTo(oldInventoryItemTypeFromDb.RiskDescription));
            Assert.That(inventoryItemTypeVersions[0].SalesUnitOfMeasure, Is.EqualTo(oldInventoryItemTypeFromDb.SalesUnitOfMeasure));
            Assert.That(inventoryItemTypeVersions[0].StandardCost, Is.EqualTo(oldInventoryItemTypeFromDb.StandardCost));
            Assert.That(inventoryItemTypeVersions[0].Usage, Is.EqualTo(oldInventoryItemTypeFromDb.Usage));
            Assert.That(inventoryItemTypeVersions[0].UnitVolume, Is.EqualTo(oldInventoryItemTypeFromDb.UnitVolume));
            Assert.That(inventoryItemTypeVersions[0].UnitPrice, Is.EqualTo(oldInventoryItemTypeFromDb.UnitPrice));
            Assert.That(inventoryItemTypeVersions[0].UnitCost, Is.EqualTo(oldInventoryItemTypeFromDb.UnitCost));
            Assert.That(inventoryItemTypeVersions[0].ItemTypeId, Is.EqualTo(oldInventoryItemTypeFromDb.Id));
            Assert.That(inventoryItemTypeVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemTypeVersions[0].WorkflowState, Is.EqualTo(oldInventoryItemTypeFromDb.WorkflowState));
            Assert.That(inventoryItemTypeVersions[0].Version, Is.EqualTo(1));

            Assert.That(inventoryItemTypeVersions[1].CreatedByUserId, Is.EqualTo(itemType.CreatedByUserId));
            Assert.That(inventoryItemTypeVersions[1].UpdatedByUserId, Is.EqualTo(itemType.UpdatedByUserId));
            Assert.That(inventoryItemTypeVersions[1].Name, Is.EqualTo(itemType.Name));
            Assert.That(inventoryItemTypeVersions[1].BaseUnitOfMeasure, Is.EqualTo(itemType.BaseUnitOfMeasure));
            Assert.That(inventoryItemTypeVersions[1].Comment, Is.EqualTo(itemType.Comment));
            Assert.That(inventoryItemTypeVersions[1].CostingMethod, Is.EqualTo(itemType.CostingMethod));
            Assert.That(inventoryItemTypeVersions[1].Description, Is.EqualTo(itemType.Description));
            Assert.That(inventoryItemTypeVersions[1].EformId, Is.EqualTo(itemType.EformId));
            Assert.That(inventoryItemTypeVersions[1].GrossWeight, Is.EqualTo(itemType.GrossWeight));
            Assert.That(inventoryItemTypeVersions[1].GtinEanUpc, Is.EqualTo(itemType.GtinEanUpc));
            Assert.That(inventoryItemTypeVersions[1].LastPhysicalInventoryDate, Is.EqualTo(itemType.LastPhysicalInventoryDate));
            Assert.That(inventoryItemTypeVersions[1].NetWeight, Is.EqualTo(itemType.NetWeight));
            Assert.That(inventoryItemTypeVersions[1].No, Is.EqualTo(itemType.No));
            Assert.That(inventoryItemTypeVersions[1].ProfitPercent, Is.EqualTo(itemType.ProfitPercent));
            Assert.That(inventoryItemTypeVersions[1].Region, Is.EqualTo(itemType.Region));
            Assert.That(inventoryItemTypeVersions[1].RiskDescription, Is.EqualTo(itemType.RiskDescription));
            Assert.That(inventoryItemTypeVersions[1].SalesUnitOfMeasure, Is.EqualTo(itemType.SalesUnitOfMeasure));
            Assert.That(inventoryItemTypeVersions[1].StandardCost, Is.EqualTo(itemType.StandardCost));
            Assert.That(inventoryItemTypeVersions[1].Usage, Is.EqualTo(itemType.Usage));
            Assert.That(inventoryItemTypeVersions[1].UnitVolume, Is.EqualTo(itemType.UnitVolume));
            Assert.That(inventoryItemTypeVersions[1].UnitPrice, Is.EqualTo(itemType.UnitPrice));
            Assert.That(inventoryItemTypeVersions[1].UnitCost, Is.EqualTo(itemType.UnitCost));
            Assert.That(inventoryItemTypeVersions[1].ItemTypeId, Is.EqualTo(itemType.Id));
            Assert.That(inventoryItemTypeVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemTypeVersions[1].WorkflowState, Is.EqualTo(itemType.WorkflowState));
            Assert.That(inventoryItemTypeVersions[1].Version, Is.EqualTo(2));
        }

        [Test]
        public async Task InventoryItemType_Delete_DoesDelete()
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

            // Act
            await itemType.Create(DbContext);

            var oldInventoryItemTypeFromDb = DbContext.ItemTypes
                .AsNoTracking()
                .First();
            

            await itemType.Delete(DbContext);


            var inventoryItemTypeFromDb = DbContext.ItemTypes
                .AsNoTracking()
                .ToList();

            var inventoryItemTypeVersions = DbContext.ItemTypeVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.That(inventoryItemTypeFromDb.Count, Is.EqualTo(1));
            Assert.That(inventoryItemTypeFromDb[0].CreatedByUserId, Is.EqualTo(itemType.CreatedByUserId));
            Assert.That(inventoryItemTypeFromDb[0].UpdatedByUserId, Is.EqualTo(itemType.UpdatedByUserId));
            Assert.That(inventoryItemTypeFromDb[0].Name, Is.EqualTo(itemType.Name));
            Assert.That(inventoryItemTypeFromDb[0].BaseUnitOfMeasure, Is.EqualTo(itemType.BaseUnitOfMeasure));
            Assert.That(inventoryItemTypeFromDb[0].Comment, Is.EqualTo(itemType.Comment));
            Assert.That(inventoryItemTypeFromDb[0].CostingMethod, Is.EqualTo(itemType.CostingMethod));
            Assert.That(inventoryItemTypeFromDb[0].Description, Is.EqualTo(itemType.Description));
            Assert.That(inventoryItemTypeFromDb[0].EformId, Is.EqualTo(itemType.EformId));
            Assert.That(inventoryItemTypeFromDb[0].GrossWeight, Is.EqualTo(itemType.GrossWeight));
            Assert.That(inventoryItemTypeFromDb[0].GtinEanUpc, Is.EqualTo(itemType.GtinEanUpc));
            Assert.That(inventoryItemTypeFromDb[0].LastPhysicalInventoryDate, Is.EqualTo(itemType.LastPhysicalInventoryDate));
            Assert.That(inventoryItemTypeFromDb[0].NetWeight, Is.EqualTo(itemType.NetWeight));
            Assert.That(inventoryItemTypeFromDb[0].No, Is.EqualTo(itemType.No));
            Assert.That(inventoryItemTypeFromDb[0].ProfitPercent, Is.EqualTo(itemType.ProfitPercent));
            Assert.That(inventoryItemTypeFromDb[0].Region, Is.EqualTo(itemType.Region));
            Assert.That(inventoryItemTypeFromDb[0].RiskDescription, Is.EqualTo(itemType.RiskDescription));
            Assert.That(inventoryItemTypeFromDb[0].SalesUnitOfMeasure, Is.EqualTo(itemType.SalesUnitOfMeasure));
            Assert.That(inventoryItemTypeFromDb[0].StandardCost, Is.EqualTo(itemType.StandardCost));
            Assert.That(inventoryItemTypeFromDb[0].Usage, Is.EqualTo(itemType.Usage));
            Assert.That(inventoryItemTypeFromDb[0].UnitVolume, Is.EqualTo(itemType.UnitVolume));
            Assert.That(inventoryItemTypeFromDb[0].UnitPrice, Is.EqualTo(itemType.UnitPrice));
            Assert.That(inventoryItemTypeFromDb[0].UnitCost, Is.EqualTo(itemType.UnitCost));
            Assert.That(inventoryItemTypeFromDb[0].Version, Is.EqualTo(2));
            Assert.That(inventoryItemTypeFromDb[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(inventoryItemTypeFromDb[0].WorkflowState, Is.EqualTo(itemType.WorkflowState));

            // versions
            Assert.That(inventoryItemTypeVersions.Count, Is.EqualTo(2));
            Assert.That(inventoryItemTypeVersions[0].CreatedByUserId, Is.EqualTo(oldInventoryItemTypeFromDb.CreatedByUserId));
            Assert.That(inventoryItemTypeVersions[0].UpdatedByUserId, Is.EqualTo(oldInventoryItemTypeFromDb.UpdatedByUserId));
            Assert.That(inventoryItemTypeVersions[0].Name, Is.EqualTo(oldInventoryItemTypeFromDb.Name));
            Assert.That(inventoryItemTypeVersions[0].BaseUnitOfMeasure, Is.EqualTo(oldInventoryItemTypeFromDb.BaseUnitOfMeasure));
            Assert.That(inventoryItemTypeVersions[0].Comment, Is.EqualTo(oldInventoryItemTypeFromDb.Comment));
            Assert.That(inventoryItemTypeVersions[0].CostingMethod, Is.EqualTo(oldInventoryItemTypeFromDb.CostingMethod));
            Assert.That(inventoryItemTypeVersions[0].Description, Is.EqualTo(oldInventoryItemTypeFromDb.Description));
            Assert.That(inventoryItemTypeVersions[0].EformId, Is.EqualTo(oldInventoryItemTypeFromDb.EformId));
            Assert.That(inventoryItemTypeVersions[0].GrossWeight, Is.EqualTo(oldInventoryItemTypeFromDb.GrossWeight));
            Assert.That(inventoryItemTypeVersions[0].GtinEanUpc, Is.EqualTo(oldInventoryItemTypeFromDb.GtinEanUpc));
            Assert.That(inventoryItemTypeVersions[0].LastPhysicalInventoryDate, Is.EqualTo(oldInventoryItemTypeFromDb.LastPhysicalInventoryDate));
            Assert.That(inventoryItemTypeVersions[0].NetWeight, Is.EqualTo(oldInventoryItemTypeFromDb.NetWeight));
            Assert.That(inventoryItemTypeVersions[0].No, Is.EqualTo(oldInventoryItemTypeFromDb.No));
            Assert.That(inventoryItemTypeVersions[0].ProfitPercent, Is.EqualTo(oldInventoryItemTypeFromDb.ProfitPercent));
            Assert.That(inventoryItemTypeVersions[0].Region, Is.EqualTo(oldInventoryItemTypeFromDb.Region));
            Assert.That(inventoryItemTypeVersions[0].RiskDescription, Is.EqualTo(oldInventoryItemTypeFromDb.RiskDescription));
            Assert.That(inventoryItemTypeVersions[0].SalesUnitOfMeasure, Is.EqualTo(oldInventoryItemTypeFromDb.SalesUnitOfMeasure));
            Assert.That(inventoryItemTypeVersions[0].StandardCost, Is.EqualTo(oldInventoryItemTypeFromDb.StandardCost));
            Assert.That(inventoryItemTypeVersions[0].Usage, Is.EqualTo(oldInventoryItemTypeFromDb.Usage));
            Assert.That(inventoryItemTypeVersions[0].UnitVolume, Is.EqualTo(oldInventoryItemTypeFromDb.UnitVolume));
            Assert.That(inventoryItemTypeVersions[0].UnitPrice, Is.EqualTo(oldInventoryItemTypeFromDb.UnitPrice));
            Assert.That(inventoryItemTypeVersions[0].UnitCost, Is.EqualTo(oldInventoryItemTypeFromDb.UnitCost));
            Assert.That(inventoryItemTypeVersions[0].ItemTypeId, Is.EqualTo(oldInventoryItemTypeFromDb.Id));
            Assert.That(inventoryItemTypeVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemTypeVersions[0].WorkflowState, Is.EqualTo(oldInventoryItemTypeFromDb.WorkflowState));
            Assert.That(inventoryItemTypeVersions[0].Version, Is.EqualTo(1));

            Assert.That(inventoryItemTypeVersions[1].CreatedByUserId, Is.EqualTo(itemType.CreatedByUserId));
            Assert.That(inventoryItemTypeVersions[1].UpdatedByUserId, Is.EqualTo(itemType.UpdatedByUserId));
            Assert.That(inventoryItemTypeVersions[1].Name, Is.EqualTo(itemType.Name));
            Assert.That(inventoryItemTypeVersions[1].BaseUnitOfMeasure, Is.EqualTo(itemType.BaseUnitOfMeasure));
            Assert.That(inventoryItemTypeVersions[1].Comment, Is.EqualTo(itemType.Comment));
            Assert.That(inventoryItemTypeVersions[1].CostingMethod, Is.EqualTo(itemType.CostingMethod));
            Assert.That(inventoryItemTypeVersions[1].Description, Is.EqualTo(itemType.Description));
            Assert.That(inventoryItemTypeVersions[1].EformId, Is.EqualTo(itemType.EformId));
            Assert.That(inventoryItemTypeVersions[1].GrossWeight, Is.EqualTo(itemType.GrossWeight));
            Assert.That(inventoryItemTypeVersions[1].GtinEanUpc, Is.EqualTo(itemType.GtinEanUpc));
            Assert.That(inventoryItemTypeVersions[1].LastPhysicalInventoryDate, Is.EqualTo(itemType.LastPhysicalInventoryDate));
            Assert.That(inventoryItemTypeVersions[1].NetWeight, Is.EqualTo(itemType.NetWeight));
            Assert.That(inventoryItemTypeVersions[1].No, Is.EqualTo(itemType.No));
            Assert.That(inventoryItemTypeVersions[1].ProfitPercent, Is.EqualTo(itemType.ProfitPercent));
            Assert.That(inventoryItemTypeVersions[1].Region, Is.EqualTo(itemType.Region));
            Assert.That(inventoryItemTypeVersions[1].RiskDescription, Is.EqualTo(itemType.RiskDescription));
            Assert.That(inventoryItemTypeVersions[1].SalesUnitOfMeasure, Is.EqualTo(itemType.SalesUnitOfMeasure));
            Assert.That(inventoryItemTypeVersions[1].StandardCost, Is.EqualTo(itemType.StandardCost));
            Assert.That(inventoryItemTypeVersions[1].Usage, Is.EqualTo(itemType.Usage));
            Assert.That(inventoryItemTypeVersions[1].UnitVolume, Is.EqualTo(itemType.UnitVolume));
            Assert.That(inventoryItemTypeVersions[1].UnitPrice, Is.EqualTo(itemType.UnitPrice));
            Assert.That(inventoryItemTypeVersions[1].UnitCost, Is.EqualTo(itemType.UnitCost));
            Assert.That(inventoryItemTypeVersions[1].ItemTypeId, Is.EqualTo(itemType.Id));
            Assert.That(inventoryItemTypeVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(inventoryItemTypeVersions[1].WorkflowState, Is.EqualTo(itemType.WorkflowState));
            Assert.That(inventoryItemTypeVersions[1].Version, Is.EqualTo(2));
        }
    }
}