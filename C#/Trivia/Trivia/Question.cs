using System;

namespace Trivia
{
    internal class Question
    {
        public QuestionType Type { get; set; }
        public int Number { get; set; }

        public static QuestionType QuestionCategoryForOccupiedPlace(int place)
        {
            switch (place)
                {
                    case 0:
                        return QuestionType.Pop;
                    case 1:
                        return QuestionType.Science;
                    case 2:
                        return QuestionType.Sport;
                    case 3:
                        return QuestionType.Rock;
                    case 4:
                        return QuestionType.Pop;
                    case 5:
                        return QuestionType.Science;
                    case 6:
                        return QuestionType.Sport;
                    case 7:
                        return QuestionType.Rock;
                    case 8:
                        return QuestionType.Pop;
                    case 9:
                        return QuestionType.Science;
                    case 10:
                        return QuestionType.Sport;
                    case 11:
                        return QuestionType.Rock;
                    default:
                        throw new Exception();
                }
            
        }
    }

    internal enum QuestionType
    {
        Rock,
        Pop,
        Science,
        Sport
    }
}