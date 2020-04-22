using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{

    //share context across test classes!
    //TestClass1 & TestClass2 shared the same context, the same GameStateFixture instance!
    [Collection("GameState collection")]
    public class TestClass2
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public TestClass2(GameStateFixture gameStateFixture,
            ITestOutputHelper output)
        {
            _output = output;
            _gameStateFixture = gameStateFixture;

        }

        [Fact]
        public void Test3()
        {
            _output.WriteLine($"GameState ID={ _gameStateFixture.State.Id }");
        }

        [Fact]
        public void Test4()
        {
            _output.WriteLine($"GameState ID={ _gameStateFixture.State.Id }");
        }

    }
}
