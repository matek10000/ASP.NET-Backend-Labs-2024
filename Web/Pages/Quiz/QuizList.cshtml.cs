using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages.Quiz
{
    public class QuizListModel : PageModel
    {
        public List<BackendLab01.Quiz> QuizLista { get; set; }

        private readonly IQuizUserService quizUserService;

        public QuizListModel(IQuizUserService quizUserService)
        {
            this.quizUserService = quizUserService;
        }

        public void OnGet()
        {
            QuizLista = quizUserService.GetAllQuiz();
        }
    }
}
