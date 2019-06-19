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

namespace RLTutorial {

    /// <summary>
    ///   Any instruction that can be given to an in-game entity. Commands can be generated from
    ///   user input or from the AI.
    /// </summary>
    public interface Command {}

    /// <summary>
    ///   A command to move an entity.
    /// </summary>
    public class Move : Command {

        /// <summary>
        ///   The amount by which to move the entity left or right.
        /// </summary>
        public int DeltaX { get; private set; }

        /// <summary>
        ///   The amount by which to move the entity up or down.
        /// </summary>
        public int DeltaY { get; private set; }

        /// <summary>
        ///   Creates a new move command.
        /// </summary>
        /// <param name="dx">The delta-x property.</param>
        /// <param name="dy">The delta-y property.</param>
        public Move(int dx, int dy) {
            DeltaX = dx;
            DeltaY = dy;
        }
    }
}
