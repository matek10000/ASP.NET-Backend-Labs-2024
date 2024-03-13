using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.AccessControl;

namespace BackendLab01.Pages;

public class Summary : PageModel
{
    public int CorrectAnswersCount { get; set; }

    private readonly IQuizUserService _userService;

    public Summary(IQuizUserService userService)
    {
        _userService= userService;
    }

    public void OnGet(int quizId, int userId)
    {
        CorrectAnswersCount = _userService.CountCorrectAnswersForQuizFilledByUser(quizId, userId);
    }
}