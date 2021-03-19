using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace bootcamp.TDD.Demo.Core
{
    public class TeamService
    {
        private readonly IMongoCollection<Team> _teams;
        public TeamService(IMongoDbSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.Database);
            _teams = db.GetCollection<Team>(settings.Collection);
        }
        public List<Team> GetAll() => _teams.Find(t => true).ToList();

        public Team GetSingle(string id)
        {
            return _teams.Find(t => t.Id == id).FirstOrDefault();
        }

        public Team Create(Team team)
        {
            _teams.InsertOne(team);
            return team;
        }

        public long Delete(string id)
        {
            var result = _teams.DeleteOne(t => t.Id == id).DeletedCount;
            return result;
        }

        public long Update(string id, Team currentInfo) => _teams.ReplaceOne(t => t.Id == id, currentInfo).ModifiedCount;
    }
}