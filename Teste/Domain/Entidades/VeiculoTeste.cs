using MinimalApi.Dominio.Entidades;

namespace Teste.Domain.Entidades;

[TestClass]
public class VeiculoTeste
{
    [TestMethod]
    public void TestarGetSetProriedades()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Action
        veiculo.Id = 1;
        veiculo.Marca = "Kia";
        veiculo.Nome = "Soul";
        veiculo.Ano = 2023;
        //Assert

        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Kia", veiculo.Marca);
        Assert.AreEqual("Soul", veiculo.Nome);
        Assert.AreEqual(2023, veiculo.Ano);

    }
}