namespace TargetSistemas.model
{
    public class FaturamentoMensal
    {
        public List<string>? listaEstado { get; set; }

        public List<decimal>? listaValores { get; set; }

        public decimal SomarTotal() {

            decimal total = 0;

            for (int i = 0; i < listaValores.Count; i++)
            {
                total += listaValores[i];
            }

            return total;
        }

        private List<decimal> porcentagemPorEstado(){
            decimal total = SomarTotal();
            decimal porcentagem = 0;

            List<decimal> listaPorcentagem = new List<decimal>();

            for (int i = 0; i < listaValores.Count; i++)
            {
                porcentagem = (listaValores[i]*100)/total;
                listaPorcentagem.Add(porcentagem);
            }
                
            return listaPorcentagem;
        }

        public void ExibirFaturamento() {

            var listaPorcentagem = porcentagemPorEstado();

            for (int i = 0; i < listaEstado.Count; i++)
            {
                Console.WriteLine($"Estado: {listaEstado[i]} - {listaPorcentagem[i].ToString("F")}%");
            }
            
        }
    }
}