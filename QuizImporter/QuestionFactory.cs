using System;
using DotNetNinjaQuizLib.Domain;
using System.Collections;

namespace QuizImporter
{
    public class QuestionFactory
    {
        internal static QuizQuestion CreateFromCSV(string csvLine)
        {
            string[] lineParts = Split(csvLine, ",", "\"", true);

            return new QuizQuestion()
            {
                QuestionText = lineParts[0],
                CorrectAnswer = lineParts[1],
                WrongAnswer1 = lineParts[2],
                WrongAnswer2 = lineParts[3],
                WrongAnswer3 = lineParts[4],
                Difficulty = lineParts[5].ConvertToDifficultyLevel(),
            };
        }

        /// <summary>
        /// Split Function that Supports Text Qualifiers
        /// Source: http://www.codeproject.com/KB/dotnet/TextQualifyingSplit.aspx
        /// </summary>
        private static string[] Split(string expression, string delimiter, string qualifier, bool ignoreCase)
        {
            bool qualifierState = false;
            int startIndex = 0;
            ArrayList values = new ArrayList();

            for (int charIndex = 0; charIndex < expression.Length - 1; charIndex++)
            {
                if ((qualifier != null)
                 & (string.Compare(expression.Substring(charIndex, qualifier.Length), qualifier, ignoreCase) == 0))
                {
                    qualifierState = !(qualifierState);
                }
                else if (!(qualifierState) & (delimiter != null)
                      & (string.Compare(expression.Substring(charIndex, delimiter.Length), delimiter, ignoreCase) == 0))
                {
                    values.Add(expression.Substring(startIndex, charIndex - startIndex));
                    startIndex = charIndex + 1;
                }
            }

            if (startIndex < expression.Length)
                values.Add(expression.Substring(startIndex, expression.Length - startIndex));

            string[] returnValues = new string[values.Count];
            values.CopyTo(returnValues);
            return returnValues;
        }
    }
}
