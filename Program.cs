bool empezar = true;

while (empezar)
{
    Console.WriteLine("***************  TIC-TAC-TOE GAME ***************\n");

    // Crear Tabla
    char[,] tablero = new char[,]
    {
    {'1','2','3'},
    {'4','5','6'},
    {'7','8','9'}
    };
   

    imprimirTablero(tablero);

    string JugadorN = "Jugador1";
    char jugadorActual;

    while (true)
    {
        jugadorActual = JugadorN.Equals("Jugador1") ? 'X' : 'O';

        Console.WriteLine($"> {JugadorN}, elige una posición (1-9)");
        string? valor = Console.ReadLine();

        if (int.TryParse(valor, out int numero))
        {
            if (numero <= 0 || numero >= 10)
            {
                Console.WriteLine("----- Error : Ingrese un valor valido entre 1-9 -----\n");
                continue;
            }

        }
        else
        {
            Console.WriteLine("----- Error :Ingrese un numero valido ------\n");
            continue;
        }

        ConsegirPosicion(numero, out int fila, out int columna);

        if (tablero[fila, columna] == 'X' || tablero[fila, columna] == 'O')
        {
            Console.WriteLine("-------- Casilla ocupada ---------\n");
            continue;

        }

        tablero[fila, columna] = jugadorActual;

        if (VerificarGanador(tablero))
        {
            imprimirTablero(tablero);
            Console.WriteLine($"        ******** {JugadorN}  gana!********* ");
            
            Console.WriteLine("Presione 1 para volver a jugar \n");
            string? continuar = Console.ReadLine();
            empezar = continuar.Equals("1") ? true : false;
            

            break;
        }
        else if (VerificarEmpate(tablero))
        {
            imprimirTablero(tablero);
            Console.WriteLine("     ************* Empate! *************\n");
            
            Console.WriteLine("Presione 1 para volver a jugar");
            string? continuar = Console.ReadLine();
            empezar = continuar.Equals("1") ? true : false;
            break;
        }

        imprimirTablero(tablero);
        JugadorN = JugadorN.Equals("Jugador1") ? "Jugador2" : "Jugador1";

    }



    void ConsegirPosicion(int posicion,out int fila, out int columna)
    {
        fila = (posicion - 1) / 3;
        columna = (posicion - 1) % 3;
    }

    void imprimirTablero(char[,] tablero)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.Write("                 ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($" {tablero[i, j]}  ");
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2)
            {
                Console.Write("                 ");
                Console.Write("-------------\n");
                
            }
        }
        Console.WriteLine();
        Console.WriteLine("     Jugador1 : X       |       Jugador2 : O \n");
     
    }

    bool VerificarEmpate(char[,] tablero)
    {
     foreach(char x in tablero)
        {
            if(x!='X' && x!='O')
            {
                return false;
            }
        }
        return true;
    }

    bool VerificarGanador(char[,] tablero)
    {
        for (int i=0; i<3;i++)
        {
            if (tablero[i, 0] == tablero[i, 1] && tablero[i, 1] == tablero[i, 2]) return true;
            if (tablero[0, i] == tablero[1, i] && tablero[1, i] == tablero[2, i]) return true;
        }
        if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2]) return true;
        if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0]) return true;
        return false;
    }


}

