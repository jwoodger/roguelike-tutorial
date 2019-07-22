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
using System.Collections.Generic;

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
        /// <param name="world">The world that the owner lives in.</param>
        /// <returns>A collection of all events that occured during the turn.</returns>
        public abstract IEnumerable<Result> TakeTurn(World world);
    }

    /// <summary>
    ///   Basic AI for monsters.
    /// </summary>
    public class BasicMonster : AI {

        public override IEnumerable<Result> TakeTurn(World world) {
            var results = new List<Result>();
            if (world.IsInFOV(Owner.X, Owner.Y)) {
                var distance = Math.Sqrt(Math.Pow(world.Hero.X - Owner.X, 2) +
                                         Math.Pow(world.Hero.Y - Owner.Y, 2));
                if (distance > 1) {
                    Owner.MoveAStar(world.AStarGrid, world.Hero);
                } else {
                    var attackResults = Owner.Fighter.Attack(world.Hero);
                    results.AddRange(attackResults);
                }
            }
            return results;
        }
    }
}
