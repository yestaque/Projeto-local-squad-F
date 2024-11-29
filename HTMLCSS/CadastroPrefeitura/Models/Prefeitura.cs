using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CadastroPrefeitura.Models;
public class Prefeitura
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty; // Necessário para MongoDB
    public string CNPJ { get; set; } = string.Empty;
    public string CNES { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string NomePrefeitura { get; set; } = string.Empty;
    public string NumeroConvenio { get; set; } = string.Empty;
    public string ResponsavelPrefeitura { get; set; } = string.Empty;
    public string TelefoneResponsavel { get; set; } = string.Empty;
    public string EmailResponsavel { get; set; } = string.Empty;
}

