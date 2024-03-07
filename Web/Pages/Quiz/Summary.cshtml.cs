using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class Summary : PageModel
{
    public int CorrectAnswersCount { get; set; }

        public void OnGet(int correctAnswersCount)
        {
            CorrectAnswersCount = correctAnswersCount;
        }
}