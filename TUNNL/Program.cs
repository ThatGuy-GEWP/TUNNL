using SFML.Graphics;
using SFML.Window;
using SFML_GE.System;
using System.Diagnostics;
using System.Numerics;
using TUNNL.Common;
using TUNNL.Layers;
using TUNNL.Layers.Activations;

/*
 *  T U N N L
 *  Tims
 *  Universal/Ultimate/uhhhhhh
 *  Neural
 *  Network
 *  Library
 *  
 *  god i love funny acronyms
 */


namespace TUNNL
{
    public class Program
    {
        public static RenderWindow App { get; private set; } = new RenderWindow(
            new VideoMode(1280, 720),
            "TUNNL Visualizer",
            Styles.Close | Styles.Titlebar
        );

        static void Main(string[] args)
        {
            bool appOpen = true;

            App.Closed += (a, args) => { App.Close(); appOpen = false; };
            App.SetFramerateLimit(144);

            Project mainProject = new Project("Res", App);
            Scene scene = mainProject.CreateSceneAndLoad("DefaultScene");

            Network testNetwork = new Network(
                new Linear(28 * 28),
                new MaxPool1D(2),
                new Linear((28*28) / 2, 512),
                new TanH(),
                new Linear(512, 10)
            );


            testNetwork.Forward(new float[28 * 28]);

            int[] sizes = testNetwork.GetLayerSizes();

            Console.Write("[");
            for(int i = 0; i < sizes.Length; i++)
            {
                Console.Write(sizes[i] + (i != sizes.Length - 1 ? ", " : "]"));
            }
            Console.Write("\n");

            return; // just return for the time being while testing maths and stuff

            mainProject.Start();
            while (appOpen)
            {
                mainProject.Update();

                App.Clear();
                mainProject.Render(App);
                App.Display();
            }
        }
    }
}
