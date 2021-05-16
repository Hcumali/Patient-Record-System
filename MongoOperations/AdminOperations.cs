using HastaTakipSistemi.DBModels;
using MongoDB.Driver;
using System;
using System.Linq;

namespace HastaTakipSistemi.MongoOperations
{
    public class AdminOperations
    {
        public static Boolean IsThereAdmin(Admin admin)
        {
            var client = new MongoClient("mongodb+srv://hakann:123456asdasd@hastatakip.djqeb.mongodb.net/HastaTakip?retryWrites=true&w=majority");
            var db = client.GetDatabase("HastaTakip");
            var collec = db.GetCollection<Admin>("Admin");

            var filter = Builders<Admin>.Filter.Eq(x => x.userName, admin.userName);
            filter &= (Builders<Admin>.Filter.Eq(x => x.password, admin.password));


            var firstDocument = collec.Find(filter).ToList();
            if (firstDocument.Count == 1)
            {
                return true;
            }
            return false;

        }
    }
}