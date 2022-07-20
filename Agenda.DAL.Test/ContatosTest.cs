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
            var contato = new Contato
            {
                Id = Guid.NewGuid(),
                Nome = "JoaoTest"
            };

            //Executa
            _contatos.Adicionar(contato);

            //Verifica
            Assert.True(true);
        }

        //ObterContatoTest
        [Test]
        public void ObterContatoTest()
        {
            //Monta
            var contato = new Contato
            {
                Id = Guid.NewGuid(),
                Nome = "MariaTest"
            };

            //Executa
            _contatos.Adicionar(contato);
            var nomeResultado = _contatos.Obter(contato.Id);

            //Verifica
            Assert.AreEqual(contato.Id, nomeResultado.Id);
            Assert.AreEqual(contato.Nome, nomeResultado.Nome);
        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }

    }
}
