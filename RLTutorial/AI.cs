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

namespace RLTutorial {

    /// <summary>
    ///   The artificial intelligence controlling in-game NPCs.
    /// </summary>
    public abstract class AI {

        /// <summary>
        ///   Which entity this AI is controlling.
        /// </summary>
        public Entity Owner;

        /// <summary>
        ///   Have the entity perform an action on this turn.
        /// </summary>
        public abstract void TakeTurn();
    }

    /// <summary>
    ///   Basic AI for monsters.
    /// </summary>
    public class BasicMonster : AI {

        public override void TakeTurn() {
            Console.WriteLine("The {0} wonders when it can have a turn.", Owner.Name);
        }
    }
}
