public class ContaBancaria
{
    protected decimal _saldo;

    public ContaBancaria(decimal saldoInicial)
    {
        // Pré-condição
        if (saldoInicial < 0)
            throw new ArgumentOutOfRangeException(nameof(saldoInicial),
                "Saldo inicial não pode ser negativo.");
        _saldo = saldoInicial;
    }

    public decimal Saldo => _saldo;

    /// <summary>
    /// CONTRATO:
    /// Pré-condição : valor > 0
    /// Pós-condição : Saldo == old(Saldo) + valor
    /// Exceções     : ArgumentOutOfRangeException se valor <= 0
    /// </summary>
    public virtual void Depositar(decimal valor)
    {
        // Pré-condição
        if (valor <= 0)
            throw new ArgumentOutOfRangeException(nameof(valor),
                "Depósito deve ser positivo.");

        var saldoAntigo = _saldo;
        _saldo += valor;

        // Pós-condição
        if (_saldo != saldoAntigo + valor)
            throw new InvalidOperationException("Pós-condição violada em Depositar.");
    }
    /// <summary>
    /// CONTRATO:
    /// Pré-condição : valor > 0 E valor <= Saldo
    /// Pós-condição : Saldo == old(Saldo) - valor
    /// </summary>
    public virtual void Sacar(decimal valor)
    {
        // Pré-condição
        if (valor <= 0)
            throw new ArgumentOutOfRangeException(nameof(valor),
                "Saque deve ser positivo.");
        if (valor > _saldo)
            throw new InvalidOperationException("Saldo insuficiente.");

        var saldoAntigo = _saldo;
        _saldo -= valor;

        // Pós-condição
        if (_saldo != saldoAntigo - valor)
            throw new InvalidOperationException("Pós-condição violada em Sacar.");
    }
}