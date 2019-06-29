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
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace RLTutorial {

    /// <summary>
    ///   The entire state of the currently-running game.
    /// </summary>
    public class World {
        private const int levelWidth = 80;
        private const int levelHeight = 25;
        private const int fovRadius = 10;

        private bool[,] fovMap;
        private List<Entity> entityList;

        /// <summary>
        ///   The player character's entity.
        /// </summary>
        public Entity Hero { get; private set; }

        /// <summary>
        ///   The map of the current level.
        /// </summary>
        public Map LevelMap { get; private set; }

        /// <summary>
        ///   Every entity that exists in the world.
        /// </summary>
        public IEnumerable<Entity> Entities {
            get {
                foreach (var entity in entityList) {
                    yield return entity;
                }
            }
        }

        /// <summary>
        ///   Creates a new game world.
        /// </summary>
        public World() {
            LevelMap = new Map(levelWidth, levelHeight);
            LevelMap.Generate();

            var startCenter = LevelMap.StartRoom.Center;
            var startX = startCenter.Item1;
            var startY = startCenter.Item2;
            Hero = new Entity(startX, startY, 2, Color.WhiteSmoke, LevelMap);

            fovMap = new bool[levelHeight, levelWidth];

            entityList = new List<Entity>();
            entityList.Add(Hero);

            RecalculateFOV();
        }

        /// <summary>
        ///   Changes the world state based on the given command.
        /// </summary>
        /// <param name="command">A command for the hero.</param>
        public void Process(Command command) {
            switch (command) {
            case Move move:
                Hero.Move(move.DeltaX, move.DeltaY);
                RecalculateFOV();
                break;
            }
        }

        /// <summary>
        ///   Determines if the tile at the given coordinates is in the player's field of vision.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public bool IsInFOV(int x, int y) {
            return (x >= 0 && x < levelWidth && y >= 0 && y < levelHeight && fovMap[y, x]);
        }

        /// <summary>
        ///   Calculate the field of view from the player character's current position.
        /// </summary>
        public void RecalculateFOV() {
            // Initially set all tiles to invisible.
            for (var y = 0; y < levelHeight; y++) {
                for (var x = 0; x < levelWidth; x++) {
                    fovMap[y, x] = false;
                }
            }

            // Loop over all 360 degrees.
            for (var i = 0; i < 360; i++) {
                // The delta-x and delta-y determine the angle to cast the ray at.
                var dx = Math.Cos(i * 0.01745f);
                var dy = Math.Sin(i * 0.01745f);
                // The starting x and y positions.
                var x = (double)Hero.X + 0.5;
                var y = (double)Hero.Y + 0.5;
                // Cast the ray out at this angle.
                for (var j = 0; j < fovRadius; j++) {
                    var mapX = (int)x;
                    var mapY = (int)y;
                    // If we get outside the map boundaries, stop.
                    if (mapX < 0 || mapX >= levelWidth || mapY < 0 || mapY >= levelHeight) {
                        break;
                    }
                    // Otherwise, mark this square as visible.
                    fovMap[mapY, mapX] = true;
                    // If this tile blocks sight, don't cast the ray past it.
                    if (LevelMap[mapX, mapY].BlocksSight) {
                        break;
                    }
                    // Otherwise, keep going to the next square.
                    x += dx;
                    y += dy;
                }
            }
        }
    }
}
