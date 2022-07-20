using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Agenda.Domain;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest
    {
        Contatos _contatos;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
        }

        //IncluirContatoTest
        [Test]
        public void AdicionarContatoTest()
        {
            //Monta
            var id = Guid.NewGuid().ToString();
            var nome = "FulanoTest";

            //Executa
            _contatos.Adicionar(id, nome);

            //Verifica
            Assert.True(true);
        }

        //ObterContatoTest
        [Test]
        public void ObterContatoTest()
        {
            //Monta
            var id = Guid.NewGuid().ToString();
            var nome = "MariaTest";

            //Executa
            _contatos.Adicionar(id, nome);
            var nomeResultado = _contatos.Obter(id);

            //Verifica
            Assert.AreEqual(nome, nomeResultado);
        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }

    }
}
