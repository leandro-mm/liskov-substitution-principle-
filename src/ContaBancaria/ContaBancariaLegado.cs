using System.Diagnostics.Contracts;

public class ContaBancariaLegado
{
    private decimal _saldo;

    public decimal Saldo
    {
        get { Contract.Ensures(Contract.Result<decimal>() >= 0); return _saldo; }
    }

    public void Depositar(decimal valor)
    {
        Contract.Requires<ArgumentOutOfRangeException>(valor > 0);
        Contract.Ensures(_saldo == Contract.OldValue(_saldo) + valor);

        _saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        Contract.Requires<ArgumentOutOfRangeException>(valor > 0);
        Contract.Requires<InvalidOperationException>(valor <= _saldo);
        Contract.Ensures(_saldo == Contract.OldValue(_saldo) - valor);

        _saldo -= valor;
    }
    [ContractInvariantMethod]
    private void Invariantes()
    {
        Contract.Invariant(_saldo >= 0);
    }
}