
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
using MegaMozg.App.Abstract;
using MegaMozg.App.Concrete;
using MegaMozg.App.Managers;
using MegaMozg.Domain.Entity;
using System.Collections.Generic;

InterfaceActionService actionService = new InterfaceActionService();
CategoryQuestionsService categoryQuestionsService = new CategoryQuestionsService();
QuestionService questionService = new QuestionService();
QuestionsManager questionsManager = new QuestionsManager(categoryQuestionsService, questionService);
AnswerService answerService = new AnswerService();
AnswersManager answersManager = new AnswersManager(answerService);
PlayerService playerService = new PlayerService();
PlayerManager playerManager = new PlayerManager(playerService);
GameService gameService = new GameService();
GameManager gameManager = new GameManager(playerService,questionService,answerService, gameService);
//QuestionService questionService = new QuestionService();
//PlayerService playerService = new PlayerService();
//AnswerService answerService = new AnswerService();
//InterfaceActionService actionService = new InterfaceActionService();
//CategoryQuestionsService categoryQuestionsService = new CategoryQuestionsService();
//List<CategoryQuestion> categoryQuestions = new List<CategoryQuestion>();
int exitMenu = 0;

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
            int playerId = playerManager.AddNewPlayer();
            var endGame = gameManager.StartGame(playerId);
            break;
        case '2':
            int questionId = questionsManager.AddNewQuestions();
            answersManager.AddUserAnswer(questionId);
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





