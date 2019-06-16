/*
This file is part of RLTutorial.

RLTutorial is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Foobar is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Foobar.  If not, see <https://www.gnu.org/licenses/>.
*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SadConsole;

namespace RLTutorial {

    /// <summary>
    ///   Contains the main application code.
    /// </summary>
    class Program {

        /// <summary>
        ///   The width of the console, in characters.
        /// </summary>
        const int ConsoleWidth = 80;

        /// <summary>
        ///   The height of the console, in characters.
        /// </summary>
        const int ConsoleHeight = 25;

        /// <summary>
        ///   The main entry point to the program.
        /// </summary>
        /// <param name="args">Command-line arguments (unused).</param>
        static void Main(string[] args) {
            SadConsole.Game.Create(ConsoleWidth, ConsoleHeight);
            SadConsole.Game.OnInitialize = Initialize;

            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        /// <summary>
        ///   Callback for SadConsole. Sets up the console and other components.
        /// </summary>
        static void Initialize() {
            var console = new Console(ConsoleWidth, ConsoleHeight);
            console.FillWithRandomGarbage();
            console.Fill(new Rectangle(3, 3, 22, 3), Color.White, Color.Black, ' ', SpriteEffects.None);
            console.Print(4, 4, "Welcome to the game!");

            SadConsole.Global.CurrentScreen = console;
        }
    }
}
