namespace ArrayCircunferencias.Entidades
{
    //Esta es la clase Circunferencia "El plano o contenedor del objeto (Circunferencia)"
    public class Circunferencia:ICloneable//Interface
    {
        // Atributos de la clase:
        private const double _CantidadDeRadio = 1;
        private double _medidaDeRadio;
        private TipoDeBorde tipoDeBorde; 
        private ColorRelleno colorRelleno;

        public TipoDeBorde TipoDeBorde
        {
            get { return tipoDeBorde; }
            set { tipoDeBorde = value; }
        }
        

        public ColorRelleno ColorRelleno
        {  
            get {  return colorRelleno; }
            set { colorRelleno = value; }   
        }


        // Estos son los constructores:
        public Circunferencia() // Constructor por defecto. 
        {

        }
        public Circunferencia(double MedidaDeRadio, TipoDeBorde borde, ColorRelleno color) {
            _medidaDeRadio = MedidaDeRadio;
            TipoDeBorde = borde;
            ColorRelleno = color;
           
        }
        // Este es le metodo: accede a atributos
        public bool Validar()
        {
            return _medidaDeRadio>0;
        }
        public double GetRadio() => _medidaDeRadio;

        public void SetRadio(double MedidaDeRadio)
        {
            if (MedidaDeRadio > 0)
            {
                _medidaDeRadio = MedidaDeRadio;
            }
        }

        //Métodos de información
        public double GetPerimetro() => 2 * Math.PI * _medidaDeRadio;
        public double  GetSuperficie()=> Math.PI * Math.Pow(_medidaDeRadio, 2);

        public object Clone()
        {
            return this.MemberwiseClone();// Copia del objeto
        }
    }
}