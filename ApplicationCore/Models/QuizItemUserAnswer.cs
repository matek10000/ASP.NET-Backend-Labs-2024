using ApplicationCore.Interfaces.Repository;

namespace BackendLab01;

public class QuizItemUserAnswer: IIdentity<string>
{
    public int QuizId { get; }
    public QuizItem  QuizItem{ get; }
    public int UserId { get; }
    public string Answer { get; }
    public QuizItemUserAnswer(QuizItem quizItem, int userId, int quizId,string answer)
    {
        QuizItem = quizItem;
        Answer = answer;
        UserId = userId;
        QuizId = quizId;
    }

    public bool IsCorrect()
    {
        return QuizItem.CorrectAnswer == Answer;
    }

    public string Id
    {
        get => $"{QuizId}{UserId}{QuizItem.Id}";
        set
        {
            
        }
    }
}