using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LedGeekBox
{
    public class ViewModelMax7219 : INotifyPropertyChanged
    {

        private static Color Black = Color.FromRgb(0, 0, 0);
        private static Color Red = Color.FromRgb(255, 0, 0);

        public ViewModelMax7219()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            var handlers = PropertyChanged;
            if (handlers != null)
            {
                var args = new PropertyChangedEventArgs(property);
                handlers(this, args);
            }
        }

        #region A
        private Color a1_fill = Black;
        public Color A1_fill
        {
            get { return a1_fill; }
            set
            {
                if (a1_fill.Equals(value))
                    return;

                a1_fill = value;
                RaisePropertyChanged("A1_fill");
            }
        }

        private Color a2_fill = Black;
        public Color A2_fill
        {
            get { return a2_fill; }
            set
            {
                if (a2_fill.Equals(value))
                    return;

                a2_fill = value;
                RaisePropertyChanged("A2_fill");
            }
        }

        private Color a3_fill = Black;
        public Color A3_fill
        {
            get { return a3_fill; }
            set
            {
                if (a3_fill.Equals(value))
                    return;

                a3_fill = value;
                RaisePropertyChanged("A3_fill");
            }
        }

        private Color a4_fill = Black;
        public Color A4_fill
        {
            get { return a4_fill; }
            set
            {
                if (a4_fill.Equals(value))
                    return;

                a4_fill = value;
                RaisePropertyChanged("A4_fill");
            }
        }

        private Color a5_fill = Black;
        public Color A5_fill
        {
            get { return a5_fill; }
            set
            {
                if (a5_fill.Equals(value))
                    return;

                a5_fill = value;
                RaisePropertyChanged("A5_fill");
            }
        }
        private Color a6_fill = Black;
        public Color A6_fill
        {
            get { return a6_fill; }
            set
            {
                if (a6_fill.Equals(value))
                    return;

                a6_fill = value;
                RaisePropertyChanged("A6_fill");
            }
        }
        private Color a7_fill = Black;
        public Color A7_fill
        {
            get { return a7_fill; }
            set
            {
                if (a7_fill.Equals(value))
                    return;

                a7_fill = value;
                RaisePropertyChanged("A7_fill");
            }
        }
        private Color a8_fill = Black;
        public Color A8_fill
        {
            get { return a8_fill; }
            set
            {
                if (a8_fill.Equals(value))
                    return;

                a8_fill = value;
                RaisePropertyChanged("A8_fill");
            }
        }
        #endregion A

        #region B
        private Color b1_fill = Black;
        public Color B1_fill
        {
            get { return b1_fill; }
            set
            {
                if (b1_fill.Equals(value))
                    return;

                b1_fill = value;
                RaisePropertyChanged("B1_fill");
            }
        }

        private Color b2_fill = Black;
        public Color B2_fill
        {
            get { return b2_fill; }
            set
            {
                if (b2_fill.Equals(value))
                    return;

                b2_fill = value;
                RaisePropertyChanged("B2_fill");
            }
        }

        private Color b3_fill = Black;
        public Color B3_fill
        {
            get { return b3_fill; }
            set
            {
                if (b3_fill.Equals(value))
                    return;

                b3_fill = value;
                RaisePropertyChanged("B3_fill");
            }
        }

        private Color b4_fill = Black;
        public Color B4_fill
        {
            get { return b4_fill; }
            set
            {
                if (b4_fill.Equals(value))
                    return;

                b4_fill = value;
                RaisePropertyChanged("B4_fill");
            }
        }

        private Color b5_fill = Black;
        public Color B5_fill
        {
            get { return b5_fill; }
            set
            {
                if (b5_fill.Equals(value))
                    return;

                b5_fill = value;
                RaisePropertyChanged("B5_fill");
            }
        }
        private Color b6_fill = Black;
        public Color B6_fill
        {
            get { return b6_fill; }
            set
            {
                if (b6_fill.Equals(value))
                    return;

                b6_fill = value;
                RaisePropertyChanged("B6_fill");
            }
        }
        private Color b7_fill = Black;
        public Color B7_fill
        {
            get { return b7_fill; }
            set
            {
                if (b7_fill.Equals(value))
                    return;

                b7_fill = value;
                RaisePropertyChanged("B7_fill");
            }
        }
        private Color b8_fill = Black;
        public Color B8_fill
        {
            get { return b8_fill; }
            set
            {
                if (b8_fill.Equals(value))
                    return;

                b8_fill = value;
                RaisePropertyChanged("B8_fill");
            }
        }
        #endregion B

        #region C
        private Color c1_fill = Black;
        public Color C1_fill
        {
            get { return c1_fill; }
            set
            {
                if (c1_fill.Equals(value))
                    return;

                c1_fill = value;
                RaisePropertyChanged("C1_fill");
            }
        }

        private Color c2_fill = Black;
        public Color C2_fill
        {
            get { return c2_fill; }
            set
            {
                if (c2_fill.Equals(value))
                    return;

                c2_fill = value;
                RaisePropertyChanged("C2_fill");
            }
        }

        private Color c3_fill = Black;
        public Color C3_fill
        {
            get { return c3_fill; }
            set
            {
                if (c3_fill.Equals(value))
                    return;

                c3_fill = value;
                RaisePropertyChanged("C3_fill");
            }
        }

        private Color c4_fill = Black;
        public Color C4_fill
        {
            get { return c4_fill; }
            set
            {
                if (c4_fill.Equals(value))
                    return;

                c4_fill = value;
                RaisePropertyChanged("C4_fill");
            }
        }

        private Color c5_fill = Black;
        public Color C5_fill
        {
            get { return c5_fill; }
            set
            {
                if (c5_fill.Equals(value))
                    return;

                c5_fill = value;
                RaisePropertyChanged("C5_fill");
            }
        }
        private Color c6_fill = Black;
        public Color C6_fill
        {
            get { return c6_fill; }
            set
            {
                if (c6_fill.Equals(value))
                    return;

                c6_fill = value;
                RaisePropertyChanged("C6_fill");
            }
        }
        private Color c7_fill = Black;
        public Color C7_fill
        {
            get { return c7_fill; }
            set
            {
                if (c7_fill.Equals(value))
                    return;

                c7_fill = value;
                RaisePropertyChanged("C7_fill");
            }
        }
        private Color c8_fill = Black;
        public Color C8_fill
        {
            get { return c8_fill; }
            set
            {
                if (c8_fill.Equals(value))
                    return;

                c8_fill = value;
                RaisePropertyChanged("C8_fill");
            }
        }
        #endregion C

        #region D
        private Color d1_fill = Black;
        public Color D1_fill
        {
            get { return d1_fill; }
            set
            {
                if (d1_fill.Equals(value))
                    return;

                d1_fill = value;
                RaisePropertyChanged("D1_fill");
            }
        }

        private Color d2_fill = Black;
        public Color D2_fill
        {
            get { return d2_fill; }
            set
            {
                if (d2_fill.Equals(value))
                    return;

                d2_fill = value;
                RaisePropertyChanged("D2_fill");
            }
        }

        private Color d3_fill = Black;
        public Color D3_fill
        {
            get { return d3_fill; }
            set
            {
                if (d3_fill.Equals(value))
                    return;

                d3_fill = value;
                RaisePropertyChanged("D3_fill");
            }
        }

        private Color d4_fill = Black;
        public Color D4_fill
        {
            get { return d4_fill; }
            set
            {
                if (d4_fill.Equals(value))
                    return;

                d4_fill = value;
                RaisePropertyChanged("D4_fill");
            }
        }

        private Color d5_fill = Black;
        public Color D5_fill
        {
            get { return d5_fill; }
            set
            {
                if (d5_fill.Equals(value))
                    return;

                d5_fill = value;
                RaisePropertyChanged("D5_fill");
            }
        }
        private Color d6_fill = Black;
        public Color D6_fill
        {
            get { return d6_fill; }
            set
            {
                if (d6_fill.Equals(value))
                    return;

                d6_fill = value;
                RaisePropertyChanged("D6_fill");
            }
        }
        private Color d7_fill = Black;
        public Color D7_fill
        {
            get { return d7_fill; }
            set
            {
                if (d7_fill.Equals(value))
                    return;

                d7_fill = value;
                RaisePropertyChanged("D7_fill");
            }
        }
        private Color d8_fill = Black;
        public Color D8_fill
        {
            get { return d8_fill; }
            set
            {
                if (d8_fill.Equals(value))
                    return;

                d8_fill = value;
                RaisePropertyChanged("D8_fill");
            }
        }
        #endregion D

        #region E
        private Color e1_fill = Black;
        public Color E1_fill
        {
            get { return e1_fill; }
            set
            {
                if (e1_fill.Equals(value))
                    return;

                e1_fill = value;
                RaisePropertyChanged("E1_fill");
            }
        }

        private Color e2_fill = Black;
        public Color E2_fill
        {
            get { return e2_fill; }
            set
            {
                if (e2_fill.Equals(value))
                    return;

                e2_fill = value;
                RaisePropertyChanged("E2_fill");
            }
        }

        private Color e3_fill = Black;
        public Color E3_fill
        {
            get { return e3_fill; }
            set
            {
                if (e3_fill.Equals(value))
                    return;

                e3_fill = value;
                RaisePropertyChanged("E3_fill");
            }
        }

        private Color e4_fill = Black;
        public Color E4_fill
        {
            get { return e4_fill; }
            set
            {
                if (e4_fill.Equals(value))
                    return;

                e4_fill = value;
                RaisePropertyChanged("E4_fill");
            }
        }

        private Color e5_fill = Black;
        public Color E5_fill
        {
            get { return e5_fill; }
            set
            {
                if (e5_fill.Equals(value))
                    return;

                e5_fill = value;
                RaisePropertyChanged("E5_fill");
            }
        }
        private Color e6_fill = Black;
        public Color E6_fill
        {
            get { return e6_fill; }
            set
            {
                if (e6_fill.Equals(value))
                    return;

                e6_fill = value;
                RaisePropertyChanged("E6_fill");
            }
        }
        private Color e7_fill = Black;
        public Color E7_fill
        {
            get { return e7_fill; }
            set
            {
                if (e7_fill.Equals(value))
                    return;

                e7_fill = value;
                RaisePropertyChanged("E7_fill");
            }
        }
        private Color e8_fill = Black;
        public Color E8_fill
        {
            get { return e8_fill; }
            set
            {
                if (e8_fill.Equals(value))
                    return;

                e8_fill = value;
                RaisePropertyChanged("E8_fill");
            }
        }
        #endregion E

        #region F
        private Color f1_fill = Black;
        public Color F1_fill
        {
            get { return f1_fill; }
            set
            {
                if (f1_fill.Equals(value))
                    return;

                f1_fill = value;
                RaisePropertyChanged("F1_fill");
            }
        }

        private Color f2_fill = Black;
        public Color F2_fill
        {
            get { return f2_fill; }
            set
            {
                if (f2_fill.Equals(value))
                    return;

                f2_fill = value;
                RaisePropertyChanged("F2_fill");
            }
        }

        private Color f3_fill = Black;
        public Color F3_fill
        {
            get { return f3_fill; }
            set
            {
                if (f3_fill.Equals(value))
                    return;

                f3_fill = value;
                RaisePropertyChanged("F3_fill");
            }
        }

        private Color f4_fill = Black;
        public Color F4_fill
        {
            get { return f4_fill; }
            set
            {
                if (f4_fill.Equals(value))
                    return;

                f4_fill = value;
                RaisePropertyChanged("F4_fill");
            }
        }

        private Color f5_fill = Black;
        public Color F5_fill
        {
            get { return f5_fill; }
            set
            {
                if (f5_fill.Equals(value))
                    return;

                f5_fill = value;
                RaisePropertyChanged("F5_fill");
            }
        }
        private Color f6_fill = Black;
        public Color F6_fill
        {
            get { return f6_fill; }
            set
            {
                if (f6_fill.Equals(value))
                    return;

                f6_fill = value;
                RaisePropertyChanged("F6_fill");
            }
        }
        private Color f7_fill = Black;
        public Color F7_fill
        {
            get { return f7_fill; }
            set
            {
                if (f7_fill.Equals(value))
                    return;

                f7_fill = value;
                RaisePropertyChanged("F7_fill");
            }
        }
        private Color f8_fill = Black;
        public Color F8_fill
        {
            get { return f8_fill; }
            set
            {
                if (f8_fill.Equals(value))
                    return;

                f8_fill = value;
                RaisePropertyChanged("F8_fill");
            }
        }
        #endregion F

        #region G
        private Color g1_fill = Black;
        public Color G1_fill
        {
            get { return g1_fill; }
            set
            {
                if (g1_fill.Equals(value))
                    return;

                g1_fill = value;
                RaisePropertyChanged("G1_fill");
            }
        }

        private Color g2_fill = Black;
        public Color G2_fill
        {
            get { return g2_fill; }
            set
            {
                if (g2_fill.Equals(value))
                    return;

                g2_fill = value;
                RaisePropertyChanged("G2_fill");
            }
        }

        private Color g3_fill = Black;
        public Color G3_fill
        {
            get { return g3_fill; }
            set
            {
                if (g3_fill.Equals(value))
                    return;

                g3_fill = value;
                RaisePropertyChanged("G3_fill");
            }
        }

        private Color g4_fill = Black;
        public Color G4_fill
        {
            get { return g4_fill; }
            set
            {
                if (g4_fill.Equals(value))
                    return;

                g4_fill = value;
                RaisePropertyChanged("G4_fill");
            }
        }

        private Color g5_fill = Black;
        public Color G5_fill
        {
            get { return g5_fill; }
            set
            {
                if (g5_fill.Equals(value))
                    return;

                g5_fill = value;
                RaisePropertyChanged("G5_fill");
            }
        }
        private Color g6_fill = Black;
        public Color G6_fill
        {
            get { return g6_fill; }
            set
            {
                if (g6_fill.Equals(value))
                    return;

                g6_fill = value;
                RaisePropertyChanged("G6_fill");
            }
        }
        private Color g7_fill = Black;
        public Color G7_fill
        {
            get { return g7_fill; }
            set
            {
                if (g7_fill.Equals(value))
                    return;

                g7_fill = value;
                RaisePropertyChanged("G7_fill");
            }
        }
        private Color g8_fill = Black;
        public Color G8_fill
        {
            get { return g8_fill; }
            set
            {
                if (g8_fill.Equals(value))
                    return;

                g8_fill = value;
                RaisePropertyChanged("G8_fill");
            }
        }
        #endregion G

        #region H
        private Color h1_fill = Black;
        public Color H1_fill
        {
            get { return h1_fill; }
            set
            {
                if (h1_fill.Equals(value))
                    return;

                h1_fill = value;
                RaisePropertyChanged("H1_fill");
            }
        }

        private Color h2_fill = Black;
        public Color H2_fill
        {
            get { return h2_fill; }
            set
            {
                if (h2_fill.Equals(value))
                    return;

                h2_fill = value;
                RaisePropertyChanged("H2_fill");
            }
        }

        private Color h3_fill = Black;
        public Color H3_fill
        {
            get { return h3_fill; }
            set
            {
                if (h3_fill.Equals(value))
                    return;

                h3_fill = value;
                RaisePropertyChanged("H3_fill");
            }
        }

        private Color h4_fill = Black;
        public Color H4_fill
        {
            get { return h4_fill; }
            set
            {
                if (h4_fill.Equals(value))
                    return;

                h4_fill = value;
                RaisePropertyChanged("H4_fill");
            }
        }

        private Color h5_fill = Black;
        public Color H5_fill
        {
            get { return h5_fill; }
            set
            {
                if (h5_fill.Equals(value))
                    return;

                h5_fill = value;
                RaisePropertyChanged("H5_fill");
            }
        }
        private Color h6_fill = Black;
        public Color H6_fill
        {
            get { return h6_fill; }
            set
            {
                if (h6_fill.Equals(value))
                    return;

                h6_fill = value;
                RaisePropertyChanged("H6_fill");
            }
        }
        private Color h7_fill = Black;
        public Color H7_fill
        {
            get { return h7_fill; }
            set
            {
                if (h7_fill.Equals(value))
                    return;

                h7_fill = value;
                RaisePropertyChanged("H7_fill");
            }
        }
        private Color h8_fill = Black;
        public Color H8_fill
        {
            get { return h8_fill; }
            set
            {
                if (h8_fill.Equals(value))
                    return;

                h8_fill = value;
                RaisePropertyChanged("H8_fill");
            }
        }
        #endregion H


        public void Apply(bool[,] datas)
        {
            int height = datas.GetLength(0);
            int width = datas.GetLength(1);

            if (height >= 1)
            {
                if (width >= 1)
                    A1_fill = datas[0, 0] ? Red : Black;
                if (width >= 2)
                    A2_fill = datas[0, 1] ? Red : Black;
                if (width >= 3)
                    A3_fill = datas[0, 2] ? Red : Black;
                if (width >= 4)
                    A4_fill = datas[0, 3] ? Red : Black;
                if (width >= 5)
                    A5_fill = datas[0, 4] ? Red : Black;
                if (width >= 6)
                    A6_fill = datas[0, 5] ? Red : Black;
                if (width >= 7)
                    A7_fill = datas[0, 6] ? Red : Black;
                if (width >= 8)
                    A8_fill = datas[0, 7] ? Red : Black;
            }

            if (height >= 2)
            {
                if (width >= 1)
                    B1_fill = datas[1, 0] ? Red : Black;
                if (width >= 2)
                    B2_fill = datas[1, 1] ? Red : Black;
                if (width >= 3)
                    B3_fill = datas[1, 2] ? Red : Black;
                if (width >= 4)
                    B4_fill = datas[1, 3] ? Red : Black;
                if (width >= 5)
                    B5_fill = datas[1, 4] ? Red : Black;
                if (width >= 6)
                    B6_fill = datas[1, 5] ? Red : Black;
                if (width >= 7)
                    B7_fill = datas[1, 6] ? Red : Black;
                if (width >= 8)
                    B8_fill = datas[1, 7] ? Red : Black;
            }

            if (height >= 3)
            {
                if (width >= 1)
                    C1_fill = datas[2, 0] ? Red : Black;
                if (width >= 2)
                    C2_fill = datas[2, 1] ? Red : Black;
                if (width >= 3)
                    C3_fill = datas[2, 2] ? Red : Black;
                if (width >= 4)
                    C4_fill = datas[2, 3] ? Red : Black;
                if (width >= 5)
                    C5_fill = datas[2, 4] ? Red : Black;
                if (width >= 6)
                    C6_fill = datas[2, 5] ? Red : Black;
                if (width >= 7)
                    C7_fill = datas[2, 6] ? Red : Black;
                if (width >= 8)
                    C8_fill = datas[2, 7] ? Red : Black;
            }

            if (height >= 4)
            {
                if (width >= 1)
                    D1_fill = datas[3, 0] ? Red : Black;
                if (width >= 2)
                    D2_fill = datas[3, 1] ? Red : Black;
                if (width >= 3)
                    D3_fill = datas[3, 2] ? Red : Black;
                if (width >= 4)
                    D4_fill = datas[3, 3] ? Red : Black;
                if (width >= 5)
                    D5_fill = datas[3, 4] ? Red : Black;
                if (width >= 6)
                    D6_fill = datas[3, 5] ? Red : Black;
                if (width >= 7)
                    D7_fill = datas[3, 6] ? Red : Black;
                if (width >= 8)
                    D8_fill = datas[3, 7] ? Red : Black;
            }

            if (height >= 5)
            {
                if (width >= 1)
                    E1_fill = datas[4, 0] ? Red : Black;
                if (width >= 2)
                    E2_fill = datas[4, 1] ? Red : Black;
                if (width >= 3)
                    E3_fill = datas[4, 2] ? Red : Black;
                if (width >= 4)
                    E4_fill = datas[4, 3] ? Red : Black;
                if (width >= 5)
                    E5_fill = datas[4, 4] ? Red : Black;
                if (width >= 6)
                    E6_fill = datas[4, 5] ? Red : Black;
                if (width >= 7)
                    E7_fill = datas[4, 6] ? Red : Black;
                if (width >= 8)
                    E8_fill = datas[4, 7] ? Red : Black;
            }

            if (height >= 6)
            {
                if (width >= 1)
                    F1_fill = datas[5, 0] ? Red : Black;
                if (width >= 2)
                    F2_fill = datas[5, 1] ? Red : Black;
                if (width >= 3)
                    F3_fill = datas[5, 2] ? Red : Black;
                if (width >= 4)
                    F4_fill = datas[5, 3] ? Red : Black;
                if (width >= 5)
                    F5_fill = datas[5, 4] ? Red : Black;
                if (width >= 6)
                    F6_fill = datas[5, 5] ? Red : Black;
                if (width >= 7)
                    F7_fill = datas[5, 6] ? Red : Black;
                if (width >= 8)
                    F8_fill = datas[5, 7] ? Red : Black;
            }

            if (height >= 7)
            {
                if (width >= 1)
                    G1_fill = datas[6, 0] ? Red : Black;
                if (width >= 2)
                    G2_fill = datas[6, 1] ? Red : Black;
                if (width >= 3)
                    G3_fill = datas[6, 2] ? Red : Black;
                if (width >= 4)
                    G4_fill = datas[6, 3] ? Red : Black;
                if (width >= 5)
                    G5_fill = datas[6, 4] ? Red : Black;
                if (width >= 6)
                    G6_fill = datas[6, 5] ? Red : Black;
                if (width >= 7)
                    G7_fill = datas[6, 6] ? Red : Black;
                if (width >= 8)
                    G8_fill = datas[6, 7] ? Red : Black;
            }

            if (height >= 0)
            {
                if (width >= 1)
                    H1_fill = datas[7, 0] ? Red : Black;
                if (width >= 2)
                    H2_fill = datas[7, 1] ? Red : Black;
                if (width >= 3)
                    H3_fill = datas[7, 2] ? Red : Black;
                if (width >= 4)
                    H4_fill = datas[7, 3] ? Red : Black;
                if (width >= 5)
                    H5_fill = datas[7, 4] ? Red : Black;
                if (width >= 6)
                    H6_fill = datas[7, 5] ? Red : Black;
                if (width >= 7)
                    H7_fill = datas[7, 6] ? Red : Black;
                if (width >= 8)
                    H8_fill = datas[7, 7] ? Red : Black;
            }



        }
    }
}
