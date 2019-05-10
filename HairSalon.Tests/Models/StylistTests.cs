using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=stuart_mckay_test;";
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("test");
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Bob";
      Client newClient = new Client(name);

      //Act
      string result = newClient.GetName();

      //Assert
      Assert.AreEqual(name, result);
    }

    // [TestMethod]
    // public void SetName_SetName_String()
    // {
    //   //Arrange
    //   string name = "Bob";
    //   Client newClient = new Client(name);
    //
    //   //Act
    //   string updatedName = "Do the dishes";
    //   newClient.SetName(updatedName);
    //   string result = newClient.GetName();
    //
    //   //Assert
    //   Assert.AreEqual(updatedName, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ClientList()
    {
      //Arrange
      List<Client> newList = new List<Client> { };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNameAreTheSame_Client()
    {
      Client firstClient = new Client("Bob");
      Client secondClient = new Client("Samantha");
      Assert.AreEqual(firstClient, secondClient);
    }
    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      Client testClient = new Client("Bob");
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      //Arrange
      string name1 = "Bob";
      string name2 = "Samantha";
      Client newClient1 = new Client(name1);
      newClient1.Save();
      Client newClient2 = new Client(name2);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };

      //Act
      List<Client> result = Client.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_AssignsIdObject_Id()
    {
      Client testClient = new Client("Bob");
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      Assert.AreEqual(testId, result);

    }
    // [TestMethod]
    // public void GetId_ClientsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   //Arrange
    //   string name = "Bob";
    //   Client newClient = new Client(name);
    //
    //   //Act
    //   int result = newClient.GetId();
    //
    //   //Assert
    //   Assert.AreEqual(1, result);
    // }
    //
    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Bob");
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.AreEqual(testClient, foundClient);
    }


  }
}
