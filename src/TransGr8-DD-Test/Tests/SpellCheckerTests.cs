﻿using NUnit.Framework;

namespace TransGr8_DD_Test.Tests
{

	[TestFixture]
	public class SpellCheckerTests
	{


		private List<Spell> spells;
		private User user;

		[SetUp]
		public void Setup()
		{

			spells = new List<Spell>();
			spells.Add(new Spell
			{
				Name = "Fireball",
				Level = 3,
				CastingTime = "1 action",
				Components = "V, S, M (a tiny ball of bat guano and sulfur)",
				Range = 150,
				Duration = "Instantaneous",
				SavingThrow = "Dexterity"
			});
			spells.Add(new Spell
			{
				Name = "Magic Missile",
				Level = 1,
				CastingTime = "1 action",
				Components = "V, S",
				Range = 120,
				Duration = "Instantaneous",
				SavingThrow = ""
			});
			spells.Add(new Spell
			{
				Name = "Cure Wounds",
				Level = 1,
				CastingTime = "1 action",
				Components = "V, S",
				Range = 1,
				Duration = "Instantaneous",
				SavingThrow = ""
			});


			// Create a new User object with default values for testing.
			user = new User
			{
				Level = 3,
				HasVerbalComponent = true,
				HasSomaticComponent = true,
				HasMaterialComponent = true,
				Range = 200,
				HasConcentration = true
			};
		}

		[Test]
		public void TestCanUserCastSpellReturnsTrue()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spells);
			string spellName = "Fireball";

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.True(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForInsufficientLevel()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spells);
			string spellName = "Fireball";
			user.Level = 2;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForMissingVerbalComponent()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spells);
			string spellName = "Command";
			user.HasVerbalComponent = false;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForMissingSomaticComponent()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spells);
			string spellName = "Cure Wounds";
			user.HasSomaticComponent = false;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForMissingMaterialComponent()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spells);
			string spellName = "Identify";
			user.HasMaterialComponent = false;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForInsufficientRange()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spells);
			string spellName = "Fireball";
			user.Range = 20;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForMissingConcentration()
		{
			// Arrange
			SpellChecker spellChecker = new SpellChecker(spells);
			string spellName = "Hold Person";
			user.HasConcentration = false;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}


		//update
        [Test]
        public void CanUserCastSpell_Should_ReturnFalse_When_SpellRequiresSomaticComponent_And_UserDoesNotHaveIt()
        {
            // Arrange
            var spells = new List<Spell>
            {
                new Spell
                {
                    Name = "Cure Wounds",
                    Level = 1,
                    CastingTime = "1 action",
                    Components = "V, S",
                    Range = 1,
                    Duration = "Instantaneous",
                    SavingThrow = ""
                }
            };
            var user = new User
            {
                Level = 1,
                HasVerbalComponent = true,
                HasMaterialComponent = false,
                Range = 1,
                HasConcentration = false
            };
            var spellChecker = new SpellChecker(spells);

            // Act
            var canCast = spellChecker.CanUserCastSpell(user, "Cure Wounds");

            // Assert
            Assert.IsFalse(canCast);
        }

        [Test]
        public void CanUserCastSpell_Should_ReturnTrue_When_SpellRequiresSomaticComponent_And_UserHasIt()
        {
            // Arrange
            var spells = new List<Spell>
            {
                new Spell
                {
                    Name = "Cure Wounds",
                    Level = 1,
                    CastingTime = "1 action",
                    Components = "V, S",
                    Range = 1,
                    Duration = "Instantaneous",
                    SavingThrow = ""
                }
            };
            var user = new User
            {
                Level = 1,
                HasVerbalComponent = true,
                HasSomaticComponent = true,
                HasMaterialComponent = false,
                Range = 1,
                HasConcentration = false
            };
            var spellChecker = new SpellChecker(spells);

            // Act
            var canCast = spellChecker.CanUserCastSpell(user, "Cure Wounds");

            // Assert
            Assert.IsTrue(canCast);
        }




    }
}
