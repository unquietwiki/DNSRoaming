﻿using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DNS_Roaming_Common;

namespace DNS_Roaming_Unit_Tests
{
    [TestClass]
    public class TestNetworkExtensions
    {
        [TestMethod]
        public void GetNetworkAddress_SameSubNet_Equals()
        {
            //Arange
            IPAddress ip1 = IPAddress.Parse("192.168.1.1");
            IPAddress subnet1 = IPAddress.Parse("255.255.255.0");

            IPAddress ip2 = IPAddress.Parse("192.168.1.100");
            IPAddress subnet2 = IPAddress.Parse("255.255.255.0");

            //Act
            IPAddress network1 = ip1.GetNetworkAddress(subnet1);
            IPAddress network2 = ip2.GetNetworkAddress(subnet2);

            //Asset
            Assert.IsTrue(network1.Equals(network2));
        }

        [TestMethod]
        public void GetNetworkAddress_DiffentAddress_NotEquals()
        {
            //Arange
            IPAddress ip1 = IPAddress.Parse("192.168.0.1");
            IPAddress subnet1 = IPAddress.Parse("255.255.255.0");

            IPAddress ip2 = IPAddress.Parse("192.168.1.100");
            IPAddress subnet2 = IPAddress.Parse("255.255.255.0");

            //Act
            IPAddress network1 = ip1.GetNetworkAddress(subnet1);
            IPAddress network2 = ip2.GetNetworkAddress(subnet2);

            //Asset
            Assert.IsFalse(network1.Equals(network2));
        }

        [TestMethod]
        public void GetNetworkAddress_DiffentSubNet_NotEquals()
        {
            //Arange
            IPAddress ip1 = IPAddress.Parse("192.168.1.1");
            IPAddress subnet1 = IPAddress.Parse("255.255.0.0");

            IPAddress ip2 = IPAddress.Parse("192.168.1.1");
            IPAddress subnet2 = IPAddress.Parse("255.255.255.0");

            //Act
            IPAddress network1 = ip1.GetNetworkAddress(subnet1);
            IPAddress network2 = ip2.GetNetworkAddress(subnet2);

            //Asset
            Assert.IsFalse(network1.Equals(network2));
        }

        
        [TestMethod]
        public void GetDNSSetIPAddress_Blank_ReturnsNotEmpty()
        {
            //Arange
            string dnsSet = string.Empty;
            string ipPreferred = string.Empty;
            string ipAlternative = string.Empty;

            //Act
            NetworkingExtensions.GetDNSSetIPAddress(dnsSet, out ipPreferred, out ipAlternative);

            //Asset
            Assert.IsTrue(ipPreferred != String.Empty && ipAlternative != String.Empty);
        }
    }
}
