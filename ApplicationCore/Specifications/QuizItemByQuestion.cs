using BackendLab01;

namespace ApplicationCore.Interfaces.Criteria;

public class QuizItemByQuestion: BaseSpecification<QuizItem>
{
    public QuizItemByQuestion(string question): base(item => item.Question == question)
    {
        AddInclude(item => item.IncorrectAnswers);
    }
}