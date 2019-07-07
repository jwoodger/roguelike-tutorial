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

using System;

using Microsoft.Xna.Framework;
using SadConsole;

using Console = System.Console;

namespace RLTutorial {

    /// <summary>
    ///   The generic entity which can represent any in-game object.
    /// </summary>
    public class Entity {

        private World world;

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
        ///   What the entity is called.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///   Whether or not other entities can walk through this one.
        /// </summary>
        public bool Blocks { get; private set; }

        /// <summary>
        ///   Creates a new entity,
        /// </summary>
        /// <param name="x">The starting x-coordinate.</param>
        /// <param name="y">The starting y-coordinate.</param>
        /// <param name="glyph">The character representing the entity.</param>
        /// <param name="name">What the entity is called.
        /// <param name="colour">The colour of the entity.</param>
        /// <param name="world">The world this entity belongs to.</param>
        /// <param name="blocks">Can other entities walk through this entity?</param>
        public Entity(int x, int y, int glyph, string name, Color colour, World world, bool blocks = true) {
            X = x;
            Y = y;
            Glyph = new ColoredGlyph(glyph, colour, Color.DimGray);
            Name = name;
            Blocks = blocks;
            this.world = world;
        }

        /// <summary>
        ///   Moves the entity on the map.
        /// </summary>
        /// <param name="dx">The amount by which to move left or right.</param>
        /// <param name="dy">The amount by which to move up or down.</param>
        public void Move(int dx, int dy) {
            var newX = X + dx;
            var newY = Y + dy;
            if (newX < 0 || newX >= world.LevelMap.Width || newY < 0 || newY >= world.LevelMap.Height) {
                return;
            }
            if (world.LevelMap[newX, newY].Blocked) {
                return;
            }
            var target = world.BlockingEntityAt(newX, newY);
            if (target != null) {
                Console.WriteLine("You kick the {0} in the grill!", target.Name);
                return;
            }
            X = newX;
            Y = newY;
        }
    }
}
