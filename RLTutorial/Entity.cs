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
using RoyT.AStar;
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
        ///   The AI controlling this entity. May be null if the user is controlling the entity.
        /// </summary>
        public AI AI { get; private set; }

        /// <summary>
        ///   The combat statistics of this entity.
        /// </summary>
        public Fighter Fighter { get; private set; }

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
        /// <param name="fighter">The entity's combat stats.</param>
        /// <param name="ai">The AI controlling this entity.</param>
        public Entity(int x, int y, int glyph, string name, Color colour, World world,
                      bool blocks = true, Fighter fighter = null, AI ai = null) {
            X = x;
            Y = y;
            Glyph = new ColoredGlyph(glyph, colour, Color.DimGray);
            Name = name;
            Blocks = blocks;
            this.world = world;
            Fighter = fighter;
            if (fighter != null) {
                fighter.Owner = this;
            }
            AI = ai;
            if (ai != null) {
                ai.Owner = this;
            }
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
            if (target != null && Fighter != null) {
                Fighter.Attack(target);
                return;
            }
            X = newX;
            Y = newY;
        }

        /// <summary>
        ///   Moves the entity towards the given position.
        /// </summary>
        /// <param name="targetX">The x-coordinate to move towards.</param>
        /// <param name="targetY">The y-coordinate to move towards.</param>
        public void MoveTowards(int targetX, int targetY) {
            var dx = targetX - X;
            var dy = targetY - Y;
            var distance = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            dx = (int) Math.Round(dx / distance);
            dy = (int) Math.Round(dy / distance);
            if (world.BlockingEntityAt(X + dx, Y + dy) == null) {
                Move(dx, dy);
            }
        }

        /// <summary>
        ///   Use the A* algorithm to move towards the target entity.
        /// </summary>
        /// <param name="grid">The grid used to calculate the path.</param>
        /// <param name="target">The entity to move towards.</param>
        public void MoveAStar(Grid grid, Entity target) {
            var path = grid.GetPath(new Position(X, Y), new Position(target.X, target.Y));
            if (path.Length > 1 && path.Length <= 25) {
                var next = path[1];
                MoveTowards(next.X, next.Y);
            }
        }
    }
}
