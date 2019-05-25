using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    public int client_id { get; set; }
    public string client_name { get; set; }
    public int preferred_stylist_id { get; set; }

    public Client(int client_id, string client_name, int preferred_stylist_id)
    {
      client_id = client_id;
      client_name = client_name;
      preferred_stylist_id = preferred_stylist_id;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.client_id == newClient.client_id);
        bool nameEquality = (this.client_name == newClient.client_name);
        bool stylistEquality = (this.preferred_stylist_id == newClient.preferred_stylist_id);
        return (idEquality && nameEquality && stylistEquality);
      }
    }


    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO client (client_name, preferred_stylist_id) VALUES (@ClientName, @PreferredStylistId);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@ClientName";
      name.Value = this.client_name;
      MySqlParameter preferredStylistId = new MySqlParameter();
      preferredStylistId.ParameterName = "@PreferredStylistId";
      preferredStylistId.Value = this.preferred_stylist_id;
      cmd.Parameters.Add(client_name);
      cmd.Parameters.Add(preferred_stylist_id);
      cmd.ExecuteNonQuery();
      client_id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE client SET client_name = @newName WHERE client_id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = client_id;
      cmd.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      client_name = newName;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int preferredStylistId = rdr.GetInt32(2);
        Client newClient = new Client(clientId, clientName, preferredStylistId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public void DeleteClient()
{
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"DELETE FROM clients WHERE client_id = @searchId;";
    MySqlParameter searchId = new MySqlParameter();
    searchId.ParameterName = "@searchId";
    searchId.Value = client_id;
    cmd.Parameters.Add(searchId);
    cmd.ExecuteNonQuery();
    conn.Close();
    if (conn != null)
    {
        conn.Dispose();
    }
}

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM client;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Client Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM client WHERE client_id = (@stylistId);";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@stylistId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int clientId = 0;
      string clientName = "";
      int preferredStylistId = 0;
      // Client foundClient = new Client(clientName, clientDueDate, clientStylistId, clientId);
      // DateTime dueDate = 0;
      while(rdr.Read())
      {
        clientId = rdr.GetInt32(0);
        clientName = rdr.GetString(1);
        preferredStylistId = rdr.GetInt32(2);
      }
      Client foundClient = new Client(clientId, clientName, preferredStylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundClient;
    }
  }
}
