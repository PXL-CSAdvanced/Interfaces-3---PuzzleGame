// Gegeven code: Grid, Program
using PuzzleGame;

public class Program
{
    static void Main()
    {
        Grid grid = new Grid(7, 20);
        // Create player
        Player player = new Player(grid);
        grid.SetEntity(3, 18, player);

        // Walls
        for (int x = 0; x < grid.Width; x++)
        {
            grid.SetEntity(x, 0, new Wall());
            grid.SetEntity(x, grid.Height - 1, new Wall());
        }

        for (int y = 0; y < grid.Height; y++)
        {
            grid.SetEntity(0, y, new Wall());
            grid.SetEntity(grid.Width - 1, y, new Wall());
        }

        // Furniture: Closets
        for (int i = 0; i < 9; i++)
        {
            grid.SetEntity(1, 18 - i, new Closet());
            grid.SetEntity(5, 18 - i, new Closet());
        }
        grid.SetEntity(2, 8, new Closet());
        grid.SetEntity(3, 8, new Closet());
        grid.SetEntity(4, 8, new Closet());

        // Fruniture: Chairs
        grid.SetEntity(3, 14, new Chair());
        grid.SetEntity(2, 13, new Chair());
        grid.SetEntity(4, 13, new Chair());
        grid.SetEntity(3, 12, new Chair());
        grid.SetEntity(2, 11, new Chair());
        grid.SetEntity(4, 11, new Chair());
        grid.SetEntity(3, 10, new Chair());


        // Furniture: Tables
        grid.SetEntity(2, 6, new Table());
        grid.SetEntity(3, 6, new Table());
        grid.SetEntity(4, 6, new Table());
        grid.SetEntity(1, 5, new Table());
        grid.SetEntity(5, 5, new Table());
        grid.SetEntity(2, 4, new Table());
        grid.SetEntity(3, 4, new Table());
        grid.SetEntity(4, 4, new Table());
        grid.SetEntity(1, 3, new Table());
        grid.SetEntity(2, 3, new Table());
        grid.SetEntity(4, 3, new Table());
        grid.SetEntity(5, 3, new Table());

        grid.SetEntity(1, 2, new Closet());
        grid.SetEntity(5, 2, new Closet());
        grid.SetEntity(1, 1, new Closet());
        grid.SetEntity(2, 1, new Closet());
        grid.SetEntity(4, 1, new Closet());
        grid.SetEntity(5, 1, new Closet());

        grid.RemoveEntity(3, 0);

        while (true)
        {
            Console.Clear();
            grid.Draw();
            Console.WriteLine("Use arrow keys. ESC to quit.");

            var key = Console.ReadKey(true).Key;
            int dx = 0, dy = 0;

            switch (key)
            {
                case ConsoleKey.UpArrow: dy = -1; break;
                case ConsoleKey.DownArrow: dy = 1; break;
                case ConsoleKey.LeftArrow: dx = -1; break;
                case ConsoleKey.RightArrow: dx = 1; break;
                case ConsoleKey.Escape: return;
                default: continue;
            }

            player.Move(dx, dy);
        }
    }
}
