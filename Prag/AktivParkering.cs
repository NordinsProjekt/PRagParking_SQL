using System;
using System.Collections.Generic;
using System.Text;

namespace Prag
{
    class AktivParkering
    {
        private int aktivID;
        private int rutaID;
        private string regNr;
        private int personID;
        private DateTime startDatumTid;
        private DateTime slutDatumTid; //Används bara vid arkivering
        public AktivParkering(string text, string separator)
        {
            string[] temp = text.Split(separator);
            aktivID = int.Parse(temp[0]);
            rutaID = int.Parse(temp[1]);
            regNr = temp[2];
            personID = int.Parse(temp[3]);
            startDatumTid = DateTime.Parse(temp[4]);
        }
        public int AktivID
        {
            get { return aktivID; }
            set { aktivID = value; }
        }
        public int RutaID
        {
            set { rutaID = value; }
            get { return rutaID; }
        }
        public string RegNr
        {
            get { return regNr; }
            set { regNr = value; }
        }
        public int PersonID
        {
            get { return personID; }
            set { personID = value; }
        }
        public DateTime StartDatumTid
        {
            get { return startDatumTid; }
            set { startDatumTid = value; }
        }
        public DateTime SlutDatumTid
        {
            get { return slutDatumTid; }
            set { slutDatumTid = value; }
        }
        public SQLQuery Arkivera()
        {
            //Arkivera post
            SlutDatumTid = DateTime.Now;
            string sql = "INSERT INTO arkiv (RutaID,RegNr,PersonID,StartDatumTid,SlutDatumTid) VALUES (@rutaID,@regNr,@personID,@startDatumTid,@slutDatumTid);";
            SQLQuery sq = new SQLQuery(DatabasHantering.ConnectionString, sql);
            sq.com.Parameters.AddWithValue("@rutaID", RutaID);
            sq.com.Parameters.AddWithValue("@regNr", RegNr);
            sq.com.Parameters.AddWithValue("@personID", PersonID);
            sq.com.Parameters.AddWithValue("@startDatumTid", StartDatumTid);
            sq.com.Parameters.AddWithValue("@slutDatumTid", SlutDatumTid);
            return sq;
        }
        public SQLQuery Arkivera(DateTime slut)
        {
            //Arkivera post
            SlutDatumTid = slut;
            string sql = "INSERT INTO arkiv (RutaID,RegNr,PersonID,StartDatumTid,SlutDatumTid) VALUES (@rutaID,@regNr,@personID,@startDatumTid,@slutDatumTid);";
            SQLQuery sq = new SQLQuery(DatabasHantering.ConnectionString, sql);
            sq.com.Parameters.AddWithValue("@rutaID", RutaID);
            sq.com.Parameters.AddWithValue("@regNr", RegNr);
            sq.com.Parameters.AddWithValue("@personID", PersonID);
            sq.com.Parameters.AddWithValue("@startDatumTid", StartDatumTid);
            sq.com.Parameters.AddWithValue("@slutDatumTid", SlutDatumTid);
            return sq;
        }
        public int GetArkivID()
        {
            string sql = "SELECT ArkivID FROM arkiv WHERE RutaID = @rutaID AND RegNr = @regNr " +
                "AND PersonID = @personID AND StartDatumTid = @startDatumTid AND SlutDatumTid = @slutDatumTid;";
            SQLQuery sq = new SQLQuery(DatabasHantering.ConnectionString, sql);
            sq.com.Parameters.AddWithValue("@rutaID", RutaID);
            sq.com.Parameters.AddWithValue("@regNr", RegNr);
            sq.com.Parameters.AddWithValue("@personID", PersonID);
            sq.com.Parameters.AddWithValue("@startDatumTid", StartDatumTid);
            sq.com.Parameters.AddWithValue("@slutDatumTid", SlutDatumTid);
            try
            {
                string resultat = DatabasHantering.GetStringFromQuery(sq, "");
                return int.Parse(resultat);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int UpdateAktiv(int nyttID)
        {
            string sql = "UPDATE aktiv SET RutaID = @nyttid WHERE AktivID = @aktivID ";
            SQLQuery sq = new SQLQuery(DatabasHantering.ConnectionString, sql);
            sq.com.Parameters.AddWithValue("@nyttid",nyttID);
            sq.com.Parameters.AddWithValue("@aktivID", AktivID);
            try
            {
                return DatabasHantering.SendSqlQuery(sq);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
