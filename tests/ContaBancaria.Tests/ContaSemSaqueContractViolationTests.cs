namespace ContaBancariaTests;

public class ContaSemSaqueContractViolationTests
{
    [Fact]
    public void ContaSemSaque_QuebraContratoDeSaqueDaClasseBase()
    {
        // Usa a subclasse como se fosse a base (princípio da substituição)
        ContaBancaria conta = new ContaSemSaque(100m);

        // O cliente espera que o saque funcione (pré-condição da base: valor <= Saldo)
        // Mas a subclasse lança NotSupportedException
        Action act = () => conta.Sacar(50m);

        // Este teste PASSA ao verificar a violação — documenta o problema
        act.Should().Throw<NotSupportedException>()
            .WithMessage("*não permite saques*");

        // Em um teste de conformidade LSP, isso seria uma FALHA,
        // pois o cliente da base não espera essa exceção.
    }
}