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

    public class InventoryItemGroupUTest : DbTestFixture
    {
        [Test]
        public async Task InventoryItemGroup_Save_DoesSave()
        {
            // Arrange
            var itemGroup = new ItemGroup
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                CreatedByUserId = 1,
                UpdatedByUserId = 1,
                Code = Guid.NewGuid().ToString(),
            };

            // Act
            await itemGroup.Create(DbContext);



            var itemGroups = DbContext.ItemGroups
                .AsNoTracking()
                .ToList();

            var itemGroupVersions = DbContext.ItemGroupVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.AreEqual(1, itemGroups.Count);
            Assert.AreEqual(itemGroup.CreatedByUserId, itemGroups[0].CreatedByUserId);
            Assert.AreEqual(itemGroup.UpdatedByUserId, itemGroups[0].UpdatedByUserId);
            Assert.AreEqual(itemGroup.Name, itemGroups[0].Name);
            Assert.AreEqual(itemGroup.Code, itemGroups[0].Code);
            Assert.AreEqual(itemGroup.Description, itemGroups[0].Description);
            Assert.AreEqual(1, itemGroups[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, itemGroups[0].WorkflowState);
            Assert.AreEqual(itemGroup.WorkflowState, itemGroups[0].WorkflowState);


            // versions
            Assert.AreEqual(1, itemGroupVersions.Count);
            Assert.AreEqual(itemGroup.CreatedByUserId, itemGroupVersions[0].CreatedByUserId);
            Assert.AreEqual(itemGroup.UpdatedByUserId, itemGroupVersions[0].UpdatedByUserId);
            Assert.AreEqual(itemGroup.Description, itemGroupVersions[0].Description);
            Assert.AreEqual(itemGroup.Code, itemGroupVersions[0].Code);
            Assert.AreEqual(itemGroup.Name, itemGroupVersions[0].Name);
            Assert.AreEqual(itemGroup.Id, itemGroupVersions[0].ItemGroupId);
            Assert.AreEqual(itemGroup.WorkflowState, itemGroupVersions[0].WorkflowState);
            Assert.AreEqual(1, itemGroupVersions[0].Version);
        }

        [Test]
        public async Task InventoryItemGroup_Update_DoesUpdate()
        {
            // Arrange
            var itemGroup = new ItemGroup
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Code = Guid.NewGuid().ToString(),
                CreatedByUserId = 1,
                UpdatedByUserId = 1,
            };

            // Act
            await itemGroup.Create(DbContext);


            var oldInventoryItemGroupFromDb = DbContext.ItemGroups
                .AsNoTracking()
                .First();

            itemGroup.Description = Guid.NewGuid().ToString();
            itemGroup.Code = Guid.NewGuid().ToString();
            itemGroup.Name = Guid.NewGuid().ToString();

            await itemGroup.Update(DbContext);


            var inventoryItemGroupFromDb = DbContext.ItemGroups
                .AsNoTracking()
                .First();

            var inventoryItemGroupVersions = DbContext.ItemGroupVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.AreEqual(itemGroup.CreatedByUserId, inventoryItemGroupFromDb.CreatedByUserId);
            Assert.AreEqual(itemGroup.UpdatedByUserId, inventoryItemGroupFromDb.UpdatedByUserId);
            Assert.AreEqual(itemGroup.Description, inventoryItemGroupFromDb.Description);
            Assert.AreEqual(itemGroup.Code, inventoryItemGroupFromDb.Code);
            Assert.AreEqual(itemGroup.Name, inventoryItemGroupFromDb.Name);
            Assert.AreEqual(2, inventoryItemGroupFromDb.Version);
            Assert.AreEqual(itemGroup.WorkflowState, inventoryItemGroupFromDb.WorkflowState);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemGroupFromDb.WorkflowState);

            // versions
            Assert.AreEqual(2, inventoryItemGroupVersions.Count);
            Assert.AreEqual(oldInventoryItemGroupFromDb.CreatedByUserId, inventoryItemGroupVersions[0].CreatedByUserId);
            Assert.AreEqual(oldInventoryItemGroupFromDb.UpdatedByUserId, inventoryItemGroupVersions[0].UpdatedByUserId);
            Assert.AreEqual(oldInventoryItemGroupFromDb.Description, inventoryItemGroupVersions[0].Description);
            Assert.AreEqual(oldInventoryItemGroupFromDb.Code, inventoryItemGroupVersions[0].Code);
            Assert.AreEqual(oldInventoryItemGroupFromDb.Name, inventoryItemGroupVersions[0].Name);
            Assert.AreEqual(oldInventoryItemGroupFromDb.WorkflowState, inventoryItemGroupVersions[0].WorkflowState);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemGroupVersions[0].WorkflowState);
            Assert.AreEqual(1, inventoryItemGroupVersions[0].Version);

            Assert.AreEqual(itemGroup.CreatedByUserId, inventoryItemGroupVersions[1].CreatedByUserId);
            Assert.AreEqual(itemGroup.UpdatedByUserId, inventoryItemGroupVersions[1].UpdatedByUserId);
            Assert.AreEqual(itemGroup.Description, inventoryItemGroupVersions[1].Description);
            Assert.AreEqual(itemGroup.Code, inventoryItemGroupVersions[1].Code);
            Assert.AreEqual(itemGroup.Name, inventoryItemGroupVersions[1].Name);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemGroupVersions[1].WorkflowState);
            Assert.AreEqual(itemGroup.WorkflowState, inventoryItemGroupVersions[1].WorkflowState);
            Assert.AreEqual(2, inventoryItemGroupVersions[1].Version);
        }

        [Test]
        public async Task InventoryItemGroup_Delete_DoesDelete()
        {
            // Arrange
            var itemGroup = new ItemGroup
            {
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Code = Guid.NewGuid().ToString(),
                CreatedByUserId = 1,
                UpdatedByUserId = 1,
            };

            // Act
            await itemGroup.Create(DbContext);

            var oldInventoryItemGroupFromDb = DbContext.ItemGroups
                .AsNoTracking()
                .First();

            await itemGroup.Delete(DbContext);


            var inventoryItemGroupFromDb = DbContext.ItemGroups
                .AsNoTracking()
                .First();

            var inventoryItemGroupVersions = DbContext.ItemGroupVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.AreEqual(itemGroup.CreatedByUserId, inventoryItemGroupFromDb.CreatedByUserId);
            Assert.AreEqual(itemGroup.UpdatedByUserId, inventoryItemGroupFromDb.UpdatedByUserId);
            Assert.AreEqual(itemGroup.Description, inventoryItemGroupFromDb.Description);
            Assert.AreEqual(itemGroup.Code, inventoryItemGroupFromDb.Code);
            Assert.AreEqual(itemGroup.Name, inventoryItemGroupFromDb.Name);
            Assert.AreEqual(2, inventoryItemGroupFromDb.Version);
            Assert.AreEqual(itemGroup.WorkflowState, inventoryItemGroupFromDb.WorkflowState);
            Assert.AreEqual(Constants.WorkflowStates.Removed, inventoryItemGroupFromDb.WorkflowState);

            // versions
            Assert.AreEqual(2, inventoryItemGroupVersions.Count);
            Assert.AreEqual(oldInventoryItemGroupFromDb.CreatedByUserId, inventoryItemGroupVersions[0].CreatedByUserId);
            Assert.AreEqual(oldInventoryItemGroupFromDb.UpdatedByUserId, inventoryItemGroupVersions[0].UpdatedByUserId);
            Assert.AreEqual(oldInventoryItemGroupFromDb.Description, inventoryItemGroupVersions[0].Description);
            Assert.AreEqual(oldInventoryItemGroupFromDb.Code, inventoryItemGroupVersions[0].Code);
            Assert.AreEqual(oldInventoryItemGroupFromDb.Name, inventoryItemGroupVersions[0].Name);
            Assert.AreEqual(oldInventoryItemGroupFromDb.WorkflowState, inventoryItemGroupVersions[0].WorkflowState);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryItemGroupVersions[0].WorkflowState);
            Assert.AreEqual(1, inventoryItemGroupVersions[0].Version);

            Assert.AreEqual(itemGroup.CreatedByUserId, inventoryItemGroupVersions[1].CreatedByUserId);
            Assert.AreEqual(itemGroup.UpdatedByUserId, inventoryItemGroupVersions[1].UpdatedByUserId);
            Assert.AreEqual(itemGroup.Name, inventoryItemGroupVersions[1].Name);
            Assert.AreEqual(itemGroup.Code, inventoryItemGroupVersions[1].Code);
            Assert.AreEqual(itemGroup.Description, inventoryItemGroupVersions[1].Description);
            Assert.AreEqual(Constants.WorkflowStates.Removed, inventoryItemGroupVersions[1].WorkflowState);
            Assert.AreEqual(itemGroup.WorkflowState, inventoryItemGroupVersions[1].WorkflowState);
            Assert.AreEqual(2, inventoryItemGroupVersions[1].Version);
        }
    }
}