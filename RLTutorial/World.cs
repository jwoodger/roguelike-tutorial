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

namespace RLTutorial {

    /// <summary>
    ///   The entire state of the currently-running game.
    /// </summary>
    public class World {

        /// <summary>
        ///   The player character's entity.
        /// </summary>
        public Entity Hero { get; private set; }

        /// <summary>
        ///   Creates a new game world.
        /// </summary>
        /// <param name="startX">The hero's starting x-coordinate.</param>
        /// <param name="startY">The hero's starting y-coordinate.</param>
        public World(int startX, int startY) {
            Hero = new Entity(startX, startY, '@', Color.WhiteSmoke);
        }

        /// <summary>
        ///   Changes the world state based on the given command.
        /// </summary>
        /// <param name="command">A command for the hero.</param>
        public void Process(Command command) {
            switch (command) {
            case Move move:
                Hero.Move(move.DeltaX, move.DeltaY);
                break;
            }
        }
    }
}