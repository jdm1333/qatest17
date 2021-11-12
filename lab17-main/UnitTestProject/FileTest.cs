using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using UnitTestEx;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class FileTest
    {

        public const string SIZE_EXCEPTION = "Wrong size";
        public const string NAME_EXCEPTION = "Wrong name";
        public const string WARNING_CONTENT_EMPTY = " ";
        public const string SPACE_STRING = " ";
        public const string FILE_PATH_STRING = "@D:\\JDK-intellij-downloader-info.txt";
        public const string CONTENT_STRING = "Some text";
        public double lenght;

        /* ПРОВАЙДЕР */
        static object[] FilesData =
        {
            new object[] {new File(FILE_PATH_STRING, CONTENT_STRING), FILE_PATH_STRING, CONTENT_STRING},
            new object[] { new File(SPACE_STRING, SPACE_STRING), SPACE_STRING, SPACE_STRING}
        };

        /* Тестируем получение размера */
        [Test, TestCaseSource(nameof(FilesData))]
        public void GetSizeTest(File newFile, String name, String content)
        {
            lenght = content.Length / 2;

            Assert.AreEqual(newFile.GetSize(), lenght, SIZE_EXCEPTION);
        }

        /* Тестируем получение имени */
        [Test, TestCaseSource(nameof(FilesData))]
        public void GetFilenameTest(File newFile, String name, String content)
        {
            Assert.AreEqual(newFile.GetFilename(), name, NAME_EXCEPTION);
        }

        /* Тестируем запрет на загурзку htaccess файлов*/
        [Test, TestCaseSource(nameof(FilesData))]
        public void GetExtensionTest(File newFile, String extension, String content)
        {
            Assert.AreNotEqual(newFile.GetExtension(), ".htaccess");
        }
        /* Тестируем на проверку создания контента */
        [Test, TestCaseSource(nameof(FilesData))]
        public void GetContentTest(File newFile , String content)
        {
            // проверям что переданный контент равняется созданному контенту
            Assert.AreEqual(newFile.GetContent(), content);
        }

        /* Тестируем на то, что размер файла - целое число */
        [Test, TestCaseSource(nameof(FilesData))]
        public void GetIntSizeFileTest(File newFile, String content, Int32 size)
        {
            // проверям что переданный контент равняется созданному контенту
            Assert.AreEqual(GetType(newFile.GetSize()), "int");
        }

        private object GetType(double v)
        {
            throw new NotImplementedException();
        }
    }
}
