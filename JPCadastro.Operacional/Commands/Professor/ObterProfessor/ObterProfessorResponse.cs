namespace JPCadastro.Operacional.Commands.Professor.ObterProfessor
{
    public class ObterProfessorResponse
    {
        public Guid Id { get; set; }    
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
