using Xunit;

namespace GameEngine.Tests
{
    public class NonPlayerCharacterShould
    {
        //[Theory]
        //[InlineData(0, 100)]
        //[InlineData(1, 99)]
        //[InlineData(50, 50)]
        //[InlineData(101, 1)] //TODO: Using shared data - replace these inline data statements using MemberData
        [Theory]
        [MemberData(nameof(InternalHealthDamageTestData.TestData),
           MemberType = typeof(InternalHealthDamageTestData))]
        public void TakeDamage(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

        //TODO: Test using test data from an external data source.
        //NOTE: Take care to change file property to "Copy Always"
        [Theory]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData),
           MemberType = typeof(ExternalHealthDamageTestData))]
        public void TakeDamage_UsingExternalDataSource(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }

        [Theory]
        //TODO: Using an own custom data atrribute to inject data in the test
        //[MemberData(nameof(InternalHealthDamageTestData.TestData),
        //  MemberType = typeof(InternalHealthDamageTestData))] Replace this statement with our own data custom attribute
        [HealthDamageData]
        public void TakeDamage_UsingCustomDataAttribute(int damage, int expectedHealth)
        {
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}
