using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Restaurant
{
    public class FacturaBL
    {
        Contexto _contexto;

        public BindingList<Factura> ListaFacturas { get; set; }

        public FacturaBL()
        {
            _contexto = new Contexto();
        }

        public BindingList<Factura> ObtenerFacturas()
        {
            _contexto.Facturas.Include("FacturaDetalle").Load();
            ListaFacturas = _contexto.Facturas.Local.ToBindingList();

            return ListaFacturas;
        }

        public void AgregarFactura()
        {
            var nuevaFactura = new Factura();
            _contexto.Facturas.Add(nuevaFactura);
        }

        public void AgregarFacturaDetalle(Factura factura)
        {
            if (factura != null)
            {
                var nuevoDetalle = new FacturaDetalle();
                factura.FacturaDetalle.Add(nuevoDetalle);
            }
        }

        public void RemoverFacturaDetalle(Factura factura, FacturaDetalle facturaDetalle)
        {
            if (factura != null && facturaDetalle != null)
            {
                factura.FacturaDetalle.Remove(facturaDetalle);
            }
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarFactura(Factura factura)
        {
            var resultado = Validar(factura);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            CalcularExistencia(factura);

            _contexto.SaveChanges();
            resultado.Exitoso = true;
            return resultado;
        }

        public void CalcularFactura(Factura factura)
        {
            if (factura !=null)
            {
                double subtotal = 0;
                foreach (var detalle in factura . FacturaDetalle )
                {
                    var producto = _contexto.Productos.Find(detalle.ProductoId);
                    if(producto != null)
                    {
                        detalle.Precio = producto.Precio;
                        detalle.Total = detalle.Cantidad * producto.Precio;

                        subtotal += detalle.Total; 
                    }
                }
                factura.Subtotal = subtotal;
                factura.Impuesto = subtotal * 0.15;
                factura.Total = subtotal + factura.Impuesto;
            }
        }

        private void CalcularExistencia(Factura factura)
        {
            foreach (var detalle in factura.FacturaDetalle)
            {
                var producto = _contexto.Productos.Find(detalle.ProductoId);
                if (producto != null)
                {
                    if (factura.Activo == true)
                    {
                        producto.Existencia = producto.Existencia - detalle.Cantidad;
                    }
                    else
                    {
                        producto.Existencia = producto.Existencia + detalle.Cantidad;
                    }
                }
            }
        }

        private Resultado Validar(Factura factura)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            return resultado;
        

        }
    }

    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }  //Nuevo tipo que nos da la hora y fecha de la factura
        public int ClienteId { get; set; } //Seleccionaremos un cliente del combobox
        public Cliente Cliente { get; set; }
        public BindingList<FacturaDetalle> FacturaDetalle { get; set; }  //Relacionando factura detalle con la factura , dandonos una lista
        public double Subtotal { get; set; }
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        public Factura()
        {
            Fecha = DateTime.Now;
            FacturaDetalle = new BindingList<FacturaDetalle>();  //Inicializamos la factura detalle
            Activo = true;
        }
    }

    public class FacturaDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

        public FacturaDetalle() //Constructor
        {
            Cantidad = 1;  //Inicializamos la cantidad en 1
        }
    }
}
