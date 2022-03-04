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
        static int[] quantidadeDeVezesQueFoiParaManutencao = new int[1000];

        static string[] tituloChamado = new string[1000];
        static string[] descricaoChamado = new string[1000];
        static string[] equipamentoChamado = new string[1000];
        static string[] solicitanteChamado = new string[1000];
        static DateTime[] dataDeAberturaChamado = new DateTime[1000];
        static string[] situacaoChamado = new string[1000];
        static int[] posicaoEmArrayDeEquipamentosDoItemNoChamado = new int[1000]; //cria link direto entre arrays de equipamentos e chamados
        static int[] posicaoEmArraydeSolicitantesDePessoaQueIniciouChamado = new int[1000]; //cria link direto entre arrys de solicitantes e chamados

        static string[] nomeSolicitante = new string[1000];
        static string[] emailSolicitante = new string[1000];
        static string[] numeroTelefoneSolicitante = new string[1000];
        
        
        static int contadorQuantidadeDeEquipamentos = 0;
        static int contadorQuantidadeDeChamados = 0;
        static int contadorQuantidadeDeSolicitantes = 0;

        static int opcaoMenu;

        static bool ExcluirSolicitante()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o ID do Solicitante a ser excluído: ");
            Console.WriteLine("Digite 0 para voltar ao Menu de Solicitantes");
            int idSolicitanteParaExcluir = Int32.Parse(Console.ReadLine());
            int posicaoArraySolicitanteParaExcluir = idSolicitanteParaExcluir - 1;
            for (int i = 0; i < contadorQuantidadeDeChamados; i++)
            {
                if (posicaoArraySolicitanteParaExcluir == posicaoEmArraydeSolicitantesDePessoaQueIniciouChamado[i])
                {
                    Console.WriteLine();
                    Console.WriteLine("Solicitante está vinculado com entrada de manutenção e por isso não pode ser excluído. Retornando ao Menu Principal.");
                    MenuPrincipal();
                    return true;
                }
            }

            if (idSolicitanteParaExcluir == 0)
            {
                MenuSolicitante();
                return true;
            }
           
            while (idSolicitanteParaExcluir > contadorQuantidadeDeSolicitantes || idSolicitanteParaExcluir < 0)
            {
                Console.WriteLine();
                Console.WriteLine("Digite o ID do Solicitante desejado: ");
                Console.WriteLine("Digite 0 para voltar ao Menu de Solicitantes");
                Console.WriteLine("ID inválido. Digite novamente.");
                idSolicitanteParaExcluir = Int32.Parse(Console.ReadLine());

                if (idSolicitanteParaExcluir == 0)
                {
                    MenuSolicitante();
                    return true;
                }
            }

            int posicaoSolicitanteASerExcluido = idSolicitanteParaExcluir--;
            
            string[] novaArrayNomeSolicitante = new string[1000];
            string[] novaArrayEmailSolicitante = new string[1000];
            string[] novaArrayNumeroTelefoneSolicitante = new string[1000];
            

            //Executa método para exclusão
            ExcluirElementoArrayString(ref nomeSolicitante, novaArrayNomeSolicitante, posicaoSolicitanteASerExcluido);
            ExcluirElementoArrayString(ref emailSolicitante, novaArrayEmailSolicitante, posicaoSolicitanteASerExcluido);
            ExcluirElementoArrayString(ref numeroTelefoneSolicitante, novaArrayNumeroTelefoneSolicitante, posicaoSolicitanteASerExcluido);
            

            contadorQuantidadeDeSolicitantes--;

            return true;
        }

        static bool EditarSolicitante()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o ID do Solicitante desejado: ");
            Console.WriteLine("Digite 0 para voltar ao Menu de Solicitantes");
            int idSolicitanteParaEditar = Int32.Parse(Console.ReadLine());

            if(idSolicitanteParaEditar == 0)
            {
                MenuSolicitante();
                return true;
            }

            while (idSolicitanteParaEditar > contadorQuantidadeDeSolicitantes || idSolicitanteParaEditar < 0)
            {
                Console.WriteLine();
                Console.WriteLine("Digite o ID do Solicitante desejado: ");
                Console.WriteLine("Digite 0 para voltar ao Menu de Solicitantes");
                Console.WriteLine("ID inválido. Digite novamente.");
                idSolicitanteParaEditar = Int32.Parse(Console.ReadLine());

                if (idSolicitanteParaEditar == 0)
                {
                    MenuSolicitante();
                    return true;
                }
            }

            Console.WriteLine();
            Console.WriteLine("O que você quer editar? ");
            Console.WriteLine("1 - Nome do Solicitante");
            Console.WriteLine("2 - Email");
            Console.WriteLine("3 - Telefone");
            int opcao = Int32.Parse(Console.ReadLine());

            while(opcao != 1 && opcao != 2 && opcao != 3)
            {
                Console.WriteLine();
                Console.WriteLine("O que você quer editar? ");
                Console.WriteLine("1 - Nome do Solicitante");
                Console.WriteLine("2 - Email");
                Console.WriteLine("3 - Telefone");
                Console.WriteLine("Opção inválida. Digite novamente");
                opcao = Int32.Parse(Console.ReadLine());
            }


            idSolicitanteParaEditar--;
           
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Nome atual: " + nomeSolicitante[idSolicitanteParaEditar]);
                    Console.Write("Novo Nome: ");
                    string novoNome = Console.ReadLine();
                    

                    while(novoNome.Length < 6)
                    {
                        Console.WriteLine("Nome deve ter no mínimo 6 caracteres.");
                        Console.WriteLine("Nome atual: " + nomeSolicitante[idSolicitanteParaEditar]);
                        Console.Write("Novo Nome: ");
                        novoNome = Console.ReadLine();

                    }

                    //Caso Solicitante esteja vinculado com algum chamado, atualiza nome no chamado também
                    for (int i = 0; i < contadorQuantidadeDeChamados; i++)
                    {
                        if (idSolicitanteParaEditar == posicaoEmArraydeSolicitantesDePessoaQueIniciouChamado[i])
                        {
                            solicitanteChamado[posicaoEmArraydeSolicitantesDePessoaQueIniciouChamado[i]] = novoNome;
                        }
                    }

                    nomeSolicitante[idSolicitanteParaEditar] = novoNome;

                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Email atual: " + emailSolicitante[idSolicitanteParaEditar]);
                    Console.Write("Novo Email: ");
                    emailSolicitante[idSolicitanteParaEditar] = Console.ReadLine();
                    
                    break;

                case 3:
                    Console.WriteLine();
                    Console.WriteLine("Telefone atual: " + numeroTelefoneSolicitante[idSolicitanteParaEditar]);
                    Console.Write("Novo telefone: ");
                    numeroTelefoneSolicitante[idSolicitanteParaEditar] = Console.ReadLine();

                    break;
            }

            return true;

        }
        
        static void VisualizarSolicitantes()
        {
            int idSolicitante = 1;
           
            Console.WriteLine();

            Console.WriteLine(" ID  " + "Nome".PadRight(36) + "Email".PadRight(36) + "Telefone");  
            for(int i = 0; i < contadorQuantidadeDeSolicitantes; i++)
            {
                Console.WriteLine("|" + idSolicitante.ToString().PadRight(3) + "|" + nomeSolicitante[i].PadRight(35) + "|" + emailSolicitante[i].PadRight(35) + "|" + numeroTelefoneSolicitante[i].PadRight(13) + "|");
                idSolicitante++;
            }
        }
        
        static void RegistrarSolicitante()
        {
            
            Console.WriteLine();
            Console.WriteLine("Digite o nome do Solicitante (mín 6 caracteres): ");
            nomeSolicitante[contadorQuantidadeDeSolicitantes] = Console.ReadLine();
            int tamanhoString = nomeSolicitante[contadorQuantidadeDeSolicitantes].Length;

            while(tamanhoString < 6)
            {
                Console.WriteLine("Nome do Solicitante deve ter no mínimo 6 caracteres. Digite novamente: ");
                nomeSolicitante[contadorQuantidadeDeSolicitantes] = Console.ReadLine();
                tamanhoString = nomeSolicitante[contadorQuantidadeDeSolicitantes].Length;
            }

            Console.WriteLine();
            Console.WriteLine("Digite o email do Solicitante: ");
            emailSolicitante[contadorQuantidadeDeSolicitantes] = Console.ReadLine();
            while(emailSolicitante[contadorQuantidadeDeSolicitantes] == "")
            {
                Console.WriteLine();
                Console.WriteLine("Email inválido. Digite novamente: ");
                emailSolicitante[contadorQuantidadeDeSolicitantes] = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("Digite o número de telefone do Solicitante: ");
            numeroTelefoneSolicitante[contadorQuantidadeDeSolicitantes] = Console.ReadLine();
            while(numeroTelefoneSolicitante[contadorQuantidadeDeSolicitantes].Length != 9)
            {
                Console.WriteLine();
                Console.WriteLine("Telefone inválido. Digite novamente: ");
                numeroTelefoneSolicitante[contadorQuantidadeDeSolicitantes] = Console.ReadLine();
            }

            contadorQuantidadeDeSolicitantes++;
        }
       
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
            string[] novaArraySituacaoChamado = new string[1000];
            int[] novaArrayLinkEquipamentosEChamado = new int[1000];
            int[] novaArrayLinkSolicitanteEChamado = new int[1000];

            //Executa método para exclusão
            ExcluirElementoArrayString(ref tituloChamado, novaArrayTituloChamado, posicaoChamadoASerExcluido);
            ExcluirElementoArrayString(ref descricaoChamado, novaArrayDescricaoChamado, posicaoChamadoASerExcluido);
            ExcluirElementoArrayString(ref equipamentoChamado, novaArrayEquipamentoChamado, posicaoChamadoASerExcluido);
            ExcluirElementoArrayDateTime(ref dataDeAberturaChamado, novaArrayDataDeAberturaChamado, posicaoChamadoASerExcluido);
            ExcluirElementoArrayString(ref situacaoChamado, novaArraySituacaoChamado, posicaoChamadoASerExcluido);
            ExcluirElementoArrayInt(ref posicaoEmArrayDeEquipamentosDoItemNoChamado, novaArrayLinkEquipamentosEChamado, posicaoChamadoASerExcluido);
            ExcluirElementoArrayInt(ref posicaoEmArraydeSolicitantesDePessoaQueIniciouChamado, novaArrayLinkSolicitanteEChamado, posicaoChamadoASerExcluido);
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
            Console.WriteLine("5 - Solicitante do chamado");
            Console.WriteLine("6 - Situação do chamado (aberto ou fechado)");
            Console.WriteLine("7 - Voltar");
            int opcao = Int32.Parse(Console.ReadLine());

            while(opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5 && opcao != 6 & opcao != 7)
            {
                Console.WriteLine();
                Console.WriteLine("O que você deseja editar?");
                Console.WriteLine("1 - Título do chamado");
                Console.WriteLine("2 - Descrição");
                Console.WriteLine("3 - Equipamento");
                Console.WriteLine("4 - Data de Abertura");
                Console.WriteLine("5 - Solicitante do chamado");
                Console.WriteLine("6 - Editar Situação do chamado (aberto ou fechado)");
                Console.WriteLine("7 - Voltar");
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
                    Console.WriteLine("Econtrar novo Equipamento pelo seu: ");
                    Console.WriteLine("1 - Número no inventário");
                    Console.WriteLine("2 - Número de série");
                    int opcao1 = Int32.Parse(Console.ReadLine());

                    switch (opcao1)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.WriteLine("Digite o número do equipamento no inventário: ");
                            int numeroDoEquipamentoInventario = Int32.Parse(Console.ReadLine());
                            numeroDoEquipamentoInventario--;
                            int posicaoEquipamento = numeroDoEquipamentoInventario;

                            equipamentoChamado[posicaoChamadoASerEditado] = nomeEquipamento[posicaoEquipamento];
                            posicaoEmArrayDeEquipamentosDoItemNoChamado[posicaoChamadoASerEditado] = posicaoEquipamento;
                            break;

                        case 2:
                            Console.WriteLine();
                            Console.WriteLine("Digite o número de série do equipamento: ");
                            string numeroSerieEquipamentoParaEditar = Console.ReadLine();
                            int posicaoEquipamento2 = DescobrirEquipamentoPeloNumeroDeSerie(numeroSerieEquipamentoParaEditar);

                            equipamentoChamado[posicaoChamadoASerEditado] = nomeEquipamento[posicaoEquipamento2];
                            posicaoEmArrayDeEquipamentosDoItemNoChamado[posicaoChamadoASerEditado] = posicaoEquipamento2;
                            break;
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
                    Console.WriteLine();
                    Console.WriteLine("Solicitante atual: " + solicitanteChamado[posicaoChamadoASerEditado]);
                    Console.Write("Digite o ID do novo solicitante: ");
                    int idSolicitante = Int32.Parse(Console.ReadLine());

                   while(idSolicitante > contadorQuantidadeDeSolicitantes || idSolicitante <= 0)
                    {
                        Console.WriteLine("ID inválido. Retornando ao Menu de Manutenção.");
                        MenuDeManutencao();
                        return true;
                    }
                    idSolicitante--;
                    int posicaoArraySolicitante = idSolicitante;
                    solicitanteChamado[posicaoChamadoASerEditado] = nomeSolicitante[posicaoArraySolicitante];
                    posicaoEmArraydeSolicitantesDePessoaQueIniciouChamado[posicaoChamadoASerEditado] = posicaoArraySolicitante;
                    
                    break;

                case 6:
                    Console.WriteLine();
                    Console.WriteLine("Situação atual: " + situacaoChamado[posicaoChamadoASerEditado]);
                    Console.WriteLine("Deseja trocar situação? (S/N)");
                    string sn = Console.ReadLine();
                    char[] snChar = sn.ToCharArray();

                    if (snChar[0] == 's' || snChar[0] == 'S')
                    {

                        if (situacaoChamado[posicaoChamadoASerEditado] == "Aberto")
                        {
                            situacaoChamado[posicaoChamadoASerEditado] = "Fechado";
                            return true;
                        }

                        if (situacaoChamado[posicaoChamadoASerEditado] == "Fechado")
                        {
                            situacaoChamado[posicaoChamadoASerEditado] = "Aberto";
                            return true;
                        }
                    }

                   
                    break;
                
                case 7:
                    MenuDeManutencao();
                    break;

            }
               return true;
        }
        
        static void VisualizarChamados()
        {

            Console.WriteLine("Visualizar Entradas:");
            Console.WriteLine("1 - Por ordem de cadastro");
            Console.WriteLine("2 - Chamados em aberto");
            Console.WriteLine("3 - Chamados fechados");
            int opcao = Int32.Parse(Console.ReadLine());

            while(opcao != 1 && opcao != 2 && opcao!= 3)
            {
                Console.WriteLine("Visualizar Entradas:");
                Console.WriteLine("1 - Por ordem de cadastro");
                Console.WriteLine("2 - Chamados em aberto");
                Console.WriteLine("3 - Chamados fechados");
                Console.WriteLine("Opcao Inválida. Digite novamente:");
                opcao = Int32.Parse(Console.ReadLine());
            }
           
            //Faz calculo dias em aberto
            double[] dias = new double[1000];
            for (int i = 0; i < contadorQuantidadeDeChamados; i++)
            {
                TimeSpan diferenca = DateTime.Today - dataDeAberturaChamado[i];
                dias[i] = diferenca.TotalDays;
            }

            switch (opcao) {

               case 1:

                   Console.WriteLine();
                   Console.WriteLine(" Título".PadRight(27) + "Descrição".PadRight(36) + "Equipamento".PadRight(21) + "Solicitante".PadRight(31) + "Data Abertura".PadRight(14) + "D. Aberto".PadRight(12) + "Situação".PadRight(9));
                   for (int i = 0; i < contadorQuantidadeDeChamados; i++)
                   {
                     Console.WriteLine("|" + tituloChamado[i].PadRight(25) + "|" + descricaoChamado[i].PadRight(35) + "|" + equipamentoChamado[i].PadRight(20) + "|" + solicitanteChamado[i].PadRight(30) + "|" + dataDeAberturaChamado[i].ToShortDateString().PadLeft(13) + "| " + dias[i].ToString().PadLeft(10) + "|" + situacaoChamado[i].PadRight(8) + "|");
                   }
                    break;

                case 2:

                    Console.WriteLine();
                    Console.WriteLine(" CHAMADOS EM ABERTO");
                    Console.WriteLine();
                    Console.WriteLine(" Título".PadRight(27) + "Descrição".PadRight(36) + "Equipamento".PadRight(21) + "Solicitante".PadRight(31) + "Data Abertura".PadRight(14) + "D. Aberto".PadRight(11));
                    for (int i = 0; i < contadorQuantidadeDeChamados; i++)
                    {
                        if (situacaoChamado[i] == "Aberto")
                        {
                            Console.WriteLine("|" + tituloChamado[i].PadRight(25) + "|" + descricaoChamado[i].PadRight(35) + "|" + equipamentoChamado[i].PadRight(20) + "|" + solicitanteChamado[i].PadRight(30) + "|" + dataDeAberturaChamado[i].ToShortDateString().PadLeft(13) + "| " + dias[i].ToString().PadLeft(10) + "|");
                        }
                    }

                    break;

                case 3:

                    Console.WriteLine();
                    Console.WriteLine(" CHAMADOS FECHADOS");
                    Console.WriteLine();
                    Console.WriteLine(" Título".PadRight(27) + "Descrição".PadRight(36) + "Equipamento".PadRight(21) + "Solicitante".PadRight(31) + "Data Abertura".PadRight(14));
                    for (int i = 0; i < contadorQuantidadeDeChamados; i++)
                    {
                        if (situacaoChamado[i] == "Fechado")
                        {
                            Console.WriteLine("|" + tituloChamado[i].PadRight(25) + "|" + descricaoChamado[i].PadRight(35) + "|" + equipamentoChamado[i].PadRight(20) + "|" + solicitanteChamado[i].PadRight(30) + "|" + dataDeAberturaChamado[i].ToShortDateString().PadLeft(13) + "| ");
                        }
                    }
                    break;

            }
            

        } 
        
        static bool IniciarChamado()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o ID do solicitante do chamado");
            Console.WriteLine("Digite 0 para sair");
            int idSolicitanteDoChamado = Int32.Parse(Console.ReadLine());

            if(idSolicitanteDoChamado == 0)
            {
                MenuDeManutencao();
                return true;
            }

            while (idSolicitanteDoChamado > contadorQuantidadeDeSolicitantes || idSolicitanteDoChamado <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("ID inválido. Digite Novamente: ");
                idSolicitanteDoChamado = Int32.Parse(Console.ReadLine());

                if (idSolicitanteDoChamado == 0)
                {
                    MenuDeManutencao();
                    return true;
                }
            }
            idSolicitanteDoChamado--;
            posicaoEmArraydeSolicitantesDePessoaQueIniciouChamado[contadorQuantidadeDeChamados] = idSolicitanteDoChamado;
            solicitanteChamado[contadorQuantidadeDeChamados] = nomeSolicitante[idSolicitanteDoChamado];
            
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
                    
              


                    if (nomeEquipamento[posicaoNoInventarioDoEquipamentoEmChamado] == "")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Número inválido. Retornando ao Menu de Chamados.");
                        MenuDeManutencao();
                        return true;
                    }

                    //Armazena a posição para existir link entre Equipamento na lista de Equipamentos e Equipamentos na Lista de Chamados
                    posicaoEmArrayDeEquipamentosDoItemNoChamado[contadorQuantidadeDeChamados] = posicaoNoInventarioDoEquipamentoEmChamado;

                    equipamentoChamado[contadorQuantidadeDeChamados] = nomeEquipamento[posicaoNoInventarioDoEquipamentoEmChamado];
                    quantidadeDeVezesQueFoiParaManutencao[posicaoNoInventarioDoEquipamentoEmChamado] ++;
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
                            Console.WriteLine("Número de série não está cadastrado no inventário. Retornando ao Menu de Chamados.");
                            MenuDeManutencao();
                            return true;
                        }
                    }
                    equipamentoChamado[contadorQuantidadeDeChamados] = nomeEquipamento[posicaoEquipamento];
                    quantidadeDeVezesQueFoiParaManutencao[posicaoEquipamento]++;
                    break;
            }
            //Pega titulo
            Console.WriteLine("Digite o título do chamado: ");
            tituloChamado[contadorQuantidadeDeChamados] = Console.ReadLine();
            while(tituloChamado[contadorQuantidadeDeChamados] == "")
            {
                Console.WriteLine("Titulo inválido. Digite novamente: ");
                tituloChamado[contadorQuantidadeDeChamados] = Console.ReadLine();
            }

            //Pega descrição
            Console.WriteLine("Digite a descrição do chamado: ");
            descricaoChamado[contadorQuantidadeDeChamados] = Console.ReadLine();
            while(descricaoChamado[contadorQuantidadeDeChamados] == "")
            {
                Console.WriteLine("Descrião inválida. Digite novamente: ");
                descricaoChamado[contadorQuantidadeDeChamados] = Console.ReadLine();
            }
            Console.WriteLine("Digite a data de abertura do chamado(dd/mm/aaaa): ");
           
            string strDataAbertura = Console.ReadLine();
            char[] ch = strDataAbertura.ToCharArray();

            while (strDataAbertura.Length != 10 && ch[2] != '/' && ch[5] != '/')
            {
                Console.WriteLine("Data inválida. Digite novamente (dd/mm/aaaa): ");
                strDataAbertura = Console.ReadLine();
                ch = strDataAbertura.ToCharArray();
            }   
           
            DateTime dataAbertura = Convert.ToDateTime(strDataAbertura);
            dataDeAberturaChamado[contadorQuantidadeDeChamados] = dataAbertura;
            situacaoChamado[contadorQuantidadeDeChamados] = "Aberto";

            contadorQuantidadeDeChamados++;
            

            return true;
        }



        static void ExcluirElementoArrayInt(ref int[] vetorOriginal, int[] novoVetor, int posicao)
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
                    int posicaoNoInventarioDoEquipamentoASerExcluido = numeroNoInventarioDoEquipamentoQueVaiSerExcluido - 1;
                    for (int i = 0; i < contadorQuantidadeDeChamados; i++)
                    {
                        if (posicaoNoInventarioDoEquipamentoASerExcluido == posicaoEmArrayDeEquipamentosDoItemNoChamado[i]) 
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
                        if (posicaoEquipamentoQueVaiSerExcluido == posicaoEmArrayDeEquipamentosDoItemNoChamado[i])
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
        
        static int DescobrirEquipamentoPeloNumeroDeSerie(string numeroSerieEquipamento)
        {

            int posicaoEquipamento = 0;
            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                if (Program.numeroSerieEquipamento[i] == numeroSerieEquipamento)
                {
                    posicaoEquipamento = i;
                    break;
                }

                if(i == (contadorQuantidadeDeEquipamentos))
                {
                    Console.WriteLine("Número de série não está cadastrado no inventário. Retornando ao menu principal.");
                    MenuPrincipal();
                    return -1;
                }
            }

            

            return posicaoEquipamento;
            
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

                        int posicaoEquipamentoParaEditar = DescobrirEquipamentoPeloNumeroDeSerie(numeroSerieEquipamentoParaEditar);
                        EditarEquipamento(opcaoItemParaEditar, posicaoEquipamentoParaEditar);

                    break;

                case 3:
                    MenuDeEquipamentos();
                    break;
                }
            return true;

            }

        static void VisualizarEquipamentosCadastrados()
        {

            Console.WriteLine();
            Console.WriteLine("Exibir equipamentos: ");
            Console.WriteLine("1 - Em ordem de entrada");
            Console.WriteLine("2 - Em ordem de quantidade de vezes que foi para manutenção");
            int opcao = Int32.Parse(Console.ReadLine());

            while (opcao != 1 && opcao != 2)
            {
                Console.WriteLine();
                Console.WriteLine("Exibir equipamentos: ");
                Console.WriteLine("1 - Em ordem de entrada");
                Console.WriteLine("2 - Em ordem de quantidade de vezes que foi para manutenção");
                Console.WriteLine("opcao inválida. Digite novamente");
                opcao = Int32.Parse(Console.ReadLine());
            }


            string[] precoEquipamentoString = new string[1000];
            //Transforma preço em String para poder printar na tela usando comando PadRight()
            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                precoEquipamentoString[i] = precoAquisicaoEquipamento[i].ToString("0.00");
            }

            switch (opcao) {

                case 1:
               
            int numeroEquipamentoNoInventario = 1;
            Console.WriteLine();
            Console.WriteLine("QVM = quantidade de vezes que item foi enviado para manutenção");
            Console.WriteLine("     " + "Equipamento".PadRight(26) + "Preço".PadRight(9) + "Nr de série".PadRight(16) + "Data Fabricaçao".PadRight(17) + "Nome do Fabricante".PadRight(21) + "QVM");

            string numeroEquipamentonoInventarioString;
            for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
            {
                numeroEquipamentonoInventarioString = numeroEquipamentoNoInventario.ToString();
                Console.WriteLine("|" + numeroEquipamentonoInventarioString.PadRight(3) + "|" + nomeEquipamento[i].PadRight(25) + "|" + precoEquipamentoString[i].PadLeft(8) + "|" + numeroSerieEquipamento[i].PadLeft(15) + "|" + dataFabricacao[i].PadLeft(16) + "|" + nomeFabricante[i].PadLeft(20) + "|" + quantidadeDeVezesQueFoiParaManutencao[i].ToString().PadRight(4) + "|");
                numeroEquipamentoNoInventario++;
            }
                    break;
                    
                case 2:
                    
                    
                    int[] novaArrayQuantidadeDeVezesQueFoiParaManutencao = new int [1000];
                    int[] gravaPosicoesOriginais = new int[1000];
                    for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++) { 
                      novaArrayQuantidadeDeVezesQueFoiParaManutencao [i] = quantidadeDeVezesQueFoiParaManutencao[i];
                        }
                   //Inicia vetor
                    int x = 0;
                    for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++) {
                        gravaPosicoesOriginais[i] = x;
                        x++;
                   }
                    //Organiza vetor em ordem descendente e grava as posicoes originais das informaçoes do equipamento
                    Array.Sort(novaArrayQuantidadeDeVezesQueFoiParaManutencao, gravaPosicoesOriginais);
                    Array.Reverse(novaArrayQuantidadeDeVezesQueFoiParaManutencao);
                    Array.Reverse(gravaPosicoesOriginais);

                    Console.WriteLine();
                    Console.WriteLine("QVM = quantidade de vezes que item foi enviado para manutenção");
                    Console.WriteLine(" Equipamento".PadRight(26) + "Preço".PadRight(9) + "Nr de série".PadRight(16) + "Data Fabricaçao".PadRight(17) + "Nome do Fabricante".PadRight(21) + "QVM");

                    int contador = 0;
                    for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
                    {
                        Console.WriteLine("|" + nomeEquipamento[gravaPosicoesOriginais[contador]].PadRight(25) + "|" + precoEquipamentoString[gravaPosicoesOriginais[contador]].PadLeft(8) + "|" + numeroSerieEquipamento[gravaPosicoesOriginais[contador]].PadLeft(15) + "|" + dataFabricacao[gravaPosicoesOriginais[contador]].PadLeft(16) + "|" + nomeFabricante[gravaPosicoesOriginais[contador]].PadLeft(20) + "|" + quantidadeDeVezesQueFoiParaManutencao[gravaPosicoesOriginais[contador]].ToString().PadRight(4) + "|");
                        contador++;
                    }

                    break;

            
            }
        }

        static void CadastrarNovoEquipamento()
            {   
               //Pega nome
                Console.WriteLine();
                Console.WriteLine("Digite o nome do Equipamento (mín 6 caracteres): ");
                nomeEquipamento[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                int tamanhoString = nomeEquipamento[contadorQuantidadeDeEquipamentos].Length;
                //Caso nome do equipamento não tenha no mínimo 6 caracteres
                while (tamanhoString < 6)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nome do Equipamento deve ter no mínimo 6 caracteres. Digite novamente: ");
                    nomeEquipamento[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                    tamanhoString = nomeEquipamento[contadorQuantidadeDeEquipamentos].Length;
            }
                //Pega preço
                Console.WriteLine("Digite o preço de aquisição: ");
                precoAquisicaoEquipamento[contadorQuantidadeDeEquipamentos] = decimal.Parse(Console.ReadLine());
               while(precoAquisicaoEquipamento[contadorQuantidadeDeEquipamentos] <= 0)
            {
                Console.WriteLine("Preço inválido Digite novamente:");
                precoAquisicaoEquipamento[contadorQuantidadeDeEquipamentos] = decimal.Parse(Console.ReadLine());
            }

               //Pega numero de série
                Console.WriteLine("Digite o número de série: ");
                numeroSerieEquipamento[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                for (int i = 0; i < contadorQuantidadeDeEquipamentos; i++)
                {
                    while (numeroSerieEquipamento[contadorQuantidadeDeEquipamentos] == numeroSerieEquipamento[i] || numeroSerieEquipamento[contadorQuantidadeDeEquipamentos]=="")
                    {
                        Console.WriteLine("Número de série já está cadastrado ou nulo. Digite outro: ");
                        numeroSerieEquipamento[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
                    }
                }
                
                //Pega data
                Console.WriteLine("Digite a data de fabricação: ");
                string strDataFabricacao = Console.ReadLine();
                char[] ch = strDataFabricacao.ToCharArray();

           // while (strDataFabricacao.Length != 10 && ch[2] != '/' && ch[5] != '/')
            {
                Console.WriteLine("Data inválida. Digite novamente (dd/mm/aaaa): ");
                strDataFabricacao = Console.ReadLine();
                ch = strDataFabricacao.ToCharArray();
            }
            dataFabricacao[contadorQuantidadeDeEquipamentos] = strDataFabricacao;

            //Pega nome fabricante
            Console.WriteLine("Digite o nome do fabricante: ");
                nomeFabricante[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
            while(nomeFabricante[contadorQuantidadeDeEquipamentos] == "")
            {
                Console.WriteLine("Digite o nome do fabricante: ");
                nomeFabricante[contadorQuantidadeDeEquipamentos] = Console.ReadLine();
            }

                contadorQuantidadeDeEquipamentos++;
            quantidadeDeVezesQueFoiParaManutencao[contadorQuantidadeDeChamados] = 0;
            }

            static void MenuSolicitante()
            {
            Console.WriteLine();
            Console.WriteLine("1 - Registrar Solicitante");
            Console.WriteLine("2 - Visualizar Solicitantes");
            Console.WriteLine("3 - Editar Solicitante");
            Console.WriteLine("4 - Excluir Solicitante");
            Console.WriteLine("5 - voltar");
            int opcao = Int32.Parse(Console.ReadLine());

            while(opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Registrar Solicitante");
                Console.WriteLine("2 - Visualizar Solicitantes");
                Console.WriteLine("3 - Editar Solicitante");
                Console.WriteLine("4 - Excluir Solicitante");
                Console.WriteLine("5 - voltar");
                Console.WriteLine("Opção inválida. Digite novamente");
                opcao = Int32.Parse(Console.ReadLine());
            }

            switch (opcao)
            {
                case 1:
                    RegistrarSolicitante();
                    break;
                case 2:
                    VisualizarSolicitantes();
                    break;
                case 3:
                    EditarSolicitante();
                    break;
                case 4:
                    ExcluirSolicitante();
                    break;
                case 5:
                    MenuPrincipal();
                    break;

            }
          
           

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
                Console.WriteLine("1 - Cadastrar novo Equipamento");
                Console.WriteLine("2 - Visualizar Equipamentos cadastrados");
                Console.WriteLine("3 - Editar Equipamento");
                Console.WriteLine("4 - Excluir Equipamento");
                Console.WriteLine("5 - Voltar");
                opcao = Int32.Parse(Console.ReadLine());
                Console.Clear();

            while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4 && opcao != 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Cadastrar novo Equipamento");
                    Console.WriteLine("2 - Visualizar Equipamentos cadastrados");
                    Console.WriteLine("3 - Editar Equipamento");
                    Console.WriteLine("4 - Excluir Equipamento");
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
                Console.WriteLine("1 - Menu de Gerenciamento de Equipamentos");
                Console.WriteLine("2 - Menu de Chamados");
                Console.WriteLine("3 - Menu de Solicitantes");
                Console.WriteLine("4 - Sair do Programa");
                    
                    opcaoMenu = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                //Caso opção seja inválida
                while (opcaoMenu != 1 && opcaoMenu != 2 && opcaoMenu != 3 && opcaoMenu != 4)
                    {
                  
                    Console.WriteLine();
                    Console.WriteLine("1 - Menu de gerenciamento de equipamentos");
                    Console.WriteLine("2 - Menu de chamados");
                    Console.WriteLine("3 - Menu de solicitantes");
                    Console.WriteLine("4 - Sair do programa");
                    Console.WriteLine("Opção inválida. Digite Novamente.");

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
                    if ( opcaoMenu == 3)
                    {
                        MenuSolicitante();
                    }
                } while (opcaoMenu != 4);

            }

            static void Main(string[] args)
            {
                MenuPrincipal();

            }
        }
    
    }






