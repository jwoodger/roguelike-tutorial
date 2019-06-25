/*
 * This file is part of RLTutorial.
 *
 * RLTutorial is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * RLTutorial is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with RLTutorial.  If not, see <https://www.gnu.org/licenses/>.
 */

using NUnit.Framework;

using RLTutorial;

namespace RLTutorialTest {

    /// <summary>
    ///   Tests for the game world class.
    /// </summary>
    [TestFixture]
    class WorldTest {
        private World world;

        /// <summary>
        ///   Sets up the world to perform tests on.
        /// </summary>
        [SetUp]
        public void Setup() {
            world = new World();
        }

        /// <summary>
        ///   Checks that the move command properly moves the player character.
        /// </summary>
        [Test]
        public void MoveCommand() {
            world.LevelMap.DigRoom(new Room(0, 0, world.LevelMap.Width, world.LevelMap.Height));

            var startX = world.Hero.X;
            var startY = world.Hero.Y;

            var moveCmd = new Move(2, 3);
            world.Process(moveCmd);

            Assert.AreEqual(startX + 2, world.Hero.X);
            Assert.AreEqual(startY + 3, world.Hero.Y);
        }
    }
}
