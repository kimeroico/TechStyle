using System;
using TechStyle.Dominio.Repositorio;

namespace TechStyle.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SegmentoRepositorio repoSeg = new SegmentoRepositorio();
            repoSeg.Incluir("Masculino", "Social");

            Console.WriteLine("Vamos adicionar um produto!");
            Console.Write("Valor de Mercado: ");
            var valor = decimal.Parse(Console.ReadLine());
            Console.Write("Nome do Produto: ");
            var nome = Console.ReadLine();
            Console.Write("SKU: ");
            var sku = Console.ReadLine();
            Console.Write("Segmento do Produto: ");
            var segmento = repoSeg.SelecionarPorId(int.Parse(Console.ReadLine()));
            Console.Write("Material: ");
            var material = Console.ReadLine();
            Console.Write("Cor: ");
            var cor = Console.ReadLine();
            Console.Write("Marca: ");
            var marca = Console.ReadLine();
            Console.Write("Modelo: ");
            var modelo = Console.ReadLine();
            Console.Write("Tamanho: ");
            var tamanho = Console.ReadLine();

            ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
            produtoRepositorio.Incluir(valor, nome, sku, segmento, material, cor, marca, modelo, tamanho);

            Console.WriteLine("Você deseja visualizar os produtos? s/n");
            var condicao = Console.ReadLine();
            if (condicao == "s")
            {
                var resultado = produtoRepositorio.SelecionarTudo();
                foreach (var i in resultado)
                {
                    Console.WriteLine($"{i.ValorVenda} | {i.Nome} | {i.SKU} | {i.Segmento} | {i.DetalheProduto} | {i.Ativo}");
                }
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.WriteLine("Selecione o Produto que será alterado:");
            var skuSelecionado = Console.ReadLine();

            Console.WriteLine("Novos dados!");
            Console.Write("Valor de Mercado: ");
            var valorNovo = decimal.Parse(Console.ReadLine());
            Console.Write("Nome do Produto: ");
            var nomeNovo = Console.ReadLine();
            Console.Write("Segmento do Produto: ");
            var segmentoNovo = repoSeg.SelecionarPorId(int.Parse(Console.ReadLine()));
            Console.Write("Material: ");
            var materialNovo = Console.ReadLine();
            Console.Write("Cor: ");
            var corNovo = Console.ReadLine();
            Console.Write("Marca: ");
            var marcaNovo = Console.ReadLine();
            Console.Write("Modelo: ");
            var modeloNovo = Console.ReadLine();
            Console.Write("Tamanho: ");
            var tamanhoNovo = Console.ReadLine();

            produtoRepositorio.AtualizarProduto(skuSelecionado, valorNovo, nomeNovo, segmentoNovo, 
                materialNovo, corNovo, marcaNovo, modeloNovo, tamanhoNovo);

            Console.WriteLine("Você deseja visualizar os produtos? s/n");
            condicao = Console.ReadLine();
            if (condicao == "s")
            {
                var resultado = produtoRepositorio.SelecionarTudo();
                foreach (var i in resultado)
                {
                    Console.WriteLine($"{i.ValorVenda} | {i.Nome} | {i.SKU} | {i.Segmento} | {i.DetalheProduto} | {i.Ativo}");
                }
            }

        }

        public void TesteSegmento()
        {
            /*
             1 - para cadastrar categoria/sub
             2 - para cadastrar produtos
             3 - para vender produto
             */


            // digitou 1

            //Console.WriteLine("Informe a categoria");
            //var categoria = Console.ReadLine();

            //Console.WriteLine("Informe a subcategoria");
            //var subcategoria = Console.ReadLine();

            //SegmentoRepositorio repoSeg = new SegmentoRepositorio();

            ////repoSeg.Incluir(categoria, subcategoria);
            //repoSeg.Incluir("Masculino", "Social");
            //repoSeg.Incluir("Infantil", "fantasias");
            //repoSeg.Incluir("Feminino", "Social");
            //repoSeg.Incluir("Feminino", "Saias");

            //Console.WriteLine("Você deseja consultar o codigo da categoria/subcategoria ? s/n");
            //var resposta = Console.ReadLine();
            //if (resposta == "s")
            //{
            //    var resultadoConsulta = repoSeg.SelecionarTudo();
            //    foreach (var item in resultadoConsulta)
            //    {
            //        Console.WriteLine($"{item.Id} - {item.Categoria} / {item.Subcategoria}");
            //    }
            //}

            //Console.WriteLine("Informe o codigo desejado");
            //var idSeg = int.Parse(Console.ReadLine());

            //var segmento = repoSeg.SelecionarPorId(idSeg);

            //Console.WriteLine(segmento.Ativo);
            //Console.WriteLine("------------------------");
            //var statusAlterado = repoSeg.AlterarStatus(idSeg);
            //Console.WriteLine(segmento.Ativo);

            //var lstSeg = repoSeg.SelecionarTudo();

            // ---------------------------------------------

            // digitou 2


            //Segmento seg = new Segmento();
            //seg.Cadastrar(2, "Calcados", "tenis");

            //Console.WriteLine("Você deseja consultar o codigo da categoria/subcategoria ? s/n");
            //var resposta = Console.ReadLine();
            //if (resposta == "s")
            //{
            //    var resultadoConsulta = repoSeg.SelecionarTudo();
            //    foreach (var item in resultadoConsulta)
            //    {
            //        Console.WriteLine($"{item.Id} - {item.Categoria} / {item.Subcategoria}");
            //    }
            //}

            //Console.WriteLine("Informe o codigo desejado");
            //var idSeg = int.Parse(Console.ReadLine());

            //var segmento = repoSeg.SelecionarPorId(idSeg);

            //Console.WriteLine($"{segmento.Id} - {segmento.Categoria} / {segmento.Subcategoria}");

            //Console.WriteLine("------------------------------------------------------------------------");

            //Console.WriteLine("Vc deseja alterar algum produto? s/n");
            //var resposta2 = Console.ReadLine();
            //if (resposta2 == "s")
            //{
            //    var resultadoConsulta = repoSeg.SelecionarTudo();
            //    foreach (var item in resultadoConsulta)
            //    {
            //        Console.WriteLine($"{item.Id} - {item.Categoria} / {item.Subcategoria}");
            //    }
            //}
            //Console.WriteLine("Informe o codigo desejado");
            //var idSeg2 = int.Parse(Console.ReadLine());

            //Console.WriteLine("Adicione a nova categoria:");
            //var novaCategoria = Console.ReadLine();

            //Console.WriteLine("Adicione a nova subcategoria");
            //var novaSubcategoria = Console.ReadLine();


            //var segmentoAlterado = repoSeg.Alterar(idSeg2, novaCategoria, novaSubcategoria);

            //var segmento2 = repoSeg.SelecionarPorId(idSeg2);

            //Console.WriteLine($"{segmento2.Id} - {segmento2.Categoria} / {segmento2.Subcategoria}");



            //Produto prod = new Produto();
            //prod.Cadastrar(10, "Kit de meias", "a1s5edf6a4", seg);
        }
    }
}
