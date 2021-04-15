using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Helpers.Test
{
    [TestClass]
    public class StringLibraryTest
    {
        [TestMethod]
        public void CutStringTest()
        {
            string strCut = "Hello World, This is a test sentence.";
            int intChar = 15;

            var expected = "Hello World,...";
            var actual = StringLibrary.CutString(strCut, intChar);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CutStringUnicodeTest()
        {
            string strCut = "안녕하세요. 부경대학교입니다.";
            int intChar = 9;

            var expected = "안녕하세요....";
            var actual = StringLibrary.CutStringUnicode(strCut, intChar);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest()
        {
            var expected = 10;
            var actual = (5 + 5);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPhotoTest()
        {
            var imagePath = @"C:\Sources\GitRepository\StudyDesktopApp\WPFApp\WpfAdvBank\packages\Newtonsoft.Json.13.0.1";
            bool result = BoardLibrary.IsPhoto(imagePath);
            Assert.IsTrue(result, "file extension must be png, jpg, gif"); //imagepath 주소에 확장자 없으면 istrue일때 테스트 실패, isfalse면 테스트 성공
        }
        [TestMethod]
        public void IsNotPhotoTest()
        {
            var imagePath = @"C:\Sources\GitRepository\StudyDesktopApp\WPFApp\WpfAdvBank\packages\Newtonsoft.Json.13.0.1";
            bool result = BoardLibrary.IsPhoto(imagePath);
            Assert.IsFalse(result, "file extension must be png, jpg, gif"); //imagepath 주소에 확장자 없으면 istrue일때 테스트 실패, isfalse면 테스트 성공

        }
    }
}
