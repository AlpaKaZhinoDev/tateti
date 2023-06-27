namespace Tateti
{
    class Program
    {
        static int[,] _tablero = new int[3,3];
        static char[] _simbolos = {'.','X','O'};

        static int _jugador = 1;

        static bool _finDelJuego = false;

        static void Main(string[] args)
        {
            while (!_finDelJuego)
            {
                ProcesarEntrada();
                Actualizar();
                Renderizar();    
            }
        } 

        private static void ProcesarEntrada()
        {
            PedirUnaEntradaAlUsuario();
        }

        private static void Actualizar()
        {
            ComprobarEstadoDelJuego();
            AlternarJugador();
        }

        private static void Renderizar()
        {
            DibujarTablero();
        }

        private static void AlternarJugador()
        {
            _jugador = _jugador == 1 ? 2 : 1;
        }

        private static void ComprobarEstadoDelJuego()
        {
            ComprobarSiHuboEmpate();
            ComprobarSiJugadorXGano(1);
            ComprobarSiJugadorXGano(2);
        }

        private static void ComprobarSiHuboEmpate()
        {
            bool empate = true;
            for (int fila = 0; fila < _tablero.GetLength(0); fila++)
            {
                for (int columna = 0; columna < _tablero.GetLength(1); columna++)
                {
                    if(_tablero[fila, columna] == 0)
                    {
                        empate = false;
                        break;
                    }
                }
            }
            if(empate)
            {
                _finDelJuego = true;
                Console.WriteLine("Empate");
            }
        }

        private static void ComprobarSiJugadorXGano(int jugador)
        {
            for(int fila = 0; fila < _tablero.GetLength(0); fila++)
            {
                bool gano = true;

                for (int columna = 0; columna < _tablero.GetLength(1); columna++)
                {
                    if(_tablero[fila, columna] != jugador) 
                    {
                        gano = false;
                    }
                }

                if(gano)
                {
                    _finDelJuego = true;
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Felicidades, gano el jugador " + jugador);
                    break;
                }
            }
            
            for(int columna = 0; columna < _tablero.GetLength(0); columna++)
            {
                bool gano = true;

                for (int fila = 0; fila < _tablero.GetLength(1); fila++)
                {
                    if(_tablero[fila, columna] != jugador) 
                    {
                        gano = false;
                    }
                }

                if(gano)
                {
                    _finDelJuego = true;
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("Felicidades, gano el jugador " + jugador);
                    break;
                }
            }
        }

        private static void DibujarTablero()
        {
            Console.WriteLine("---------------------------------------------");
            
            for(int fila = 0; fila < _tablero.GetLength(0); fila++)
            {
                for (int columna = 0; columna < _tablero.GetLength(1); columna++)
                {
                    Console.Write(_simbolos[ _tablero[fila, columna] ]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------------------");
        }

        private static void PedirUnaEntradaAlUsuario()
        {
            int fila, columna;

            Console.WriteLine("TURNO DEL JUGADOR " + _jugador);
            Console.WriteLine();

            while(true)
            {
                try
                {
                    Console.WriteLine("Ingrese la fila: ");
                    fila = Convert.ToInt32( Console.ReadLine() );

                    Console.WriteLine("Ingrese la columna: ");
                    columna = Convert.ToInt32( Console.ReadLine() );

                    if(fila > 3 || fila <1 || columna > 3 || columna < 1 || _tablero[fila, columna] != 0) 
                        throw new Exception();
                    
                    break;
                }
                catch
                {
                    Console.WriteLine("Ingrese valores validos");
                }
            }          
            _tablero[fila-1, columna-1] = _jugador;
        }
    }
}