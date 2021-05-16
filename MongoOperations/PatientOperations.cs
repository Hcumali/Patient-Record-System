using HastaTakipSistemi.DBModels;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HastaTakipSistemi.MongoOperations
{
    public class PatientOperations
    {
        // Databaseye hasta kayıdı ekleme
        public static Boolean HastaKayitOlustur(Patient hasta)
        {
            var client = new MongoClient("mongodb+srv://hakann:123456asdasd@hastatakip.djqeb.mongodb.net/HastaTakip?retryWrites=true&w=majority");
            var db = client.GetDatabase("HastaTakip");
            var collec = db.GetCollection<Patient>("PatientRecord");

            try{
                collec.InsertOne(hasta);
                // Hasta hatasız bir şekilde eklenir ise true döndür.
                return true;
            }
            catch
            {
                // Hata yakarsan false döndür.
                return false;
            }
        }

        // Databesedeki tüm veriyi çekme
        public static List<Patient> HastaKayitListele()
        {
            var client = new MongoClient("mongodb+srv://hakann:123456asdasd@hastatakip.djqeb.mongodb.net/HastaTakip?retryWrites=true&w=majority");
            var db = client.GetDatabase("HastaTakip");
            var collec = db.GetCollection<Patient>("PatientRecord");

            return collec.Find(_ => true).ToList();
        }

    }
}