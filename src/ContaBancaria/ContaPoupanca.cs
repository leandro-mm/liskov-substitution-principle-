// ---------- Subclasse que RESPEITA o contrato ----------
public class ContaPoupanca : ContaBancaria
{
    public decimal TaxaRendimento { get; }

    public ContaPoupanca(decimal saldoInicial, decimal taxa)
        : base(saldoInicial)
    {
        if (taxa < 0) throw new ArgumentOutOfRangeException(nameof(taxa));
        TaxaRendimento = taxa;
    }

    public void Render()
    {
        // Não sobrescreve Depositar/Sacar => herda o contrato intacto
        _saldo += _saldo * TaxaRendimento;
    }
}