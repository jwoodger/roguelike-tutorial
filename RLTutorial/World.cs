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

using Microsoft.Xna.Framework;

namespace RLTutorial {

    /// <summary>
    ///   The entire state of the currently-running game.
    /// </summary>
    public class World {

        private List<Entity> entityList;

        /// <summary>
        ///   The player character's entity.
        /// </summary>
        public Entity Hero { get; private set; }

        /// <summary>
        ///   The map of the current level.
        /// </summary>
        public Map LevelMap { get; private set; }

        /// <summary>
        ///   Every entity that exists in the world.
        /// </summary>
        public IEnumerable<Entity> Entities {
            get {
                foreach (var entity in entityList) {
                    yield return entity;
                }
            }
        }

        /// <summary>
        ///   Creates a new game world.
        /// </summary>
        public World() {
            LevelMap = new Map(80, 25);
            LevelMap.Generate();

            var startCenter = LevelMap.StartRoom.Center;
            var startX = startCenter.Item1;
            var startY = startCenter.Item2;
            Hero = new Entity(startX, startY, '@', Color.WhiteSmoke, LevelMap);

            entityList = new List<Entity>();
            entityList.Add(Hero);
            entityList.Add(new Entity(10, 10, 'T', Color.ForestGreen, LevelMap));
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
