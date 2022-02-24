using GuessingGameLogic;
using ValidationMethods;
using GameDisplay;
using UtilityMethods;

namespace GuessingGameUserInterface
{
    public class GuessingGameUI
    {
        public static void StartGame()
        {
            string startNewGameOrExit;
            ConsoleDisplay myConsole = new ConsoleDisplay();
            Validation myGameValidation = new Validation();
            Utilities myUtilityMethods = new Utilities();

            myConsole.CleanScreen();
            myConsole.PrintGameLogo(3);
            do
            {
                bool winningFlag = false;
                bool ifUserInputNotCorrect = true;
                GameLogic myGame = new GameLogic();
                string randomFourCharters = myGame.ChooseRandomChartsAsString();

                myConsole.CleanScreen();
                while (ifUserInputNotCorrect == true)
                {
                    myConsole.PrintToConsole(string.Format("How many guessing choices do you want between 4 and 10 ?"));
                    string numOfGuessingStr = myConsole.GetFromConsole();

                    myGameValidation.CheckIfNumBetweenFourAndTenAndConvert(
                        numOfGuessingStr,
                        out int o_NumOfGuessing,
                        out Validation.eInputStatus userInputStatus);
                    switch (userInputStatus)
                    {
                        case Validation.eInputStatus.InputOk:
                            {
                                ifUserInputNotCorrect = false;
                                myGame.SetNumOfGuessing(o_NumOfGuessing);
                                myConsole.CleanScreen();
                                break;
                            }

                        case Validation.eInputStatus.SyntaxError:
                            {
                                myConsole.PrintToConsole(string.Format("Your input NOT a number (Syntax Error)"), 2);
                                myConsole.CleanScreen();
                                break;
                            }

                        case Validation.eInputStatus.InputNotCorrect:
                            {
                                myConsole.PrintToConsole(string.Format("Your input number is out of range"), 2);
                                myConsole.CleanScreen();
                                break;
                            }

                        default:
                            break;
                    }
                }

                myGame.ResizeAndCopyMatrix(2 + myGame.GetNumOfGuessing(), 2);
                for (int gameIteration = 2; gameIteration <= myGame.GetLengthOfRowsInMatrix(); gameIteration++)
                {
                    if (gameIteration == myGame.GetLengthOfRowsInMatrix())
                    {
                        myUtilityMethods.InsertSpacesBetweenCharacters(ref randomFourCharters);
                        myGame.SetValueToMatrix(randomFourCharters, 1, 0);
                        myConsole.PrintMatrixToConsole(myGame.GetMatrix());
                        myConsole.PrintToConsole(string.Format("GAME OVER, YOU LOSE"), 3);
                    }
                    else
                    {
                        myConsole.PrintMatrixToConsole(myGame.GetMatrix());
                        if (winningFlag == false)
                        {
                            myConsole.PrintToConsole(
                                string.Format("Please enter your next guess <A B C D E F G H> or Q to quit"));
                            string guessingStr = myConsole.GetFromConsole();
                            myGameValidation.UserGuessingValidation(guessingStr, out Validation.eInputStatus o_UserInputStatus);
                            switch(o_UserInputStatus)
                            {
                                case Validation.eInputStatus.InputOk:
                                    {
                                        myUtilityMethods.ConvertToUpperCase(
                                            guessingStr,
                                            out string guessingUpperCaseStr);
                                        if(guessingUpperCaseStr == "Q")
                                        {
                                            gameIteration = myGame.GetLengthOfRowsInMatrix();
                                            myConsole.PrintToConsole(string.Format("THANK YOU AND GOOD BYE ."), 3);
                                            myConsole.CleanScreen();
                                        }
                                        else
                                        {
                                            myGame.GuessingComparisonWithRandomString(
                                                randomFourCharters,
                                                guessingUpperCaseStr,
                                                out string o_CompareResults);
                                            myUtilityMethods.SortByAlphabetic(ref o_CompareResults);
                                            myUtilityMethods.InsertSpacesBetweenCharacters(ref o_CompareResults);
                                            myUtilityMethods.InsertSpacesBetweenCharacters(ref guessingUpperCaseStr);
                                            myGame.SetValueToMatrix(o_CompareResults, gameIteration, 1);
                                            myGame.SetValueToMatrix(guessingUpperCaseStr, gameIteration, 0);
                                            if(o_CompareResults == "V V V V ")
                                            {
                                                winningFlag = true;
                                                gameIteration = myGame.GetLengthOfRowsInMatrix();
                                                myConsole.PrintMatrixToConsole(myGame.GetMatrix());
                                                myConsole.PrintToConsole(
                                                    string.Format("Congratulations, YOU WIN ! ! !"), 3);
                                            }
                                        }

                                        break;
                                    }

                                case Validation.eInputStatus.SyntaxError:
                                    {
                                        gameIteration--;
                                        myConsole.PrintToConsole(string.Format("Sorry, you have a syntax Error"), 3);
                                        myConsole.CleanScreen();
                                        break;
                                    }

                                case Validation.eInputStatus.InputNotCorrect:
                                    {
                                        gameIteration--;
                                        myConsole.PrintToConsole(string.Format("Your input not as required"), 3);
                                        myConsole.CleanScreen();
                                        break;
                                    }

                                default:
                                    break;
                            }
                        }
                        else
                        {
                            gameIteration = myGame.GetLengthOfRowsInMatrix();
                            myConsole.PrintToConsole(string.Format("YOU WIN !!!!!!!!"), 3);
                        }
                    }
                }

                myConsole.PrintToConsole(string.Format("Do you want to start a new game ?"));
                myConsole.PrintToConsole(string.Format("(Press 'Q' to quit and ANY KEY to continue with new game)"));
                startNewGameOrExit = myConsole.GetFromConsole();
            } 
            while (startNewGameOrExit != "Q" && startNewGameOrExit != "q");
        }
    }
}
