using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {

    public void Dispose()
    {
      Stylist.ClearAll();
    }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      Stylist newStylist = new Stylist("Krystal");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Stylist";
      Stylist newStylist = new Stylist(name);

      //Act
      string result = newStylist.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetId_ReturnsStylistId_Int()
    {
      //Arrange
      string name = "Test Stylist";
      Stylist newStylist = new Stylist(name);

      //Act
      int result = newStylist.GetId();

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllStylistObjects_StylistList()
    {
      //Arrange
      string name1 = "Krystal";
      string name2 = "Jamie";
      Stylist newStylist1 = new Stylist(name1);
      Stylist newStylist2 = new Stylist(name2);
      List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };

      //Act
      List<Stylist> result = Stylist.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectStylist_Stylist()
    {
      //Arrange
      string name1 = "Krystal";
      string name2 = "Jamie";
      Stylist newStylist1 = new Stylist(name1);
      Stylist newStylist2 = new Stylist(name2);

      //Act
      Stylist result = Stylist.Find(2);

      //Assert
      Assert.AreEqual(newStylist2, result);
    }

    [TestMethod]
    public void GetClients_ReturnsEmptyClientList_ClientList()
    {
      //Arrange
      string name = "Krystal";
      Stylist newStylist = new Stylist(name);
      List<Client> newList = new List<Client> { };

      //Act
      List<Client> result = newStylist.GetClients();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void AddClient_AssociatesClientWithStylist_ClientList()
    {
      //Arrange
      string client = "Mr. Clean";
      Client newClient = new Client(client);
      List<Client> newList = new List<Client> { newClient };
      string name = "Krystal";
      Stylist newStylist = new Stylist(name);
      newStylist.AddClient(newClient);

      //Act
      List<Client> result = newStylist.GetClients();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

  }
}
