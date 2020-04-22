using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    //TODO: Create only one instance of GameStateFixture and shared it between all test methods
    //In each test method the constructor will be called however the gameStateFixture instance is only one
    //if test method A adds 2 player, when test method b is called receive the gameStateFixture with 2 players!
    // be careful! In this case we take this approach because create a GameState is really expensive.
    public class GameStateShould: IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public GameStateShould(GameStateFixture gameStateFixture,
            ITestOutputHelper output)
        {
            _output = output;
            _gameStateFixture = gameStateFixture;

        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _output.WriteLine($"GameState ID= { _gameStateFixture.State.Id }");

            //arrange

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            //act
            _gameStateFixture.State.Earthquake();

            //assert
            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);

        }

        [Fact]
        public void Reset()
        {
            _output.WriteLine($"GameState ID= { _gameStateFixture.State.Id }");
            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            _gameStateFixture.State.Reset();

            Assert.Empty(_gameStateFixture.State.Players);
        }

    }
}
