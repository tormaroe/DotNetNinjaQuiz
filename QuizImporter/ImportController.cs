using System;
using DotNetNinjaQuizLib.Domain;
using DotNetNinjaQuizLib.Persistance;

namespace QuizImporter
{
    public class ImportController
    {
        #region Fields and constructor

        private ImportFile _importFile;
        private IQuestionRepository _questionRespository;

        public ImportController(string pathToImportFile, string pathToTargetDb)
        {
            _importFile = new ImportFile(pathToImportFile);            
            _questionRespository = QuestionRepositoryFactory.CreateObjectDatabaseRespository(pathToTargetDb);
        }

        #endregion

        #region Import function

        internal void Import()
        {
            try
            {
                int importCount = 0;

                while (!_importFile.EOF)
                {
                    string csvLine = _importFile.NextLine();
                    QuizQuestion question = QuestionFactory.CreateFromCSV(csvLine);
                    _questionRespository.AddQuestion(question);
                    importCount++;
                }

                Console.WriteLine("Imported {0} questions.", importCount);
                Console.WriteLine("{0} questions exist in total.", _questionRespository.CountAllQuestions());
                Console.WriteLine("{0} of them are easy.", _questionRespository.CountQuestions(DifficultyLevel.Easy));
                Console.WriteLine("{0} of them are of medium difficulty.", _questionRespository.CountQuestions(DifficultyLevel.Medium));
                Console.WriteLine("{0} of them are difficult.", _questionRespository.CountQuestions(DifficultyLevel.Difficult));
                Console.WriteLine("{0} of them are of unknown difficulty.", _questionRespository.CountQuestions(DifficultyLevel.Unknown));

                Console.WriteLine();

                var unknowns = _questionRespository.GetQuestions(DifficultyLevel.Unknown);

                foreach (var question in unknowns)
                {
                    question.Print();
                }
            }
            finally
            {
                _questionRespository.Dispose();
                _importFile.Dispose();
            }
        }

        #endregion
    }
}
