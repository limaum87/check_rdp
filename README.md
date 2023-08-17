# RDP Session Checker

Este é um utilitário simples desenvolvido em C# para verificar o número de sessões ativas da Área de Trabalho Remota (RDP) em um servidor.

## Como Usar

1. **Pré-requisitos:**
   - Certifique-se de ter o .NET Core SDK instalado em sua máquina. Você pode baixá-lo em https://dotnet.microsoft.com/download.

2. **Clone o Repositório:**
   Clone este repositório para a sua máquina usando o seguinte comando:
   https://github.com/limaum87/check_rdp.git
   
4. **Navegue para a Pasta:**
Use o terminal para navegar até a pasta do projeto:

5. **Execute o Programa:**
Execute o seguinte comando para compilar e executar o programa:

6. **Resultados:**
- O programa exibirá uma mensagem informando o número de sessões RDP.
- Se houver 1 sessão, a mensagem será "WARN! Número de sessões RDP: 1".
- Se houver mais de 1 sessão, a mensagem será "OK! Número de sessões RDP: [número]".
- Se não houver sessões, a mensagem será "Critical! Número de sessões RDP: 0".

## Personalização

- No arquivo `Program.cs`, você pode modificar a parte que define a variável `process.StartInfo.Arguments` para especificar o nome ou endereço do servidor RDP que deseja verificar.

## Licença

Este projeto é licenciado sob a Licença [MIT](LICENSE).
