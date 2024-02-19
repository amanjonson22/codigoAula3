using Microsoft.Win32.SafeHandles;



bool problemaArquivo = false;
string caminho_absoluto = "C:\\Users\\amand\\OneDrive\\Área de Trabalho\\Programação\\Cursos\\Faculdade\\Algoritmo e Programação II\\aula3\\codigoAula3\\contas.txt";
string caminho_relativo = "contas.txt";

string[] arquivo = File.ReadAllLines(caminho_absoluto);
int linhas = arquivo.Length;
string[,] contas = new string[linhas,3];

try {
    StreamReader sr = new StreamReader(caminho_absoluto);

    String linha_arq = sr.ReadLine();
    int linha_mtz = 0;
    int coluna_mtz = 0;
    
    while(linha_arq != null || linha_mtz <linhas){
        foreach (var conta in linha_arq.Split(",")){
            contas[linha_mtz,coluna_mtz] = conta;
            coluna_mtz++;
        }
        linha_arq = sr.ReadLine();
        coluna_mtz = 0;
        linha_mtz++;
    } 

    sr.Close();
} catch (Exception e){
    Console.WriteLine("Ocorreu um problema na leitura do arquivo");
    problemaArquivo = true;
}

for (int l = 0; l < linhas; l++){
    Console.WriteLine($"Usuário: {contas[l,0]}, senha: {contas[l,1]}, número da conta: {contas[l,2]}");
}


Console.WriteLine("Crie uma nova conta. Seu nome:");
string nome = Console.ReadLine();
Console.WriteLine("Senha:");
string senha = Console.ReadLine();

int qtdLinhas = contas.GetLength(0);
int qtdColunas = contas.GetLength(1);
int numContaAnterior;
int.TryParse(contas[qtdLinhas-1, qtdColunas-1], out numContaAnterior);

int numNovaConta = numContaAnterior + 1;


try{
    StreamWriter sw = new StreamWriter(caminho_absoluto);
    int linha_sobrescrever = arquivo.Length;

    for(int i = 0; i <arquivo.Length+1; i++){
        if (i == linha_sobrescrever)
            sw.WriteLine($"{nome}, {senha}, 000{numNovaConta}");
        else 
            sw.WriteLine(arquivo[i]);            
    }

    sw.Close();
} catch(Exception e){
    Console.WriteLine("Ocorreu um problema na escrita do arquivo");
}