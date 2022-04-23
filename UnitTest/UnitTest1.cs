using Cursach;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DecryptionTest1()
        {
            string text = "бщцфаирщри, бл ячъбиуъ щбюэсяёш гфуаа!!! " +
                "у ъящэячэц ъэюоык, едщ бдв саэацкшгнбяр гчеа кчфцшубп цу ьгщпя вщвсящ, эвэчрысй юяуъщнщхо шпуъликугбз чъцшья с " +
                "цощъвчщ ъфмес ю лгюлэ ёъяяр! с моыящш шпмоец щаярдш цяэубфъ аьгэотызуа дщ, щръ кй юцкъщчьуац уыхэцэ ясч юбюяуяг ыовзсгюамщщ.внютвж тхыч " +
                "эядкъябе цн юкъль, мэсццогл шяьфыоэьь ть эщсщжнашанэ ыюцен, уёюяыцчан мах гъъьуун шпмоыъй ч яяьпщъхэтпык яущм бпйэае!чэьюмуд, оээ скфч саьбрвчёыа " +
                "эядуцйт ъ уьгфщуяяёу фси а эацэтшцэч юпапёи, ьь уъубфмч ысь хффы ужц чьяцнааущ эгъщйаъф, ч п эиттпьк ярвчг гмубзньцы!щб ьшяо шачюрэсч FirstLineSoftware " +
                "ц ешчтфщацдпбр шыыь, р ыоф ячцсвкрщве бттй а ядсецсцкюкх эшашёрэсуъ якжще увюгщр в# уфн ысвчюпжзцж! чй ёюычъ бщххыибй еьюхечр п хкъмэншёцч юятщвфцшчщ " +
                "с хчю ъэ ч аачсюсчыщачрняун в шъюьэжцясиьццч агфуо ацаьяычсцы .Net, чэбф ыуюбпьщо с чыдпяхбцйг щктрж!";
            string key = "скорпион";
            string expected = "поздравляю, ты получил исходный текст!!! " +
                "в принципе понять, что тут используется шифр виженера не особо трудно, основная подсказка заключается именно в наличии ключа у этого шифра! " +
                "в данной задаче особый интерес составляет то, как вы реализуете именно сам процесс расшифровки.теперь дело осталось за малым, доделать программу " +
                "до логического конца, выполнить все условия задания и опубликовать свою работу!молодец, это были достаточно трудные и интересные два с половиной " +
                "месяца, но впереди нас ждет еще множество открытий, и я надеюсь общих свершений!от лица компании FirstLineSoftware и университета итмо, я рад " +
                "поздравить тебя с официальным окончанием наших курсов с# для начинающих! мы хотим пожелать успехов в дальнейшем погружении в мир ит и программирования " +
                "с использованием стека технологий .Net, море терпения и интересных задач!";
            var crypter = new Cryption();
            string res = crypter.Decryption(text, key);
            Assert.AreEqual(expected, res);

        }
        [TestMethod]
        public void EncryptionTest1()
        {
            string text = "бебра и 23 меня";
            var key = "беб";
            var expected = "вйвсе й 23 нйоа";
            var result = new Cryption().Encryption(text, key);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DecryptionTest2()
        {
            string text = "Я в своём познании настолько преисполнился";
            string key = null;
            string res = new Cryption().Decryption(text, key);
        }

        [TestMethod]
        public void DecryptionTest3()
        {
            string text = "Amogus is sus";
            string key = "ёж";
            string expected = "Amogus is sus";
            string res = new Cryption().Decryption(text, key);
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        public void EncryptionTest2()
        {
            string text = "Зашифрованное сообщение";
            string key = "ключ";
            string expected = "Тлцаяьмщкщлёп эмёлегеур";
            string result = new Cryption().Encryption(text, key);
            Assert.AreEqual(expected, result);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void EncryptionTest3()
        {
            string text = "Зашифрованное сообщение";
            string key = null;
            string result = new Cryption().Encryption(text, key);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void EncryptTest1()
        {
            string text = "Тестик";
            string key = null;
            new Model().Encrypt(text, key);
        }
    }
}
