using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscadoDesktop
{
    public partial class FormModoPesquisa : Form
    {
        int idMercado;
        List<string> nomeProdutos;
        List<decimal> precoProdutos;
        List<string> setorProdutos;
        List<string> corredorProdutos;
        List<string> imagemProdutos;
        public FormModoPesquisa(int idMercado)
        {
            InitializeComponent();
            this.idMercado = idMercado;
        }

        private void FormModoPesquisa_Load(object sender, EventArgs e)
        {
            
        }

        private void tbBusca_TextChanged(object sender, EventArgs e)
        {
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            
            using (var context = new BuscadoEntities())
            {
                var query = from Mercado_has_Produto in context.Mercado_has_Produto
                            join Produto in context.Produto on Mercado_has_Produto.idProduto equals Produto.idProduto
                            where idMercado == Mercado_has_Produto.idMercado
                            where Produto.Nome.Contains(tbBusca.Text)
                            select Produto.Nome;
                nomeProdutos = query.ToList();
            }
            using (var context = new BuscadoEntities())
            {
                var query = from Mercado_has_Produto in context.Mercado_has_Produto
                            join Produto in context.Produto on Mercado_has_Produto.idProduto equals Produto.idProduto
                            where idMercado == Mercado_has_Produto.idMercado
                            where Produto.Nome.Contains(tbBusca.Text)
                            select Mercado_has_Produto.Preco;
                precoProdutos = query.ToList();
            }
            using (var context = new BuscadoEntities())
            {
                var query = from Mercado_has_Produto in context.Mercado_has_Produto
                            join Produto in context.Produto on Mercado_has_Produto.idProduto equals Produto.idProduto
                            where idMercado == Mercado_has_Produto.idMercado
                            where Produto.Nome.Contains(tbBusca.Text)
                            select Mercado_has_Produto.Corredor;
                corredorProdutos = query.ToList();
            }
            using (var context = new BuscadoEntities())
            {
                var query = from Mercado_has_Produto in context.Mercado_has_Produto
                            join Produto in context.Produto on Mercado_has_Produto.idProduto equals Produto.idProduto
                            where idMercado == Mercado_has_Produto.idMercado
                            where Produto.Nome.Contains(tbBusca.Text)
                            select Produto.Imagem;
                imagemProdutos = query.ToList();
            }
            populateItems();
        }
        private void populateItems()
        {
            flowLayoutPanel1.Controls.Clear();
            ListaProduto[] listaProdutos = new ListaProduto [nomeProdutos.Count]; //20 = qt de produtos
            for(int i = 0;i < listaProdutos.Length; i++) { 
                listaProdutos[i] = new ListaProduto();
                listaProdutos[i].NomeProduto = nomeProdutos[i]; //pegar do banco
                listaProdutos[i].Setor = "pendente";
                listaProdutos[i].Corredor = corredorProdutos[i];
                listaProdutos[i].Preco = precoProdutos[i].ToString();
                listaProdutos[i].Thumbnail = imagemProdutos[i];
                //if (flowLayoutPanel1.Controls.Count > 0)
                //{
                //    flowLayoutPanel1.Controls.Clear();
                //}
                //else
                
                    flowLayoutPanel1.Controls.Add(listaProdutos[i]);
                
            }
        }

    }
}
