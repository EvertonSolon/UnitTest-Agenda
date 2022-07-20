using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Agenda.Domain;
using AutoFixture;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        //IncluirContatoTest
        [Test]
        public void AdicionarContatoTest()
        {
            //Monta
            var contato = _fixture.Create<Contato>();

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
            var contato = _fixture.Create<Contato>();

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
            var contato = _fixture.Create<Contato>();
            var contato2 = _fixture.Create<Contato>();

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
            _fixture = null;
        }

    }
}
