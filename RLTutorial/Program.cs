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
            new Program().Play();
        }

        private World world;
        private Controller controller;
        private Display display;

        /// <summary>
        ///   Creates the application. Sets up the user interface and the game state.
        /// </summary>
        Program() {
            world = new World();

            Game.Create(ConsoleWidth, ConsoleHeight);
            Game.OnInitialize = Initialize;
            Game.OnDraw = Draw;
            Game.OnUpdate = Update;
        }

        /// <summary>
        ///   Begins the game, and then destroys the game window when it is finished.
        /// </summary>
        void Play() {
            Game.Instance.Run();
            Game.Instance.Dispose();
        }

        /// <summary>
        ///   Callback for SadConsole. Sets up the console and other components.
        /// </summary>
        void Initialize() {
            display = new Display(ConsoleWidth, ConsoleHeight);
            controller = new Controller(Global.KeyboardState);
        }

        /// <summary>
        ///   Callback for SadConsole. Outputs the game state onto the terminal.
        /// </summary>
        /// <param name="time">Elapsed time (unused).</param>
        void Draw(GameTime time) {
            display.Render(world);
        }

        /// <summary>
        ///   Callback for SadConsole. Reads user input and updates the game state.
        /// </summary>
        /// <param name="time">Elapsed time (unused).</param>
        void Update(GameTime time) {
            var command = controller.InputCommand();
            world.Process(command);
        }
    }
}
