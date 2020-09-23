using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Tile : Button
{
    public int ID { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsMine { get; set; }
    public int NaapuriPommit { get; set; }
    public bool Painettu { get; set; }
    public bool Liputettu { get; set; }

    public Tile(int id, int x, int y)
    {
        ID = id;
        X = x;
        Y = y;
    }
}
