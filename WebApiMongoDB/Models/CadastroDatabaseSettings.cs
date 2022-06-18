namespace WebApiMongoDB.Models
{
    public class CadastroDatabaseSettings 
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string CadastroCollectionName { get; set; } = null;
    }
}
