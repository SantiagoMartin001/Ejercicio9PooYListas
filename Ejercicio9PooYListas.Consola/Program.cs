using ArrayCircunferencias.Entidades;

namespace Ejercicio9PooYListas.Consola
{
    internal class Program
    {

//Desarrolle un programa que sea capaz de almacenar y recuperar la información de las
//distintas circunferencias que se ingresen.



        static void Main(string[] args)
        {
            // Defino el tipo Cuadrado
            Circunferencia[] arrayCircunferencias= new Circunferencia[3];
            for (int i = 0; i < arrayCircunferencias.Length; i++) 
            {
                do
                {
                    Console.Write($"Ingrese la medida del {i+1}° radio: ");
                    var radio = double.Parse(Console.ReadLine());
                    Circunferencia circunferenciaCreada = new Circunferencia(radio);
                    
                    if (circunferenciaCreada.Validar())
                    {
                        arrayCircunferencias[i] = circunferenciaCreada;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Radio fuera de parametro.");
                    }
                } while (true);
                
            }
            Console.WriteLine("Array completo");
            Console.Clear();
            foreach (var item in arrayCircunferencias)
            {
                Console.WriteLine($"Circunferencia de radio{item.GetRadio()} - Sup: {item.GetSuperficie()} - Perimetro: {item.GetPerimetro()}");
            }

            // MODIFICACION DE RADIO INGRESADOS
            
            Console.Write("Ingrese el nro de radio a modificar:");
            //Capturo la posición a modificr.
            var index=int.Parse(Console.ReadLine());
            // Accedo a la circunferencia que voy a modificar.
            var circunferenciaEditar= arrayCircunferencias[index];
            //Ingreso la medida del nuevo radio.
            Console.Write("Ingrese nueva medida: ");
            var nuevaMedidad=double.Parse(Console.ReadLine());
            // Asigno la medidada a la cricunferencia.
            circunferenciaEditar.SetRadio(nuevaMedidad);

            Console.Clear();
            // Vuelvo a mostrar los datos con la modificación incorporada.
            foreach (var item in arrayCircunferencias)
            {
                Console.WriteLine($"Circunferencia de radio{item.GetRadio()} - Sup: {item.GetSuperficie()} - Perimetro: {item.GetPerimetro()}");
            }
        }
    }
}