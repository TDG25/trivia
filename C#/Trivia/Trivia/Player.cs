using System;

namespace Trivia
{
    internal class Player
    {
        public string Name { get; set; }
        public int Place { get; set; }
        public int GoldCoins { get; set; }
        public bool IsInPenaltyBox { get; set; }

        public void MoveToPenaltyBox()
        {
            IsInPenaltyBox = true;
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(Name + " was sent to the penalty box");
        }

        public void MoveOutOfPenaltyBox()
        {
            IsInPenaltyBox = false;
            Console.WriteLine($"{Name} got out");
        }


        public void MovePlayer(int roll)
        {
            if (IsInPenaltyBox)
                MoveOutOfPenaltyBox();

            Place += roll;
            if (Place > 11)
                Place -= 12;

            Console.WriteLine(Name
                              + "'s new location is "
                              + Place);
            Console.WriteLine("The category is " + Question.QuestionCategoryForOccupiedPlace(Place));
        }



        public void AnswersCorrectly()
        {
            if (IsInPenaltyBox)
            {
                MoveOutOfPenaltyBox();
            }

            Console.WriteLine("CORRECT ANSWER");
            GoldCoins++;
            Console.WriteLine($"{Name} now has {GoldCoins} Gold Coins.");
        }

        public void AnswersIncorrectly()
        {
            Console.WriteLine("INCORRECT ANSWER");
            MoveToPenaltyBox();
        }

        public bool DidPlayerWin()
        {
            return GoldCoins == 6;
        }

    }
}