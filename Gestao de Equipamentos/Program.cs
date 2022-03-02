using System;

namespace Gestao_de_Equipamentos
{
    

    internal class Program
    {
        static string[] nomeEquipamento = new string[1000];
        static decimal[] precoAquisicaoEquipamento = new decimal[1000];
        static string[] numeroSerieEquipamento = new string[1000];
        static string[] dataFabricacao = new string[1000];
        static string[] nomeFabricante = new string[1000];

        static string[] tituloChamado = new string[1000];
        static string[] descricaoChamado = new string[1000];
        static string[] equipamentoChamado = new string[1000];
        static DateTime[] dataDeAberturaChamado = new DateTime[1000];
        static int[] posicaoEmArrayDeEquipamentosDoItemNoChamado = new int[1000]; //cria link direto entre arrays de equipamentos e chamados
        
        static int contadorQuantidadeDeEquipamentos = 0;
        static int contadorQuantidadeDeChamados = 0;

        static int opcaoMenu; 

        static int DescobrirPosicaoNaArrayPeloTitulo(string titulo)
        {
            int posicaoChamadoASerEditado = 0;
            int contadorTitulosIguais = 0;
            int[] x = new int[1000];
            
           
            
            for (int i = 0; i<contadorQuantidadeDeChamados; i++)
            {
                if (tituloChamado[i] == titulo)
                {
                    contadorTitulosIguais++; 
                }

            }

              //Caso exista mais de uma entrada com esse título
            int opcaoParaEscolher = 0;
            if (contadorTitulosIguais >= 2)
            {
              Console.WriteLine();
              Console.WriteLine("Qual entrada de chamado você quer editar? ");
               for (int i = 0; i < contadorQuantidadeDeChamados; i++)
               {
                  if (tituloChamado[i] == titulo)
                  {
                    opcaoParaEscolher++;
                    Console.WriteLine();
                    Console.WriteLine("ENTRADA NÚMERO " + opcaoParaEscolher);
                    Console.WriteLine("Título: " + tituloChamado[i]);
                    Console.WriteLine("Descrição: " + descricaoChamado[i]);
                    Console.WriteLine("Equipamento: " + equipamentoChamado[i]);
                    Console.WriteLine("Data Abertura: " + dataDeAberturaChamado[i].ToShortDateString());
                    x[opcaoParaEscolher] = i;

                  }
               }

                Console.WriteLine();
                Console.WriteLine("Digite a opção desejada: ");
                int opcaoDesejadaEntreTitulosIguais = Int32.Parse(Console.ReadLine());
                posicaoChamadoASerEditado = x[opcaoDesejadaEntreTitulosIguais];
                return posicaoChamadoASerEditado;
            }

              if (contadorTitulosIguais == 1)
              {
                 for (int i = 0; i < contadorQuantidadeDeChamados; i++)
                 {
                    if (tituloChamado[i] == titulo)
                    {
                       posicaoChamadoASerEditado = i;
                        return posicaoChamadoASerEditado;
                    }
                 }
              }

              if (contadorTitulosIguais == 0)
              {
                Console.WriteLine();
                Console.WriteLine("Título não cadastrado. Voltando ao menu de manutenção.");
                return -1;
              }
              return posicaoChamadoASerEditado;
        }

