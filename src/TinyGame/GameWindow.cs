using System.Drawing;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using System;

namespace TinyGame
{
    public class GameWindow
    {
        private IWindow window;
        public GameWindow(int width = 800, int height = 600, string title = "GameWindow") 
        {
            var options = WindowOptions.Default;
                        options.Size = new Vector2D<int>(width, height);
                        options.Title = title;

                        window = Window.Create(options);

                        //Assign events.
                        window.Load += OnLoad;
                        window.Update += OnUpdate;
                        window.Render += OnRender;

                        //Run the window.
                        window.Run();
        }

        private void OnLoad()
        {
            //Set-up input context.
            IInputContext input = window.CreateInput();
            for (int i = 0; i < input.Keyboards.Count; i++)
            {
                input.Keyboards[i].KeyDown += KeyDown;
            }
        }

        private void OnRender(double deltaTime)
        {
            //Here all rendering should be done.
        }

        private void OnUpdate(double deltaTime)
        {
            //Here all updates to the program should be done.
        }

        private void KeyDown(IKeyboard keyboard, Key key, int arg3)
        {
            //Check to close the window on escape.
            if (key == Key.Escape)
            {
                window.Close();
            }
        }
    }
}
