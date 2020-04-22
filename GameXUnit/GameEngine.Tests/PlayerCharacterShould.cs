using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould: IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;

        //This constructor is called every time that a method is invoked.
        //We try to do the ARRANGE here -Centralize
        public PlayerCharacterShould(ITestOutputHelper output)
        {
            //arrange
            _sut = new PlayerCharacter();
            _output = output;
            _output.WriteLine("Creating new PlayerCharacter");
            

        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            //act
            //assert
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            //act
            _sut.FirstName = "Franco";
            _sut.LastName = "Morales";

            //assert
            Assert.Equal("Franco Morales", _sut.FullName);
        }

        [Fact]
        public void HaveAFullNameStartingWithFirstName()
        {
            //act
            _sut.FirstName = "Franco";
            _sut.LastName = "Morales";

            //assert
            Assert.StartsWith("Franco", _sut.FullName);
        }

        [Fact]
        public void HaveAFullNameEndingWithLastName()
        {
            //act
            _sut.FirstName = "Franco";
            _sut.LastName = "Morales";

            //assert
            Assert.EndsWith("Morales", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            //act
            _sut.FirstName = "FRANCO";
            _sut.LastName = "MORALES";

            //assert
            Assert.Equal("Franco Morales", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            //act
            _sut.FirstName = "Franco";
            _sut.LastName = "Morales";

            //assert
            Assert.Contains("anco Mor", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            //act
            _sut.FirstName = "Franco";
            _sut.LastName = "Morales";

            //uppecase first letter for firstname & lastname
            //assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", _sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            //act

            //assert
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualsExample()
        {
            //act

            //assert
            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            //act
            _sut.Sleep(); //Expect increase between 1 to 100 inclusive

            //assert
            //Assert.True(_sut.Health >= 101 && _sut.Health <= 200);
            Assert.InRange(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            //act
            //assert
            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            //act
            //assert
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            //act
            //assert
            Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            //act
            //assert
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            //arrange
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword",
            };

            //act
            //assert
            Assert.Equal(expectedWeapons, _sut.Weapons);
        }


        [Fact]
        public void HaveNotEmptyDefaultWeapons()
        {
            //act

            //not have any empty weapon in the collection
            //assert
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }


        [Fact]
        public void RaiseSleptEvent()
        {
            //act
            //assert
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler, //atach event
                handler => _sut.PlayerSlept -= handler, //detach event
                () => _sut.Sleep()); //method to test
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            //act
            //assert
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }

        #region refactoring: repetead tests into inline parameters
        //[Fact]
        //public void TakeZeroDamage()
        //{
        //    _sut.TakeDamage(0);

        //    Assert.Equal(100, _sut.Health);
        //}

        //[Fact]
        //public void TakeSmallDamage()
        //{
        //    _sut.TakeDamage(1);

        //    Assert.Equal(99, _sut.Health);
        //}

        //[Fact]
        //public void TakeMediumDamage()
        //{
        //    _sut.TakeDamage(50);

        //    Assert.Equal(50, _sut.Health);
        //}

        [Theory] //TODO: delete repeated tests using InlineData
        [InlineData(0,100)] //TakeZeroDamage
        [InlineData(1, 99)] //TakeSmallDamage
        [InlineData(50, 50)]//TakeMediumDamage
        public void TakeDamage(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, _sut.Health);
        }

        [Theory] //TODO: Using shared data source - we can shared test data across multiple tests
        [MemberData(nameof(InternalHealthDamageTestData.TestData),
            MemberType = typeof(InternalHealthDamageTestData))]
        public void TakeDamage_WithSharedData(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, _sut.Health);
        }

        #endregion

        [Fact]
        public void HaveMinimum1Health()
        {
            _sut.TakeDamage(101);

            Assert.Equal(1, _sut.Health);
        }

        public void Dispose()
        {
            //put here any clean up code
            _output.WriteLine($"Disposing PlayerCharacter { _sut.FullName }");

        }


        
    }
}
