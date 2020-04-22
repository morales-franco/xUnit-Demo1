using Xunit;

namespace GameEngine.Tests
{
    //TODO: share context across test classes!
    [CollectionDefinition("GameState collection")]
    public class GameStateCollection: ICollectionFixture<GameStateFixture>
    {
    }
}
