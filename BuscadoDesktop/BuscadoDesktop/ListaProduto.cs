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
    public partial class ListaProduto : UserControl
    {
        public ListaProduto()
        {
            InitializeComponent();
        }
        #region atributos
        private string _nomeProduto;
        private string _setor;
        private string _corredor;
        private string _preco;
        private string _thumbnail;


        [Category("Custom Props")]
        public string NomeProduto
        {
            get { return _nomeProduto; }
            set { _nomeProduto = value; labelTitulo.Text = value;  }
        }

        [Category("Custom Props")]
        public string Setor 
        {
            get { return _setor; }
            set { _setor = value; labelSetor.Text = value; }
        }

        [Category("Custom Props")]
        public string Corredor
        {
            get { return _corredor; }
            set { _corredor = value; labelCorredor.Text = value; }
        }

        [Category("Custom Props")]
        public string Preco
        {
            get { return _preco; }
            set { _preco = value; labelPreco.Text = value; }
        }

        [Category("Custom Props")]
        public string Thumbnail
        {
            get { return _thumbnail; }
            set { _thumbnail = value; pictureBox1.ImageLocation = value; }
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
