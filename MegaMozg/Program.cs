
//Mega Mózg - gra w quizy
//Funkcjonalności
// 1.Nowa gra
// 1a. Nazwa gracza
//1b. Tryby gru (mieszane kategorie, lub pytania z określonj kategorii.
//2. Dodawanie własnych pytań
//2a. Pytania mają określoną trudność (1-10) oraz kategorię
//3. Hall of Fame - lista graczy z najlepszymi wynikami (%)
//3a. Podział na mistrzów wybranej kategorii lub  kategorii mieszanych. 

using MegaMozg;
using System.Collections.Generic;

QuestionService questionService = new QuestionService();
PlayerService playerService = new PlayerService();
AnswerService answerService = new AnswerService();
InterfaceActionService actionService = new InterfaceActionService();
CategoryQuestionsService categoryQuestionsService = new CategoryQuestionsService();
List<CategoryQuestion> categoryQuestions = new List<CategoryQuestion>();
int exitMenu = 0;
categoryQuestions = ReadCategoryBase(categoryQuestionsService);
Initialize(actionService);
BazaPytan(questionService, answerService); //Wczytanie pytań i odpowiedzi do pamięci
do
{
    Console.Clear();
    var mainMenu = actionService.GetInterfaceActionsByName("Main");

    for (int i = 0; i < mainMenu.Count; i++)
    {
        Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
    }
    var wyborMenu = Console.ReadKey();

    switch (wyborMenu.KeyChar)
    {
        case '1':
            int playerId = playerService.AddPlayer();
            GameService.StartGame(playerId, playerService, categoryQuestionsService, questionService, answerService);
            break;
        case '2':
            var keyInfo = questionService.AddQuestionsView(categoryQuestions);
            int questionId = questionService.AddNewQuestion(keyInfo.KeyChar);
            answerService.AddNewAnswer(questionId);
            break;
        case '3':
            break;//Implementacja przy bazach danych
        case '4':
            exitMenu = 1;
            break;

        default:
            Console.WriteLine("Błąd: Nie wprowodzano odpowiedniej pozycji menu (1-4");
            break;
    }
} while (exitMenu != 1);
static void Initialize(InterfaceActionService actionService)
{
    actionService.AddNewAction(1, "Nowa gra", "Main");
    actionService.AddNewAction(2, "Dodaj własne pytanie", "Main");
    actionService.AddNewAction(3, "Tablica wyników", "Main");
    actionService.AddNewAction(4, "Wyjście", "Main");    
}
//Odczyt z bazy tymczasowej 
//Kategorie pytań
static List<CategoryQuestion> ReadCategoryBase(CategoryQuestionsService categoryQuestionsService)
{
    categoryQuestionsService.AddCategoryQuestions(1, "Techika");
    categoryQuestionsService.AddCategoryQuestions(2, "Historia");
    categoryQuestionsService.AddCategoryQuestions(3, "Geografia");
    categoryQuestionsService.AddCategoryQuestions(4, "Biologia");

    return categoryQuestionsService.GetCategoryQuestions(); ;
}
static void BazaPytan(QuestionService questionService, AnswerService answerService)
{
    //Pytania :
    questionService.AddBaseQuestions(1, 1, "Ile klawiszy ma standardowa klawiatura komputerowa ?");
    //Odpowiedzi:
    answerService.AddBaseAnswer(1, "104", true);
    answerService.AddBaseAnswer(1, "110", false);
    answerService.AddBaseAnswer(1, "101", false);
    answerService.AddBaseAnswer(1, "112", false);
    //Pytania :
    questionService.AddBaseQuestions(2, 1, "130 koni mechanicznych ile to kiloWatów");
    //Odpowiedzi:
    answerService.AddBaseAnswer(2, "130kW", false);
    answerService.AddBaseAnswer(2, "75.86kW", false);
    answerService.AddBaseAnswer(2, "95.61kW", true);
    answerService.AddBaseAnswer(2, "165.32kW", false);
    //Pytania :
    questionService.AddBaseQuestions(3, 2, "Który król najdłużej rządził w Polsce(48 lat i 3 miesiące)?");
    //Odpowiedzi:
    answerService.AddBaseAnswer(3, "Bolesław Chrobry", false);
    answerService.AddBaseAnswer(3, "Zygmunt I Stary", false);
    answerService.AddBaseAnswer(3, "Władysław Jagiełło", true);
    answerService.AddBaseAnswer(3, "Jan III Sobieski", false);
    //Pytania :
    questionService.AddBaseQuestions(4, 3, "Ile w Polsce jest województw ?");
    //Odpowiedzi:
    answerService.AddBaseAnswer(4, "14", false);
    answerService.AddBaseAnswer(4, "18", false);
    answerService.AddBaseAnswer(4, "22", false);
    answerService.AddBaseAnswer(4, "16", true);
    //Pytania :
    questionService.AddBaseQuestions(5, 4, "Stonoga (Oniscoidea) ile ma nóg ?");
    //Odpowiedzi:
    answerService.AddBaseAnswer(5, "7 par", true);
    answerService.AddBaseAnswer(5, "47 par", false);
    answerService.AddBaseAnswer(5, "50 par", false);
    answerService.AddBaseAnswer(5, "67 par", false);
}


