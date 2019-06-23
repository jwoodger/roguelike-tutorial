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
    ///   Tests for the level map class.
    /// </summary>
    [TestFixture]
    public class MapTest {

        private const int mapWidth = 10;
        private const int mapHeight = 10;

        private Map map;

        /// <summary>
        ///   Initializes the map we are testing.
        /// </summary>
        [SetUp]
        public void Setup() {
            map = new Map(mapWidth, mapHeight);
        }

        /// <summary>
        ///   Checks that the map is initialized with the correct width.
        /// </summary>
        [Test]
        public void InitializesWidth() {
            Assert.AreEqual(mapWidth, map.Width);
        }

        /// <summary>
        ///   Checks that the map is initialized with the correct height.
        /// </summary>
        [Test]
        public void InitializesHeight() {
            Assert.AreEqual(mapHeight, map.Height);
        }

        /// <summary>
        ///   Checks that all tiles in the map are initialized so that they are not solid and do not
        ///   block sight.
        /// </summary>
        /// <param name="x">The column of the tile to check.</param>
        /// <param name="y">The row of the tile to check.</param>
        [TestCase(0, 0)]
        [TestCase(mapWidth - 1, mapHeight - 1)]
        public void InitializesTiles(int x, int y) {
            Assert.AreEqual(false, map[x, y].Blocked);
            Assert.AreEqual(false, map[x, y].BlocksSight);
        }

        /// <summary>
        ///   Tests that the map creates rooms correctly.
        /// </summary>
        [Test]
        public void DigsRoom() {
            var room = new Room(0, 0, mapWidth - 1, mapHeight - 1);
            map.DigRoom(room);
            Assert.AreEqual(true, map[0, 0].Blocked);
            Assert.AreEqual(true, map[0, 0].BlocksSight);
            Assert.AreEqual(true, map[mapWidth - 1, mapHeight - 1].Blocked);
            Assert.AreEqual(true, map[mapWidth - 1, mapHeight - 1].BlocksSight);
        }
    }
}
