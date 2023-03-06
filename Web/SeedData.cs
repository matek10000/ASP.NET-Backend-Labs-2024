using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            List<QuizItem> items = new List<QuizItem>();
            items.Add(quizItemRepo.Add(new QuizItem(
                question: "Litera?",
                incorrectAnswers: new List<string>() {"B", "C", "D"}, 
                correctAnswer:"A", id: 1)));
            items.Add(quizItemRepo.Add(new QuizItem(
                question: "Planeta?",
                incorrectAnswers: new List<string>() {"Mars", "Wenus", "Pluton"}, 
                correctAnswer:"Jowisz", id: 2)));
            items.Add(quizItemRepo.Add(new QuizItem(
                question: "Miasto?",
                incorrectAnswers: new List<string>() {"Kielce", "Kraków", "Katowice"}, 
                correctAnswer:"Kołobrzeg", id: 3)));
            quizRepo.Add(new Quiz(id: 1, items: items, title: "Różne"));
        }
    }
}