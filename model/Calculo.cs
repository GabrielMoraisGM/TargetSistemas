using Newtonsoft.Json;

namespace TargetSistemas.model
{
    public class Calculo
    {

        public void Soma()
        {
            int indice = 13;
            int soma = 0;
            int k = 0;

            while (k < indice)
            {
                k += 1;
                soma = soma + k;
            }
            Console.WriteLine($"O valor de (SOMA) será: {soma} \n");
        }

        public void Fibonacci()
        {

            bool repeteEntradaFibonacci = false;
            int atual = 0, proximo = 1, fibo;

            do{

                Console.WriteLine("Digite um número inteiro");
                bool sucesso = Int32.TryParse(Console.ReadLine(), out int numeroEntrada);

                if(sucesso){
                    for (int i = 0; i < numeroEntrada; i++)
                    {
                        fibo = proximo + atual;
                        atual = proximo;
                        proximo = fibo;

                        if (numeroEntrada == fibo)
                        {
                            Console.WriteLine($"\n O número {numeroEntrada}, ESTÁ presente em Fibonacci \n");
                            return;
                        }
                    }
                    Console.WriteLine($"\n O número {numeroEntrada}, NÃO está presente em Fibonacci \n");
                }
                else{
                    Console.WriteLine("Caractere inválido detectado, por favor digite um número inteiro");
                    repeteEntradaFibonacci = false;
                }
            }while(repeteEntradaFibonacci == true);
        }

        public void TotalFaturamento() { 
            
        }
    }
}