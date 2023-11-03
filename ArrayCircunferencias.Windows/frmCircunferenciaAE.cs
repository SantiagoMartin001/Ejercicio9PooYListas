using ArrayCircunferencias.Entidades;

namespace ArrayCircunferencias.Windows
{
    public partial class frmCircunferenciaAE : Form
    {
        public frmCircunferenciaAE()
        {
            InitializeComponent();
        }

        private Circunferencia Circunferencia;

        protected override void OnLoad(EventArgs e) ///Muestro la modificacion de radio.
        {
            base.OnLoad(e);
            CargarDatosComboColorRelleno();
            CrearBotonesOpcionBordes();
            if (Circunferencia != null)
            {
                txtRadio.Text = Circunferencia.GetRadio().ToString();
            }
        }

        private void CrearBotonesOpcionBordes()
        {
            var listaBordes = Enum.GetValues(typeof(TipoDeBorde))
                .Cast<TipoDeBorde>()
                .ToList();
            int x = 18;
            int y = 36;
            bool check = true;
            foreach (var itemBorde in listaBordes)
            {
                RadioButton rb = new RadioButton()
                {
                    Text = itemBorde.ToString(),
                    Location = new Point(x, y),
                    Checked = check
                };
                gbxBordes.Controls.Add(rb);
                y += 20;
                check = false;

            }
        }

        private void CargarDatosComboColorRelleno()// De la enueracion saca los colores y los asigna a lista
        {
            var listaColores = Enum.GetValues(typeof(ColorRelleno))
                .Cast<ColorRelleno>()
                .ToList();
            cboColores.DataSource = listaColores;
            cboColores.SelectedIndex = 0;
        }

        public Circunferencia GetCircunferencia()
        {
            return Circunferencia;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (Circunferencia == null)
                {
                    Circunferencia = new Circunferencia();
                }
                Circunferencia.SetRadio(int.Parse(txtRadio.Text));// edicicion del radio
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtRadio.Text, out int radio))
            {
                valido = false;
                errorProvider1.SetError(txtRadio, "Número mal ingresados");
            }
            else if (radio <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtRadio, "El número debe ser mayor que cero");
            }
            return valido;
        }

        private void frmCircunferenciaAE_Load(object sender, EventArgs e)
        {

        }

        private void txtRadio_TextChanged(object sender, EventArgs e)
        {

        }

        public void SetCircunferencia(Circunferencia? circunferencia)
        {
            this.Circunferencia = circunferencia;/// Muestro la nueva circunferencia
        }
    }
}
