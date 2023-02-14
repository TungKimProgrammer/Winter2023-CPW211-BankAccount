using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount()
        {
            acc = new Account("J. Doe");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(0.01)]
        [DataRow(1.99)]
        [DataRow(9_999.99)]
        public void Deposit_APositiveAmount_AddToBalance(double aPositiveAmount)
        {
            // Account acc = new Account("J Doe");
            acc.Deposit(aPositiveAmount);

            Assert.AreEqual(aPositiveAmount, acc.Balance);
        }

        [TestMethod]
        public void Deposit_ApositiveAmount_ReturnUpdatedBalance()
        {
            // AAA - Arrange Act Assert
            // Arrange
            // Account acc = new Account("J Doe");
            double depositAmount = 100;
            double expectedReturn = 100;

            // Act
            double returnValue = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidDepositAmount)
        {
            // Arrange
            // Account acc = new Account("J. Doe");

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmount));
        }

        
        [TestMethod]
        [DataRow(50)]
        public void Withdraw_APositiveAmount_DecreasesBalance(double aPositiveAmount)
        {
            // Arrange
            double initialDeposit = 100;
            double expectedBalance = initialDeposit - aPositiveAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(aPositiveAmount);

            double actualBalance = acc.Balance; 

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);

        }

        [TestMethod]
        [DataRow(50)]
        public void Withdraw_APositiveAmount_ReturnsUpdatedBalance(double aPositiveAmount)
        {
            // Arrange
            double initialDeposit = 100;
            double expectedBalance = initialDeposit - aPositiveAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(aPositiveAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);

        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-10)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double aPositiveAmount)
        {
            // Arrange
            double initialDeposit = 100;
            double expectedBalance = initialDeposit - aPositiveAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(aPositiveAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);

        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-10)]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException(double aPositiveAmount)
        {
            // Arrange
            double initialDeposit = 100;
            double expectedBalance = initialDeposit - aPositiveAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(aPositiveAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);

        }
    }

}

// Withdrawing a positive amount - returns updated balance
//             0 - Throw ArgumentOutOfRangeException
//             negative amount - Throw ArgumentOutOfRangeException
//             more than balance - Throw ArgumentException