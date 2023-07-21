namespace SistemaDeEstacionamento
{
    public partial class Form1 : Form
    {
        List<string> Veiculos = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        void estacionarVeiculo()
        {
            if(Veiculos.Count >= 5)
            {
                MessageBox.Show("O estacionamento está lotado!!!");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Digite algo no campo!!");
                return;
            }
  
            string veiculo = textBox1.Text;
            string veiculoTratado = veiculo.ToUpper();
            if (Veiculos.Contains(veiculoTratado))
            {
                MessageBox.Show("Este veiculo já está estacionado!!");
                return;
            }
            Veiculos.Add(veiculoTratado);

            listEstacionar.Items.Clear();

            for (int i = 0; i < Veiculos.Count; i++)
            {
                listEstacionar.Items.Add($"[VAGAS {i}] " + Veiculos[i]);
            }

        }

        void atualizarVeiculo()
        {
            int quantidadeVeiculos = Veiculos.Count();
            lblNumero.Text = quantidadeVeiculos.ToString();
        }

        void retirarVeiculo()
        {
            if (Veiculos.Count==0)
            {
                MessageBox.Show("Não tem veiculo estacionado!!");
                return;
            }
            string placa = textBox1.Text;
            if(placa == "")
            {
                MessageBox.Show("Digite algo no campo!!!");
                return;
            }
            string placaTratada = placa.ToUpper();

            for (int i = 0; i < Veiculos.Count; i++)
            {
                if (Veiculos[i]==placaTratada)
                {
                    Veiculos.RemoveAt(i);
                    listEstacionar.Items.RemoveAt(i);
                }
                else
                {
                    MessageBox.Show("Não existe veiculo com essa placa!!");
                    return;
                }
            }
        }

        void limpaCampos()
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        //txt Digitar Placa
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //txt Digitar Placa

        private void btnEstacionar_Click(object sender, EventArgs e)
        {
            estacionarVeiculo();
            atualizarVeiculo();
            limpaCampos();
            btnEstacionar.BackColor = Color.LightBlue;
            btnEstacionar.ForeColor = Color.Blue;
            btnRetirar.BackColor = Color.Gainsboro;
            btnRetirar.ForeColor = Color.Black;
            btnFecharPrograma.BackColor = Color.Gainsboro;
            btnFecharPrograma.ForeColor= Color.Black;
        }

        private void listEstacionar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            retirarVeiculo();
            atualizarVeiculo();
            limpaCampos();

            btnRetirar.BackColor = Color.LightBlue;
            btnRetirar.ForeColor = Color.Blue;
            btnEstacionar.BackColor = Color.Gainsboro;
            btnEstacionar.ForeColor = Color.Black;
            btnFecharPrograma.BackColor = Color.Gainsboro;
            btnFecharPrograma.ForeColor = Color.Black;
        }

        private void btnFecharPrograma_Click(object sender, EventArgs e)
        {
            Veiculos.Clear();
            listEstacionar.Clear();
            atualizarVeiculo();


            btnFecharPrograma.BackColor = Color.LightBlue;
            btnFecharPrograma.ForeColor = Color.Blue;
            btnRetirar.BackColor = Color.Gainsboro;
            btnRetirar.ForeColor = Color.Black;
            btnEstacionar.BackColor = Color.Gainsboro;
            btnEstacionar.ForeColor = Color.Black;

            if (Veiculos.Count==0)
            {
                MessageBox.Show("O estacionamento está vazio!!");
                return;
            }
        }
    }
}