using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        [Fact]
        [Trait("Category", "Enemy")]
        public void CreateNormalEnemyByDefault()
        {
            //arrange
            var sut = new EnemyFactory();

            //act
            var enemy = sut.Create("Zoombie");

            //assert
            Assert.IsType<NormalEnemy>(enemy);

        }

        [Fact(Skip = "Don't need to run this")]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            //arrange
            var sut = new EnemyFactory();

            //act
            var enemy = sut.Create("Zoombie");

            //assert
            Assert.IsNotType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            //arrange
            var sut = new EnemyFactory();

            //act
            var enemy = sut.Create("Zoombie King", true);

            //assert
            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            //arrange
            var sut = new EnemyFactory();

            //act
            var enemy = sut.Create("Zoombie King", true);

            //assert
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            //additional asserts on type object
            Assert.Equal("Zoombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            //arrange
            var sut = new EnemyFactory();

            //act
            var enemy = sut.Create("Zoombie King", true);

            //assert
            //Assert.IsType<Enemy>(enemy);
            Assert.IsAssignableFrom<Enemy>(enemy);

        }

        [Fact]
        public void CreateSeparateInstances()
        {
            //arrange
            var sut = new EnemyFactory();

            //act
            var enemy1 = sut.Create("Zoombie");
            var enemy2 = sut.Create("Zoombie");

            //assert
            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {
            //arrange
            var sut = new EnemyFactory();

            //act
            //assert
            //We expect a exception
            //Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            Assert.Throws<ArgumentNullException>("name",() => sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            //arrange
            var sut = new EnemyFactory();

            //act
            //assert
            //We expect a exception
            var ex = 
                Assert.Throws<EnemyCreationException>(() => sut.Create("Zoombie", true));

            Assert.Equal("Zoombie", ex.RequestedEnemyName);
        }

    }
}
