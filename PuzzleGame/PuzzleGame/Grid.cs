using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class Grid
    {
        private readonly int width;
        private readonly int height;
        private Entity[,] cells;

        public int Width => width;
        public int Height => height;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new Entity[width, height];
        }

        public Entity GetEntity(int x, int y)
        {
            return IsInside(x, y) ? cells[x, y] : new Wall(); // Default: wall out-of-bounds
        }

        public void SetEntity(int x, int y, Entity e)
        {
            if (IsInside(x, y))
            {
                cells[x, y] = e;
                if (e != null) e.SetPosition(x, y);
            }
        }

        public void RemoveEntity(int x, int y)
        {
            if (IsInside(x, y))
            {
                cells[x, y] = null;
            }
        }

        public bool IsEmpty(int x, int y)
        {
            return IsInside(x, y) && cells[x, y] == null;
        }

        public bool IsInside(int x, int y)
        {
            return x >= 0 && y >= 0 && x < width && y < height;
        }

        public void Draw()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var e = cells[x, y];
                    Console.Write(e?.Symbol ?? ' ');
                }
                Console.WriteLine();
            }
        }
    }
}