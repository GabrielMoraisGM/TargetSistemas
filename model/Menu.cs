
namespace TargetSistemas.model
{
    public class Menu
    {
        public List<string>? ListaOpcoes { get; set; } 
        public void Adicionar(string opcao){
            ListaOpcoes?.Add(opcao);
        }

        public void Remover(string opcao){
            ListaOpcoes?.Remove(opcao);
        }

        public void Listar(){
            Console.WriteLine("\n Opções disponíveis: ");
            
            for (int i = 0; i < ListaOpcoes?.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {ListaOpcoes[i]}");
            }

        }
        
    }
}