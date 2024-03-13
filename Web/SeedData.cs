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
            
            var quiz1 = new Quiz(
                    id: 1,
                    items: new List<QuizItem>
                    {
                        new QuizItem(
                            id: 1,
                            question: "Jaka jest stolica Polski?",
                            incorrectAnswers: new List<string> {"Krosno", "Wadowice", "Wieliczka"},
                            correctAnswer: "Warszawa"
                        ),
                        new QuizItem(
                            id: 2,
                            question: "Więcej niż jedno zwierze to.. ",
                            incorrectAnswers: new List<string> {"Pies", "2", "10"},
                            correctAnswer: "Owca"
                        ),
                        new QuizItem(
                            id: 3,
                            question: "Gdzie siedzi wykładowca z JS?",
                            incorrectAnswers: new List<string> {"Na szczycie", "W mieście", "W lesie"},
                            correctAnswer: "Na brzegu"
                        )
                    },
                    title: "Quiz 1"
                );

            var quiz2 = new Quiz(
                    id: 2,
                    items: new List<QuizItem>
                    {
                        new QuizItem(
                            id: 1,
                            question: "Z jakim morzem sąsiaduje Polska?",
                            incorrectAnswers: new List<string> {"Może", "Morze Spokojne", "Morze Bałkańskie"},
                            correctAnswer: "Morze Bałtyckie"
                        ),
                        new QuizItem(
                            id: 2,
                            question: "Z kim nie graniczy Polska?",
                            incorrectAnswers: new List<string> {"Słowacja", "Węgry", "Niemcy"},
                            correctAnswer: "Włochy"
                        ),
                        new QuizItem(
                            id: 3,
                            question: "Najlepsze piwko?",
                            incorrectAnswers: new List<string> {"Tyskie", "Piwo Tesco", "Harnaś"},
                            correctAnswer: "Żuberek"
                        )
                    },
                    title: "Quiz 2"
                );

                quizRepo.Add(quiz1);
                quizRepo.Add(quiz2);
            }
        }
    }