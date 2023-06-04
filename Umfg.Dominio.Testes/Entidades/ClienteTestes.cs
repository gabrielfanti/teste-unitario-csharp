using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umfg.Dominio.Entidades;

namespace Umfg.Dominio.Testes.Entidades
{
    [TestClass]
    public sealed class ClienteTestes
    {
        private const string _firstOwner = "Juliano Maciel";
        private const string _secondOwner = "Ruan";
        private const string _category = "Cliente";

        [TestMethod]
        [Owner(_firstOwner)]
        [TestCategory(_category)]
        public void Cliente_Construtor_Sucesso()
        {
            try
            {
                var cliente = new Cliente("04405125228", "TESTE");

                Assert.AreEqual("TESTE", cliente.Nome);
                Assert.AreEqual("04405125228", cliente.Documento);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Owner(_firstOwner)]
        [TestCategory(_category)]
        public void Cliente_DocumentoNull_ThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Cliente(null, "TESTE"));
        }

        [TestMethod]
        [Owner(_firstOwner)]
        [TestCategory(_category)]
        public void Cliente_NomeNull_ThrowArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Cliente("04405125228", null));
        }

        [TestMethod]
        [Owner(_firstOwner)]
        [TestCategory(_category)]
        public void Cliente_DocumentoVazio_ThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Cliente("", "TESTE"));
        }

        [TestMethod]
        [Owner(_firstOwner)]
        [TestCategory(_category)]
        public void Cliente_NomeVazio_ThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => new Cliente("04405125228", ""));
        }
    }

    public class Cliente
    {
        public string Documento { get; }
        public string Nome { get; }

        public Cliente(string documento, string nome)
        {
            if (string.IsNullOrEmpty(documento))
                throw new ArgumentException("O valor do documento não pode estar vazio.", nameof(documento));

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("O valor do nome não pode estar vazio.", nameof(nome));

            Documento = documento;
            Nome = nome;
        }
    }
}