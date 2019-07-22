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
    ///   Used to keep track of different events.
    /// </summary>
    public abstract class Result {}

    /// <summary>
    ///   The event occuring when an entity dies.
    /// </summary>
    public class Dead : Result {

        /// <summary>
        ///   Which entity died.
        /// </summary>
        public Entity Deceased { get; private set; }

        /// <summary>
        ///   Create a new "death" result.
        /// </summary>
        /// <param name="deceased">The entity that died.</param>
        public Dead(Entity deceased) {
            Deceased = deceased;
        }
    }

    /// <summary>
    ///   A message to appear on the game's message log.
    /// </summary>
    public class Message : Result {

        /// <summary>
        ///   The text of the message.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        ///   Creates a new message.
        /// </summary>
        /// <param name="text">What the message says.</param>
        public Message(string text) {
            Text = text;
        }
    }
}
