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
    ///   The map of a game level, represented as a 2D grid of tiles.
    /// </summary>
    public class Map {

        private const int maxRooms = 30;
        private const int roomMaxSize = 10;
        private const int roomMinSize = 6;

        private Tile[,] contents;
        private List<Room> rooms;

        /// <summary>
        ///   The width of the map grid.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        ///   The height of the map grid.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        ///   The first room on the map, where the player character must start.
        /// </summary>
        public Room StartRoom { get; private set; }

        /// <summary>
        ///   Every room on the map.
        /// </summary>
        public IEnumerable<Room> Rooms {
            get {
                foreach (var room in rooms) {
                    yield return room;
                }
            }
        }

        /// <summary>
        ///   Creates a new map with the given dimensions.
        /// </summary>
        /// <param name="width">The width of the map in tiles.</param>
        /// <param name="height">The height of the map in tiles.</param>
        public Map(int width, int height) {
            Width = width;
            Height = height;
            contents = new Tile[height, width];

            for (var y = 0; y < height; y++) {
                for (var x = 0; x < width; x++) {
                    contents[y, x] = new Tile(true);
                }
            }

            rooms = new List<Room>();
            StartRoom = null;
        }

        /// <summary>
        ///   Accesses the tiles in the map.
        /// </summary>
        /// <param name="x">The column where the tile is located.</param>
        /// <param name="y">The row where the tile is located.</param>
        public Tile this[int x, int y] {
            get {
                return contents[y, x];
            }
        }

        /// <summary>
        ///   Creates a new room on the map.
        /// </summary>
        /// <param name="room">The room to create.</param>
        public void DigRoom(Room room) {
            for (var y = room.Y1 + 1; y < room.Y2; y++) {
                for (var x = room.X1 + 1; x < room.X2; x++) {
                    this[x, y].Blocked = false;
                    this[x, y].BlocksSight = false;
                }
            }
        }

        /// <summary>
        ///   Creates a horizontal hallway on the map.
        /// </summary>
        /// <param name="x1">The x-coordinate where the tunnel starts.</param>
        /// <param name="x2">The x-coordinate where the tunnel ends.</param>
        /// <param name="y">The y-coordinate of the tunnel.</param>
        public void DigHTunnel(int x1, int x2, int y) {
            var maxX = Math.Max(x1, x2);
            var minX = Math.Min(x1, x2);
            for (var x = minX; x <= maxX; x++) {
                this[x, y].Blocked = false;
                this[x, y].BlocksSight = false;
            }
        }

        /// <summary>
        ///   Creates a vertical hallway on the map.
        /// </summary>
        /// <param name="y1">The y-coordinate where the tunnel starts.</param>
        /// <param name="y2">The y-coordinate where the tunnel ends.</param>
        /// <param name="x">The x-coordinate of the tunnel.</param>
        public void DigVTunnel(int y1, int y2, int x) {
            var maxY = Math.Max(y1, y2);
            var minY = Math.Min(y1, y2);
            for (var y = minY; y <= maxY; y++) {
                this[x, y].Blocked = false;
                this[x, y].BlocksSight = false;
            }
        }

        /// <summary>
        ///   Randomly generates a new map.
        /// </summary>
        public void Generate() {
            var rng = new Random();
            var roomCount = 0;

            for (var r = 0; r < maxRooms; r++) {
                var width = rng.Next(roomMinSize, roomMaxSize + 1);
                var height = rng.Next(roomMinSize, roomMaxSize + 1);
                var x = rng.Next(0, this.Width - width);
                var y = rng.Next(0, this.Height - height);

                var newRoom = new Room(x, y, width, height);
                var validRoom = true;
                foreach (var otherRoom in rooms) {
                    if (newRoom.Intersects(otherRoom)) {
                        validRoom = false;
                        break;
                    }
                }

                if (!validRoom) {
                    continue;
                }

                DigRoom(newRoom);

                if (roomCount == 0) {
                    StartRoom = newRoom;
                } else {
                    var newCenter = newRoom.Center;
                    var newX = newCenter.Item1;
                    var newY = newCenter.Item2;
                    var prevCenter = rooms[roomCount - 1].Center;
                    var prevX = prevCenter.Item1;
                    var prevY = prevCenter.Item2;

                    if (rng.Next(2) == 0) {
                        DigHTunnel(prevX, newX, prevY);
                        DigVTunnel(prevY, newY, newX);
                    } else {
                        DigVTunnel(prevY, newY, prevX);
                        DigHTunnel(prevX, newX, newY);
                    }
                }

                rooms.Add(newRoom);
                roomCount++;
            }
        }
    }
}
