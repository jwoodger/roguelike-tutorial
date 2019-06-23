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

    /// <summary>
    ///   The map of a game level, represented as a 2D grid of tiles.
    /// </summary>
    public class Map {

        private Tile[,] contents;

        /// <summary>
        ///   The width of the map grid.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        ///   The height of the map grid.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        ///   Creates a new map with the given dimensions.
        /// </summary>
        /// <param name="width">The width of the map in tiles.</param>
        /// <param name="height">The height of the map in tiles.</param>
        public Map(int width, int height) {
            Width = width;
            Height = height;
            contents = new Tile[height, width];

            for (var y = 0; y < height; y++) {
                for (var x = 0; x < width; x++) {
                    contents[y, x] = new Tile(false, false);
                }
            }
        }

        /// <summary>
        ///   Accesses the tiles in the map.
        /// </summary>
        /// <param name="x">The column where the tile is located.</param>
        /// <param name="y">The row where the tile is located.</param>
        public Tile this[int x, int y] {
            get {
                return contents[y, x];
            }
        }
    }
}
