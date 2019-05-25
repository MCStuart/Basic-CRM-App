using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int stylist_id { get; set; }
        public string stylist_name { get; set; }

        public Stylist(int stylistId, string stylistName)
        {
            stylist_id = stylistId;
            stylist_name = stylistName;
        }

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = this.stylist_id.Equals(newStylist.stylist_id);
                bool nameEquality = this.stylist_name.Equals(newStylist.stylist_name);
                return (idEquality && nameEquality);
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylist (stylist_name) VALUES (@stylist_name);";
            MySqlParameter stylist_name = new MySqlParameter();
            stylist_name.ParameterName = "@stylist_name";
            stylist_name.Value = this.stylist_name;
            cmd.Parameters.Add(stylist_name);
            cmd.ExecuteNonQuery();
            stylist_id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylist;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                Stylist newStylist = new Stylist(stylistId, stylistName);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public static Stylist Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylist WHERE stylist_id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int stylistId = 0;
            string stylistName = "";

            while(rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
            }
            Stylist newStylist = new Stylist(stylistId, stylistName);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newStylist;
        }

        public List<Client> GetClients()
        {
            List<Client> allStylistClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM client WHERE preferred_stylist_id = @stylist_id;";
            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@stylist_id";
            stylistId.Value = this.stylist_id;
            cmd.Parameters.Add(stylistId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int preferredStylistId = rdr.GetInt32(2);
                Client newClient = new Client(clientId, clientName, preferredStylistId);
                allStylistClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylistClients;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylist;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Specialty> GetSpecialties()
       {
           List<Specialty> stylistSpecialties = new List<Specialty> {};
           MySqlConnection conn = DB.Connection();
           conn.Open();
           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"SELECT specialty.* FROM stylist JOIN stylist_specialties ON (stylist.stylist_id = stylist_specialties.stylist_id) JOIN specialty ON (stylist_specialties.specialty_id = specialty.specialty_id) WHERE stylist.stylist_id = @searchId;";
           MySqlParameter searchId = new MySqlParameter();
           searchId.ParameterName = "@searchId";
           searchId.Value = this.stylist_id;
           cmd.Parameters.Add(searchId);
           int specialtyId = 0;
           string specialtyStyle = "";
           var rdr = cmd.ExecuteReader() as MySqlDataReader;
           while(rdr.Read())
           {
               specialtyId = rdr.GetInt32(0);
               specialtyStyle= rdr.GetString(1);
               Specialty newSpecialty = new Specialty(specialtyId, specialtyStyle);
               stylistSpecialties.Add(newSpecialty);
           }
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return stylistSpecialties;
       }

       public void AddSpecialty(int specialtyId)
       {
           MySqlConnection conn = DB.Connection();
           conn.Open();
           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"INSERT INTO stylist_specialties (specialty_id, stylist_id) VALUES (@specialtyId, @stylistId);";
           MySqlParameter specialty_Id = new MySqlParameter();
           specialty_Id.ParameterName = "@specialtyId";
           specialty_Id.Value = specialtyId;
           cmd.Parameters.Add(specialty_Id);
           MySqlParameter stylistid = new MySqlParameter();
           stylistid.ParameterName = "@stylistId";
           stylistid.Value = this.stylist_id;
           cmd.Parameters.Add(stylistid);
           cmd.ExecuteNonQuery();
           stylist_id = (int) cmd.LastInsertedId;
           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
       }
    }
}
