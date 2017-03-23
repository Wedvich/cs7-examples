namespace Cs7.Helpers
{
    public class WorldMap
    {
        private const int SizeX = 5;
        private const int SizeY = 5;

        private readonly Tile[,] _tiles;

        public WorldMap()
        {
            _tiles = new Tile[SizeX, SizeY];
            for (var x = 0; x < SizeX; ++x)
            {
                for (var y = 0; y < SizeY; ++y)
                {
                    _tiles[x, y] = new GrassTile();
                }
            }
        }

        public ref Tile FindTileAt(int x, int y)
        {
            return ref _tiles[x, y];
        }
    }

    public abstract class Tile
    {
    }

    public class GrassTile : Tile
    {
    }

    public class TreeTile : Tile
    {
    }

    public class LavaTile : Tile
    {
    }
}
