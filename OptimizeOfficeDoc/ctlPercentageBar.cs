using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimizeOfficeDoc
{
    public partial class ctlPercentageBar : UserControl
    {
        public ctlPercentageBar()
        {
            InitializeComponent();
        }

        private float _Total = 100;
        public float Total
        {

            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
                _UpdateBar();
            }

        }

        private float _Value = 50;
        public float Value
        {

            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                _UpdateBar();
            }
        }

        private float _Percent;

        private void _UpdateBar()
        {
            _Percent = (_Value / _Total) * 100;

            lblPercentInside.Visible = (_Percent >= 51);
            lblPercentOutside.Visible = !lblPercentInside.Visible;

            lblPercentInside.Text = _Percent.ToString("0.00") + "%";
            lblPercentOutside.Text = lblPercentInside.Text;

            pnlPercentage.Width = (int)((float)pnlTotal.Width * (float)(_Percent / 100));
            lblPercentOutside.Left = pnlPercentage.Size.Width + 6;
            lblPercentInside.Left = pnlPercentage.Size.Width - 42 - 6;

        }
    }
}
