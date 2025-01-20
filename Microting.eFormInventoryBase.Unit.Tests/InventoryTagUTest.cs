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
            Assert.That(inventoryTagsList.Count, Is.EqualTo(1));
            Assert.That(inventoryTagsList[0].CreatedByUserId, Is.EqualTo(inventoryTag.CreatedByUserId));
            Assert.That(inventoryTagsList[0].UpdatedByUserId, Is.EqualTo(inventoryTag.UpdatedByUserId));
            Assert.That(inventoryTagsList[0].Name, Is.EqualTo(inventoryTag.Name));
            Assert.That(inventoryTagsList[0].Id, Is.EqualTo(inventoryTag.Id));
            Assert.That(inventoryTagsList[0].Version, Is.EqualTo(1));
            Assert.That(inventoryTagsList[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryTagsList[0].WorkflowState, Is.EqualTo(inventoryTag.WorkflowState));


            // versions
            Assert.That(inventoryTagsListVersions.Count, Is.EqualTo(1));
            Assert.That(inventoryTagsListVersions[0].CreatedByUserId, Is.EqualTo(inventoryTag.CreatedByUserId));
            Assert.That(inventoryTagsListVersions[0].UpdatedByUserId, Is.EqualTo(inventoryTag.UpdatedByUserId));
            Assert.That(inventoryTagsListVersions[0].Name, Is.EqualTo(inventoryTag.Name));
            Assert.That(inventoryTagsListVersions[0].InventoryTagId, Is.EqualTo(inventoryTag.Id));
            Assert.That(inventoryTagsListVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryTagsListVersions[0].WorkflowState, Is.EqualTo(inventoryTag.WorkflowState));
            Assert.That(inventoryTagsListVersions[0].Version, Is.EqualTo(1));
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
            Assert.That(inventoryTagFromDb.CreatedByUserId, Is.EqualTo(inventoryTag.CreatedByUserId));
            Assert.That(inventoryTagFromDb.UpdatedByUserId, Is.EqualTo(inventoryTag.UpdatedByUserId));
            Assert.That(inventoryTagFromDb.Name, Is.EqualTo(inventoryTag.Name));
            Assert.That(inventoryTagFromDb.Id, Is.EqualTo(inventoryTag.Id));
            Assert.That(inventoryTagFromDb.Version, Is.EqualTo(2));
            Assert.That(inventoryTagFromDb.WorkflowState, Is.EqualTo(inventoryTag.WorkflowState));

            // versions
            Assert.That(inventoryTagsListVersions.Count, Is.EqualTo(2));
            Assert.That(inventoryTagsListVersions[0].CreatedByUserId, Is.EqualTo(oldInventoryTagsList.CreatedByUserId));
            Assert.That(inventoryTagsListVersions[0].UpdatedByUserId, Is.EqualTo(oldInventoryTagsList.UpdatedByUserId));
            Assert.That(inventoryTagsListVersions[0].Name, Is.EqualTo(oldInventoryTagsList.Name));
            Assert.That(inventoryTagsListVersions[0].InventoryTagId, Is.EqualTo(oldInventoryTagsList.Id));
            Assert.That(inventoryTagsListVersions[0].WorkflowState, Is.EqualTo(oldInventoryTagsList.WorkflowState));
            Assert.That(inventoryTagsListVersions[0].Version, Is.EqualTo(1));

            Assert.That(inventoryTagsListVersions[1].CreatedByUserId, Is.EqualTo(inventoryTag.CreatedByUserId));
            Assert.That(inventoryTagsListVersions[1].UpdatedByUserId, Is.EqualTo(inventoryTag.UpdatedByUserId));
            Assert.That(inventoryTagsListVersions[1].Name, Is.EqualTo(inventoryTag.Name));
            Assert.That(inventoryTagsListVersions[1].InventoryTagId, Is.EqualTo(inventoryTag.Id));
            Assert.That(inventoryTagsListVersions[1].WorkflowState, Is.EqualTo(inventoryTag.WorkflowState));
            Assert.That(inventoryTagsListVersions[1].Version, Is.EqualTo(2));
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
            Assert.That(inventoryTagFromDb.CreatedByUserId, Is.EqualTo(inventoryTag.CreatedByUserId));
            Assert.That(inventoryTagFromDb.UpdatedByUserId, Is.EqualTo(inventoryTag.UpdatedByUserId));
            Assert.That(inventoryTagFromDb.Name, Is.EqualTo(inventoryTag.Name));
            Assert.That(inventoryTagFromDb.Id, Is.EqualTo(inventoryTag.Id));
            Assert.That(inventoryTagFromDb.Version, Is.EqualTo(2));
            Assert.That(inventoryTagFromDb.WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));

            // versions
            Assert.That(inventoryTagsListVersions.Count, Is.EqualTo(2));
            Assert.That(inventoryTagsListVersions[0].CreatedByUserId, Is.EqualTo(inventoryTag.CreatedByUserId));
            Assert.That(inventoryTagsListVersions[0].UpdatedByUserId, Is.EqualTo(inventoryTag.UpdatedByUserId));
            Assert.That(inventoryTagsListVersions[0].Name, Is.EqualTo(inventoryTag.Name));
            Assert.That(inventoryTagsListVersions[0].InventoryTagId, Is.EqualTo(inventoryTag.Id));
            Assert.That(inventoryTagsListVersions[0].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Created));
            Assert.That(inventoryTagsListVersions[0].Version, Is.EqualTo(1));

            Assert.That(inventoryTagsListVersions[1].CreatedByUserId, Is.EqualTo(inventoryTag.CreatedByUserId));
            Assert.That(inventoryTagsListVersions[1].UpdatedByUserId, Is.EqualTo(inventoryTag.UpdatedByUserId));
            Assert.That(inventoryTagsListVersions[1].Name, Is.EqualTo(inventoryTag.Name));
            Assert.That(inventoryTagsListVersions[1].InventoryTagId, Is.EqualTo(inventoryTag.Id));
            Assert.That(inventoryTagsListVersions[1].WorkflowState, Is.EqualTo(Constants.WorkflowStates.Removed));
            Assert.That(inventoryTagsListVersions[1].Version, Is.EqualTo(2));
        }
    }
}