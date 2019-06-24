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

using Microsoft.Xna.Framework;
using RLTutorial;

namespace RLTutorialTest {

    /// <summary>
    ///   Tests for the generic entity class.
    /// </summary>
    [TestFixture]
    class EntityTest {
        private const int startX = 1;
        private const int startY = 1;
        private const int glyph = ' ';
        private const int mapWidth = 10;
        private const int mapHeight = 10;
        private static Color colour = Color.Black;

        private Entity entity;
        private Map map;

        /// <summary>
        ///   Creates a new entity to do tests on.
        /// </summary>
        [SetUp]
        public void Setup() {
            map = new Map(mapWidth, mapHeight);
            map.DigRoom(new Room(-1, -1, mapWidth, mapHeight));
            entity = new Entity(startX, startY, glyph, colour, map);
        }

        /// <summary>
        ///   Makes sure that the entity was constructed with the correct values.
        /// </summary>
        [Test]
        public void InitializedCorrectly() {
            Assert.AreEqual(startX, entity.X);
            Assert.AreEqual(startY, entity.Y);
            Assert.AreEqual(glyph, entity.Glyph.Glyph);
            Assert.AreEqual(colour, entity.Glyph.Foreground);
        }

        /// <summary>
        ///   Checks that the entity's coordinates are changed when it moves.
        /// </summary>
        [Test]
        public void MoveChangesCoordinates() {
            entity.Move(2, 3);
            Assert.AreEqual(startX + 2, entity.X);
            Assert.AreEqual(startY + 3, entity.Y);
        }

        /// <summary>
        ///   Checks that the entity cannot move outside the map bounds.
        /// </summary>
        [Test]
        public void CannotMoveBeyondBounds() {
            entity.Move(-startX - 1, -startY - 1);
            Assert.AreEqual(startX, entity.X);
            Assert.AreEqual(startY, entity.Y);
        }

        /// <summary>
        ///   Checks that the entity cannot move through a blocked tile.
        /// </summary>
        [Test]
        public void CannotMoveThroughBlocked() {
            map[startX + 1, startY].Blocked = true;
            entity.Move(1, 0);
            Assert.AreEqual(startX, entity.X);
            Assert.AreEqual(startY, entity.Y);
        }
    }
}
