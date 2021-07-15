using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStyle.Dominio.Modelo
{
    class DetalheProduto
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tamanho { get; set; }

        public void Cadastrar(int id, string material, string cor, string marca, string modelo, string tamanho)
        {
            Id = id;
            Material = material;
            Cor = cor;
            Marca = marca;
            Modelo = modelo;
            Tamanho = tamanho;
        }

        public void Alterar(string material, string cor, string marca, string modelo, string tamanho)
        {
            Material = string.IsNullOrEmpty(material.Trim()) ? Material : material;
            Cor = string.IsNullOrEmpty(cor.Trim()) ? Cor : cor;
            Marca = string.IsNullOrEmpty(marca.Trim()) ? Marca : marca;
            Modelo = string.IsNullOrEmpty(modelo.Trim()) ? Modelo : modelo;
            Tamanho = string.IsNullOrEmpty(tamanho.Trim()) ? Tamanho : tamanho;
        }        

    }
}
