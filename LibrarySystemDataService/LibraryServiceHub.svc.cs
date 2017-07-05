using EntitiesCore;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

namespace LibrarySystemDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class LibraryServiceHub : ILibraryServiceHub
    {
        private MongoDatabase database;
        private MongoCollection<SampleTestCollection> collection;

        public LibraryServiceHub()
        {
            GetDatabase();
            GetCollection();
        }

        public bool Insert(SampleTestCollection entity)
        {
            entity.Id = Guid.NewGuid();//MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            return collection.Insert(entity).Ok;
        }

        public bool Update(SampleTestCollection entity)
        {
            if (entity.Id == null)
                return Insert(entity);

            return collection
                .Save(entity)
                    .DocumentsAffected > 0;
        }

        public bool Delete(SampleTestCollection entity)
        {
            return collection
                .Remove(Query.EQ("_id", entity.Id))
                    .DocumentsAffected > 0;
        }

        public IList<SampleTestCollection>
            SearchFor(Expression<Func<SampleTestCollection, bool>> predicate)
        {
            return collection
                .AsQueryable<SampleTestCollection>()
                    .Where(predicate.Compile())
                        .ToList();
        }

        public IList<SampleTestCollection> GetAll()
        {
            return collection.FindAllAs<SampleTestCollection>().ToList();
        }

        public SampleTestCollection GetById(Guid id)
        {
            return collection.FindOneByIdAs<SampleTestCollection>(id);
        }

        #region Private Helper Methods
        private void GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());
            var server = client.GetServer();

            database = server.GetDatabase(GetDatabaseName());
        }

        private string GetConnectionString()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbConnectionString");
        }

        private string GetDatabaseName()
        {
            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbDatabaseName");
        }

        private void GetCollection()
        {
            collection = database
                .GetCollection<SampleTestCollection>(typeof(SampleTestCollection).Name);
        }

        #endregion
    }
}