        static void ExcluirElementoArrayDateTime(ref DateTime[] vetorOriginal, DateTime[] novoVetor, int posicao)
        {
            int j = 0;
            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                novoVetor[j] = vetorOriginal[i];
                if (i != posicao)
                {
                    j++;

                }
            }

            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                vetorOriginal[i] = novoVetor[i];
            }
        }
       
        static void ExcluirChamadoMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o título do Chamado a ser excluído: ");
            Console.WriteLine("Digite sair para voltar ao Menu de Manutenção.");
            string titulo = Console.ReadLine();

            if (titulo == "sair" || titulo == "Sair" || titulo == "SAIR")
            {
                MenuDeManutencao();
                Console.Clear();
            }

            int posicaoChamadoASerExcluido = DescobrirPosicaoNaArrayPeloTitulo(titulo);

            //Cria novas Arrays para serem substituirem as posições das originais
            string[] novaArrayTituloChamado = new string[1000];
            string[] novaArrayDescricaoChamado = new string[1000];
            string[] novaArrayEquipamentoChamado = new string[1000];
            DateTime[] novaArrayDataDeAberturaChamado = new DateTime[1000];

            //Executa método para exclusão
            ExcluirElementoArrayString(ref tituloChamado, novaArrayTituloChamado, posicaoChamadoASerExcluido);
            ExcluirElementoArrayString(ref descricaoChamado, novaArrayDescricaoChamado, posicaoChamadoASerExcluido);
            ExcluirElementoArrayString(ref equipamentoChamado, novaArrayEquipamentoChamado, posicaoChamadoASerExcluido);
            ExcluirElementoArrayDateTime(ref dataDeAberturaChamado, novaArrayDataDeAberturaChamado, posicaoChamadoASerExcluido);

            contadorQuantidadeDeChamados--;

        } 
       
        static bool EditarChamado()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o título do chamado a ser editado: ");
            Console.WriteLine("Digite sair para voltar ao Menu de Manutenção.");
            string titulo = Console.ReadLine();

            if (titulo == "sair" || titulo == "Sair" || titulo == "SAIR")
            {
                MenuDeManutencao();
                Console.Clear();
                return true;     //Finaliza execução do metodo
            } 

           int posicaoChamadoASerEditado = DescobrirPosicaoNaArrayPeloTitulo(titulo);
            if(posicaoChamadoASerEditado == -1){
                MenuPrincipal();
                return true;
            }


            Console.WriteLine();
            Console.WriteLine("O que você deseja editar?");
            Console.WriteLine("1 - Título do chamado");
            Console.WriteLine("2 - Descrição");
            Console.WriteLine("3 - Equipamento");
            Console.WriteLine("4 - Data de Abertura");
            Console.WriteLine("5 - Voltar");
            int opcao = Int32.Parse(Console.ReadLine());

            while(opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5)
            {
                Console.WriteLine();
                Console.WriteLine("O que você deseja editar?");
                Console.WriteLine("1 - Título do chamado");
                Console.WriteLine("2 - Descrição");
                Console.WriteLine("3 - Equipamento");
                Console.WriteLine("4 - Data de Abertura");
                Console.WriteLine("5 - Voltar");
                Console.WriteLine("Opção inválida. Digite novamente: ");
                opcao = Int32.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Título Atual: " + tituloChamado[posicaoChamadoASerEditado]);
                    Console.Write("Novo Título: ");
                    tituloChamado[posicaoChamadoASerEditado] = Console.ReadLine();  
                   
                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Descrição Atual: " + descricaoChamado[posicaoChamadoASerEditado]);
                    Console.Write("Nova Descrição: ");
                    descricaoChamado[posicaoChamadoASerEditado] = Console.ReadLine();
                   
                    break;

                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Equipamento Atual: " + equipamentoChamado[posicaoChamadoASerEditado]);
                    Console.WriteLine("Novo Equipamento: ");
                    string inputNovoEquipamentoEdicao = Console.ReadLine();
                    
                    for(int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
                    {
                       if(inputNovoEquipamentoEdicao == nomeEquipamento[i])
                        {
                            equipamentoChamado[posicaoChamadoASerEditado] = inputNovoEquipamentoEdicao;
                            break;
                        } 
                       if(i == contadorQuantidadeDeEquipamentos - 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Equipamento não existente no inventário. Voltando ao menu de edição de chamado.");
                            EditarChamado();
                        }
                    }

                    break;

                case 4:
                    Console.WriteLine();
                    Console.WriteLine("Data de Abertura Atual: " + dataDeAberturaChamado[posicaoChamadoASerEditado].ToShortDateString());
                    Console.Write("Nova Data de Abertura: ");
                    string strDataAbertura = Console.ReadLine();
                    char[] ch = strDataAbertura.ToCharArray();

                    while (strDataAbertura.Length != 10)
                    {
                        Console.WriteLine("Data inválida. Digite novamente (dd/mm/aaaa): ");
                        strDataAbertura = Console.ReadLine();
                        ch = strDataAbertura.ToCharArray();
                    }

                    while (ch[2] != '/' && ch[5] != '/')
                    {
                        Console.WriteLine("Data inválida. Digite novamente (dd/mm/aaaa): ");
                        strDataAbertura = Console.ReadLine();
                        ch = strDataAbertura.ToCharArray();
                    }



                    DateTime dataAbertura = Convert.ToDateTime(strDataAbertura);
                    dataDeAberturaChamado[posicaoChamadoASerEditado] = dataAbertura;


                    break;

                  case 5:
                    MenuDeManutencao();
                    break;
                    
            }
               return true;
        }
        
        static void VisualizarChamados()
        {
           
          
            double[] dias = new double[1000];
            for (int i = 0; i < contadorQuantidadeDeChamados; i++) { 
           TimeSpan  diferenca = DateTime.Today - dataDeAberturaChamado[i];
                dias[i] = diferenca.TotalDays;
            }

            Console.WriteLine(" Título".PadRight(27) + "Descrição".PadRight(36) + "Equipamento".PadRight(21) + "Data Abertura".PadRight(19) + "Dias em Aberto".PadRight(15));
            for (int i = 0; i < contadorQuantidadeDeChamados; i++)
            {
                Console.WriteLine("|" + tituloChamado[i].PadRight(25) + "|" + descricaoChamado[i].PadRight(35) + "|" + equipamentoChamado[i].PadRight(20) + "|" + dataDeAberturaChamado[i].ToShortDateString().PadLeft(18) + "| " + dias[i].ToString().PadLeft(14) + "|");
            }
        } 
        
        static bool IniciarChamado()
        {
            Console.WriteLine();
            Console.WriteLine("Econtrar equipamento para iniciar chamado pelo seu: ");
            Console.WriteLine("1 - Número na lista do inventário");
            Console.WriteLine("2 - Número de série");
            Console.WriteLine("Digite 0 para voltar ao Menu de Manutenção.");
            int opcao = Int32.Parse(Console.ReadLine());

            if (opcao == 0)
            {
                MenuDeManutencao();
                return true;
            }

            switch (opcao)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Qual o número no inventario do equipamento a ser mandado para manutenção: ");
                    int posicaoNoInventarioDoEquipamentoEmChamado = Int32.Parse(Console.ReadLine());
                    
                    if (posicaoNoInventarioDoEquipamentoEmChamado == 0)
                    {
                        MenuDeManutencao();
                        return true;
                    }

                    posicaoNoInventarioDoEquipamentoEmChamado--;
                    
              


                    if (nomeEquipamento[posicaoNoInventarioDoEquipamentoEmChamado] == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Número inválido. Retornando ao Menu Principal.");
                        MenuPrincipal();
                        return true;
                    }

                    //Armazena a posição para existir link entre Equipamento na lista de Equipamentos e Equipamentos na Lista de Chamados
                    posicaoEmArrayDeEquipamentosDoItemNoChamado[contadorQuantidadeDeChamados] = posicaoNoInventarioDoEquipamentoEmChamado;

                    equipamentoChamado[contadorQuantidadeDeChamados] = nomeEquipamento[posicaoNoInventarioDoEquipamentoEmChamado];
                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Digite o número de série do equipamento: ");
                    string numeroDeSerieParaIniciarChamado = Console.ReadLine();
                    int posicaoEquipamento = 0;
                    for(int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
                    {
                        if (numeroSerieEquipamento[i] == numeroDeSerieParaIniciarChamado)
                        {
                            posicaoEquipamento = i;
                  
                         //Armazena a posição para existir link entre Equipamento na lista de Equipamentos e Equipamentos na Lista de Chamados
                            posicaoEmArrayDeEquipamentosDoItemNoChamado[contadorQuantidadeDeChamados] = posicaoEquipamento;
                            break;
                        }

                        if (i == (contadorQuantidadeDeEquipamentos - 1))
                        {
                            Console.WriteLine("Número de série não está cadastrado no inventário. Retornando ao menu principal.");
                            MenuPrincipal();
                            return true;
                        }
                    }
                    equipamentoChamado[contadorQuantidadeDeChamados] = nomeEquipamento[posicaoEquipamento];
                    break;
            }

            Console.WriteLine("Digite o título do chamado: ");
            tituloChamado[contadorQuantidadeDeChamados] = Console.ReadLine();
            Console.WriteLine("Digite a descrição do chamado: ");
            descricaoChamado[contadorQuantidadeDeChamados] = Console.ReadLine();
            Console.WriteLine("Digite a data de abertura do chamado(dd/mm/aaaa): ");
           
            string strDataAbertura = Console.ReadLine();
            char[] ch = strDataAbertura.ToCharArray();

            while (strDataAbertura.Length != 10)
            {
                Console.WriteLine("Data inválida. Digite novamente (dd/mm/aaaa): ");
                strDataAbertura = Console.ReadLine();
                ch = strDataAbertura.ToCharArray();
            }
               
            while (ch[2] != '/' && ch[5] != '/')
                {
                    Console.WriteLine("Data inválida. Digite novamente (dd/mm/aaaa): ");
                    strDataAbertura = Console.ReadLine();
                    ch = strDataAbertura.ToCharArray();
                }
            
            
           
            DateTime dataAbertura = Convert.ToDateTime(strDataAbertura);
            dataDeAberturaChamado[contadorQuantidadeDeChamados] = dataAbertura;

            contadorQuantidadeDeChamados++;

            return true;
        } 
        

        static void ExcluirElementoArrayDecimal(ref decimal[] vetorOriginal, decimal[] novoVetor, int posicao)
        {
            int j = 0;
            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                novoVetor[j] = vetorOriginal[i];
                if (i != posicao)
                {
                    j++;

                }
            }

            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                vetorOriginal[i] = novoVetor[i];
            }
        }
        static void ExcluirElementoArrayString(ref string[] vetorOriginal, string[] novoVetor, int posicao)
        {
            int j = 0;
            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                novoVetor[j] = vetorOriginal[i];
                if (i != posicao)
                {
                    j++;
             
                }
            }

            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                vetorOriginal[i] = novoVetor[i];
            }
        }
        static void ExcluirEquipamento(int posicaoEquipamentoQueVaiSerExcluido)
        {
           
          

            //Cria novas Arrays para serem substituirem as posições das originais
            string[] novaArrayNomeEquipamento = new string[1000];
            decimal[] novaArrayPrecoAquisicao = new decimal[1000];
            string[] novaArrayNumeroDeSerie = new string[1000];
            string[] novaArrayDataFabricacao = new string[1000];
            string[] novaArrayNomeFabricante = new string[1000];

            //Executa método para exclusão
            ExcluirElementoArrayString(ref nomeEquipamento, novaArrayNomeEquipamento, posicaoEquipamentoQueVaiSerExcluido);
            ExcluirElementoArrayDecimal(ref precoAquisicaoEquipamento, novaArrayPrecoAquisicao, posicaoEquipamentoQueVaiSerExcluido);
            ExcluirElementoArrayString(ref numeroSerieEquipamento, novaArrayNumeroDeSerie, posicaoEquipamentoQueVaiSerExcluido);
            ExcluirElementoArrayString(ref dataFabricacao, novaArrayDataFabricacao,  posicaoEquipamentoQueVaiSerExcluido);
            ExcluirElementoArrayString(ref nomeFabricante, novaArrayNomeFabricante, posicaoEquipamentoQueVaiSerExcluido);
         

            contadorQuantidadeDeEquipamentos--;
        
        }   
        static bool ExcluirEquipamentoMenu()
        {
            int opcao = 0;

            Console.WriteLine("Encontrar equipamento pelo: ");
            Console.WriteLine("1 - Número no inventário");
            Console.WriteLine("2 - Número de série");
            Console.WriteLine("3 - Voltar");
            opcao = Int32.Parse(Console.ReadLine());
            if(opcao == 3)
            {
                MenuDeEquipamentos();
                return true;
            }

            while (opcao != 1 && opcao != 2 && opcao != 3)
            {
                Console.WriteLine("Encontrar equipamento pelo: ");
                Console.WriteLine("1 - Número no inventário");
                Console.WriteLine("2 - Número de série");
                Console.WriteLine("3 - Voltar");
                Console.WriteLine("Opção inválida. Digite novamente: ");
                opcao = Int32.Parse(Console.ReadLine());
                if (opcao == 3)
                {
                    MenuDeEquipamentos();
                    return true;
                }
            }
            switch (opcao)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Digite o número do equipamento no inventário: ");
                    int numeroNoInventarioDoEquipamentoQueVaiSerExcluido = Int32.Parse(Console.ReadLine());
                    numeroNoInventarioDoEquipamentoQueVaiSerExcluido--;
                    for (int i = 0; i < contadorQuantidadeDeChamados; i++)
                    {
                        if(nomeEquipamento[numeroNoInventarioDoEquipamentoQueVaiSerExcluido] == equipamentoChamado[i])
                        {
                            Console.WriteLine();
                            Console.WriteLine("Equipamento está vinculado com entrada de manutenção e por isso não pode ser excluído. Retornando ao Menu Principal.");
                            MenuPrincipal();
                            return true;
                        }
                    }
                    
                    ExcluirEquipamento(numeroNoInventarioDoEquipamentoQueVaiSerExcluido);
                    break;

                case 2:
                    Console.WriteLine("Digite o número de série do equipamento: ") ;
                    string numeroSerieEquipamentoQueVaiSerExcluido = Console.ReadLine();
                    int posicaoEquipamentoQueVaiSerExcluido = 0;
                   
                    for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
                    {
                        if (numeroSerieEquipamento[i] == numeroSerieEquipamentoQueVaiSerExcluido)
                        {
                            posicaoEquipamentoQueVaiSerExcluido = i;
                            
                        }

                        if (i == (contadorQuantidadeDeEquipamentos))
                        {
                            Console.WriteLine("Número de série não está cadastrado no inventário. Retornando ao menu principal.");
                            MenuPrincipal();
                            return true;
                        }
                    }

                    for (int i = 0; i < contadorQuantidadeDeChamados; i++)
                    {
                        if (nomeEquipamento[posicaoEquipamentoQueVaiSerExcluido] == equipamentoChamado[i])
                        {
                            Console.WriteLine();
                            Console.WriteLine("Equipamento está vinculado com entrada de manutenção e por isso não pode ser excluído. Retornando ao Menu Principal.");
                            MenuPrincipal();
                            return true;
                        }
                    }

                    ExcluirEquipamento(posicaoEquipamentoQueVaiSerExcluido);
                    break;

                case 3:
                    MenuDeEquipamentos();
                    break;
                  
            }
            return true;
        }
        
        static bool DescobrirEquipamentoPeloNumeroDeSerie(int opcaoItemParaEditar, string numeroSerieEquipamentoQueVaiSerEditado)
        {

            int posicaoEquipamentoQueVaiSerEditado = 0;
            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                if (numeroSerieEquipamento[i] == numeroSerieEquipamentoQueVaiSerEditado)
                {
                    posicaoEquipamentoQueVaiSerEditado = i;
                    break;
                }

                if(i == (contadorQuantidadeDeEquipamentos))
                {
                    Console.WriteLine("Número de série não está cadastrado no inventário. Retornando ao menu principal.");
                    MenuPrincipal();
                    return true;
                }
            }

            EditarEquipamento(opcaoItemParaEditar, posicaoEquipamentoQueVaiSerEditado);

            return true;
            
        }
        static void EditarEquipamento(int opcaoItemParaEditar, int posicaoEquipamentoQueVaiSerEditado)
            {
                
            
            switch (opcaoItemParaEditar)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Nome Atual: " + nomeEquipamento[posicaoEquipamentoQueVaiSerEditado]);
                        Console.Write("Novo nome: ");
                        string novoNomeEquipamento = Console.ReadLine();

                        int tamanhoString = novoNomeEquipamento.Length;
                        //Caso nome do equipamento não tenha no mínimo 6 caracteres
                        if (tamanhoString < 6)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Nome do equipamento deve ter no mínimo 6 caracteres. Digite novamente: ");
                            novoNomeEquipamento = Console.ReadLine();
                        }

                   //Caso equipamento esteja vinculado com algum chamado, atualiza nome no chamado também
                    for (int i = 0; i < contadorQuantidadeDeChamados; i++) {
                        if (posicaoEquipamentoQueVaiSerEditado == posicaoEmArrayDeEquipamentosDoItemNoChamado[i])
                        {
                            equipamentoChamado[posicaoEmArrayDeEquipamentosDoItemNoChamado[i]] = novoNomeEquipamento;
                        }
                    }

                    nomeEquipamento[posicaoEquipamentoQueVaiSerEditado] = novoNomeEquipamento;

                    break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Preço de aquisição Atual: " + precoAquisicaoEquipamento[posicaoEquipamentoQueVaiSerEditado]);
                        Console.Write("Novo preço: ");
                        precoAquisicaoEquipamento[posicaoEquipamentoQueVaiSerEditado] = decimal.Parse(Console.ReadLine());
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Numero de série atual: " + numeroSerieEquipamento[posicaoEquipamentoQueVaiSerEditado]);
                        Console.Write("Novo número de série: ");
                        numeroSerieEquipamento[posicaoEquipamentoQueVaiSerEditado] = Console.ReadLine();
                    for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
                    {
                        while (numeroSerieEquipamento[contadorQuantidadeDeEquipamentos] == numeroSerieEquipamento[i])
                        {
                            Console.WriteLine("Número de série já está cadastrado. Digite outro: ");
                            numeroSerieEquipamento[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                        }
                    }
                    break;

                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Data de fabricação atual: " + dataFabricacao[posicaoEquipamentoQueVaiSerEditado]);
                        Console.Write("Nova Data de Fabricação: ");
                        dataFabricacao[posicaoEquipamentoQueVaiSerEditado] = Console.ReadLine();
                        break;

                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("Nome do Fabricante atual: " + nomeFabricante[posicaoEquipamentoQueVaiSerEditado]);
                        Console.Write("Novo nome do fabricante: ");
                        nomeFabricante[posicaoEquipamentoQueVaiSerEditado] = Console.ReadLine();
                        break;

                }
            }
        static bool EditarEquipamentoMenu()
            {
                int opcao = 0;
           
                   Console.WriteLine();
                   Console.WriteLine("Econtrar equipamento pelo: ");
                   Console.WriteLine("1 - Número no inventário");
                   Console.WriteLine("2 - Número de série");
                   Console.WriteLine("3 - Voltar");
                   opcao = Int32.Parse(Console.ReadLine());
          
            if(opcao == 3)
            {
                MenuDeEquipamentos();
                return true;
            }
           

            while (opcao != 1 && opcao != 2 && opcao != 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Econtrar equipamento pelo: ");
                    Console.WriteLine("1 - Número no inventário");
                    Console.WriteLine("2 - Número de série");
                    Console.WriteLine("3 - Voltar");
                    Console.WriteLine("Opção inválida. Digite novamente: ");
                    opcao = Int32.Parse(Console.ReadLine());
                if (opcao == 3)
                {
                    MenuDeEquipamentos();
                    return true;
                }
            }
           

            Console.WriteLine();
                Console.WriteLine("O que você quer editar? ");
                Console.WriteLine("1 - Nome do equipamento");
                Console.WriteLine("2 - Preço de aquisição");
                Console.WriteLine("3 - Número de série");
                Console.WriteLine("4 - Data de Fabricação");
                Console.WriteLine("5 - Nome do Fabricante");
                
                int opcaoItemParaEditar = Int32.Parse(Console.ReadLine());
              
            
               
               while (opcaoItemParaEditar != 1 && opcaoItemParaEditar != 2 && opcaoItemParaEditar != 3 && opcaoItemParaEditar != 4 && opcaoItemParaEditar != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("O que você quer editar? ");
                    Console.WriteLine("1 - Nome do equipamento");
                    Console.WriteLine("2 - Preço de aquisição");
                    Console.WriteLine("3 - Número de série");
                    Console.WriteLine("4 - Data de Fabricação");
                    Console.WriteLine("5 - Nome do Fabricante");
                       
                    Console.WriteLine("Opção inválida. Digite novamente: ");
                    opcaoItemParaEditar = Int32.Parse(Console.ReadLine());
               

            }


                switch (opcao)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Digite o número do equipamento no inventário: ");
                        int numeroNoInventarioDoEquipamentoQueVaiSerEditado = Int32.Parse(Console.ReadLine());
                        numeroNoInventarioDoEquipamentoQueVaiSerEditado--;
                        int posicaoEquipamentoQueVaiSerEditado = numeroNoInventarioDoEquipamentoQueVaiSerEditado;

                        EditarEquipamento(opcaoItemParaEditar, posicaoEquipamentoQueVaiSerEditado);

                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Digite o número de série do equipamento: ");
                        string numeroSerieEquipamentoParaEditar = Console.ReadLine();

                        DescobrirEquipamentoPeloNumeroDeSerie(opcaoItemParaEditar, numeroSerieEquipamentoParaEditar);

                        break;

                case 3:
                    MenuDeEquipamentos();
                    break;
                }
            return true;

            }

        static void VisualizarEquipamentosCadastrados()
            {

                string[] precoEquipamentoString = new string[1000];
                int numeroEquipamentoNoInventario = 1;
                Console.WriteLine();
                Console.WriteLine("     " + "Equipamento".PadRight(26) + "Preço".PadRight(9) + "Nr de série".PadRight(16) + "Data Fabricaçao".PadRight(17) + "Nome do Fabricante");

                //Transforma preço em String para poder printar na tela usando comando PadRight()
                for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
                {
                    precoEquipamentoString[i] = precoAquisicaoEquipamento[i].ToString("0.00");
                }

                string numeroEquipamentonoInventarioString;
                for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
                {
                    numeroEquipamentonoInventarioString = numeroEquipamentoNoInventario.ToString();
                    Console.WriteLine("|" + numeroEquipamentonoInventarioString.PadRight(3) + "|" + nomeEquipamento[i].PadRight(25) + "|" + precoEquipamentoString[i].PadLeft(8) + "|" + numeroSerieEquipamento[i].PadLeft(15) + "|" + dataFabricacao[i].PadLeft(16) + "|" + nomeFabricante[i].PadLeft(20) + "|");
                    numeroEquipamentoNoInventario++;
                }
            }

        static void CadastrarNovoEquipamento()
            {
                Console.WriteLine();
                Console.WriteLine("Digite o nome do equipamento (mín 6 caracteres): ");
                nomeEquipamento[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                int tamanhoString = nomeEquipamento[contadorQuantidadeDeEquipamentos].Length;
                //Caso nome do equipamento não tenha no mínimo 6 caracteres
                while (tamanhoString < 6)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nome do equipamento deve ter no mínimo 6 caracteres. Digite novamente: ");
                    nomeEquipamento[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                    tamanhoString = nomeEquipamento[contadorQuantidadeDeEquipamentos].Length;
            }

                Console.WriteLine("Digite o preço de aquisição: ");
                precoAquisicaoEquipamento[contadorQuantidadeDeEquipamentos] = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Digite o número de série: ");
                numeroSerieEquipamento[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
                {
                    while (numeroSerieEquipamento[contadorQuantidadeDeEquipamentos] == numeroSerieEquipamento[i])
                    {
                        Console.WriteLine("Número de série já está cadastrado. Digite outro: ");
                        numeroSerieEquipamento[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                    }
                }
                Console.WriteLine("Digite a data de fabricação: ");
                dataFabricacao[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                Console.WriteLine("Digite o nome do fabricante: ");
                nomeFabricante[contadorQuantidadeDeEquipamentos] = Console.ReadLine();

                contadorQuantidadeDeEquipamentos++;
            }


            static void MenuDeManutencao()
            {
                int opcao = 0;
                Console.WriteLine();
                Console.WriteLine("1 - Iniciar chamado");
                Console.WriteLine("2 - Visualizar chamados");
                Console.WriteLine("3 - Editar chamado");
                Console.WriteLine("4 - Excluir chamado");
                Console.WriteLine("5 - Voltar");
                
                opcao = Int32.Parse(Console.ReadLine());
                Console.Clear();

            while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5)
                {
                    Console.WriteLine("1 - Iniciar chamado");
                    Console.WriteLine("2 - Visualizar chamados");
                    Console.WriteLine("3 - Editar chamado");
                    Console.WriteLine("4 - Excluir chamado");
                    Console.WriteLine("5 - Voltar");
                    Console.WriteLine("Opção inválida. Digite novamente: ");
                    
                    opcao = Int32.Parse(Console.ReadLine());
                    Console.Clear();
            }

                switch (opcao)
                {
                    case 1:
                        IniciarChamado();
                        break;

                    case 2:
                        VisualizarChamados();
                        break;

                    case 3:
                        EditarChamado();
                        break;

                    case 4:
                        ExcluirChamadoMenu();
                        break;
                    case 5:
                        MenuPrincipal();
                        break;

                }
                    
            }

            static void MenuDeEquipamentos()
            {
                int opcao = 0;

                Console.WriteLine();
                Console.WriteLine("1 - Cadastrar novo equipamento");
                Console.WriteLine("2 - Visualizar esquipamentos cadastrados");
                Console.WriteLine("3 - Editar equipamento");
                Console.WriteLine("4 - Excluir equipamento");
                Console.WriteLine("5 - Voltar");
                opcao = Int32.Parse(Console.ReadLine());
                Console.Clear();

            while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Cadastrar novo equipamento");
                    Console.WriteLine("2 - Visualizar esquipamentos cadastrados");
                    Console.WriteLine("3 - Editar equipamento");
                    Console.WriteLine("4 - Excluir equipamento");
                    Console.WriteLine("5 - Voltar");
                    Console.WriteLine("Opção inválida, digite novamente: ");
                    opcao = Int32.Parse(Console.ReadLine());
                    Console.Clear();
            }

                switch (opcao)
                {
                    case 1:
                        CadastrarNovoEquipamento();
                        break;

                    case 2:
                        VisualizarEquipamentosCadastrados();
                        break;

                    case 3:
                        EditarEquipamentoMenu();
                        break;

                    case 4:
                        ExcluirEquipamentoMenu();
                        break;
                    case 5:
                        MenuPrincipal();
                        break;
                }
            }

            static void MenuPrincipal()
            {
                
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Menu de gerenciamento de equipamentos");
                    Console.WriteLine("2 - Menu de chamados");
                    Console.WriteLine("3 - Sair do programa");
                    
                    opcaoMenu = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                //Caso opção seja inválida
                while (opcaoMenu != 1 && opcaoMenu != 2 && opcaoMenu != 3)
                    {

                        Console.WriteLine();
                        Console.WriteLine("1 - Menu de gerenciamento equipamentos");
                        Console.WriteLine("2 - Menu de chamado");
                        Console.WriteLine("Opção inválida, digite novamente: ");
                        Console.WriteLine();
                        
                        opcaoMenu = Int32.Parse(Console.ReadLine());
                        Console.Clear();

                }

                    //Caso opção seja válida
                    if (opcaoMenu == 1)
                    {
                        MenuDeEquipamentos();
                    }
                    if (opcaoMenu == 2)
                    {
                        MenuDeManutencao();
                    }
                } while (opcaoMenu != 3);

            }

            static void Main(string[] args)
            {
                MenuPrincipal();

            }
        }
    
    }






