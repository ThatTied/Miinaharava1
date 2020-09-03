using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMiinaharava
{
    public partial class Miinaharava : Form
    {
        public Miinaharava()
        {
            InitializeComponent();
            miinaTextBox.Hide();
        }
        public List<int> Tile;
        Button ruutu;
        public Random Rnd = new Random();
        public int Miinamaara = 0; // Miinojen määrä
        public int RndMiinamaara; //Miinojen määrä miinojen istutusta varten
        public int MaxMiinat; // Max miinat per kenttä
        public int RuutuKoko = 26; // Ruutujen säädeltävä koko
        public Image Miina = WindowsFormsMiinaharava.Properties.Resources.pienimiina;
        public Image Lipputanko = WindowsFormsMiinaharava.Properties.Resources.lippu;
        public bool IstutaMiina(ref Random Rand)
        {
            int chance = Rand.Next(RndMiinamaara);
            if (chance < MaxMiinat && MaxMiinat > Miinamaara) // 10/40/99 > 81/256/480, jos on tarpeeksi miinoja, return false aina
            {
                Miinamaara++;
                return true;
            }
            else
            {
                return false;
            } 
        }
        public void FormKoko(int x, int y) // Säädeltävä Formin koko X ja Y -arvoilla
        {
            int KokoX;
            int KokoY;
            KokoX = 5 + (x * RuutuKoko) + (x * 2) + 20;
            KokoY = 35 + (y * RuutuKoko) + (y * 2) + 40;
            this.Size = new Size(KokoX, KokoY);
        }
        public void LuoKentta(int x, int y) // Luodaan miinakenttä, ruutujen määrää pystyy säätää X ja Y -arvoilla
        {
            Point newLoc = new Point(5, 35);
            this.helpponappi.Hide(); // Piilotetaan aloitusruudun asiat
            this.vaikeanappi.Hide();
            this.keskivaikeanappi.Hide();
            this.vaikeustasotext.Hide();

            for (int o = 0; o < x; ++o) // X-akseli
            {
                for (int i = 0; i < y; ++i) // Y-akseli, luodaan ruudut
                {
                    ruutu = new Button(); // Luodaan uusi ruutu, ja asetetaan parametrit
                    ruutu.Size = new Size(RuutuKoko, RuutuKoko);
                    ruutu.Location = newLoc;
                    newLoc.Offset(0, RuutuKoko + 2);
                    ruutu.MouseUp += (object sender, MouseEventArgs e) => { // Lisätään ruudulle MouseUp eventti jotta voidaan katsoa vasen tai oikean hiirinklikkauksia
                        Button tamaRuutu = sender as Button;
                        bool OnPommi = IstutaMiina(ref Rnd);


                        if (tamaRuutu.Image == Miina || tamaRuutu.BackColor == System.Drawing.Color.LightGray)
                        {
                            return;
                        }
                        else if (e.Button == System.Windows.Forms.MouseButtons.Left && tamaRuutu.Image == Lipputanko)
                        {
                            tamaRuutu.Image = null;
                        }
                        else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            tamaRuutu.Image = Lipputanko;
                        }
                        else if (e.Button == System.Windows.Forms.MouseButtons.Left && OnPommi == true)
                        {
                            tamaRuutu.Image = Miina;
                            tamaRuutu.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            tamaRuutu.BackColor = System.Drawing.Color.LightGray;
                        }
                    };
                    Controls.Add(ruutu);
                }
                newLoc.Y = 35;
                newLoc.Offset(RuutuKoko + 2, 0);
            }
            miinaTextBox.Show();
            miinaTextBox.Text = Convert.ToString(Miinamaara);
        }
        private void Helpponappi_Click(object sender, EventArgs e)
        {
            MaxMiinat = 10;
            RndMiinamaara = 81;
            LuoKentta(9, 9);
            FormKoko(9, 9);
            miinaTextBox.Text = "10";
        }

        private void Keskivaikeanappi_Click(object sender, EventArgs e)
        {
            MaxMiinat = 40;
            RndMiinamaara = 256;
            LuoKentta(16, 16);
            FormKoko(16, 16);
            miinaTextBox.Text = "40";
        }

        private void Vaikeanappi_Click(object sender, EventArgs e)
        {
            MaxMiinat = 99;
            RndMiinamaara = 480;
            LuoKentta(30, 16);
            FormKoko(30, 16);
            miinaTextBox.Text = "99";
        }
    }
}
