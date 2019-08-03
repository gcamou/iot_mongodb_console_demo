using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDbConsoleDemo.Models;

namespace MongoDbConsoleDemo.Repository
{
    public class AssetsRepository
    {
        public IMongoCollection<Asset> _assets;
        public AssetsRepository()
        {
            var connectionString = "mongodb://sa:sa@clusteriot-shard-00-00-ymfdv.azure.mongodb.net:27017,clusteriot-shard-00-01-ymfdv.azure.mongodb.net:27017,clusteriot-shard-00-02-ymfdv.azure.mongodb.net:27017/IoT?ssl=true&replicaSet=ClusterIoT-shard-0&authSource=admin&retryWrites=true&w=majority";
            var dbName = "IoT";
            var collectionName = "AssetOne";

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);


            _assets = database.GetCollection<Asset>(collectionName);
            
        }
        public List<Asset> Get() =>
            _assets.Find(asset => true).ToList();

        public Asset Get(string id) =>
            _assets.Find<Asset>(asset => asset.Id == id).FirstOrDefault();

        public Asset Create(Asset assetOne)
        {
            _assets.InsertOne(assetOne);
            return assetOne;
        }

        public void Update(string id, Asset assetOneIn) =>
            _assets.ReplaceOne(asset => asset.Id == id, assetOneIn);

        public void Remove(Asset assetOneIn) =>
            _assets.DeleteOne(asset => asset.Id == assetOneIn.Id);

        public void Remove(string id) =>
            _assets.DeleteOne(asset => asset.Id == id);
        public T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(new Random().Next(v.Length));
        }

    }
}