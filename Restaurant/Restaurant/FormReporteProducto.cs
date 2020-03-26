﻿using BL.Restaurant;
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

            var _productoBL = new ProductosBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _productoBL.ObtenerProductos();


            var reporte = new CrystalReportProducto();
            reporte.SetDataSource(bindingSource);


            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();



        }
    }
}
