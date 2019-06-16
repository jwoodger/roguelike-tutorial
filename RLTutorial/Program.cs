using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SadConsole;

namespace RLTutorial {

    class Program {

        const int ConsoleWidth = 80;
        const int ConsoleHeight = 25;

        static void Main(string[] args) {
            SadConsole.Game.Create(ConsoleWidth, ConsoleHeight);
            SadConsole.Game.OnInitialize = Initialize;

            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        static void Initialize() {
            var console = new Console(ConsoleWidth, ConsoleHeight);
            console.FillWithRandomGarbage();
            console.Fill(new Rectangle(3, 3, 22, 3), Color.White, Color.Black, ' ', SpriteEffects.None);
            console.Print(4, 4, "Welcome to the game!");

            SadConsole.Global.CurrentScreen = console;
        }
    }
}
