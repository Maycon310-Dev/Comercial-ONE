using Comercial_ONE.BLL.Services;
using System.Windows.Forms;
using System;

namespace Comercial_ONE
{
    public partial class FrmLogin : Form
    {
        private AuthService _authService;

        public FrmLogin()
        {
            InitializeComponent();
            _authService = new AuthService();
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha corretamente os campos de usuário e senha!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool sucesso = _authService.Autenticar(login, senha);

            if (sucesso)
            {
                MessageBox.Show($"Bem-vindo, {AuthService.UsuarioLogado.Nome}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Clear();
                txtSenha.Focus();
            }
        }
    }
}