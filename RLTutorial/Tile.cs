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

    public class Tile {

        /// <summary>
        ///   Does this tile block entities from moving into it?
        /// </summary>
        public bool Blocked { get; set; }

        /// <summary>
        ///   Does this tile block the player character's field of vision?
        /// </summary>
        public bool BlocksSight { get; set; }

        /// <summary>
        ///   Creates a new tile.
        /// </summary>
        /// <param name="blocked">Whether or not this tile blocks entities.</param>
        /// <param name="blocksSight">Whether or not the tile blocks field of vision. When left
        /// empty defaults to the same value as blocked.</param>
        public Tile(bool blocked, bool? blocksSight = null) {
            Blocked = blocked;
            if (blocksSight == null) {
                BlocksSight = blocked;
            } else {
                BlocksSight = blocksSight.Value;
            }
        }
    }
}
