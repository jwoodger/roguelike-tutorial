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
    ///   Tests for the room class.
    /// </summary>
    [TestFixture]
    public class RoomTest {

        private const int roomX = 1;
        private const int roomY = 1;
        private const int roomWidth = 10;
        private const int roomHeight = 12;

        private Room room;

        /// <summary>
        ///   Initializes the room we are testing on.
        /// </summary>
        [SetUp]
        public void Setup() {
            room = new Room(roomX, roomY, roomWidth, roomHeight);
        }

        /// <summary>
        ///   Makes sure that the (x1, y1) and (x2, y2) coordinates are initialized correctly.
        /// </summary>
        [Test]
        public void InitializesCoordinates() {
            Assert.AreEqual(roomX, room.X1);
            Assert.AreEqual(roomY, room.Y1);
            Assert.AreEqual(roomX + roomWidth, room.X2);
            Assert.AreEqual(roomY + roomHeight, room.Y2);
        }

        /// <summary>
        ///   Checks that the coordinates of the room's center are calculated correctly.
        /// </summary>
        [Test]
        public void RoomCenter() {
            var center = room.Center;
            Assert.AreEqual((roomX * 2 + roomWidth) / 2, center.Item1);
            Assert.AreEqual((roomY * 2 + roomHeight) / 2, center.Item2);
        }

        /// <summary>
        ///   Checks that the room's Intersects method works when another room intersects it.
        /// </summary>
        [Test]
        public void RoomIntersects() {
            var otherRoom = new Room(roomX + 1, roomY + 1, roomWidth, roomHeight);
            Assert.True(room.Intersects(otherRoom));
        }

        /// <summary>
        ///   Checks that the room's Intersects method workd when the given room does not intersect
        ///   with it.
        /// </summary>
        [Test]
        public void RoomDoesntIntersect() {
            var otherRoom = new Room(room.X2 + 1, room.Y2 + 1, roomWidth, roomHeight);
            Assert.False(room.Intersects(otherRoom));
        }
    }
}
