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
    ///   The combat statistics of a game entity.
    /// </summary>
    public class Fighter {

        /// <summary>
        ///   The entity to whom these state belong.
        /// </summary>
        public Entity Owner;

        /// <summary>
        ///   The maximum possible health the entity has.
        /// </summary>
        public int MaxHealth { get; private set; }

        /// <summary>
        ///   The current health the entity has.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        ///   The entity's attack power.
        /// </summary>
        public int Power { get; private set; }

        /// <summary>
        ///   The entity's defensive ability.
        /// </summary>
        public int Defence { get; private set; }

        /// <summary>
        ///   Creates a new fighter.
        /// </summary>
        /// <param name="health">The maximum health.</param>
        /// <param name="power">The attack power.</param>
        /// <param name="defence">The defensive power.</param>
        public Fighter(int health, int power, int defence) {
            MaxHealth = health;
            Health = health;
            Power = power;
            Defence = defence;
        }

        /// <summary>
        ///   Be damaged by an enemy attack or some other effect.
        /// </summary>
        /// <param name="amount">How much damage is taken.</param>
        /// <returns>A list containing any events that occured when the fighter took
        /// damage.</returns>
        public IEnumerable<Result> TakeDamage(int amount) {
            var results = new List<Result>();
            Health -= amount;
            if (Health <= 0) {
                results.Add(new Dead(Owner));
            }
            return results;
        }

        /// <summary>
        ///   Attempt to do damage to another entity.
        /// </summary>
        /// <param name="target">The entity to attack.</param>
        /// <returns>A list containing eny events that happened when the fighter attacked.</returns>
        public IEnumerable<Result> Attack(Entity target) {
            var results = new List<Result>();
            if (target.Fighter == null) {
                return results;
            }
            var damage = Power - target.Fighter.Defence;
            if (damage > 0) {
                var damageResults = target.Fighter.TakeDamage(damage);
                var message = String.Format("The {0} attacks the {1} for {2} damage.",
                                            Owner.Name.ToLower(), target.Name.ToLower(), damage);
                results.AddRange(damageResults);
                results.Add(new Message(message));
            } else {
                var message = String.Format("The {0} blocks the {1}'s attack.",
                                            target.Name.ToLower(), Owner.Name.ToLower());
                results.Add(new Message(message));
            }
            return results;
        }
    }
}
