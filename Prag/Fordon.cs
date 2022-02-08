using System;
using System.Collections.Generic;
using System.Text;

namespace Prag
{
    public enum FordonTyp
    {
        None,
        Bil,
        MC,
        Buss
    }
    public enum PrisTimme
    {
        Gratis = 0,
        Bil = 40,
        MC = 25,
        Buss = 300
    }
    class Fordon
    {
        private string regNr;
        private FordonTyp typ;

        public Fordon(string regNr,FordonTyp typ)
        {
            RegNr = regNr;
            Typ = typ;
        }
        public Fordon(string regNr)
        {
            RegNr=regNr;
        }
        public Fordon()
        {
        }
        public string RegNr
        {
            get { return regNr; }
            set //skrubbar stringen från dåliga inmatningar.
            {
                if (value.Length > 6)
                    regNr = value.Substring(0, 6);
                else
                    regNr = value;
            }
        }
        public FordonTyp Typ
        {
            get { return typ; }
            set { typ = value; }
        }
        public bool GenerateTestData(FordonTyp typ)
        {
            string regNr = Testdata.SlumpaRegNr();
            RegNr = regNr;
            Typ = typ;
            return true;
        }
        public SQLQuery ToSQLQuery()
        {
            string sql = string.Format("INSERT INTO fordon (RegNr,FordonTyp) VALUES (@regNr,@fordonTyp)");
            SQLQuery sq = new SQLQuery(DatabasHantering.ConnectionString, sql);
            sq.com.Parameters.AddWithValue("@regNr", RegNr);
            sq.com.Parameters.AddWithValue("@fordonTyp", (int)Typ);
            return sq;
        }
    }
}
