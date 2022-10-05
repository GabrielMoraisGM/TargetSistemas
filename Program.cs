using TargetSistemas.model;

Calculo calc = new Calculo();


Menu menuPrincipal = new Menu();
List<string> itensMenuPrincipal = new List<string>();
itensMenuPrincipal.Add("Laço de repetição com soma");
itensMenuPrincipal.Add("Fibonacci");
itensMenuPrincipal.Add("Vetor da distribuidora");
itensMenuPrincipal.Add("Percentual de faturamento mensal por estado");
itensMenuPrincipal.Add("Inverte caracteres de uma string");
itensMenuPrincipal.Add("Sair");
menuPrincipal.ListaOpcoes = itensMenuPrincipal;
bool showMenu = false;

do
{
    Console.WriteLine("MENU DE RESPOSTAS");
    menuPrincipal.Listar();
    string? entradaMenu = Console.ReadLine();
    Int32.TryParse(entradaMenu, out int escolha);

    switch (escolha) 
    { 
        case 1:
            Console.Clear();
            calc.Soma();
            showMenu = true;
            break;

        case 2:
            Console.Clear();
            calc.Fibonacci();
            showMenu = true;
            break;

        case 3:

            FaturamentoModel ft = new FaturamentoModel();
            ft.Menu();

            break;

        case 4:
            FaturamentoMensal fatMensal = new FaturamentoMensal();
            List<string> listaEstado = new List<string>();
            List<decimal> listaValores = new List<decimal>();
            listaEstado.Add("SP");
            decimal valorSP = 67836.43M;
            listaValores.Add(valorSP);
            listaEstado.Add("RJ");
            decimal valorRJ = 36678.66M;
            listaValores.Add(valorRJ);
            listaEstado.Add("MG");
            decimal valorMG = 29229.88M;
            listaValores.Add(valorMG);
            listaEstado.Add("ES");
            decimal valorES = 27165.48M;
            listaValores.Add(valorES);
            listaEstado.Add("Outros");
            decimal valorOutros = 19849.53M;
            listaValores.Add(valorOutros);

            fatMensal.listaEstado = listaEstado;
            fatMensal.listaValores = listaValores;

            fatMensal.ExibirFaturamento();
            break;

        case 5:

            ReverteString reverse = new ReverteString();

            Console.WriteLine("Digite uma palavra para reverter: ");
            string? entrada = Console.ReadLine();
            reverse.palavra = entrada;
            reverse.reverterCaracteres();
            break;

        case 6:
            Environment.Exit(0);
            break;

        default:
            Console.Clear();
            Console.WriteLine($"Esta opção, não é válida");
            Console.ReadKey();
            showMenu = true;
            break;
    }
}
while (showMenu == true);






