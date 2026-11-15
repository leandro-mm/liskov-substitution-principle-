// ---------- Subclasse que VIOLA o contrato (para contraste) ----------
public class ContaSemSaque : ContaBancaria
{
    public ContaSemSaque(decimal saldoInicial) : base(saldoInicial) { }

    public override void Sacar(decimal valor)
    {
        // ❌ Pré-condição FORTALECIDA: antes bastava valor <= Saldo;
        // agora exige também que a conta permita saque.
        // Isso quebra o LSP: um cliente que usa ContaBancaria espera poder sacar.
        throw new NotSupportedException("Esta conta não permite saques.");
    }
}