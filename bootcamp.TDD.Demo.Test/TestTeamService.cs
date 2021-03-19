using bootcamp.TDD.Demo.Core;
using bootcamp.TDD.Demo.Core.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace bootcamp.TDD.Demo.Test
{
    [TestClass]
    public class TestTeamService
    {

        private TeamService service;

        [TestInitialize]
        public void setup()
        {
            IMongoDbSettings settings = new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                Database = "NBADatabase",
                Collection = "teams"
            };

            service = new TeamService(settings);
        }
        [TestMethod]
        public void Get_Should_Retrieve_AllTeam()
        {
            
            List<Team> teams = service.GetAll();
            Assert.AreNotEqual(0, teams.Count);

        }
        [TestMethod]
        public void Get_Should_Retrieve_Team_ByID()
        {
            string id = "6054f5e8e3a88a7b802baba1";
            Team team = service.GetSingle(id);
            Assert.AreNotEqual(null, team);
            Assert.AreEqual("Atlanta Hawks", team.TeamName);
        }
        [TestMethod]
        public void Create_Should_Add_TeamInfo()
        {
            Team team = new Team { 
            TeamName = "kızılkale beydağ spor",
            SimpleName = "kızılkale",
            Location = "Zara",
            Abbreviation = "KBS"

            };
            var inserted = service.Create(team);
            Assert.AreNotEqual(0, inserted.Id);
            Assert.AreEqual(24, inserted.Id.Length);
        }
        [TestMethod]
        public void Delete_Should_Remove_Team()
        {
            var id = "60550616d16393f6168e5a79";
            var deletedCount = service.Delete(id);
            Assert.AreEqual(1, deletedCount);
        }
        [TestMethod]
        public void Update_Should_Replace_TeamInfo()
        {
            string id = "605506a91630e4d6cb6e5cb9";
            Team currentInfo = new Team {
                Id = "605506a91630e4d6cb6e5cb9",
            TeamName = "kizilkale beydag spor"};
            long updatedCount = service.Update(id, currentInfo);
            Assert.AreEqual(1, updatedCount);
        }
    }
}
