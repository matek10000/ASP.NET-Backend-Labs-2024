using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using Infrastructure.Memory;
using Infrastructure.Memory.Repository;

namespace UnitTest;

public class MemoryQuizServiceTest
{
    private IGenericRepository<Quiz, int> quizRepository = new MemoryGenericRepository<Quiz, int>(new IntGenerator());
    private IGenericRepository<QuizItem, int> itemRepository = new MemoryGenericRepository<QuizItem, int>(new IntGenerator());
    private IGenericRepository<QuizItemUserAnswer, string> answerRepository =  new MemoryGenericRepository<QuizItemUserAnswer, string>();
    
    private IQuizAdminService _aservice;
    private IQuizUserService _uservice;
    private User _user = new User() {Id = 1, Username = "Testowy"};
    private Quiz _quiz; 
    
    public MemoryQuizServiceTest()
    {
        _aservice = new QuizAdminService(quizRepository, itemRepository);
        _uservice = new QuizUserService(quizRepository, answerRepository, itemRepository);
        _aservice.AddQuizItem(points: 1, correctAnswer: "A", incorrectAnswers: new List<string>(){"B", "C", "D"},question: "Pierwsza litera alfabetu?" );
        _aservice.AddQuizItem(points: 1, correctAnswer: "B", incorrectAnswers: new List<string>(){"A", "C", "E"},question: "Druga litera alfabetu?" );
        _aservice.AddQuizItem(points: 1, correctAnswer: "C", incorrectAnswers: new List<string>(){"A", "B", "F"},question: "Trzecia litera alfabetu?" );
        _quiz = _aservice.AddQuiz("Litery alfabetu", _aservice.FindAllQuizItems());
    }

    [Fact]
    public void CreateItemsTest()
    {
        _aservice.AddQuizItem(points: 2, correctAnswer: "A", incorrectAnswers: new List<string>(){"B", "C", "D"},question: "Pierwsza litera alfabetu?" );
        var items = _aservice.FindAllQuizItems();
        Assert.Equal(1, items.Count());
    }
    [Fact]
    public void CreateQuizTest()
    {
        var findQuiz = _uservice.FindQuizById(_quiz.Id);
        Assert.Equal(_quiz.Id, findQuiz.Id);
    }
    
    [Fact]
    public void AddUserAnswerTest()
    {
        var quiz = _uservice.FindQuizById(_quiz.Id);
        _uservice.SaveUserAnswerForQuiz(quizId: quiz.Id, userId: _user.Id, quizItemId: quiz.Items[0].Id, "x");
        _uservice.SaveUserAnswerForQuiz(quizId: quiz.Id, userId: _user.Id, quizItemId: quiz.Items[1].Id, quiz.Items[1].CorrectAnswer);
        _uservice.SaveUserAnswerForQuiz(quizId: quiz.Id, userId: _user.Id, quizItemId: quiz.Items[2].Id, quiz.Items[2].CorrectAnswer);
        List<QuizItemUserAnswer> userAnswers = _uservice.GetUserAnswersForQuiz(quiz.Id, userId: _user.Id);
        Assert.Equal(3, userAnswers.Count);
        int count = _uservice.CountCorrectAnswersForQuizFilledByUser(quiz.Id, _user.Id);
        Assert.Equal(2, count);
    }
}