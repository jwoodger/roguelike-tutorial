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

using Game = SadConsole.Game;

namespace RLTutorial {

    /// <summary>
    ///   Controls the program's user interface.
    /// </summary>
    public class Display {

        private static Color floor = Color.DimGray;
        private static Color wall = Color.LightSeaGreen;
        private static Color darkFloor = Color.DarkSlateGray;
        private static Color darkWall = Color.SeaGreen;

        private Console console;

        /// <summary>
        ///   Creates a new display.
        /// </summary>
        /// <param name="consoleWidth">The width of the display console.</param>
        /// <param name="consoleHeight">The height of the display console.</param>
        public Display(int consoleWidth, int consoleHeight) {
            console = new Console(consoleWidth, consoleHeight);
            Global.CurrentScreen = console;
        }

        /// <summary>
        ///   Outputs the game state onto the console.
        /// </summary>
        /// <param name="world">The game state to render.</param>
        public void Render(World world) {
            console.Clear();
            RenderMap(world);
            foreach (var entity in world.DeadEntities) {
                if (world.IsInFOV(entity.X, entity.Y)) {
                    RenderEntity(entity);
                }
            }
            foreach (var entity in world.Entities) {
                if (world.IsInFOV(entity.X, entity.Y)) {
                    RenderEntity(entity);
                }
            }
        }

        /// <summary>
        ///   Draws the game map onto the console.
        /// </summary>
        /// <param name="world">The world whose map we should draw.</param>
        public void RenderMap(World world) {
            for (var y = 0; y < world.LevelMap.Height; y++) {
                for (var x = 0; x < world.LevelMap.Width; x++) {
                    var colour = Color.Black;
                    if (world.IsInFOV(x, y)) {
                        if (world.LevelMap[x, y].Blocked) {
                            colour = wall;
                        } else {
                            colour = floor;
                        }

                    } else if (world.IsSeen(x, y)) {
                        if (world.LevelMap[x, y].Blocked) {
                            colour = darkWall;
                        } else {
                            colour = darkFloor;
                        }
                    }
                    console.SetBackground(x, y, colour);
                }
            }
        }

        /// <summary>
        ///   Draws a single entity onto the console.
        /// </summary>
        /// <param name="entity">The entity to draw.</param>
        public void RenderEntity(Entity entity) {
            console.Print(entity.X, entity.Y, entity.Glyph);
        }
    }
}
