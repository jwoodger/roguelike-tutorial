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
        private static Color colour = Color.Black;

        private Entity entity;

        /// <summary>
        ///   Creates a new entity to do tests on.
        /// </summary>
        [SetUp]
        public void Setup() {
            entity = new Entity(startX, startY, glyph, colour);
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
            entity.Move(2, -3);
            Assert.AreEqual(startX + 2, entity.X);
            Assert.AreEqual(startY - 3, entity.Y);
        }
    }
}
