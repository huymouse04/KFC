using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFC
{
    public partial class FormReport : Form
    {
        public enum LoaiBaoCao
        {
            NhanVien,
            LuongNhanVien,
        }

        private LoaiBaoCao loaiBaoCao;
        private DataTable duLieuBaoCao;


        public FormReport(LoaiBaoCao loaiBaoCao, DataTable duLieuBaoCao)
        {
            InitializeComponent();
            this.loaiBaoCao = loaiBaoCao;
            this.duLieuBaoCao = duLieuBaoCao;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {

            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            switch (loaiBaoCao)
            {
                case LoaiBaoCao.NhanVien:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "KFC.NhanVienRP.rdlc";
                    break;
                case LoaiBaoCao.LuongNhanVien:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "KFC.LuongNhanVienRP.rdlc";
                    break;
            }
            ReportDataSource rds = new ReportDataSource("DataSet1", duLieuBaoCao);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
