# Laboratorium 1

1. Zapoznaj się z budową całego rozwiązania zgodnego z Clean Architecture
2. W projekcie UnitTest znajdziesz kod, który tworzy serwisy wraz z zależnościami
3. W projekcie Web zarejestruj w postaci singletonów repozytoria dla Quiz, QuizItem i QuizItemUserAnswer oraz serwis IQuizUserService w postaci implementacji QuizUserService.
4. Dokończ klasę SeedData, w której dodaj co najmniej dwa obiekty klasy Quiz, każdy  co najmniej z trzema pytaniami (QuizItem).
5. Dokończ stronę QuizItem (plik Item.cshtml.cs), aby po osiągnięciu ostatniego pytani quizu, nastapiło przejście do strony Symmary.
6. Zaimplementuj logikę i stwórz widok strony Summary.cshmtl, aby zawierała informację ile poprawnych odpowiedzi udzielił użytkownik.
7. Stwórz stronę RazorPage, która wyświetli wszystkie quizy w postaci linków. Każdy z  linków powinien kierować do strony  Quiz/Item z parametrem quizId z numerem quizu i pierwszym pytaniem w postaci parametru itemId=1
8. W pliku _Layout.cshtml dodaj link do strony z punktu 7.