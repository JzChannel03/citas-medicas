using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitasMedicas
{
    public class Limpieza
    {
        public static void Clean(params Label[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i].Text = "";
            }
        }

        public static void Clean(params TextBox[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i].Text = "";
            }
        }
    }
}
