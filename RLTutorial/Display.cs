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

        private static Color darkFloor = Color.DarkSlateGray;
        private static Color darkWall = Color.LightSeaGreen;

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
            RenderMap(world.LevelMap);
            foreach (var entity in world.Entities) {
                RenderEntity(entity);
            }
        }

        /// <summary>
        ///   Draws the game map onto the console.
        /// </summary>
        /// <param name="map">The map to draw.</param>
        public void RenderMap(Map map) {
            for (var y = 0; y < map.Height; y++) {
                for (var x = 0; x < map.Width; x++) {
                    if (map[x, y].Blocked) {
                        console.SetBackground(x, y, darkWall);
                    } else {
                        console.SetBackground(x, y, darkFloor);
                    }
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
