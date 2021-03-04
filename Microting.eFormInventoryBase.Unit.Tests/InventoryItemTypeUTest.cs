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
            Assert.AreEqual(1, itemTypes.Count);
            Assert.AreEqual(itemType.CreatedByUserId, itemTypes[0].CreatedByUserId);
            Assert.AreEqual(itemType.UpdatedByUserId, itemTypes[0].UpdatedByUserId);
            Assert.AreEqual(itemType.Name, itemTypes[0].Name);
            Assert.AreEqual(itemType.BaseUnitOfMeasure, itemTypes[0].BaseUnitOfMeasure);
            Assert.AreEqual(itemType.Comment, itemTypes[0].Comment);
            Assert.AreEqual(itemType.CostingMethod, itemTypes[0].CostingMethod);
            Assert.AreEqual(itemType.Description, itemTypes[0].Description);
            Assert.AreEqual(itemType.EformId, itemTypes[0].EformId);
            Assert.AreEqual(itemType.GrossWeight, itemTypes[0].GrossWeight);
            Assert.AreEqual(itemType.GtinEanUpc, itemTypes[0].GtinEanUpc);
            Assert.AreEqual(itemType.LastPhysicalInventoryDate, itemTypes[0].LastPhysicalInventoryDate);
            Assert.AreEqual(itemType.NetWeight, itemTypes[0].NetWeight);
            Assert.AreEqual(itemType.No, itemTypes[0].No);
            Assert.AreEqual(itemType.ProfitPercent, itemTypes[0].ProfitPercent);
            Assert.AreEqual(itemType.Region, itemTypes[0].Region);
            Assert.AreEqual(itemType.RiskDescription, itemTypes[0].RiskDescription);
            Assert.AreEqual(itemType.SalesUnitOfMeasure, itemTypes[0].SalesUnitOfMeasure);
            Assert.AreEqual(itemType.StandardCost, itemTypes[0].StandardCost);
            Assert.AreEqual(itemType.Usage, itemTypes[0].Usage);
            Assert.AreEqual(itemType.UnitVolume, itemTypes[0].UnitVolume);
            Assert.AreEqual(itemType.UnitPrice, itemTypes[0].UnitPrice);
            Assert.AreEqual(itemType.UnitCost, itemTypes[0].UnitCost);
            Assert.AreEqual(1, itemTypes[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemTypes[0].WorkflowState);
            Assert.AreEqual(itemType.WorkflowState, itemTypes[0].WorkflowState);


            // versions
            Assert.AreEqual(1, itemTypeVersions.Count);
            Assert.AreEqual(itemType.CreatedByUserId, itemTypeVersions[0].CreatedByUserId);
            Assert.AreEqual(itemType.UpdatedByUserId, itemTypeVersions[0].UpdatedByUserId);
            Assert.AreEqual(itemType.Name, itemTypeVersions[0].Name);
            Assert.AreEqual(itemType.BaseUnitOfMeasure, itemTypeVersions[0].BaseUnitOfMeasure);
            Assert.AreEqual(itemType.Comment, itemTypeVersions[0].Comment);
            Assert.AreEqual(itemType.CostingMethod, itemTypeVersions[0].CostingMethod);
            Assert.AreEqual(itemType.Description, itemTypeVersions[0].Description);
            Assert.AreEqual(itemType.EformId, itemTypeVersions[0].EformId);
            Assert.AreEqual(itemType.GrossWeight, itemTypeVersions[0].GrossWeight);
            Assert.AreEqual(itemType.GtinEanUpc, itemTypeVersions[0].GtinEanUpc);
            Assert.AreEqual(itemType.LastPhysicalInventoryDate, itemTypeVersions[0].LastPhysicalInventoryDate);
            Assert.AreEqual(itemType.NetWeight, itemTypeVersions[0].NetWeight);
            Assert.AreEqual(itemType.No, itemTypeVersions[0].No);
            Assert.AreEqual(itemType.ProfitPercent, itemTypeVersions[0].ProfitPercent);
            Assert.AreEqual(itemType.Region, itemTypeVersions[0].Region);
            Assert.AreEqual(itemType.RiskDescription, itemTypeVersions[0].RiskDescription);
            Assert.AreEqual(itemType.SalesUnitOfMeasure, itemTypeVersions[0].SalesUnitOfMeasure);
            Assert.AreEqual(itemType.StandardCost, itemTypeVersions[0].StandardCost);
            Assert.AreEqual(itemType.Usage, itemTypeVersions[0].Usage);
            Assert.AreEqual(itemType.UnitVolume, itemTypeVersions[0].UnitVolume);
            Assert.AreEqual(itemType.UnitPrice, itemTypeVersions[0].UnitPrice);
            Assert.AreEqual(itemType.UnitCost, itemTypeVersions[0].UnitCost);
            Assert.AreEqual(itemType.Id, itemTypeVersions[0].ItemTypeId);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemTypeVersions[0].WorkflowState);
            Assert.AreEqual(itemType.WorkflowState, itemTypeVersions[0].WorkflowState);
            Assert.AreEqual(1, itemTypeVersions[0].Version);
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
            Assert.AreEqual(1, inventoryItemTypeFromDb.Count);
            Assert.AreEqual(itemType.CreatedByUserId, inventoryItemTypeFromDb[0].CreatedByUserId);
            Assert.AreEqual(itemType.UpdatedByUserId, inventoryItemTypeFromDb[0].UpdatedByUserId);
            Assert.AreEqual(itemType.Name, inventoryItemTypeFromDb[0].Name);
            Assert.AreEqual(itemType.BaseUnitOfMeasure, inventoryItemTypeFromDb[0].BaseUnitOfMeasure);
            Assert.AreEqual(itemType.Comment, inventoryItemTypeFromDb[0].Comment);
            Assert.AreEqual(itemType.CostingMethod, inventoryItemTypeFromDb[0].CostingMethod);
            Assert.AreEqual(itemType.Description, inventoryItemTypeFromDb[0].Description);
            Assert.AreEqual(itemType.EformId, inventoryItemTypeFromDb[0].EformId);
            Assert.AreEqual(itemType.GrossWeight, inventoryItemTypeFromDb[0].GrossWeight);
            Assert.AreEqual(itemType.GtinEanUpc, inventoryItemTypeFromDb[0].GtinEanUpc);
            Assert.AreEqual(itemType.LastPhysicalInventoryDate, inventoryItemTypeFromDb[0].LastPhysicalInventoryDate);
            Assert.AreEqual(itemType.NetWeight, inventoryItemTypeFromDb[0].NetWeight);
            Assert.AreEqual(itemType.No, inventoryItemTypeFromDb[0].No);
            Assert.AreEqual(itemType.ProfitPercent, inventoryItemTypeFromDb[0].ProfitPercent);
            Assert.AreEqual(itemType.Region, inventoryItemTypeFromDb[0].Region);
            Assert.AreEqual(itemType.RiskDescription, inventoryItemTypeFromDb[0].RiskDescription);
            Assert.AreEqual(itemType.SalesUnitOfMeasure, inventoryItemTypeFromDb[0].SalesUnitOfMeasure);
            Assert.AreEqual(itemType.StandardCost, inventoryItemTypeFromDb[0].StandardCost);
            Assert.AreEqual(itemType.Usage, inventoryItemTypeFromDb[0].Usage);
            Assert.AreEqual(itemType.UnitVolume, inventoryItemTypeFromDb[0].UnitVolume);
            Assert.AreEqual(itemType.UnitPrice, inventoryItemTypeFromDb[0].UnitPrice);
            Assert.AreEqual(itemType.UnitCost, inventoryItemTypeFromDb[0].UnitCost);
            Assert.AreEqual(2, inventoryItemTypeFromDb[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemTypeFromDb[0].WorkflowState);
            Assert.AreEqual(itemType.WorkflowState, inventoryItemTypeFromDb[0].WorkflowState);

            // versions
            Assert.AreEqual(2, inventoryItemTypeVersions.Count);
            Assert.AreEqual(oldInventoryItemTypeFromDb.CreatedByUserId, inventoryItemTypeVersions[0].CreatedByUserId);
            Assert.AreEqual(oldInventoryItemTypeFromDb.UpdatedByUserId, inventoryItemTypeVersions[0].UpdatedByUserId);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Name, inventoryItemTypeVersions[0].Name);
            Assert.AreEqual(oldInventoryItemTypeFromDb.BaseUnitOfMeasure, inventoryItemTypeVersions[0].BaseUnitOfMeasure);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Comment, inventoryItemTypeVersions[0].Comment);
            Assert.AreEqual(oldInventoryItemTypeFromDb.CostingMethod, inventoryItemTypeVersions[0].CostingMethod);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Description, inventoryItemTypeVersions[0].Description);
            Assert.AreEqual(oldInventoryItemTypeFromDb.EformId, inventoryItemTypeVersions[0].EformId);
            Assert.AreEqual(oldInventoryItemTypeFromDb.GrossWeight, inventoryItemTypeVersions[0].GrossWeight);
            Assert.AreEqual(oldInventoryItemTypeFromDb.GtinEanUpc, inventoryItemTypeVersions[0].GtinEanUpc);
            Assert.AreEqual(oldInventoryItemTypeFromDb.LastPhysicalInventoryDate, inventoryItemTypeVersions[0].LastPhysicalInventoryDate);
            Assert.AreEqual(oldInventoryItemTypeFromDb.NetWeight, inventoryItemTypeVersions[0].NetWeight);
            Assert.AreEqual(oldInventoryItemTypeFromDb.No, inventoryItemTypeVersions[0].No);
            Assert.AreEqual(oldInventoryItemTypeFromDb.ProfitPercent, inventoryItemTypeVersions[0].ProfitPercent);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Region, inventoryItemTypeVersions[0].Region);
            Assert.AreEqual(oldInventoryItemTypeFromDb.RiskDescription, inventoryItemTypeVersions[0].RiskDescription);
            Assert.AreEqual(oldInventoryItemTypeFromDb.SalesUnitOfMeasure, inventoryItemTypeVersions[0].SalesUnitOfMeasure);
            Assert.AreEqual(oldInventoryItemTypeFromDb.StandardCost, inventoryItemTypeVersions[0].StandardCost);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Usage, inventoryItemTypeVersions[0].Usage);
            Assert.AreEqual(oldInventoryItemTypeFromDb.UnitVolume, inventoryItemTypeVersions[0].UnitVolume);
            Assert.AreEqual(oldInventoryItemTypeFromDb.UnitPrice, inventoryItemTypeVersions[0].UnitPrice);
            Assert.AreEqual(oldInventoryItemTypeFromDb.UnitCost, inventoryItemTypeVersions[0].UnitCost);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Id, inventoryItemTypeVersions[0].ItemTypeId);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemTypeVersions[0].WorkflowState);
            Assert.AreEqual(oldInventoryItemTypeFromDb.WorkflowState, inventoryItemTypeVersions[0].WorkflowState);
            Assert.AreEqual(1, inventoryItemTypeVersions[0].Version);

            Assert.AreEqual(itemType.CreatedByUserId, inventoryItemTypeVersions[1].CreatedByUserId);
            Assert.AreEqual(itemType.UpdatedByUserId, inventoryItemTypeVersions[1].UpdatedByUserId);
            Assert.AreEqual(itemType.Name, inventoryItemTypeVersions[1].Name);
            Assert.AreEqual(itemType.BaseUnitOfMeasure, inventoryItemTypeVersions[1].BaseUnitOfMeasure);
            Assert.AreEqual(itemType.Comment, inventoryItemTypeVersions[1].Comment);
            Assert.AreEqual(itemType.CostingMethod, inventoryItemTypeVersions[1].CostingMethod);
            Assert.AreEqual(itemType.Description, inventoryItemTypeVersions[1].Description);
            Assert.AreEqual(itemType.EformId, inventoryItemTypeVersions[1].EformId);
            Assert.AreEqual(itemType.GrossWeight, inventoryItemTypeVersions[1].GrossWeight);
            Assert.AreEqual(itemType.GtinEanUpc, inventoryItemTypeVersions[1].GtinEanUpc);
            Assert.AreEqual(itemType.LastPhysicalInventoryDate, inventoryItemTypeVersions[1].LastPhysicalInventoryDate);
            Assert.AreEqual(itemType.NetWeight, inventoryItemTypeVersions[1].NetWeight);
            Assert.AreEqual(itemType.No, inventoryItemTypeVersions[1].No);
            Assert.AreEqual(itemType.ProfitPercent, inventoryItemTypeVersions[1].ProfitPercent);
            Assert.AreEqual(itemType.Region, inventoryItemTypeVersions[1].Region);
            Assert.AreEqual(itemType.RiskDescription, inventoryItemTypeVersions[1].RiskDescription);
            Assert.AreEqual(itemType.SalesUnitOfMeasure, inventoryItemTypeVersions[1].SalesUnitOfMeasure);
            Assert.AreEqual(itemType.StandardCost, inventoryItemTypeVersions[1].StandardCost);
            Assert.AreEqual(itemType.Usage, inventoryItemTypeVersions[1].Usage);
            Assert.AreEqual(itemType.UnitVolume, inventoryItemTypeVersions[1].UnitVolume);
            Assert.AreEqual(itemType.UnitPrice, inventoryItemTypeVersions[1].UnitPrice);
            Assert.AreEqual(itemType.UnitCost, inventoryItemTypeVersions[1].UnitCost);
            Assert.AreEqual(itemType.Id, inventoryItemTypeVersions[1].ItemTypeId);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemTypeVersions[1].WorkflowState);
            Assert.AreEqual(itemType.WorkflowState, inventoryItemTypeVersions[1].WorkflowState);
            Assert.AreEqual(2, inventoryItemTypeVersions[1].Version);
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
            Assert.AreEqual(1, inventoryItemTypeFromDb.Count);
            Assert.AreEqual(itemType.CreatedByUserId, inventoryItemTypeFromDb[0].CreatedByUserId);
            Assert.AreEqual(itemType.UpdatedByUserId, inventoryItemTypeFromDb[0].UpdatedByUserId);
            Assert.AreEqual(itemType.Name, inventoryItemTypeFromDb[0].Name);
            Assert.AreEqual(itemType.BaseUnitOfMeasure, inventoryItemTypeFromDb[0].BaseUnitOfMeasure);
            Assert.AreEqual(itemType.Comment, inventoryItemTypeFromDb[0].Comment);
            Assert.AreEqual(itemType.CostingMethod, inventoryItemTypeFromDb[0].CostingMethod);
            Assert.AreEqual(itemType.Description, inventoryItemTypeFromDb[0].Description);
            Assert.AreEqual(itemType.EformId, inventoryItemTypeFromDb[0].EformId);
            Assert.AreEqual(itemType.GrossWeight, inventoryItemTypeFromDb[0].GrossWeight);
            Assert.AreEqual(itemType.GtinEanUpc, inventoryItemTypeFromDb[0].GtinEanUpc);
            Assert.AreEqual(itemType.LastPhysicalInventoryDate, inventoryItemTypeFromDb[0].LastPhysicalInventoryDate);
            Assert.AreEqual(itemType.NetWeight, inventoryItemTypeFromDb[0].NetWeight);
            Assert.AreEqual(itemType.No, inventoryItemTypeFromDb[0].No);
            Assert.AreEqual(itemType.ProfitPercent, inventoryItemTypeFromDb[0].ProfitPercent);
            Assert.AreEqual(itemType.Region, inventoryItemTypeFromDb[0].Region);
            Assert.AreEqual(itemType.RiskDescription, inventoryItemTypeFromDb[0].RiskDescription);
            Assert.AreEqual(itemType.SalesUnitOfMeasure, inventoryItemTypeFromDb[0].SalesUnitOfMeasure);
            Assert.AreEqual(itemType.StandardCost, inventoryItemTypeFromDb[0].StandardCost);
            Assert.AreEqual(itemType.Usage, inventoryItemTypeFromDb[0].Usage);
            Assert.AreEqual(itemType.UnitVolume, inventoryItemTypeFromDb[0].UnitVolume);
            Assert.AreEqual(itemType.UnitPrice, inventoryItemTypeFromDb[0].UnitPrice);
            Assert.AreEqual(itemType.UnitCost, inventoryItemTypeFromDb[0].UnitCost);
            Assert.AreEqual(2, inventoryItemTypeFromDb[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, inventoryItemTypeFromDb[0].WorkflowState);
            Assert.AreEqual(itemType.WorkflowState, inventoryItemTypeFromDb[0].WorkflowState);

            // versions
            Assert.AreEqual(2, inventoryItemTypeVersions.Count);
            Assert.AreEqual(oldInventoryItemTypeFromDb.CreatedByUserId, inventoryItemTypeVersions[0].CreatedByUserId);
            Assert.AreEqual(oldInventoryItemTypeFromDb.UpdatedByUserId, inventoryItemTypeVersions[0].UpdatedByUserId);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Name, inventoryItemTypeVersions[0].Name);
            Assert.AreEqual(oldInventoryItemTypeFromDb.BaseUnitOfMeasure, inventoryItemTypeVersions[0].BaseUnitOfMeasure);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Comment, inventoryItemTypeVersions[0].Comment);
            Assert.AreEqual(oldInventoryItemTypeFromDb.CostingMethod, inventoryItemTypeVersions[0].CostingMethod);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Description, inventoryItemTypeVersions[0].Description);
            Assert.AreEqual(oldInventoryItemTypeFromDb.EformId, inventoryItemTypeVersions[0].EformId);
            Assert.AreEqual(oldInventoryItemTypeFromDb.GrossWeight, inventoryItemTypeVersions[0].GrossWeight);
            Assert.AreEqual(oldInventoryItemTypeFromDb.GtinEanUpc, inventoryItemTypeVersions[0].GtinEanUpc);
            Assert.AreEqual(oldInventoryItemTypeFromDb.LastPhysicalInventoryDate, inventoryItemTypeVersions[0].LastPhysicalInventoryDate);
            Assert.AreEqual(oldInventoryItemTypeFromDb.NetWeight, inventoryItemTypeVersions[0].NetWeight);
            Assert.AreEqual(oldInventoryItemTypeFromDb.No, inventoryItemTypeVersions[0].No);
            Assert.AreEqual(oldInventoryItemTypeFromDb.ProfitPercent, inventoryItemTypeVersions[0].ProfitPercent);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Region, inventoryItemTypeVersions[0].Region);
            Assert.AreEqual(oldInventoryItemTypeFromDb.RiskDescription, inventoryItemTypeVersions[0].RiskDescription);
            Assert.AreEqual(oldInventoryItemTypeFromDb.SalesUnitOfMeasure, inventoryItemTypeVersions[0].SalesUnitOfMeasure);
            Assert.AreEqual(oldInventoryItemTypeFromDb.StandardCost, inventoryItemTypeVersions[0].StandardCost);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Usage, inventoryItemTypeVersions[0].Usage);
            Assert.AreEqual(oldInventoryItemTypeFromDb.UnitVolume, inventoryItemTypeVersions[0].UnitVolume);
            Assert.AreEqual(oldInventoryItemTypeFromDb.UnitPrice, inventoryItemTypeVersions[0].UnitPrice);
            Assert.AreEqual(oldInventoryItemTypeFromDb.UnitCost, inventoryItemTypeVersions[0].UnitCost);
            Assert.AreEqual(oldInventoryItemTypeFromDb.Id, inventoryItemTypeVersions[0].ItemTypeId);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemTypeVersions[0].WorkflowState);
            Assert.AreEqual(oldInventoryItemTypeFromDb.WorkflowState, inventoryItemTypeVersions[0].WorkflowState);
            Assert.AreEqual(1, inventoryItemTypeVersions[0].Version);

            Assert.AreEqual(itemType.CreatedByUserId, inventoryItemTypeVersions[1].CreatedByUserId);
            Assert.AreEqual(itemType.UpdatedByUserId, inventoryItemTypeVersions[1].UpdatedByUserId);
            Assert.AreEqual(itemType.Name, inventoryItemTypeVersions[1].Name);
            Assert.AreEqual(itemType.BaseUnitOfMeasure, inventoryItemTypeVersions[1].BaseUnitOfMeasure);
            Assert.AreEqual(itemType.Comment, inventoryItemTypeVersions[1].Comment);
            Assert.AreEqual(itemType.CostingMethod, inventoryItemTypeVersions[1].CostingMethod);
            Assert.AreEqual(itemType.Description, inventoryItemTypeVersions[1].Description);
            Assert.AreEqual(itemType.EformId, inventoryItemTypeVersions[1].EformId);
            Assert.AreEqual(itemType.GrossWeight, inventoryItemTypeVersions[1].GrossWeight);
            Assert.AreEqual(itemType.GtinEanUpc, inventoryItemTypeVersions[1].GtinEanUpc);
            Assert.AreEqual(itemType.LastPhysicalInventoryDate, inventoryItemTypeVersions[1].LastPhysicalInventoryDate);
            Assert.AreEqual(itemType.NetWeight, inventoryItemTypeVersions[1].NetWeight);
            Assert.AreEqual(itemType.No, inventoryItemTypeVersions[1].No);
            Assert.AreEqual(itemType.ProfitPercent, inventoryItemTypeVersions[1].ProfitPercent);
            Assert.AreEqual(itemType.Region, inventoryItemTypeVersions[1].Region);
            Assert.AreEqual(itemType.RiskDescription, inventoryItemTypeVersions[1].RiskDescription);
            Assert.AreEqual(itemType.SalesUnitOfMeasure, inventoryItemTypeVersions[1].SalesUnitOfMeasure);
            Assert.AreEqual(itemType.StandardCost, inventoryItemTypeVersions[1].StandardCost);
            Assert.AreEqual(itemType.Usage, inventoryItemTypeVersions[1].Usage);
            Assert.AreEqual(itemType.UnitVolume, inventoryItemTypeVersions[1].UnitVolume);
            Assert.AreEqual(itemType.UnitPrice, inventoryItemTypeVersions[1].UnitPrice);
            Assert.AreEqual(itemType.UnitCost, inventoryItemTypeVersions[1].UnitCost);
            Assert.AreEqual(itemType.Id, inventoryItemTypeVersions[1].ItemTypeId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, inventoryItemTypeVersions[1].WorkflowState);
            Assert.AreEqual(itemType.WorkflowState, inventoryItemTypeVersions[1].WorkflowState);
            Assert.AreEqual(2, inventoryItemTypeVersions[1].Version);
        }
    }
}