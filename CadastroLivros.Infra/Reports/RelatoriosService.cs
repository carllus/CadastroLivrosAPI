using CadastroLivros.Domain.Entities;
using CadastroLivros.Infra.Interfaces;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroLivros.Infra.Reports
{
    public class RelatorioLivrosService : IRelatorioLivrosService
    {
        public byte[] GerarRelatorioLivros(List<Livro> livros)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Content().Column(col =>
                    {
                        col.Item().PaddingBottom(10).Text("Relatório de Livros").FontSize(20).Bold().AlignCenter();

                        foreach (var livro in livros)
                        {
                            col.Item().Text($"📘 {livro.Titulo}").FontSize(14).Bold();
                            col.Item().Text($"Editora: {livro.Editora}");
                            col.Item().Text($"Edição: {livro.Edicao}");
                            col.Item().Text($"Ano Publicação: {livro.AnoPublicacao}");

                            var autores = livro.Autores.Select(al => al.Autor.Nome).ToList();
                            col.Item().PaddingBottom(0).Text($"Autores: {string.Join(", ", autores)}");

                            var assuntos = livro.Assuntos.Select(al => al.Assunto.Descricao).ToList();
                            col.Item().PaddingBottom(0).Text($"Assuntos: {string.Join(", ", assuntos)}");

                            var precos = livro.Precos.Select(al => al.TipoCompra+" - R$"+al.Valor).ToList();
                            col.Item().PaddingBottom(10).Text($"Precos: {string.Join(", ", precos)}");
                        }
                    });
                });
            });

            return document.GeneratePdf();
        }
    }
}
