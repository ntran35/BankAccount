using BankLibrary;
using System;
using Xunit;

namespace BankingTests
{
    public class BasicTests
    {
        //We can use crtl+r+t to run the test
        [Fact]
        public void TrueIsTrue()
        {
            Assert.True(true);
        }

        [Fact]
        public void TakeOutMoreThanAvailable()
        {
            var account = new BankAccount("Quyen", 10000);

            //Test for negative balance
            Assert.Throws<InvalidOperationException>(
                () => account.MakeWithdrawal(80000, DateTime.Now, "Bank Closing")
                );    
        }

        [Fact]
        public void OpenAccountWithNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
            () => new BankAccount("CHristipher", -55)
            );
        }
    }
}
