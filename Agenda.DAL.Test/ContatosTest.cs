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
    public class ContatosTest : BaseTest
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

        [Test]
        public void ObterTodosContatosTest()
        {
            //Monta
            var contato = new Contato
            {
                Id = Guid.NewGuid(),
                Nome = "ClaudiaTest"
            };

            var contato2 = new Contato
            {
                Id = Guid.NewGuid(),
                Nome = "SilviaTest"
            };

            //Executa
            _contatos.Adicionar(contato);
            _contatos.Adicionar(contato2);
            var contatos = _contatos.ObterTodos();
            var contatoVerificado = contatos.Where(x => x.Id == contato.Id).FirstOrDefault();

            //Verifica
            Assert.IsTrue(contatos.Count() > 1);
            Assert.AreEqual(contato.Id, contatoVerificado.Id);
            Assert.AreEqual(contato.Nome, contatoVerificado.Nome);

        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }

    }
}
