using ApplicationCore.Interfaces.Criteria;
using BackendLab01;
using ApplicationCore.Interfaces.Repository;
using Infrastructure.Memory;
using Infrastructure.Memory.Repository;

namespace UnitTest;

public class GenericRepositoryTest
{
    private readonly IGenericRepository<QuizItem, int> quizItemRepository;
    private readonly QuizItem item1;
    private readonly QuizItem item2;
    private readonly QuizItem item3;
    
    public GenericRepositoryTest()
    {
        quizItemRepository = new MemoryGenericRepository<QuizItem, int>(new IntGenerator());
        item1 = quizItemRepository.Add(new QuizItem(
            question: "Litera?",
            incorrectAnswers: new List<string>() {"B", "C", "D"}, 
            correctAnswer:"A", id: 0));
        item2 = quizItemRepository.Add(new QuizItem(
            question: "{Planeta?",
            incorrectAnswers: new List<string>() {"Mars", "Wenus", "Pluton"}, 
            correctAnswer:"Jowisz", id: 0));
        item3 = quizItemRepository.Add(new QuizItem(
            question: "Miasto?",
            incorrectAnswers: new List<string>() {"Kielce", "Kraków", "Katowice"}, 
            correctAnswer:"Kołobrzeg", id: 0));
    }

    [Fact]
    public void CreateTest()
    {
        Assert.Equal(item1.Id, quizItemRepository.FindById(item1.Id).Id);
        Assert.Equal(item2.Id, quizItemRepository.FindById(item2.Id).Id);
        Assert.Equal(item3.Id, quizItemRepository.FindById(item3.Id).Id);
    }
    [Fact]
    public void DeleteTest()
    {
        var newItem = quizItemRepository.Add(new QuizItem(
            id: 1,
            correctAnswer: "x",
            incorrectAnswers: new List<string>() {"1", "2", "3"},
            question: "?")
        );
        Assert.Contains( quizItemRepository.FindAll(), item => item.Id == newItem.Id);
        Assert.Equal(4, quizItemRepository.FindAll().Count());
        quizItemRepository.RemoveById(newItem.Id);
        Assert.Equal(3, quizItemRepository.FindAll().Count());
        Assert.Contains(quizItemRepository.FindAll(), item => item.Id == item2.Id);
        Assert.Contains(quizItemRepository.FindAll(), item => item.Id == item3.Id);
        Assert.DoesNotContain(quizItemRepository.FindAll(), item => item.Id == newItem.Id);
    }

    [Fact]
    public void UpdateTest()
    {
        var updatedQuiz = new QuizItem(
            item1.Id,
            correctAnswer: item1.CorrectAnswer,
            incorrectAnswers: item1.IncorrectAnswers,
            question: "question");
        quizItemRepository.Update(item1.Id, updatedQuiz);
        var item = quizItemRepository.FindById(item1.Id);
        Assert.Equal(updatedQuiz.Question, item.Question);
    }

    [Fact]
    public void FindBySpecification()
    {
        IEnumerable<QuizItem> items = quizItemRepository.FindBySpecification(new QuizItemByQuestion("Miasto?"));
        Assert.Contains(items, item => item.Question == "Miasto?");
        Assert.Single(items);
    }

}