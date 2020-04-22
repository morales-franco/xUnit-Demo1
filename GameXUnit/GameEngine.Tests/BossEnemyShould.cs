using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {

        private readonly ITestOutputHelper _output;
        //TODO: write comments in tests
        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        [Trait("Category", "Enemy")]  //TODO: implemeting category then I can filter by Trait in the Test Explorer
        public void HaveCorrectPower()
        {
            _output.WriteLine("Creating Boss Enemy");
            //arrange
            var sut = new BossEnemy();

            //act

            //assert
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }




    }
}
