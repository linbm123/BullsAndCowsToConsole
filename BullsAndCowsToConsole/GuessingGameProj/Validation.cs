namespace ValidationMethods
{
    public class Validation
    {
        public enum eInputStatus
        {
            InputOk = 0,
            SyntaxError = 1,
            InputNotCorrect = 2
        }

        public void CheckIfNumBetweenFourAndTenAndConvert(string i_StrNumber, out int o_NumOfChoices, out eInputStatus o_Status)
        {
            if (int.TryParse(i_StrNumber, out int o_IntegerNum))
            {
                if (o_IntegerNum >= 4 && o_IntegerNum <= 10)
                {
                    o_NumOfChoices = o_IntegerNum;
                    o_Status = eInputStatus.InputOk;
                }
                else
                {
                    o_NumOfChoices = 0;
                    o_Status = eInputStatus.InputNotCorrect;
                }
            }
            else
            {
                o_NumOfChoices = 0;
                o_Status = eInputStatus.SyntaxError;
            }
        }

        public void UserGuessingValidation(string i_ChoicesStr, out eInputStatus o_UserInputStatus)
        {
            bool ifStrContainsCorrectCharactersOnlyFlag = true;
            int strLength = i_ChoicesStr.Length;

            if (i_ChoicesStr == "q" || i_ChoicesStr == "Q")
            {
                o_UserInputStatus = eInputStatus.InputOk;
            }
            else
            {
                for (int i = 0; i < strLength; i++)
                {
                    if (i_ChoicesStr[i] >= 'A' && (i_ChoicesStr[i] <= 'H' || i_ChoicesStr[i] >= 'a')
                                              && i_ChoicesStr[i] <= 'h')
                    {
                        continue;
                    }

                    ifStrContainsCorrectCharactersOnlyFlag = false;
                    break;
                }

                if (ifStrContainsCorrectCharactersOnlyFlag == false)
                {
                    o_UserInputStatus = eInputStatus.SyntaxError;
                }
                else if (strLength != 4)
                {
                    o_UserInputStatus = eInputStatus.InputNotCorrect;
                }
                else
                {
                    o_UserInputStatus = eInputStatus.InputOk;
                }
            }
        }
    }
}
