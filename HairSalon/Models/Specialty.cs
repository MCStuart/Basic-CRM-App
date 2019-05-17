using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Style { get; set; }

        public Specialty(string style, int id = 0)
        {
            Id = id;
            Style = style;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (style) VALUES (@style);";
            MySqlParameter style = new MySqlParameter();
            style.ParameterStyle = "@style";
            style.Value = this.Style;
            cmd.Parameters.Add(style);

            cmd.ExecuteNonQuery();
            Id = (int) cmd.LastInsertedId;
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
            cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterStyle = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int Id = 0;
            string Style = "";
            while(rdr.Read())
            {
                Id = rdr.GetInt32(0);
                Style = rdr.GetString(1);
            }
            Specialty newSpecialty = new Specialty(Style, Id);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newSpecialty;
        }

        public void AddStylist(Stylist newStylist)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO checkouts (specialty_id, stylist_id) VALUES (@SpecialtyId, @StylistId);";
            MySqlParameter specialty_id = new MySqlParameter();
            specialty_id.ParameterStyle = "@SpecialtyId";
            specialty_id.Value = Id;
            cmd.Parameters.Add(specialty_id);
            MySqlParameter stylist_id = new MySqlParameter();
            stylist_id.ParameterStyle = "@StylistId";
            stylist_id.Value = newStylist.Id;
            cmd.Parameters.Add(stylist_id);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                string Style = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(Style, Id);
                allSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }

        public List<Stylist> GetStylists()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT stylists.* FROM specialties
            JOIN checkouts ON (specialties.id = checkouts.specialty_id)
            JOIN stylists ON (checkouts.stylist_id = stylists.id)
            WHERE specialties.id = @SpecialtyId;";
            MySqlParameter specialtyIdParameter = new MySqlParameter();
            specialtyIdParameter.ParameterStyle = "@SpecialtyId";
            specialtyIdParameter.Value = Id;
            cmd.Parameters.Add(specialtyIdParameter);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Stylist> stylists = new List<Stylist>{};
            while(rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                string Style = rdr.GetString(1);
                Stylist newStylist = new Stylist(Style, Id);
                stylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return stylists;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";
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
                bool idEquality = this.Id.Equals(newSpecialty.Id);
                bool styleEquality = this.Style.Equals(newSpecialty.Style);
                return (idEquality && styleEquality);
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM specialties WHERE id = @SpecialtyId; DELETE FROM checkouts WHERE specialty_id = @SpecialtyId;", conn);
            MySqlParameter specialtyIdParameter = new MySqlParameter();
            specialtyIdParameter.ParameterStyle = "@SpecialtyId";
            specialtyIdParameter.Value = this.Id;
            cmd.Parameters.Add(specialtyIdParameter);
            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static Specialty Search(string style)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties WHERE style = @style;";
            cmd.Parameters.AddWithValue("@style", style);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int Id = 0;
            string Style = "";
            while(rdr.Read())
            {
                Id = rdr.GetInt32(0);
                Style = rdr.GetString(1);
            }
            Specialty newSpecialty = new Specialty(Style, Id);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newSpecialty;
        }

    }
}
