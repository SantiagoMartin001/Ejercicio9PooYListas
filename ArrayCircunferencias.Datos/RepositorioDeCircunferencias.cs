using ArrayCircunferencias.Entidades;

namespace ArrayCircunferencias.Datos
{
    public class RepositorioDeCircunferencias
    {
        // Archivo secuencia para guardar los radios, defino donde lo guardo 
        //La clase Enviroment se fija en que directorio esta corriendo la aplica y concatena "Circunferencia txt"
        private readonly String _archivo = Environment.CurrentDirectory + "\\Circunferencia.txt";
        private readonly String _archivoCopia = Environment.CurrentDirectory + "\\Circunferencia.bak";

        private List<Circunferencia> listaCircunferencias;

        public RepositorioDeCircunferencias()
        {
            listaCircunferencias = new List<Circunferencia>();
            LeerDatos();
        }
        public List<Circunferencia> GetLista()
        {
            return listaCircunferencias;
        }
        // Metodo para leer.
        private void LeerDatos()
        {
            if (File.Exists(_archivo))///Protejo el código en caso de que el archivo no exista
            {
                var lector = new StreamReader(_archivo);
                while (!lector.EndOfStream)// Mientras no sea fi  de archivo, va a leer.
                {
                    string lineaLeida = lector.ReadLine();// Leo un linea
                    Circunferencia circunferencia = ConstruirCircunferencia(lineaLeida);
                    listaCircunferencias.Add(circunferencia);
                }
                lector.Close();
            }
        }
        public void Editar(double radioAnterior, Circunferencia circunferenciaEditar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)// Mientras no sea el fin del lector
                    {
                        string lineaLeida = lector.ReadLine();
                        Circunferencia circunferencia = ConstruirCircunferencia(lineaLeida);
                        if (radioAnterior != circunferencia.GetRadio())
                        {
                            escritor.WriteLine(lineaLeida);
                        }
                        else
                        {
                            lineaLeida = ConstruirLinea(circunferenciaEditar);
                            escritor.WriteLine(lineaLeida);
                        }
                    }
                }
            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
        }
        private Circunferencia ConstruirCircunferencia(string? lineaLeida)
        {
            var campos = lineaLeida.Split('|');// alt124 alt39''Es útil en el caso de tener que dividir la línea. Ej Rectangulo, que necesita dos valores
            int radio = int.Parse(campos[0]);// Parceo y lo convierto en entero
            ColorRelleno color = (ColorRelleno)int.Parse(campos[2]);
            TipoDeBorde borde = (TipoDeBorde)int.Parse(campos[1]);
           
            Circunferencia c = new Circunferencia(radio, borde, color);
            return c;//Retorname la circunferencia
        }

        // Metodo para agregar una circunferencia.

        public void Agregar(Circunferencia circunferencia)
        {
            //Creo una estructura Using par liberar los recursos- Mas facil de manejar.
            //Creacion del archivo secuencial (Streamwriter).
            using (var escritor = new StreamWriter(_archivo, true))
            {
                // Creo la línea
                string lineaEscribir = ConstruirLinea(circunferencia);
                // Escribe la línea.
                escritor.WriteLine(lineaEscribir);
            }
            // El escritor lo cierra el using

            listaCircunferencias.Add(circunferencia);

        }

        private string ConstruirLinea(Circunferencia circunferencia)
        {
            // tengo un  entero y retorno string
            return $"{circunferencia.GetRadio()}";
        }
        /// <summary>
        /// Método para informar la cantidad de datos del repo
        /// </summary>
        /// <returns></returns>
        public int GetCantidad(int valorFiltro = 0)
        {
            if (valorFiltro > 0)
            {
                return listaCircunferencias
                    .Count(c => c.GetRadio() >= valorFiltro); // Cuenta los valores que tengan la circunferencia mayor o  igual que el filtro
            }
            return listaCircunferencias.Count;
        }
        public void Borrar(Circunferencia circunferenciaBorrar)
        {
            using (var lector = new StreamReader(_archivo))
            {
                using (var escritor = new StreamWriter(_archivoCopia))
                {
                    while (!lector.EndOfStream)
                    {
                        string lineaLeida = lector.ReadLine();
                        Circunferencia circunferenciaLeida = ConstruirCircunferencia(lineaLeida);
                        if (circunferenciaBorrar.GetRadio() != circunferenciaLeida.GetRadio())// Si no son iguales
                        {
                            escritor.WriteLine(lineaLeida);

                        }
                    }
                }

            }
            File.Delete(_archivo);
            File.Move(_archivoCopia, _archivo);
            listaCircunferencias.Remove(circunferenciaBorrar);// Saca de la lista

        }

        public List<Circunferencia> Filtrar(int intValor)
        {
            return listaCircunferencias //Retornar de la lista de circunferencias
                .Where(c => c.GetRadio() >= intValor) // Para los lados mayores o iguales que int valor
                .ToList();// Los lista
        }

        public List<Circunferencia> OrdenarAsc()
        {
            return listaCircunferencias.OrderBy(c => c.GetRadio()).ToList();
        }

        public List<Circunferencia> OrdenarDesc()
        {
            return listaCircunferencias.OrderByDescending(c => c.GetRadio()).ToList();
        }

        public bool Existe(Circunferencia circunferencia)
        {
            listaCircunferencias.Clear();
            LeerDatos();


            foreach (var itemCircunferencia in listaCircunferencias)
            {
                if (itemCircunferencia.GetRadio() == circunferencia.GetRadio())
                {
                    return true;
                }
            }
            return false;
        }
    }
}