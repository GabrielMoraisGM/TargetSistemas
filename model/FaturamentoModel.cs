using Newtonsoft.Json;

namespace TargetSistemas.model
{

    public class FaturamentoModel
    {
        public int dia { get; set; }
        public double valor { get; set; }
        
        List<int> listaDiasNaoUteis = new List<int>();


        private static List<FaturamentoModel>? DesserializarLista(string caminho)
        {  
            
            List<FaturamentoModel>? faturamentos = null;
            
            try{
                using (StreamReader stream = new StreamReader(caminho))
                {
                    string jsonString = stream.ReadToEnd();
                    faturamentos = JsonConvert.DeserializeObject<List<FaturamentoModel>>(jsonString);
                }
                return faturamentos;
            }catch (JsonException e) {
                Console.WriteLine("Erro ao localizar o JSON " + e);
            }
            return faturamentos;
        }

        private static double CalcularMediaFaturamentoMensal(List<FaturamentoModel> lista)
        {

            int dias = 0;
            double media, soma = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                soma += lista[i].valor;
                dias += lista.Count;
            }

            media = soma / dias;

            return media;
        }

        public void AdicionarNaoUteisParaLista(int item)
        {
            listaDiasNaoUteis.Add(item);
        }

        private void RemoverNaoUteisParaLista(int item)
        {
            listaDiasNaoUteis.Remove(item);
        }

        private void gerarRelatorioConsolidado()
        {
            Console.WriteLine("Digite o caminho do arquivo JSON");
            string? caminhoJson = Console.ReadLine();
            List<FaturamentoModel>? faturamentos = DesserializarLista(caminhoJson);
            List<FaturamentoModel>? sortedDescending = faturamentos?.OrderByDescending(o => o.valor).ToList();
            List<FaturamentoModel>? sortedAscending = faturamentos?.OrderBy(o => o.valor).ToList();

            foreach (var itemListaDias in listaDiasNaoUteis)
            {
                for (int i = 0; i < faturamentos?.Count; i++)
                {
                    if (itemListaDias == faturamentos[i].dia)
                    {
                        faturamentos.Remove(faturamentos[itemListaDias]);
                        Console.WriteLine($"Dia {faturamentos[i].dia} - valor: R${faturamentos[i].valor} removido");
                    }
                }
            }

            double media = CalcularMediaFaturamentoMensal(sortedDescending);

            Console.WriteLine($"O menor valor de faturamento ocorrido em um dia do mês foi: {sortedAscending[0].valor}");
            Console.WriteLine($"O maior valor de faturamento ocorrido em um dia do mês foi: {sortedDescending[0].valor}");
            Console.WriteLine($"A media mensal foi: {media}");
        }

        private void MostrarLista()
        {
            foreach (var item in listaDiasNaoUteis)
            {
                Console.WriteLine($"Dia a ser removido da contagem do faturamento: {item}");
            }
        }
        public void Menu()
        {

            Menu menu = new Menu();
            bool showMenu = false;

            List<string> itensMenu = new List<string>();
            itensMenu.Add("Adicionar dias não úteis à lista de remoção");
            itensMenu.Add("Remover dias não úteis da lista de remoção");
            itensMenu.Add("Mostrar lista de remoção");
            itensMenu.Add("Gerar relatório de faturamento consolidado");
            itensMenu.Add("Sair");
            menu.ListaOpcoes = itensMenu;

            do
            {
                Console.WriteLine("MENU FATURAMENTO");
                menu.Listar();
                string? entradaMenu = Console.ReadLine();
                Int32.TryParse(entradaMenu, out int escolha);

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        AdicionarNaoUteisParaLista(ValidaEntrada());
                        showMenu = true;
                        break;

                    case 2:
                        Console.Clear();
                        RemoverNaoUteisParaLista(ValidaEntrada());
                        showMenu = true;
                        break;

                    case 3:
                        Console.Clear();
                        MostrarLista();
                        showMenu = true;
                        break;

                    case 4:
                        Console.Clear();
                        gerarRelatorioConsolidado();
                        showMenu = true;
                        break;

                    case 5:
                        Console.Clear();
                        Environment.Exit(0);
                        showMenu = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Esta opção, não é válida");
                        Console.ReadKey();
                        showMenu = true;
                        break;
                }
            } while (showMenu == true);
        }

        private static int ValidaEntrada()
        {

            Console.WriteLine("Digite o dia: ");
            string? entrada = Console.ReadLine();

            bool sucesso = Int32.TryParse(entrada, out int dia);

            if (sucesso)
            {
                return dia;
            }
            else
            {
                Console.WriteLine("Caractere inválido detectado");
                return 0;
            }
        }

    }
}


