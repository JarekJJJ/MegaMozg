
//Mega Mózg - gra w quizy
//Funkcjonalności do zrobienia
//1b. Tryby gru (mieszane kategorie, lub pytania z określonj kategorii.
//2a. Pytania mają określoną trudność (1-10), oraz mnożnik punktacji
//2d. Ujemne punkty za złe odpowiedzi. 
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
AnswerService answerService = new AnswerService();
PlayerService playerService = new PlayerService();
GameService gameService = new GameService();
UserQuestionManager userQuestionManager = new UserQuestionManager(categoryQuestionsService,questionService,answerService);
PlayerManager playerManager = new PlayerManager(playerService);
GameManager gameManager = new GameManager(playerService,questionService,answerService, gameService);
HighScoreManager highScoreManager = new HighScoreManager(gameService, playerService);
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
            gameManager.StartGame(playerId);
            gameService.WriteJsonDB();
            break;
        case '2':
            int questionId = userQuestionManager.AddNewQuestions();
            userQuestionManager.AddUserAnswer(questionId);
            break;
        case '3':
            highScoreManager.GetHighScore();
            break;//Implementacja przy bazach danych
        case '4':
            exitMenu = 1;
            break;
        default:
            Console.WriteLine("Błąd: Nie wprowodzano odpowiedniej pozycji menu (1-4");
            break;
    }
} while (exitMenu != 1);





