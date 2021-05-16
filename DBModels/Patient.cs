using MongoDB.Bson;
using System;

namespace HastaTakipSistemi.DBModels
{
    public class Patient
    {
        public ObjectId _id;
        public string TC;
        public string Ad;
        public string Soyad;
        public string Adres;
        public string TelNo;
        public int Yas;
        public string Tani;
        public string Giris;
        public string Cikis;
    }
}