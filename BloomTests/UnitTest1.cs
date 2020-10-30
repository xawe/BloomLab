using NUnit.Framework;

namespace BloomTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FilterSomeTestOK()
        {
            var filter = new BloomFilter.Filter<string>(50000);
            filter.Add("Alam");
            filter.Add("Alam2");
            filter.Add("T1");
            filter.Add("Marte");
            filter.Add("Banco");
            filter.Add("Dinheiro");
            /*
            var filter = new Filter<string>(capacity);
            filter.Add("content");
            ...
                filter.Contains("content");
            */

            Assert.IsTrue(filter.Contains("Alam"));
            Assert.IsTrue(filter.Contains("Alam2"));
            Assert.IsFalse(filter.Contains("Camilla"));

        }


        [Test]
        public void ReadTest()
        {
            BloomLab01.Tools.File f = new BloomLab01.Tools.File();
            //Lendo 1 milhão de linhas de texto - Senhas curtas
            var items = f.Read("I:\\Projetos\\NetCore\\Bloom\\BloomTests\\file\\word.txt");            
            var filter = new BloomFilter.Filter<string>(999999);
            //Carregando o filtro com os registros
            items.ForEach( x => {
                filter.Add(x);
            });

            //Testando se os registros são encontrados no filtro.
            items.ForEach(x => {
                Assert.IsTrue(filter.Contains(x));
            });
        }
    }
}