using MongoDB.Bson;
using System;

namespace HastaTakipSistemi.DBModels
{
    public class Admin
    {
        public ObjectId _id;
        public string userName;
        public string password;
    }
}