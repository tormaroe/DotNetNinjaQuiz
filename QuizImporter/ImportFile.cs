using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace QuizImporter
{
    public class ImportFile : IDisposable
    {
        private string _filePath;
        private StreamReader _reader;        

        public ImportFile(string filePath)
        {
            _filePath = filePath;
        }

        public bool EOF
        {
            get
            {
                if (HasNotReadYet)
                {
                    OpenStream();
                }

                return _reader.EndOfStream;
            }
        }

        public string NextLine()
        {
            if (HasNotReadYet)
            {
                OpenStream();
            }

            return _reader.ReadLine();
        }

        private bool HasNotReadYet
        {
            get
            {
                return _reader == null;
            }
        }

        private void OpenStream()
        {
            _reader = new StreamReader(_filePath);
        }

        #region IDisposable Members

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            _isDisposed = true;

            if (disposing)
            {
                if (_reader != null)
                {
                    _reader.Close();
                }
            }
        }

        #endregion
    }
}
