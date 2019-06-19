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

using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;
using SadConsole;

using Keyboard = SadConsole.Input.Keyboard;

namespace RLTutorial {

    /// <summary>
    ///   The primary input handler.
    /// </summary>
    class Controller {

        private static Dictionary<Keys, Command> keyCommands = new Dictionary<Keys, Command>() {
            { Keys.Up, new Move(0, -1) },
            { Keys.K, new Move(0, -1) },
            { Keys.Down, new Move(0, 1) },
            { Keys.J, new Move(0, 1) },
            { Keys.Left, new Move(-1, 0) },
            { Keys.H, new Move(-1, 0) },
            { Keys.Right, new Move(1, 0) },
            { Keys.L, new Move(1, 0) },
            { Keys.Y, new Move(-1, -1) },
            { Keys.U, new Move(1, -1) },
            { Keys.B, new Move(-1, 1) },
            { Keys.N, new Move(1, 1) },
        };

        private Keyboard keyboard;

        /// <summary>
        ///   Creates a new controller.
        /// </summary>
        /// <param name="keyboard">The keyboard object to read user input from.</param>
        public Controller(Keyboard keyboard) {
            this.keyboard = keyboard;
        }

        /// <summary>
        ///   Reads the keyboard and finds a command based on what is being pressed.
        /// </summary>
        /// <returns>A command to execute, if a key is pressed and recognized, or null if no key is
        /// pressed or no command is found for the given key.</returns>
        public Command InputCommand() {
            if (keyboard.KeysPressed.Count == 0) {
                return null;
            }
            var key = keyboard.KeysPressed[0].Key;
            if (keyCommands.ContainsKey(key)) {
                return keyCommands[key];
            }
            return null;
        }
    }
}
