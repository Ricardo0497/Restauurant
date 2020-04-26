using BL.Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class FormReporteProducto : Form
    {

        public FormReporteProducto()
        {
            InitializeComponent();
            
                      /*     var _productoBL = new ProductosBL();
                            var bindingSource = new BindingSource();
                            bindingSource.DataSource = _productoBL.ObtenerProductos();


                            var reporte = new CrystalReportProducto();
                            reporte.SetDataSource(bindingSource);


                            crystalReportViewer1.ReportSource = reporte;
                            crystalReportViewer1.RefreshReport();*/
                          

        var _productosBL = new ProductosBL();
            var _categoriasBL = new CategoriasBL();
            var _tiemposBL = new TiemposBL();

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = _productosBL.ObtenerProductos();

            var bindingSource2 = new BindingSource();
            bindingSource2.DataSource = _categoriasBL.ObtenerCategorias();

            var bindingSource3 = new BindingSource();
            bindingSource3.DataSource = _tiemposBL.ObtenerTiempo();


            var reporte = new CrystalReportProducto  ();
            reporte.Database.Tables["Producto"].SetDataSource(bindingSource1);
            reporte.Database.Tables["Categoria"].SetDataSource(bindingSource2);
            reporte.Database.Tables["Tiempo"].SetDataSource(bindingSource3);  

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();

        }
    }
}
