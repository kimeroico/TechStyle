namespace TechStyle.Dominio.Modelo
{
    public class DetalheProduto : IEntity
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tamanho { get; set; }
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }

        public void Cadastrar(int idProduto, string material, string cor, string marca, string modelo, string tamanho)
        {            
            Material = material;
            Cor = cor;
            Marca = marca;
            Modelo = modelo;
            Tamanho = tamanho;
            IdProduto = idProduto;
        }

        public void Alterar(string material, string cor, string marca, string modelo, string tamanho)
        {
            Material = string.IsNullOrEmpty(material.Trim()) ? Material : material;
            Cor = string.IsNullOrEmpty(cor.Trim()) ? Cor : cor;
            Marca = string.IsNullOrEmpty(marca.Trim()) ? Marca : marca;
            Modelo = string.IsNullOrEmpty(modelo.Trim()) ? Modelo : modelo;
            Tamanho = string.IsNullOrEmpty(tamanho.Trim()) ? Tamanho : tamanho;
        }

        public override string ToString()
        {
            return $"{Material} | {Cor} | {Marca} | {Modelo} | {Tamanho}";
        }

    }
}
