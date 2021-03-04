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
    using Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    public class InventoryTagUTest : DbTestFixture
    {
        [Test]
        public async Task InventoryTag_Save_DoesSave()
        {
            // Arrange
            var inventoryTag = new InventoryTag
            {
                Name = Guid.NewGuid().ToString(),
                CreatedByUserId = 1,
                UpdatedByUserId = 1,
            };

            // Act
            await inventoryTag.Create(DbContext);


            var inventoryTagsList = DbContext.InventoryTags
                .AsNoTracking()
                .ToList();

            var inventoryTagsListVersions = DbContext.InventoryTagVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.AreEqual(1, inventoryTagsList.Count);
            Assert.AreEqual(inventoryTag.CreatedByUserId, inventoryTagsList[0].CreatedByUserId);
            Assert.AreEqual(inventoryTag.UpdatedByUserId, inventoryTagsList[0].UpdatedByUserId);
            Assert.AreEqual(inventoryTag.Name, inventoryTagsList[0].Name);
            Assert.AreEqual(inventoryTag.Id, inventoryTagsList[0].Id);
            Assert.AreEqual(1, inventoryTagsList[0].Version);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryTagsList[0].WorkflowState);
            Assert.AreEqual(inventoryTag.WorkflowState, inventoryTagsList[0].WorkflowState);


            // versions
            Assert.AreEqual(1, inventoryTagsListVersions.Count);
            Assert.AreEqual(inventoryTag.CreatedByUserId, inventoryTagsListVersions[0].CreatedByUserId);
            Assert.AreEqual(inventoryTag.UpdatedByUserId, inventoryTagsListVersions[0].UpdatedByUserId);
            Assert.AreEqual(inventoryTag.Name, inventoryTagsListVersions[0].Name);
            Assert.AreEqual(inventoryTag.Id, inventoryTagsListVersions[0].InventoryTagId);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryTagsListVersions[0].WorkflowState);
            Assert.AreEqual(inventoryTag.WorkflowState, inventoryTagsListVersions[0].WorkflowState);
            Assert.AreEqual(1, inventoryTagsListVersions[0].Version);
        }

        [Test]
        public async Task InventoryTag_Update_DoesUpdate()
        {
            // Arrange
            var inventoryTag = new InventoryTag
            {
                Name = Guid.NewGuid().ToString(),
                CreatedByUserId = 1,
                UpdatedByUserId = 1,
            };

            // Act
            await inventoryTag.Create(DbContext);

            var oldInventoryTagsList = DbContext.InventoryTags
                .AsNoTracking()
                .First();

            inventoryTag.Name = Guid.NewGuid().ToString();

            await inventoryTag.Update(DbContext);


            var inventoryTagFromDb = DbContext.InventoryTags
                .AsNoTracking()
                .First(x => x.Id == inventoryTag.Id);

            var inventoryTagsListVersions = DbContext.InventoryTagVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.AreEqual(inventoryTag.CreatedByUserId, inventoryTagFromDb.CreatedByUserId);
            Assert.AreEqual(inventoryTag.UpdatedByUserId, inventoryTagFromDb.UpdatedByUserId);
            Assert.AreEqual(inventoryTag.Name, inventoryTagFromDb.Name);
            Assert.AreEqual(inventoryTag.Id, inventoryTagFromDb.Id);
            Assert.AreEqual(2, inventoryTagFromDb.Version);
            Assert.AreEqual(inventoryTag.WorkflowState, inventoryTagFromDb.WorkflowState);

            // versions
            Assert.AreEqual(2, inventoryTagsListVersions.Count);
            Assert.AreEqual(oldInventoryTagsList.CreatedByUserId, inventoryTagsListVersions[0].CreatedByUserId);
            Assert.AreEqual(oldInventoryTagsList.UpdatedByUserId, inventoryTagsListVersions[0].UpdatedByUserId);
            Assert.AreEqual(oldInventoryTagsList.Name, inventoryTagsListVersions[0].Name);
            Assert.AreEqual(oldInventoryTagsList.Id, inventoryTagsListVersions[0].InventoryTagId);
            Assert.AreEqual(oldInventoryTagsList.WorkflowState, inventoryTagsListVersions[0].WorkflowState);
            Assert.AreEqual(1, inventoryTagsListVersions[0].Version);

            Assert.AreEqual(inventoryTag.CreatedByUserId, inventoryTagsListVersions[1].CreatedByUserId);
            Assert.AreEqual(inventoryTag.UpdatedByUserId, inventoryTagsListVersions[1].UpdatedByUserId);
            Assert.AreEqual(inventoryTag.Name, inventoryTagsListVersions[1].Name);
            Assert.AreEqual(inventoryTag.Id, inventoryTagsListVersions[1].InventoryTagId);
            Assert.AreEqual(inventoryTag.WorkflowState, inventoryTagsListVersions[1].WorkflowState);
            Assert.AreEqual(2, inventoryTagsListVersions[1].Version);
        }

        [Test]
        public async Task InventoryTag_Delete_DoesDelete()
        {
            // Arrange
            var inventoryTag = new InventoryTag
            {
                Name = Guid.NewGuid().ToString(),
                CreatedByUserId = 1,
                UpdatedByUserId = 1,
            };

            // Act
            await inventoryTag.Create(DbContext);
            
            await inventoryTag.Delete(DbContext);

            var inventoryTagFromDb = DbContext.InventoryTags
                .AsNoTracking()
                .First();

            var inventoryTagsListVersions = DbContext.InventoryTagVersions
                .AsNoTracking()
                .ToList();


            // Assert
            Assert.AreEqual(inventoryTag.CreatedByUserId, inventoryTagFromDb.CreatedByUserId);
            Assert.AreEqual(inventoryTag.UpdatedByUserId, inventoryTagFromDb.UpdatedByUserId);
            Assert.AreEqual(inventoryTag.Name, inventoryTagFromDb.Name);
            Assert.AreEqual(inventoryTag.Id, inventoryTagFromDb.Id);
            Assert.AreEqual(2, inventoryTagFromDb.Version);
            Assert.AreEqual(Constants.WorkflowStates.Removed, inventoryTagFromDb.WorkflowState);

            // versions
            Assert.AreEqual(2, inventoryTagsListVersions.Count);
            Assert.AreEqual(inventoryTag.CreatedByUserId, inventoryTagsListVersions[0].CreatedByUserId);
            Assert.AreEqual(inventoryTag.UpdatedByUserId, inventoryTagsListVersions[0].UpdatedByUserId);
            Assert.AreEqual(inventoryTag.Name, inventoryTagsListVersions[0].Name);
            Assert.AreEqual(inventoryTag.Id, inventoryTagsListVersions[0].InventoryTagId);
            Assert.AreEqual(Constants.WorkflowStates.Created, inventoryTagsListVersions[0].WorkflowState);
            Assert.AreEqual(1, inventoryTagsListVersions[0].Version);

            Assert.AreEqual(inventoryTag.CreatedByUserId, inventoryTagsListVersions[1].CreatedByUserId);
            Assert.AreEqual(inventoryTag.UpdatedByUserId, inventoryTagsListVersions[1].UpdatedByUserId);
            Assert.AreEqual(inventoryTag.Name, inventoryTagsListVersions[1].Name);
            Assert.AreEqual(inventoryTag.Id, inventoryTagsListVersions[1].InventoryTagId);
            Assert.AreEqual(Constants.WorkflowStates.Removed, inventoryTagsListVersions[1].WorkflowState);
            Assert.AreEqual(2, inventoryTagsListVersions[1].Version);
        }
    }
}