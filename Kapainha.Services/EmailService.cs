using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarapinhaShared.Services;
using KarapinhaDTO.User;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Karapinha.Services
{
    public class EmailService
    {
        private const string SmtpServer = "smtp.office365.com";
        private const int SmtpPort = 587;
        private const string SmtpUser = "heltonevambi@hotmail.com";
        private const string SmtpPass = "xgaodvxwcxclesxc";

        public void EnviarEmailNotificacaoCadastro(UserCreateDto usuarioDto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sistema de Cadastro", SmtpUser));
            message.To.Add(new MailboxAddress("Administrador", "heltonevambi@gmail.com"));
            message.Subject = "Novo Usuário Registrado";

            message.Body = new TextPart("plain")
            {
                Text = $"O usuário {usuarioDto.Username} acabou de se registrar no sistema. Por favor, ative a sua conta."
            };

            EnviarEmail(message);
        }

        public void EnviarEmailCredenciaisAdmin(UserCreateDto usuarioDto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sistema de Cadastro", SmtpUser));
            message.To.Add(new MailboxAddress(usuarioDto.Username, usuarioDto.EmailAddress));
            message.Subject = "Credenciais de Acesso ao Sistema";

            message.Body = new TextPart("plain")
            {
                Text = $"Olá {usuarioDto.Username},\n\n" +
                       $"Você foi registrado como administrativo no sistema. Suas credenciais são:\n" +
                       $"Username: {usuarioDto.Username}\n" +
                       $"Senha: {usuarioDto.Password}\n\n" +
                       $"Por favor, altere sua senha após o primeiro login.\n\n" +
                       $"Atenciosamente,\nEquipe Karapinha"
            };

            EnviarEmail(message);
        }

        public void EnviarEmailCadastroCliente(UserCreateDto usuarioDto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sistema de Cadastro", SmtpUser));
            message.To.Add(new MailboxAddress(usuarioDto.Username, usuarioDto.EmailAddress));
            message.Subject = "Conta Ativada";

            message.Body = new TextPart("plain")
            {
                Text = $"Olá {usuarioDto.FirstName} {usuarioDto.LastName},\n\nSua conta foi criada e deve aguardar para ativação."
            };

            EnviarEmail(message);
        }

        public void EnviarEmailAtivacao(UserCreateDto usuarioDto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sistema de Cadastro", SmtpUser));
            message.To.Add(new MailboxAddress(usuarioDto.Username, usuarioDto.EmailAddress));
            message.Subject = "Conta Ativada";

            message.Body = new TextPart("plain")
            {
                Text = $"Olá {usuarioDto.FirstName} {usuarioDto.LastName},\n\nSua conta foi ativada com sucesso. Agora você pode acessar o sistema."
            };

            EnviarEmail(message);
        }

        private void EnviarEmail(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(SmtpServer, SmtpPort, SecureSocketOptions.StartTls);
                    client.Authenticate(SmtpUser, SmtpPass);

                    client.Send(message);
                }
                catch (Exception ex)
                {
                    // Log ou tratamento do erro
                    Console.WriteLine($"Erro ao enviar email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
