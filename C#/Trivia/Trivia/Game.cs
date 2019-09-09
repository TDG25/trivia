using System;
using System.Collections.Generic;
using UglyTrivia;

namespace Trivia
{
    public class Game
    {
        public GameState State { get; set; }
        readonly List<Player> _players = new List<Player>();
        QuestionDeck _deck = new QuestionDeck();

        int _currentPlayerIndex;

        public void QueuePlayer(string playerName)
        {
            _players.Add(new Player {Name = playerName});
            Console.WriteLine(playerName + " wants to play");
        }

        public void Initialise()
        {
            if (_players.Count < 2 || _players.Count > 6)
            {
                Console.WriteLine("2-6 Players only!");
                State = GameState.InvalidPlayerCount;
            }
            else
            {
                var count = 1;
                foreach (var player in _players)
                {
                    player.Place = 0;
                    player.GoldCoins = 0;
                    player.IsInPenaltyBox = false;

                    Console.WriteLine($"{player.Name} is player number {count}");
                    count++;
                }
            }
        }

        public void Play()
        {
            State = GameState.InPlay;
            var rand = new Random();

            while (State != GameState.GameOver)
            {
                var currentPlayer = _players[_currentPlayerIndex];
                Console.WriteLine($"{currentPlayer.Name}'s turn");

                var roll = rand.Next(5) + 1;
                Console.WriteLine($"{currentPlayer.Name} rolls a {roll}");

                if (currentPlayer.IsInPenaltyBox && roll % 2 == 0)
                {
                    Console.WriteLine($"{currentPlayer.Name} is not getting out of the penalty box with a roll of: {roll}");
                    CompleteTurn();
                    continue;
                }

                currentPlayer.MovePlayer(roll);
                _deck.AskQuestion(Question.QuestionCategoryForOccupiedPlace(currentPlayer.Place));

                if (rand.Next(9) >= 4)
                    currentPlayer.AnswersIncorrectly();
                else
                    currentPlayer.AnswersCorrectly();

                State = currentPlayer.DidPlayerWin() ? GameState.GameOver : GameState.InPlay;
                CompleteTurn();
            }
        }

        private void CompleteTurn()
        {
            _currentPlayerIndex++;
            if (_currentPlayerIndex == _players.Count)
                _currentPlayerIndex = 0;
        }
    }
}