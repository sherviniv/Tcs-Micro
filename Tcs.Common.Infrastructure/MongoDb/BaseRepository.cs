using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using Tcs.Common.Domain.Exceptions;

namespace Tcs.Common.Infrastructure.MongoDb
{
    public class BaseRepository
    {
        protected readonly IMongoDatabase MongoDatabase;

        protected BaseRepository(MongoDbSettings settings)
        {
            if(settings == null) 
                throw new TcsException("empty_settings",
                     "Database settings must be defined.");

            if (string.IsNullOrEmpty(settings.ServerConnection))
                throw new TcsException("empty_settings_serverConnection",
                     "ServerConnection can not be empty.");

            if (string.IsNullOrEmpty(settings.Database))
                throw new TcsException("empty_settings_database",
                     "Database name must be defined.");

            var client = new MongoClient(settings.ServerConnection);

            MongoDatabase = client.GetDatabase(settings.Database,
                new MongoDatabaseSettings
                {
                    GuidRepresentation = GuidRepresentation.Standard
                });
        }
    }
}
