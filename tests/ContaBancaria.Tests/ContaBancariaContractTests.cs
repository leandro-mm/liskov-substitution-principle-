namespace ContaBancariaTests;

public class ContaBancariaContractTests
{
    // ---------- Testes de PRÉ-CONDIÇÃO ----------

    [Fact]
    public void Depositar_ComValorZero_DeveLancarArgumentOutOfRangeException()
    {
        // Arrange
        var conta = new ContaBancaria(100m);

        // Act
        Action act = () => conta.Depositar(0m);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithParameterName("valor")
            .WithMessage("*Depósito deve ser positivo*");
    }
    [Fact]
    public void Depositar_ComValorNegativo_DeveLancarArgumentOutOfRangeException()
    {
        var conta = new ContaBancaria(100m);
        Action act = () => conta.Depositar(-50m);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Sacar_ComValorMaiorQueSaldo_DeveLancarInvalidOperationException()
    {
        var conta = new ContaBancaria(100m);
        Action act = () => conta.Sacar(150m);
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("*Saldo insuficiente*");
    }
    // ---------- Testes de PÓS-CONDIÇÃO ----------

    [Fact]
    public void Depositar_ComValorValido_DeveAumentarSaldoCorretamente()
    {
        // Arrange
        var conta = new ContaBancaria(100m);
        var saldoAntes = conta.Saldo;

        // Act
        conta.Depositar(50m);

        // Assert (pós-condição: Saldo == old(Saldo) + valor)
        conta.Saldo.Should().Be(saldoAntes + 50m);
    }

    [Fact]
    public void Sacar_ComValorValido_DeveDiminuirSaldoCorretamente()
    {
        var conta = new ContaBancaria(100m);
        var saldoAntes = conta.Saldo;

        conta.Sacar(30m);

        conta.Saldo.Should().Be(saldoAntes - 30m);
    }
    // ---------- Testes de INVARIANTE ----------

    [Fact]
    public void AposMultiplasOperacoes_SaldoDevePermancerNaoNegativo()
    {
        var conta = new ContaBancaria(100m);

        conta.Depositar(50m);
        conta.Sacar(120m);

        // Invariante da classe: _saldo >= 0
        conta.Saldo.Should().BeGreaterThanOrEqualTo(0);
    }

    [Fact]
    public void Construtor_ComSaldoInicialNegativo_DeveLancarExcecao()
    {
        Action act = () => new ContaBancaria(-10m);
        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithParameterName("saldoInicial");
    }
}