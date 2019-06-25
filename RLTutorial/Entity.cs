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

using Microsoft.Xna.Framework;
using SadConsole;

namespace RLTutorial {

    /// <summary>
    ///   The generic entity which can represent any in-game object.
    /// </summary>
    public class Entity {

        private Map map;

        /// <summary>
        ///   The x-coordinate of the entity.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        ///   The y-coordinate of the entity.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        ///   The entity's appearance.
        /// </summary>
        public ColoredGlyph Glyph { get; private set; }

        /// <summary>
        ///   Creates a new entity,
        /// </summary>
        /// <param name="x">The starting x-coordinate.</param>
        /// <param name="y">The starting y-coordinate.</param>
        /// <param name="glyph">The character representing the entity.</param>
        /// <param name="colour">The colour of the entity.</param>
        public Entity(int x, int y, int glyph, Color colour, Map map) {
            X = x;
            Y = y;
            Glyph = new ColoredGlyph(glyph, colour, Color.DarkSlateGray);
            this.map = map;
        }

        /// <summary>
        ///   Moves the entity on the map.
        /// </summary>
        /// <param name="dx">The amount by which to move left or right.</param>
        /// <param name="dy">The amount by which to move up or down.</param>
        public void Move(int dx, int dy) {
            var newX = X + dx;
            var newY = Y + dy;
            if (newX < 0 || newX >= map.Width || newY < 0 || newY >= map.Height) {
                return;
            }
            if (map[newX, newY].Blocked) {
                return;
            }
            X = newX;
            Y = newY;
        }
    }
}
