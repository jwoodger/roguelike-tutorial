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
            console.Print(0, 0, "Use the arrow keys or HJKLYUBN to move.");
            console.Print(world.Hero.X, world.Hero.Y, world.Hero.Glyph);
        }
    }
}
