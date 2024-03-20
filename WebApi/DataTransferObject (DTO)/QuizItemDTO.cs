using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace BackendLab01.DataTransferObject__DTO_
{
    public class QuizItemDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }


        public static QuizItemDTO Of(QuizItem item)
        {
            Random rand = new Random();

            var options = new List<string>(item.IncorrectAnswers)
            {
                item.CorrectAnswer
            };

            options.Sort((a,b) => 1- rand.Next(3));


            return new QuizItemDTO
            {
                Id = item.Id,
                Question = item.Question,
                Options = options
            };
        }



    }
}
