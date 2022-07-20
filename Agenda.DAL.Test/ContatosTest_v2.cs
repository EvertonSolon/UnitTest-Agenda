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
    public class ContatosTest_v2 : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
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

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
