using System;
using SplashKitSDK;

namespace player
{
    public class Program
    {
        public static void Main()
        {
            var window = new Window("Player Game", 800, 600);
            var robotDodge = new RobotDodge(window);
           

            while (!window.CloseRequested && !robotDodge.Quit )
            {
                SplashKit.ProcessEvents();

                robotDodge.HandleInput();

                robotDodge.Draw();

                robotDodge.update();
                
            }

            window.Close();

        }
    }
}
