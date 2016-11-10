namespace LedGeekBox.Model
{
    public class Definition
    {

        public static int Number_Max7219_X
        {
            get;
            set;
        }

        public static int Number_Max7219_Y
        {
            get;
            set;
        }

        public static int Number_Led_X_Max7219
        {
            get;
            set;
        }

        public static int Number_Led_Y_Max7219
        {
            get;
            set;
        }


        public static int Number_Led_X_total
        {
            get { return Number_Led_X_Max7219* Number_Max7219_X; }
        }

        public static int Number_Led_Y_total
        {
            get { return Number_Led_Y_Max7219 * Number_Max7219_Y; }
        }

        static Definition()
        {
            Number_Max7219_X = 5;
            Number_Max7219_Y = 2;
            Number_Led_X_Max7219 = 8;
            Number_Led_Y_Max7219 = 8;
        }


        public static bool[,] Empty = new bool[8, 8];


        public static bool[,] zero = new bool[8, 8]
       {
            {false, false, false, false, false, false, false, false},
            {false, false, false, true, true, false, false, false},
            {false, false, true, false, false, true, false, false},
            {false, false, true, false, false, true, false, false},
            {false, false, true, false, false, true, false, false},
            {false, false, true, false, false, true, false, false},
            {false, false, false, true, true, false, false, false},
            {false, false, false, false, false, false, false, false}
       };

        public static bool[,] un = new bool[8, 8]
        {
            {false, false, false, false, false, false, false, false},
            {false, false, false, false, true, false, false, false},
            {false, false, false, true, true, false, false, false},
            {false, false, true, false, true, false, false, false},
            {false, false, false, false, true, false, false, false},
            {false, false, false, false, true, false, false, false},
            {false, false, false, false, true, false, false, false},
            {false, false, false, false, false, false, false, false}
        };


        public static bool[,] deux = new bool[8, 8]
         {
            { false, false, false, false, false, false, false, false },
            { false, false, true, true, true, false, false, false},
            { false, false, false, false, false, true, false, false},
            { false, false, false, true, true, true, false, false},
            { false, false, true, false, false, false, false, false},
            { false, false, true, false, false, false, false, false},
            { false, false, true, true, true, true, false, false},
            { false, false, false, false, false, false, false, false}
         };


        public static bool[,] trois = new bool[8, 8]
         {
            { false, false, false, false, false, false, false, false },
            { false, false, true, true, true, false, false, false },
            { false, false, false, false, false, true, false, false },
            { false, false, false, true, true, true, false, false },
            { false, false, false, false, false, true, false, false },
            { false, false, false, false, false, true, false, false },
            { false, false, true, true, true, false, false, false },
            { false, false, false, false, false, false, false, false }
         };


        public static bool[,] quatre = new bool[8, 8]
         {
            { false, false, false, false, false, false, false, false },
            { false, false, false, false, true, true, false, false },
            { false, false, false, true, false, true, false, false },
            { false, false, true, false, false, true, false, false },
            { false, false, true, true, true, true, false, false },
            { false, false, false, false, false, true, false, false },
            { false, false, false, false, false, true, false, false},
            { false, false, false, false, false, false, false, false }
         };


        public static bool[,] cinq = new bool[8, 8]
         {
            { false, false, false, false, false, false, false, false },
            { false, false, true, true, true, true, false, false },
            { false, false, true, false, false, false, false, false },
            { false, false, true, true, true, false, false, false },
            { false, false, false, false, false, true, false, false },
            { false, false, false, false, false, true, false, false },
            { false, false, true, true, true, false, false, false},
            { false, false, false, false, false, false, false, false }
         };



        public static bool[,] six = new bool[8, 8]
         {
            { false, false, false, false, false, false, false, false },
            { false, false, false, true, true, true, false, false },
            { false, false, true, false, false, false, false, false },
            { false, false, true, false, false, false, false, false },
            { false, false, true, true, true, false, false, false },
            { false, false, true, false, false, true, false, false },
            { false, false, false, true, true, true, false, false},
            { false, false, false, false, false, false, false, false }
         };


        public static bool[,] sept = new bool[8, 8]
         {
            { false, false, false, false, false, false, false, false },
            { false, false, true, true, true, false, false, false },
            { false, false, false, false, true, false, false, false },
            { false, false, false, false, true, false, false, false },
            { false, false, false, true, true, false, false, false },
            { false, false, false, false, true, false, false, false },
            { false, false, false, false, true, false, false, false },
            { false, false, false, false, false, false, false, false }
         };

        public static bool[,] huit = new bool[8, 8]
        {
            {false, false, false, false, false, false, false, false},
            {false, false, false, true, true, false, false, false},
            {false, false, true, false, false, true, false, false},
            {false, false, false, true, true, false, false, false},
            {false, false, true, false, false, true, false, false},
            {false, false, true, false, false, true, false, false},
            {false, false, false, true, true, false, false, false},
            {false, false, false, false, false, false, false, false}
        };

        public static bool[,] neuf = new bool[8, 8]
        {
            {false, false, false, false, false, false, false, false},
            {false, false, false, true, true, false, false, false},
            {false, false, true, false, false, true, false, false},
            {false, false, true, false, false, true, false, false},
            {false, false, false, true, true, false, false, false},
            {false, false, false, false, false, true, false, false},
            {false, false, true, true, true, true, false, false},
            {false, false, false, false, false, false, false, false}
        };

        public static bool[,] croix = new bool[8, 8]
        {
            { true, false, false, false, false, false, false, true },
            { false, true, false, false, false, false, true, false },
            { false, false, true, false, false, true, false, false },
            { false, false, false, true, true, false, false, false },
            { false, false, false, true, true, false, false, false },
            { false, false, true, false, false, true, false, false },
            { false, true, false, false, false, false, true, false },
            { true, false, false, false, false, false, false, true }
        };

    }
}