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

namespace RLTutorial {

    public class Room {

        /// <summary>
        ///   The column with the top-left corner of the room.
        /// </summary>
        public int X1 { get; private set; }

        /// <summary>
        ///   The row with the top-left corner of the room.
        /// </summary>
        public int Y1 { get; private set; }

        /// <summary>
        ///   The column with the bottom-right corner of the room.
        /// </summary>
        public int X2 { get; private set; }

        /// <summary>
        ///   The row with the bottom-right corner of the room.
        /// </summary>
        public int Y2 { get; private set; }

        /// <summary>
        ///   Creates a new room.
        /// </summary>
        /// <param name="x">The column of the top-left corner of the room.</param>
        /// <param name="y">The row of the top-left corner of the room.</param>
        /// <param name="width">The width of the room in tiles.</param>
        /// <param name="height">The height of the room in tiles.</param>
        public Room(int x, int y, int width, int height) {
            X1 = x;
            Y1 = y;
            X2 = x + width;
            Y2 = y + height;
        }
    }
}
