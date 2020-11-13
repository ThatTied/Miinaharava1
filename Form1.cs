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
        public List<Tile> Ruudut;
        public List<Tile> tyhjätRuudut;
        public List<Tile> miinaRuudut;
        public Tile ruutu;
        public Random Rnd = new Random();
        public int Miinamaara = 0; // Miinojen määrä
        public int RndMiinamaara; //Miinojen määrä miinojen istutusta varten
        public int MaxMiinat; // Max miinat per kenttä
        public Image Miina = Properties.Resources.pienimiina;
        public Image Lipputanko = Properties.Resources.lippu;

        public int oikeaLippu = 0;
        public int vääräLippu = 0;

        public bool IstutaMiina(ref Random Rand)
        {
            int chance = Rand.Next(RndMiinamaara);
            if (chance < MaxMiinat && MaxMiinat > Miinamaara) // 10/40/99 > 81/256/480, jos on tarpeeksi miinoja, return false aina
            {
                Miinamaara++;
                RndMiinamaara++;
                return true;
            }
            else
            {
                RndMiinamaara--;
                return false;
            }
        }
        /// <summary>
        /// Muokataan Formin kokoa jotta miinakenttä mahtuu siihen, ilman että pelaajan tarvitsee itse muokata sitä.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void FormKoko(int x, int y) // Säädeltävä Formin koko X ja Y -arvoilla
        {
            int KokoX;
            int KokoY;
            KokoX = 5 + (x * 26) + (x * 2) + 20;
            KokoY = 35 + (y * 26) + (y * 2) + 40;
            this.Size = new Size(KokoX, KokoY);
        }
        public int NaapuriRuudut(int x, int y) // katsotaan naapuriruudut
        {
            int Pommit = 0;
            foreach (Tile tile in Ruudut)
            {
                if (tile.X == (x - 1) && tile.Y == (y + 1) && tile.IsMine == true)
                {
                    Pommit++;
                }
                if (tile.X == x && tile.Y == (y + 1) && tile.IsMine == true)
                {
                    Pommit++;
                }
                if (tile.X == (x + 1) && tile.Y == (y + 1) && tile.IsMine == true) // 3x1 rivi ruudun yläpuolella
                {
                    Pommit++;
                }
                if (tile.X == (x - 1) && tile.Y == y && tile.IsMine == true)
                {
                    Pommit++;
                }
                if (tile.X == (x + 1) && tile.Y == y && tile.IsMine == true) // 2 ruutua ruudun vieressä
                {
                    Pommit++;
                }
                if (tile.X == (x - 1) && tile.Y == (y - 1) && tile.IsMine == true)
                {
                    Pommit++;
                }
                if (tile.X == x && tile.Y == (y - 1) && tile.IsMine == true)
                {
                    Pommit++;
                }
                if (tile.X == (x + 1) && tile.Y == (y - 1) && tile.IsMine == true) // 3x1 rivi ruudun alapuolella
                {
                    Pommit++;
                }
            }
            return Pommit;
        }
        public void piilotaAloitus()
        {
            this.helpponappi.Hide(); // Piilotetaan aloitusruudun asiat
            this.vaikeanappi.Hide();
            this.keskivaikeanappi.Hide();
            this.vaikeustasotext.Hide();
        }
        /// <summary>
        /// Luodaan pelikenttä.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void LuoKentta(int x, int y) // Luodaan miinakenttä, ruutujen määrää pystyy säätää X ja Y -arvoilla
        {
            Point newLoc = new Point(5, 35);
            piilotaAloitus();
            int id = 1;
            Ruudut = new List<Tile>();
            tyhjätRuudut = new List<Tile>();
            miinaRuudut = new List<Tile>();
            for (int o = 0; o < x; ++o) // X-akseli
            {
                for (int i = 0; i < y; ++i) // Y-akseli, luodaan ruudut
                {
                    ruutu = new Tile(id, o, i); // Luodaan uusi ruutu, ja asetetaan parametrit
                    ruutu.Size = new Size(26, 26);
                    ruutu.Location = newLoc;
                    newLoc.Offset(0, 26 + 2);
                    Ruudut.Add(ruutu);
                    id++;
                    if (IstutaMiina(ref Rnd) == true) // Miinan istutus
                    {
                        ruutu.IsMine = true;
                        miinaRuudut.Add(ruutu);
                        ruutu.BackColor = Color.Pink;
                    }
                    else
                    {
                        tyhjätRuudut.Add(ruutu);
                    }
                    ruutu.MouseUp += new MouseEventHandler(ruutuClick);
                    Controls.Add(ruutu);
                }
                newLoc.Y = 35;
                newLoc.Offset(26 + 2, 0);
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
        private void ruutuClick(object sender, MouseEventArgs e)
        {
            // Lisätään ruudulle MouseUp eventti jotta voidaan katsoa vasen tai oikean hiirinklikkauksia
            Tile tamaRuutu = sender as Tile;

            if (tamaRuutu.Painettu == true) // Ruutua "ei voi painaa" jos on paljastettu
            {
                return;
            }
            else if (e.Button == MouseButtons.Left && tamaRuutu.Liputettu == true) // Poistetaan lippu ruudusta
            {
                tamaRuutu.Image = null;
                tamaRuutu.Liputettu = false;
                if (tamaRuutu.IsMine == true)
                {
                    oikeaLippu--;
                }
                else
                {
                    vääräLippu--;
                }
            }
            else if (e.Button == MouseButtons.Right) // Laitetaan lippu ruudulle
            {
                tamaRuutu.Image = Lipputanko;
                tamaRuutu.Liputettu = true;
                if (tamaRuutu.IsMine == true)
                {
                    oikeaLippu++;
                }
                else
                {
                    vääräLippu++;
                }
            }
            else if (e.Button == MouseButtons.Left && tamaRuutu.IsMine == true) // Miina räjähti
            {
                tamaRuutu.Image = Miina;
                tamaRuutu.Painettu = true;
                foreach (Tile siili in Ruudut)
                {
                    siili.Painettu = true;
                    if (siili.IsMine == true && siili.Liputettu == true)
                    {
                        siili.BackColor = Color.Green;
                        siili.Image = Miina;
                    }
                    else if (siili.IsMine == true)
                    {
                        siili.Image = Miina;
                    }
                }
                tamaRuutu.BackColor = Color.Red;
            }
            else
            {
                tamaRuutu.BackColor = Color.LightGreen;
                tamaRuutu.Painettu = true;
                tamaRuutu.Text = (NaapuriRuudut(tamaRuutu.X, tamaRuutu.Y)).ToString(); // Tyhjä ruutu, laitetaan numero jos naapurista löytyy miina
                if (tamaRuutu.Text == "0")
                {
                    tamaRuutu.Text = "";
                }
            }
            CheckForWin();
        }
        /// <summary>
        /// Katsotaan, jos pelaaja voitti
        /// </summary>
        private void CheckForWin()
        {
            if (oikeaLippu == MaxMiinat && vääräLippu == 0)
            {
                //Voitit pelin!
                foreach (Tile tiili in Ruudut)
                {
                    if (tiili.Painettu == false)
                    {
                        if (tiili.IsMine != true)
                        {
                            tiili.Text = (NaapuriRuudut(tiili.X, tiili.Y)).ToString();
                            if (tiili.Text == "0")
                            {
                                tiili.Text = "";
                            }
                            tiili.BackColor = Color.LightGreen;
                        }
                        if (tiili.IsMine == true)
                        {
                            tiili.BackColor = Color.Green;
                            tiili.Image = Miina;
                        }
                        tiili.Painettu = true;
                    }
                }
                MessageBox.Show("Voitit Pelin!", "Voitto");
            }
            else
            {
                //Ei voittoa :(
            }
        }
    }
}