using ArrayCircunferencias.Datos;
using ArrayCircunferencias.Entidades;

namespace ArrayCircunferencias.Windows
{
    public partial class frmPrincipal : Form
    {
        private RepositorioDeCircunferencias repo;
        private List<Circunferencia> lista;
        int intValor;
        bool filterOn = false;//Si el filtro esta puesto

        public frmPrincipal()
        {
            InitializeComponent();
            repo = new RepositorioDeCircunferencias();
            ActualizarCarntidadregistros();
        }

        private void ActualizarCarntidadregistros()
        {
            if (intValor > 0)
            {
                txtCantidad.Text = repo.GetCantidad(intValor).ToString();
            }
            else
            {
                txtCantidad.Text = repo.GetCantidad().ToString();
            }

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmCircunferenciaAE frm = new frmCircunferenciaAE() { Text = "Agregar circunferencia." };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            Circunferencia circunferencia = frm.GetCircunferencia();
            if (!repo.Existe(circunferencia))
            {
                repo.Agregar(circunferencia);
                txtCantidad.Text = repo.GetCantidad().ToString();

                DataGridViewRow r = ConstruirFila();
                SetearFilas(r, circunferencia);
                AgregarFilar(r);

                MessageBox.Show("Registro agregado", "Mensaje",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Registro existente", "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void AgregarFilar(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFilas(DataGridViewRow r, Circunferencia circunferencia)
        {
            r.Cells[ColRadio.Index].Value = circunferencia.GetRadio();
            r.Cells[colBorde.Index].Value = circunferencia.TipoDeBorde;
            r.Cells[colRelleno.Index].Value = circunferencia.ColorRelleno;
            r.Cells[ColSuperficie.Index].Value = circunferencia.GetSuperficie();
            r.Cells[ColPerimetro.Index].Value = circunferencia.GetPerimetro();

            r.Tag = circunferencia;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();// Crea la fila en blanco
            r.CreateCells(dgvDatos);// Creo la celdas
            return r;//retorno la fila
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) // SelectedRows(Es un selector que va sumando filas) Count== Cuentala filas
            {
                return;// Si tiene 0 filas seleccionadas no hace nada
            }
            DialogResult dr = MessageBox.Show("¿Desea eliminar la fila?",
             "Confirmar baja",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question,
             MessageBoxDefaultButton.Button2);// Por defecto esta en el 2 (NO)
            if (dr == DialogResult.No)// Si dice que No
            {
                return;
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];
            Circunferencia Circunferencia = filaSeleccionada.Tag as Circunferencia;
            repo.Borrar(Circunferencia);
            txtCantidad.Text = repo.GetCantidad().ToString();
            QuitarFila(filaSeleccionada);/// Borra las filas guardadas
            MessageBox.Show("Registro borrado", "Mensaje",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);


        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) // SelectedRows(Es un selector que va sumando filas) Count== Cuentala filas
            {
                return;// Si tiene 0 filas seleccionadas no hace nada
            }
            var filaSeleccionada = dgvDatos.SelectedRows[0];// Selecciono fila para editar.

            Circunferencia circunferencia = (Circunferencia)filaSeleccionada.Tag;// Realizo un "Casteo" el tag, lo convierto en circunferencia
            Circunferencia circunferenciaCopia = (Circunferencia)circunferencia.Clone();
            double radioAnterior = circunferencia.GetRadio();

            frmCircunferenciaAE frm = new frmCircunferenciaAE() { Text = "Editar circunferencia" };// muestro los datos en el formulario
            frm.SetCircunferencia(circunferencia);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;// Si cancela no hace nada
            }
            circunferencia = frm.GetCircunferencia();// trae la nueva circunferencia
            if (!repo.Existe(circunferencia))
            {
                repo.Editar(radioAnterior, circunferencia);
                SetearFilas(filaSeleccionada, circunferencia);
                MessageBox.Show("Registro editado", "Mensaje",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                SetearFilas(filaSeleccionada, circunferenciaCopia);
                MessageBox.Show("Registro existente", "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {
        }

        private void tsbFiltro_Click(object sender, EventArgs e)
        {
            //Muestra al usuario un mensaje "ImputBox"
            if (!filterOn)
            {
                var stringValor = Microsoft.VisualBasic.Interaction.InputBox(
                      "Ingrese el valor del radio a filrar",// Mensaje
                      "Filtrar por Mayor o Igual",// Titulo
                      "0", 400, 400); //Valor por defecto "0" y posicion en pantalla 
                                      //Determinacion si puedo convertir en string, pone el valor en intValor
                if (!int.TryParse(stringValor, out intValor))
                {
                    return;
                }
                if (intValor <= 0)
                {
                    return;// Si es menor o igual a cero se va
                }
                lista = repo.Filtrar(intValor);
                tsbFiltro.BackColor = Color.Orange;// Si filtro cambia color
                filterOn = true;
                MostrarDatosEnGrilla();
                ActualizarCarntidadregistros();
            }
            else
            {
                MessageBox.Show("Filtro aplicado!!\n Debe actualizar grilla",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            intValor = 0;
            filterOn = false;
            tsbFiltro.BackColor = SystemColors.Control;
            lista = repo.GetLista();
            MostrarDatosEnGrilla();
            ActualizarCarntidadregistros();

        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (repo.GetCantidad() > 0)
            {
                lista = repo.GetLista();
                MostrarDatosEnGrilla();
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();// Limpio la grilla.
            foreach (var circunferencia in lista) /// Recorro la lista
            {
                DataGridViewRow r = ConstruirFila();// Creo fila
                SetearFilas(r, circunferencia);//Guardo la fila
                AgregarFilar(r);//Agrega la fila a la grilla.
            }

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ascendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repo.OrdenarAsc();
            MostrarDatosEnGrilla();
            ActualizarCarntidadregistros();
        }

        private void descendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista = repo.OrdenarDesc();
            MostrarDatosEnGrilla();
            ActualizarCarntidadregistros();
        }
    }
}
