using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;

namespace Portifolio.Domain.Test.Mocks
{
    public static class CreateIFileFormCollectionMock
    {
        public static IFormFileCollection GenerateIFileFormCollection(string fileName)
        {
            FormFileCollection collection = new FormFileCollection();

            string content = new Fixture()
                .Create<string>();

            var memoryStream = new MemoryStream();

            var writer = new StreamWriter(memoryStream);

            writer.Write(content);
            writer.Flush();


            FormFile file = new FormFile(memoryStream, 0, memoryStream.Length, "files", fileName);

            collection.Add(file);

            return collection;
        }
    }
}