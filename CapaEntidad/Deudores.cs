using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
	//Create table Deudores(
	//IdDeudor int primary key identity,
	//Nombre nvarchar(150),
	//Paterno nvarchar(50),
	//Materno nvarchar(50),
	//Prestamo decimal (6,2),
	//Telefono nvarchar(32),
	//Email nvarchar(200),
	//FechaPrestamo datetime,
	//DiaCobro smallint,
	//Meses int,
	//Intereses smallint,

    public class Deudores
    {
        public int IdDeudor { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public decimal Prestamo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public int DiaCobro { get; set; }
        public int Meses { get; set; }
        public int Intereses { get; set; }
        public decimal Pagos { get; set; }
    }
}
