using System;
using System.Collections.Generic;
using System.Text;

namespace Prag
{
    class Faktura
    {
        private int fakturaID;
        private int arkivID;
        private DateTime fakturaDatum;
        private int summa;
        public Faktura(string text, string separator)
        {
            string[] temp = text.Split(separator);
            fakturaID = int.Parse(temp[0]);
            arkivID = int.Parse(temp[1]);
            fakturaDatum = DateTime.Parse(temp[2]);
            summa = int.Parse(temp[3]);
        }
        public Faktura(int arkivID, DateTime fakturaDatum)
        {
            this.arkivID = arkivID;
            this.fakturaDatum = fakturaDatum;
        }
        public Faktura()
        {
            FakturaID = 0;
        }
        public int FakturaID
        {
            get { return this.arkivID; }
            set { this.arkivID = value;}
        }
        public int ArkivID
        {
            get { return this.arkivID; }
            set { this.arkivID = value;}
        }
        public DateTime FakturaDatum
        { 
            get { return fakturaDatum; }
            set { fakturaDatum = value; }
        }
        public int Summa
        {
            get { return summa; }
            set { summa = value; }
        }
        public void CalculateSum(DateTime start,DateTime slut,FordonTyp typ)
        {
            int pris = 0;
            if (typ.Equals(FordonTyp.Bil))
                pris = (int)PrisTimme.Bil;
            if (typ.Equals(FordonTyp.MC))
                pris = (int)PrisTimme.MC;
            if (typ.Equals(FordonTyp.Buss))
                pris = (int)PrisTimme.Buss;
            double antalTimmar = slut.Subtract(start).TotalHours;
            Summa = ((int)antalTimmar+1) * pris;
        }
        public SQLQuery ToSQLQuery()
        {
            string sql = string.Format("INSERT INTO faktura (ArkivID,FakturaDatum,Summa) VALUES (@arkivID,@fakturaDatum,@summa)");
            SQLQuery sq = new SQLQuery(DatabasHantering.ConnectionString, sql);
            sq.com.Parameters.AddWithValue("@arkivID", ArkivID);
            sq.com.Parameters.AddWithValue("@fakturaDatum", FakturaDatum);
            sq.com.Parameters.AddWithValue("@summa", Summa);
            return sq;
        }
    }
}
