using MongoDB.Bson.Serialization.Attributes;

namespace WebApiMongoDB.Models
{
    public class Cadastro
    {
        [BsonId] 
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] 
        public string? Id { get; set; } 
        [BsonElement("Nome")] 
        public string Nome { get; set; } = String.Empty;

        [BsonElement("CPF")]
        public string CPF { get; set; } = String.Empty;

        [BsonElement("Email")]
        public string Email { get; set; } = String.Empty;

        [BsonElement("Endereço")]
        public string Endereco { get; set; } = String.Empty;

        [BsonElement("TelefoneCelular")]
        public string TelefoneCelular { get; set; } = String.Empty;

        [BsonElement("Status")]
        public bool Status { get; set; }
    }
}
