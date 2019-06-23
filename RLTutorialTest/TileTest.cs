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

using NUnit.Framework;

using RLTutorial;

namespace RLTutorialTest {

    [TestFixture]
    class TileTest {

        /// <summary>
        ///   Tests that the tile initializes correctly when given both parameters.
        /// </summary>
        /// <param name="shouldBlock">The given value for the "blocked" parameter.</param>
        /// <param name="shouldBlockSight">The given value for the "blocksSight" parameter.</param>
        [TestCase(true, true)]
        [TestCase(true, false)]
        public void InitializeWithBlocksSight(bool shouldBlock, bool shouldBlockSight) {
            var tile = new Tile(shouldBlock, shouldBlockSight);
            Assert.AreEqual(shouldBlock, tile.Blocked);
            Assert.AreEqual(shouldBlockSight, tile.BlocksSight);
        }


        /// <summary>
        ///   Checks that the tile initializes correctly when only given one parameter.
        /// </summary>
        /// <param name="shouldBlock">The given value for the "blocked" parameter.</param>
        [TestCase(true)]
        [TestCase(false)]
        public void InitializeWithoutBlocksSignt(bool shouldBlock) {
            var tile = new Tile(shouldBlock);
            Assert.AreEqual(shouldBlock, tile.BlocksSight);
        }
    }
}
