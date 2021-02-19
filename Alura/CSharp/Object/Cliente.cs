namespace Object
{
    public class Cliente
    {
        public Cliente()
        {
        }

        public Cliente(long id, string firstName, string lastName, string cpf)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }

        public override bool Equals(object obj)
        {
            Cliente novoCliente = obj as Cliente;
            return novoCliente != null;
        }
    }
}