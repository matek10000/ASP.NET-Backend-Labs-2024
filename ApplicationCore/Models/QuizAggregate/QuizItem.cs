using ApplicationCore.Interfaces.Repository;

namespace BackendLab01;

public class QuizItem: IIdentity<int>
{
    public int Id { get; set; }
    public string Question { get; }
    public List<string> IncorrectAnswers { get; }
    public string CorrectAnswer { get;  }

    public QuizItem(int id, string question, List<string> incorrectAnswers, string correctAnswer)
    {
        Id = id;
        Question = question;
        IncorrectAnswers = incorrectAnswers;
        CorrectAnswer = correctAnswer;
    }
}