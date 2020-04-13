using System;

namespace MyFirstMonoGame
{
    /// <summary>
    /// The main class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            DiscoWorld game = new DiscoWorld();
            game.Run();
        }

    }
}