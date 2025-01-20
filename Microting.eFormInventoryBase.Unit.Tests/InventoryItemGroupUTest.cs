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
            Assert.That(itemGroups.Count, Is.EqualTo(1));
            Assert.That(itemGroups[0].CreatedByUserId, Is.EqualTo(itemGroup.CreatedByUserId));
            Assert.That(itemGroups[0].UpdatedByUserId, Is.EqualTo(itemGroup.UpdatedByUserId));
            Assert.That(itemGroups[0].Name, Is.EqualTo(itemGroup.Name));
            Assert.That(itemGroups[0].Code, Is.EqualTo(itemGroup.Code));
            Assert.That(itemGroups[0].Description, Is.EqualTo(itemGroup.Description));
            Assert.That(itemGroups[0].Version, Is.EqualTo(1));
            Assert.That(itemGroups[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(itemGroups[0].WorkflowState, Is.EqualTo(itemGroup.WorkflowState));


            // versions
            Assert.That(itemGroupVersions.Count, Is.EqualTo(1));
            Assert.That(itemGroupVersions[0].CreatedByUserId, Is.EqualTo(itemGroup.CreatedByUserId));
            Assert.That(itemGroupVersions[0].UpdatedByUserId, Is.EqualTo(itemGroup.UpdatedByUserId));
            Assert.That(itemGroupVersions[0].Description, Is.EqualTo(itemGroup.Description));
            Assert.That(itemGroupVersions[0].Code, Is.EqualTo(itemGroup.Code));
            Assert.That(itemGroupVersions[0].Name, Is.EqualTo(itemGroup.Name));
            Assert.That(itemGroupVersions[0].ItemGroupId, Is.EqualTo(itemGroup.Id));
            Assert.That(itemGroupVersions[0].WorkflowState, Is.EqualTo(itemGroup.WorkflowState));
            Assert.That(itemGroupVersions[0].Version, Is.EqualTo(1));
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
            Assert.That(inventoryItemGroupFromDb.CreatedByUserId, Is.EqualTo(itemGroup.CreatedByUserId));
            Assert.That(inventoryItemGroupFromDb.UpdatedByUserId, Is.EqualTo(itemGroup.UpdatedByUserId));
            Assert.That(inventoryItemGroupFromDb.Description, Is.EqualTo(itemGroup.Description));
            Assert.That(inventoryItemGroupFromDb.Code, Is.EqualTo(itemGroup.Code));
            Assert.That(inventoryItemGroupFromDb.Name, Is.EqualTo(itemGroup.Name));
            Assert.That(inventoryItemGroupFromDb.Version, Is.EqualTo(2));
            Assert.That(inventoryItemGroupFromDb.WorkflowState, Is.EqualTo(itemGroup.WorkflowState));
            Assert.That(inventoryItemGroupFromDb.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));

            // versions
            Assert.That(inventoryItemGroupVersions.Count, Is.EqualTo(2));
            Assert.That(inventoryItemGroupVersions[0].CreatedByUserId, Is.EqualTo(oldInventoryItemGroupFromDb.CreatedByUserId));
            Assert.That(inventoryItemGroupVersions[0].UpdatedByUserId, Is.EqualTo(oldInventoryItemGroupFromDb.UpdatedByUserId));
            Assert.That(inventoryItemGroupVersions[0].Description, Is.EqualTo(oldInventoryItemGroupFromDb.Description));
            Assert.That(inventoryItemGroupVersions[0].Code, Is.EqualTo(oldInventoryItemGroupFromDb.Code));
            Assert.That(inventoryItemGroupVersions[0].Name, Is.EqualTo(oldInventoryItemGroupFromDb.Name));
            Assert.That(inventoryItemGroupVersions[0].WorkflowState, Is.EqualTo(oldInventoryItemGroupFromDb.WorkflowState));
            Assert.That(inventoryItemGroupVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemGroupVersions[0].Version, Is.EqualTo(1));

            Assert.That(inventoryItemGroupVersions[1].CreatedByUserId, Is.EqualTo(itemGroup.CreatedByUserId));
            Assert.That(inventoryItemGroupVersions[1].UpdatedByUserId, Is.EqualTo(itemGroup.UpdatedByUserId));
            Assert.That(inventoryItemGroupVersions[1].Description, Is.EqualTo(itemGroup.Description));
            Assert.That(inventoryItemGroupVersions[1].Code, Is.EqualTo(itemGroup.Code));
            Assert.That(inventoryItemGroupVersions[1].Name, Is.EqualTo(itemGroup.Name));
            Assert.That(inventoryItemGroupVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemGroupVersions[1].WorkflowState, Is.EqualTo(itemGroup.WorkflowState));
            Assert.That(inventoryItemGroupVersions[1].Version, Is.EqualTo(2));
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
            Assert.That(inventoryItemGroupFromDb.CreatedByUserId, Is.EqualTo(itemGroup.CreatedByUserId));
            Assert.That(inventoryItemGroupFromDb.UpdatedByUserId, Is.EqualTo(itemGroup.UpdatedByUserId));
            Assert.That(inventoryItemGroupFromDb.Description, Is.EqualTo(itemGroup.Description));
            Assert.That(inventoryItemGroupFromDb.Code, Is.EqualTo(itemGroup.Code));
            Assert.That(inventoryItemGroupFromDb.Name, Is.EqualTo(itemGroup.Name));
            Assert.That(inventoryItemGroupFromDb.Version, Is.EqualTo(2));
            Assert.That(inventoryItemGroupFromDb.WorkflowState, Is.EqualTo(itemGroup.WorkflowState));
            Assert.That(inventoryItemGroupFromDb.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));

            // versions
            Assert.That(inventoryItemGroupVersions.Count, Is.EqualTo(2));
            Assert.That(inventoryItemGroupVersions[0].CreatedByUserId, Is.EqualTo(oldInventoryItemGroupFromDb.CreatedByUserId));
            Assert.That(inventoryItemGroupVersions[0].UpdatedByUserId, Is.EqualTo(oldInventoryItemGroupFromDb.UpdatedByUserId));
            Assert.That(inventoryItemGroupVersions[0].Description, Is.EqualTo(oldInventoryItemGroupFromDb.Description));
            Assert.That(inventoryItemGroupVersions[0].Code, Is.EqualTo(oldInventoryItemGroupFromDb.Code));
            Assert.That(inventoryItemGroupVersions[0].Name, Is.EqualTo(oldInventoryItemGroupFromDb.Name));
            Assert.That(inventoryItemGroupVersions[0].WorkflowState, Is.EqualTo(oldInventoryItemGroupFromDb.WorkflowState));
            Assert.That(inventoryItemGroupVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryItemGroupVersions[0].Version, Is.EqualTo(1));

            Assert.That(inventoryItemGroupVersions[1].CreatedByUserId, Is.EqualTo(itemGroup.CreatedByUserId));
            Assert.That(inventoryItemGroupVersions[1].UpdatedByUserId, Is.EqualTo(itemGroup.UpdatedByUserId));
            Assert.That(inventoryItemGroupVersions[1].Name, Is.EqualTo(itemGroup.Name));
            Assert.That(inventoryItemGroupVersions[1].Code, Is.EqualTo(itemGroup.Code));
            Assert.That(inventoryItemGroupVersions[1].Description, Is.EqualTo(itemGroup.Description));
            Assert.That(inventoryItemGroupVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(inventoryItemGroupVersions[1].WorkflowState, Is.EqualTo(itemGroup.WorkflowState));
            Assert.That(inventoryItemGroupVersions[1].Version, Is.EqualTo(2));
        }
    }
}