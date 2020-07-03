/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using AlDarb.DTO;
using AlDarb.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AlDarb.WebApiCore.Identity
{
    public class AuthenticationService<TUser> : IAuthenticationService
        where TUser : Entities.User, new()
    {
        protected readonly UserManager<TUser> userManager;
        protected readonly JwtManager jwtManager;

        public AuthenticationService(JwtManager jwtManager, UserManager<TUser> userManager)
        {
            this.userManager = userManager;
            this.jwtManager = jwtManager;
        }

        public async Task<AuthResult<Token>> Login(LoginDTO loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
                return AuthResult<Token>.UnvalidatedResult;

            var user = await userManager.FindByEmailAsync(loginDto.Email);

            if (user != null && user.Id > 0)
            {
                if (await userManager.CheckPasswordAsync(user, loginDto.Password))
                {
                    var token = jwtManager.GenerateToken(user);
                    return AuthResult<Token>.TokenResult(token);
                }
            }

            return AuthResult<Token>.UnauthorizedResult;
        }

        public async Task<AuthResult<Token>> ChangePassword(ChangePasswordDTO changePasswordDto, int currentUserId)
        {
            if (changePasswordDto == null ||
                string.IsNullOrEmpty(changePasswordDto.ConfirmPassword) ||
                string.IsNullOrEmpty(changePasswordDto.Password) ||
                changePasswordDto.Password != changePasswordDto.ConfirmPassword
            )
                return AuthResult<Token>.UnvalidatedResult;

            if (currentUserId > 0)
            {
                var user = await userManager.FindByIdAsync(currentUserId.ToString());
                var result = await userManager.ChangePasswordAsync(user, null, changePasswordDto.Password);
                if (result.Succeeded)
                    return AuthResult<Token>.SucceededResult;
            }

            return AuthResult<Token>.UnauthorizedResult;
        }

        public async Task<AuthResult<Token>> SignUp(SignUpDTO signUpDto)
        {
            if (signUpDto == null ||
                string.IsNullOrEmpty(signUpDto.Email) ||
                string.IsNullOrEmpty(signUpDto.Password) ||
                string.IsNullOrEmpty(signUpDto.ConfirmPassword) ||
                string.IsNullOrEmpty(signUpDto.FirstName) ||
                string.IsNullOrEmpty(signUpDto.LastName) ||
                signUpDto.Password != signUpDto.ConfirmPassword
            )
                return AuthResult<Token>.UnvalidatedResult;

            var newUser = new TUser { 
                FirstName = signUpDto.FirstName,
                LastName = signUpDto.LastName,
                Login = signUpDto.Email, 
                Email = signUpDto.Email };

            var result = await userManager.CreateAsync(newUser, signUpDto.Password);

            if (result.Succeeded)
            {
                if (newUser.Id > 0)
                {
                    await userManager.AddToRoleAsync(newUser, "User");
                    var token = jwtManager.GenerateToken(newUser);
                    return AuthResult<Token>.TokenResult(token);
                }
            }

            return AuthResult<Token>.UnauthorizedResult;
        }

        public async Task<AuthResult<string>> RequestPassword(RequestPasswordDTO requestPasswordDto)
        {
            if (requestPasswordDto == null ||
                string.IsNullOrEmpty(requestPasswordDto.Email))
                return AuthResult<string>.UnvalidatedResult;

            var user = await userManager.FindByEmailAsync(requestPasswordDto.Email);

            if (user != null && user.Id > 0)
            {
                var passwordResetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                var token =  AuthResult<string>.TokenResult(passwordResetToken);
                SendRequestPasswordEmail(token.Data, user);
                return token;
            }

            return AuthResult<string>.UnvalidatedResult;
        }

        public async Task<AuthResult<Token>> RestorePassword(RestorePasswordDTO restorePasswordDto)
        {
            if (restorePasswordDto == null ||
                string.IsNullOrEmpty(restorePasswordDto.Email) ||
                string.IsNullOrEmpty(restorePasswordDto.Token) ||
                string.IsNullOrEmpty(restorePasswordDto.NewPassword) ||
                string.IsNullOrEmpty(restorePasswordDto.ConfirmPassword) ||
                string.IsNullOrEmpty(restorePasswordDto.ConfirmPassword) ||
                restorePasswordDto.ConfirmPassword != restorePasswordDto.NewPassword
            )
                return AuthResult<Token>.UnvalidatedResult;

            var user = await userManager.FindByEmailAsync(restorePasswordDto.Email);

            if (user != null && user.Id > 0)
            {
                var result = await userManager.ResetPasswordAsync(user, restorePasswordDto.Token, restorePasswordDto.NewPassword);

                if (result.Succeeded)
                {
                    var token = jwtManager.GenerateToken(user);
                    return AuthResult<Token>.TokenResult(token);
                }
            }

            return AuthResult<Token>.UnvalidatedResult;
        }

        public Task<AuthResult<Token>> SignOut()
        {
            throw new System.NotImplementedException();
        }

        public async Task<AuthResult<Token>> RefreshToken(RefreshTokenDTO refreshTokenDto)
        {
            var refreshToken = refreshTokenDto?.Token?.Refresh_token;
            if (string.IsNullOrEmpty(refreshToken))
                return AuthResult<Token>.UnvalidatedResult;

            try
            {
                var principal = jwtManager.GetPrincipal(refreshToken, isAccessToken: false);
                var userId = principal.GetUserId();
                var user = await userManager.FindByIdAsync(userId.ToString());

                if (user != null && user.Id > 0)
                {
                    var token = jwtManager.GenerateToken(user);
                    return AuthResult<Token>.TokenResult(token);
                }
            }
            catch (Exception)
            {
                return AuthResult<Token>.UnauthorizedResult;
            }

            return AuthResult<Token>.UnauthorizedResult;
        }

        public async Task<Token> GenerateToken(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user != null && user.Id > 0)
            {
                return jwtManager.GenerateToken(user);
            }

            return null;
        }

        public String SendRequestPasswordEmail(string token, User user)
        {
            MailAddress fromAddress = new MailAddress("support@al-darb.com");
            MailAddress ToAddress = new MailAddress(user.Email);

            MailMessage mailMessage = new MailMessage(fromAddress.Address, ToAddress.Address)
            {
                Body = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"https://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\"><head><!--[if gte mso 9]><xml><o:OfficeDocumentSettings><o:AllowPNG/><o:PixelsPerInch>96</o:PixelsPerInch></o:OfficeDocumentSettings></xml><![endif]--><title>Christmas Email template</title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0 \"><meta name=\"format-detection\" content=\"telephone=no\"><!--[if !mso]><!--><link href=\"https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800\" rel=\"stylesheet\"><!--<![endif]--><style type=\"text/css\">body {	margin: 0 !important;	padding: 0 !important;	-webkit-text-size-adjust: 100% !important;	-ms-text-size-adjust: 100% !important;	-webkit-font-smoothing: antialiased !important;}img {	border: 0 !important;	outline: none !important;}p {	Margin: 0px !important;	Padding: 0px !important;}table {	border-collapse: collapse;	mso-table-lspace: 0px;	mso-table-rspace: 0px;}td, a, span {	border-collapse: collapse;	mso-line-height-rule: exactly;}.ExternalClass * {	line-height: 100%;}.em_defaultlink a {	color: inherit !important;	text-decoration: none !important;}span.MsoHyperlink {	mso-style-priority: 99;	color: inherit;}span.MsoHyperlinkFollowed {	mso-style-priority: 99;	color: inherit;} @media only screen and (min-width:481px) and (max-width:699px) {.em_main_table {	width: 100% !important;}.em_wrapper {	width: 100% !important;}.em_hide {	display: none !important;}.em_img {	width: 100% !important;	height: auto !important;}.em_h20 {	height: 20px !important;}.em_padd {	padding: 20px 10px !important;}}@media screen and (max-width: 480px) {.em_main_table {	width: 100% !important;}.em_wrapper {	width: 100% !important;}.em_hide {	display: none !important;}.em_img {	width: 100% !important;	height: auto !important;}.em_h20 {	height: 20px !important;}.em_padd {	padding: 20px 10px !important;}.em_text1 {	font-size: 16px !important;	line-height: 24px !important;}u + .em_body .em_full_wrap {	width: 100% !important;	width: 100vw !important;}}</style></head> <body class=\"em_body\" style=\"margin:0px; padding:0px;\" bgcolor=\"#efefef\"><table class=\"em_full_wrap\" valign=\"top\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"#efefef\" align=\"center\">  <tbody><tr>    <td valign=\"top\" align=\"center\"><table class=\"em_main_table\" style=\"width:700px;\" width=\"700\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\">                <!--//Banner section-->         <!--Content Text Section-->                 <tr>          <td style=\"padding:35px 70px 30px;\" class=\"em_padd\" valign=\"top\" bgcolor=\"#0d1121\" align=\"center\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\">              <tbody><tr>                <td style=\"font-family:'Open Sans', Arial, sans-serif; font-size:16px; line-height:30px; color:#ffffff;\" valign=\"top\" align=\"center\">Request for reseting your account password.</td>              </tr>              <tr>                <td style=\"font-size:0px; line-height:0px; height:15px;\" height=\"15\">&nbsp;</td><!--—this is space of 15px to separate two paragraphs ---->              </tr>              <tr>                <td style=\"font-family:'Open Sans', Arial, sans-serif; font-size:18px; line-height:22px; color:#fbeb59; letter-spacing:2px; padding-bottom:12px;\" valign=\"top\" align=\"center\">If you are not aware for why you recieve this email please <a href=\"al-darb.com/auth/login\">login</a> to you account and secure it.</td>              </tr>              <tr>                <td class=\"em_h20\" style=\"font-size:0px; line-height:0px; height:25px;\" height=\"25\">&nbsp;</td><!--—this is space of 25px to separate two paragraphs ---->              </tr><tr>                <td style=\"font-family:'Open Sans', Arial, sans-serif; font-size:18px; line-height:22px; color:#fbeb59; text-transform:uppercase; letter-spacing:2px; padding-bottom:12px;\" valign=\"top\" align=\"center\"> For reseting your account password use the folowing <a href=\"al-darb.com/auth/reset-password?email=" + user.Email + "&token=" + token + "\"> link </ a ></ td >              </ tr >            </ tbody ></ table ></ td >        </ tr ><tr>          <td style=\"padding:38px 30px;\" class=\"em_padd\" valign=\"top\" bgcolor=\"#f6f7f8\" align=\"center\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" align=\"center\">              <tbody>              <tr>                <td style=\"font-family:'Open Sans', Arial, sans-serif; font-size:11px; line-height:18px; color:#999999;\" valign=\"top\" align=\"center\"><a href=\"#\" target=\"_blank\" style=\"color:#999999; text-decoration:underline;\">PRIVACY STATEMENT</a> | <a href=\"#\" target=\"_blank\" style=\"color:#999999; text-decoration:underline;\">TERMS OF SERVICE</a> | <a href=\"#\" target=\"_blank\" style=\"color:#999999; text-decoration:underline;\">RETURNS</a><br>                  © 2020 Al Darb. All Rights Reserved.<br>              </tr>            </tbody></table></td>        </tr>        <tr>          <td class=\"em_hide\" style=\"line-height:1px;min-width:700px;background-color:#ffffff;\"><img alt=\"\" src=\"images/spacer.gif\" style=\"max-height:1px; min-height:1px; display:block; width:700px; min-width:700px;\" width=\"700\" border=\"0\" height=\"1\"></td>        </tr>      </tbody></table></td>  </tr></tbody></table><div class=\"em_hide\" style=\"white-space: nowrap; display: none; font-size:0px; line-height:0px;\">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</div></body></html>",
                Subject = "Al Darb | Reset Password",
                IsBodyHtml = true
            };

            SmtpClient client = new SmtpClient
            {
                Host = "mail.al-darb.com",
                Port = 25,
                EnableSsl = true,
                Timeout = 180000,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("support@al-darb.com", "$upport23080502")
            };

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                var e = ex;
                _ = e.Message.Length;
            }
            return token;
        }
    }
}