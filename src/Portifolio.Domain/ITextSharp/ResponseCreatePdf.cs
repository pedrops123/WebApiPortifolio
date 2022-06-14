using System;

namespace Portifolio.Domain.ITextSharp
{
    public sealed class ResponseCreatePdf
    {
        public string FileName { get; private set; }
        public byte[] FileBytes { get; private set; }
        public string ContentType
        {
            get
            {
                return "application/pdf";
            }
        }

        public ResponseCreatePdf(string fileName, byte[] fileBytes)
        {
            SetFileName(fileName);

            SetFileBytes(fileBytes);
        }

        private void SetFileName(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Nome do arquivo não pode ser vazio !", nameof(fileName));
            }

            FileName = fileName;
        }


        private void SetFileBytes(byte[] fileBytes)
        {
            if (fileBytes.Length == 0)
            {
                throw new ArgumentException("Byte do arquivo nao pode ser vazio.", nameof(fileBytes));
            }

            FileBytes = fileBytes;
        }
    }
}
