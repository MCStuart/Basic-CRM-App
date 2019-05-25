using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Specialty
    {
        public int specialty_id { get; set; }
        public string specialty_style { get; set; }

        public Specialty(int id, string style)
        {
            specialty_id = id;
            specialty_style = style;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialty;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty) otherSpecialty;
                bool idEquality = this.specialty_id == newSpecialty.specialty_id;
                bool styleEquality = (this.specialty_style == newSpecialty.specialty_style);
                return (idEquality && styleEquality);
            }
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialty;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string specialtystyle = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(specialtyId, specialtystyle);
                allSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialty (specialty_style) VALUES (@specialty_style);";
            MySqlParameter styleParam = new MySqlParameter();
            styleParam.ParameterName = "@specialty_style";
            styleParam.Value = this.specialty_style;
            cmd.Parameters.Add(styleParam);
            MySqlParameter price = new MySqlParameter();
            cmd.ExecuteNonQuery();
            specialty_id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Specialty Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialty WHERE specialty_id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int specialtyId = 0;
            string specialtyStyle = "";
            while(rdr.Read())
            {
                specialtyId = rdr.GetInt32(0);
                specialtyStyle = rdr.GetString(1);
            }
            Specialty foundSpecialty = new Specialty(specialtyId, specialtyStyle);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundSpecialty;
        }

        public void Edit(string newStyle)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE specialty SET specialty_style = @newStyle WHERE specialty_id = @searchId;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = specialty_id;
            cmd.Parameters.Add(searchId);
            MySqlParameter specialtyStyle = new MySqlParameter();
            specialtyStyle.ParameterName = "@newStyle";
            specialtyStyle.Value = newStyle;
            cmd.Parameters.Add(specialtyStyle);
            cmd.ExecuteNonQuery();
            specialty_style = newStyle;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void DeleteSpecialty()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialty WHERE specialty_id = @searchId;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = specialty_id;
            cmd.Parameters.Add(searchId);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void AddStylist(int stylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylist_specialties (stylist_id, specialty_id) VALUES (@specialtyId, @stylistId);";
            MySqlParameter specialtyId = new MySqlParameter();
            specialtyId.ParameterName = "@specialtyId";
            specialtyId.Value = this.specialty_id;
            cmd.Parameters.Add(specialtyId);
            MySqlParameter stylistid = new MySqlParameter();
            stylistid.ParameterName = "@stylistId";
            stylistid.Value = stylistId;
            cmd.Parameters.Add(stylistid);
            cmd.ExecuteNonQuery();
            specialty_id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Stylist> GetStylists()
        {
            List<Stylist> stylistSpecialties = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT stylist.* FROM specialty JOIN stylist_specialties ON (specialty.specialty_id = stylist_specialties.specialty_id) JOIN stylist ON (stylist_specialties.stylist_id = stylist.stylist_id) WHERE specialty.specialty_id = @searchId;";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = this.specialty_id;
            cmd.Parameters.Add(searchId);
            int stylistId = 0;
            string stylistName = "";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                stylistId = rdr.GetInt32(0);
                stylistName = rdr.GetString(1);
                Stylist foundStylist = new Stylist(stylistId, stylistName);
                stylistSpecialties.Add(foundStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return stylistSpecialties;
        }
    }
}
