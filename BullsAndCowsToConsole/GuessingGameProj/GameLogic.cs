using System;
using System.Collections.Generic;

namespace GuessingGameLogic
{
    public class GameLogic
    {        
        private readonly int r_MinNumOfGuessing;
        private readonly int r_MaxNumOfGuessing;
        private string[,] m_GameMatrix;
        private int m_NumberOfGuessing;

        public GameLogic()
        {
            this.m_NumberOfGuessing = 0;
            this.m_GameMatrix = new string[2, 2];
            this.r_MinNumOfGuessing = 4;
            this.r_MaxNumOfGuessing = 10;

            this.initializeMatrix();
        }

        public int GetNumOfGuessing()
        {
            return this.m_NumberOfGuessing;
        }

        public string[,] GetMatrix()
        {
            return this.m_GameMatrix;
        }

        public string GetValueFromMatrix(int i_Row, int i_Col)
        {
            string tempStr = null;

            if (i_Col >= 0 && i_Col < this.m_GameMatrix.GetLength(1) &&
                i_Row >= 0 && i_Row < this.m_GameMatrix.GetLength(0))
            {
                tempStr = this.m_GameMatrix[i_Row, i_Col];
            }

            return tempStr;
        }

        public int GetLengthOfRowsInMatrix()
        {
            return this.m_GameMatrix.GetLength(0);
        }

        public int GetLengthOfColumnsInMatrix()
        {
            return this.m_GameMatrix.GetLength(1);
        }

        public void SetValueToMatrix(string i_StrValue, int i_Row, int i_Col)
        {
            if (i_Col >= 0 && i_Col < this.m_GameMatrix.GetLength(1) &&
                i_Row >= 0 && i_Row < this.m_GameMatrix.GetLength(0))
            {
                this.m_GameMatrix[i_Row, i_Col] = i_StrValue;
            }
        }

        public void SetNumOfGuessing(int i_NumOfGuessing)
        {
            if (i_NumOfGuessing >= r_MinNumOfGuessing && i_NumOfGuessing <= r_MaxNumOfGuessing)
            {
                this.m_NumberOfGuessing = i_NumOfGuessing;
            }
        }

        private void initializeMatrix()
        {
            this.m_GameMatrix[0, 0] = "Pins:";
            this.m_GameMatrix[0, 1] = "Result:";
            this.m_GameMatrix[1, 0] = "# # # #";
            this.m_GameMatrix[1, 1] = null;
        }

        public string ChooseRandomChartsAsString()
        {
            string randomStr = null;
            Random rand = new Random();
            List<int> randomNumArr = new List<int>();

            for (int iteration = 0; iteration < 4; iteration++)
            {
                int num = rand.Next(65, 73);
                if (randomNumArr.Contains(num))
                {
                    iteration--;
                }
                else
                {
                    char singleLetter = (char)num;
                    randomStr += singleLetter;
                    randomNumArr.Add(num);
                }
            }

            return randomStr;
        }

        public void GuessingComparisonWithRandomString(string i_RandomStr, string i_GuessingStr, out string o_CompareResults)
        {
            o_CompareResults = null;

            for (int indexInGuessingStr = 0; indexInGuessingStr < i_GuessingStr.Length; indexInGuessingStr++)
            {
                for (int indexInRandomStr = 0; indexInRandomStr < i_RandomStr.Length; indexInRandomStr++)
                {
                    if (i_GuessingStr[indexInGuessingStr] == i_RandomStr[indexInRandomStr] &&
                        indexInGuessingStr == indexInRandomStr)
                    {
                        o_CompareResults += "V";
                    }
                    else if (i_GuessingStr[indexInGuessingStr] == i_RandomStr[indexInRandomStr])
                    {
                        o_CompareResults += "X";
                    }
                }
            }
        }

        public void ResizeAndCopyMatrix(int i_NewNumOfRows, int i_NewNumOfCols)
        {
            string[,] newTempArray = new string[i_NewNumOfRows, i_NewNumOfCols];
            int minRows = Math.Min(i_NewNumOfRows, this.m_GameMatrix.GetLength(0));
            int minCols = Math.Min(i_NewNumOfCols, this.m_GameMatrix.GetLength(1));

            for (int currentRowIndex = 0; currentRowIndex < minRows; currentRowIndex++)
            {
                for (int currentColIndex = 0; currentColIndex < minCols; currentColIndex++)
                {
                    newTempArray[currentRowIndex, currentColIndex] = this.GetValueFromMatrix(currentRowIndex, currentColIndex);
                }
            }

            this.m_GameMatrix = newTempArray;
        }
    }
}
