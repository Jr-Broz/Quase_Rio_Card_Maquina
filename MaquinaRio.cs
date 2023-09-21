using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
public class MaquinaRio : Ifuncoes{

int DinheiroCedula;
int saldoCartaoUsuario;
int mostrarSaldo;
MaquinaRio praFunc1, praFunc2;

 Regex regexVisa = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$");

//Getters e Setters:
public void setDinheiroCedula(int novoDinheiroCedula ){

    DinheiroCedula = novoDinheiroCedula;
    
}

public int GetDinheiroCedula(){


    return DinheiroCedula;
}
public int getSaldo(){

    return mostrarSaldo;
}

public void setSaldo(int novoSaldo){

    mostrarSaldo = novoSaldo;
}

public int getSaldoCartaoUsuario(){

    return saldoCartaoUsuario;
}

//Implementando as funções da interface:
public void mostrarMenu(){

try { 
String resposta;

do{

        System.Console.WriteLine("Escolha uma Opção ");
        System.Console.WriteLine("[1] para Débito [2] Para Dinheiro  [3] Rara Sair");
        resposta = Console.ReadLine();

        switch(resposta){

            case "1":

            EscolherCartaoDebito(praFunc1);
            break;
        
            case "2":

            DepositarDinheiro(praFunc2);
            break;


            case "3":

            break;      
       }
}
while(resposta != "3");

}
catch{
        System.Console.WriteLine("Houve um erro.");
 }
} 

//Voltar e fazer essa parte dp
//Consertar problema de senha do banco
int deposito;
public void DepositarDinheiro(MaquinaRio Usuario){
 
 String resposta = "sim".ToLower();

    while(resposta != "nao") { 

   
    System.Console.WriteLine("Seu saldo atual é " + getSaldo());

    System.Console.WriteLine("Insira quanto deseja depositar, não utilize notas amassadas ou rasgadas.");

     deposito = Int32.Parse(Console.ReadLine());

    setSaldo(deposito + getSaldo());

    System.Console.WriteLine($"Voce depositou R$ {deposito}");
    System.Console.WriteLine($"Seu novo saldo é: " + "R$" + getSaldo());

    System.Console.WriteLine("Você deseja adicionar mais crédito ao cartão ? ");
     resposta = Console.ReadLine();

        if(resposta != "sim"){

            System.Console.WriteLine("Voltando ao menu principal, aguarde 2 segundos...");
            Thread.Sleep(2000);
        }


}
}

public  void EscolherCartaoDebito(MaquinaRio Usuario){
    
try {

    System.Console.WriteLine("Aguarde...");
        Thread.Sleep(5000);

        int valorMinimo = 10;
        int valorMaximo = 200;
        String SenhaDoCartao;    
        Random cartaoAleatorio = new Random();
        String recebeCartao = string.Empty;
        int valorBaseCartaoUsuario  = 10;

    System.Console.WriteLine("Quanto desejas inserir:  [Valor Mínimo R$10  || Valor Máximo: R$200]");
    int valorInputado = Int32.Parse(Console.ReadLine());

    if(valorInputado < valorMinimo){

        System.Console.WriteLine("É necessário colocar ao menos R$10 para poder recarregar o cartão RioCard");
        
        Thread.Sleep(2500);
        System.Console.WriteLine("Tente novamente, por favor.");
        Console.Clear();
    }
    
    else if(valorInputado > valorMaximo){

        Console.WriteLine("O valor Máximo que se pode adicionar é R$200 , Por favor, escolha outro valor.");
        Thread.Sleep(3000);
        Console.Clear();
    }
    else{
 
        System.Console.WriteLine("Aguarde novamente...");
        Thread.Sleep(2500);
    
    System.Console.WriteLine("Nos iremos gerar um número aleatório e este sera  usado como senha");

    for(int i = 0; i < 16; i++){

     recebeCartao  +=  cartaoAleatorio.NextInt64(0,9).ToString();
    }

    System.Console.WriteLine("----------------------------");
    System.Console.WriteLine(recebeCartao);
    System.Console.WriteLine("----------------------------");

    System.Console.WriteLine("Insira por favor a senha do Cartão: ");
        SenhaDoCartao = Console.ReadLine();

        saldoCartaoUsuario = 10;

    if(SenhaDoCartao == recebeCartao ){
         
         System.Console.WriteLine("Checando Dados...");
         Thread.Sleep(950);
         System.Console.WriteLine("Confirmando pedido..");
         Thread.Sleep(1000);
        System.Console.WriteLine("Transação Aceita");
    }
}
    
}catch{

    System.Console.WriteLine("Algo deu errado durante o pedido, por favor tente novamente.");
}
}
}