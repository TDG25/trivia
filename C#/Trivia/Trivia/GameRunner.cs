using System;
using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {
        public static void Main(String[] args)
        {
            var aGame = new Game();
            aGame.QueuePlayer("A");
            aGame.QueuePlayer("B");
            aGame.Initialise();

            if (aGame.State == GameState.InvalidPlayerCount)
            {
                Console.WriteLine("Cannot start game. This game requires for 2-6 players.");
                Console.ReadKey();
                return;
            }
            aGame.Play();
            Console.ReadKey();
        }


    }

}

