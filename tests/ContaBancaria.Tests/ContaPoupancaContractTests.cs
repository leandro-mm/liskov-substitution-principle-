namespace ContaBancariaTests;

public class ContaPoupancaContractTests
{
    [Fact]
    public void ContaPoupanca_DeveRespeitarContratoDeDeposito()
    {
        // Arrange: usa a subclasse onde se espera a base
        ContaBancaria conta = new ContaPoupanca(100m, 0.01m);

        // Act
        conta.Depositar(50m);

        // Assert: pós-condição da base é mantida
        conta.Saldo.Should().Be(150m);
    }

    [Fact]
    public void ContaPoupanca_DeveRespeitarContratoDeSaque()
    {
        ContaBancaria conta = new ContaPoupanca(100m, 0.01m);

        conta.Sacar(30m);

        conta.Saldo.Should().Be(70m);
    }
}