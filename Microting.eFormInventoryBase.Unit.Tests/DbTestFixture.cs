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
    using System.Collections.Generic;
    using System.IO;
    using Infrastructure.Data;
    using Infrastructure.Data.Factories;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    public abstract class DbTestFixture
    {
        protected InventoryPnDbContext DbContext;
        private string _connectionString;
        private string _path;
        private const string NameDb = "inventory-pn-tests";


        private void GetContext(string connectionStr)
        {
            var contextFactory = new InventoryPnContextFactory();
            DbContext = contextFactory.CreateDbContext(new[] { connectionStr });

            DbContext.Database.Migrate();
            DbContext.Database.EnsureCreated();
        }

        [SetUp]
        public void Setup()
        {

            _connectionString =
                $@"Server = localhost; port = 3306; Database = {NameDb}; user = root; password = secretpassword; Convert Zero Datetime = true;";

            GetContext(_connectionString);


            DbContext.Database.SetCommandTimeout(300);

            try
            {
                ClearDb();
            }
            catch
            {
                DbContext.Database.Migrate();
            }

            DoSetup();
        }

        [TearDown]
        public void TearDown()
        {
            ClearDb();

            ClearFile();

            DbContext.Dispose();
        }

        private void ClearDb()
        {
            var modelNames = new List<string>
            {
                "Items",
                "ItemVersions",
                "ItemTypes",
                "ItemTypeVersions",
                "ItemGroups",
                "ItemGroupVersions",
                "ItemTypeDependencies",
                "ItemTypeDependenciesVersions",
                "ItemTypeTags",
                "ItemTypeTagVersions",
                "ItemTypeUploadedDatas",
                "ItemTypeUploadedDataVersions",
                "InventoryTags",
                "InventoryTagVersions",
                "ItemGroupDependencys",
                "ItemGroupDependencyVersions",
            };

            foreach (var modelName in modelNames)
            {
                try
                {
                    string sqlCmd;
                    if (DbContext.Database.IsMySql())
                    {
                        sqlCmd = $"SET FOREIGN_KEY_CHECKS = 0;TRUNCATE `{NameDb}`.`{modelName}`";
                    }
                    else
                    {
                        sqlCmd = $"DELETE FROM [{modelName}]";
                    }

                    DbContext.Database.ExecuteSqlRaw(sqlCmd);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ClearFile()
        {
            _path = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _path = Path.GetDirectoryName(_path)?.Replace(@"file:\", "");

            var picturePath = _path + @"\output\dataFolder\picture\Deleted";

            var diPic = new DirectoryInfo(picturePath);

            try
            {
                foreach (var file in diPic.GetFiles())
                {
                    file.Delete();
                }
            }
            catch
            {
                // ignored
            }
        }

        protected virtual void DoSetup()
        {
        }
    }
}