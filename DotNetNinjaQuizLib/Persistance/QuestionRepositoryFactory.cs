using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using DotNetNinjaQuizLib.Domain;

namespace DotNetNinjaQuizLib.Persistance
{
    public static class QuestionRepositoryFactory
    {
        public static IQuestionRepository CreateObjectDatabaseRespository(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path is null or empty");
            }

            Db4oFactory.Configure().ObjectClass(typeof(QuizQuestion))
                .CascadeOnUpdate(true);

            return new ObjectDatabaseQuestionRepository(Db4oFactory.OpenFile(path));
        }

        public static void DropObjectDatabase(string path)
        {
            System.IO.File.Delete(path);
        }
    }
}
