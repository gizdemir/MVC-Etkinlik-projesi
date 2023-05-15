using etkinlikk.Data;
using etkinlikk.Helpers;
using etkinlikk.Models;
using etkinlikk.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace etkinlikk.Controllers
{
    public class HesapController : Controller
    {
        private readonly etkinlikkDBContext _context;

        public HesapController(etkinlikkDBContext context)
        {
            _context = context;
        }


        public IActionResult Giris()
        {
            LoginViewModel x = new LoginViewModel();
            return View(x);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Giris([Bind("Emaill,Passwordd")] LoginViewModel userr)
        {

            if (ModelState.IsValid)
            {

                ClaimsIdentity identityy = null;
                bool isAuthenticated = false;
                Userr userrr = await _context.Userrs.Include(k => k.Rolee).FirstOrDefaultAsync(m => m.Emaill == userr.Emaill && m.Passwordd == userr.Passwordd);

                if (userrr == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Bulunamadı.");
                    return View(userr);
                }




                identityy = new ClaimsIdentity
                (new[]
                        {
                            new Claim(ClaimTypes.Sid,userrr.UserrID.ToString()),
                            new Claim(ClaimTypes.Email,userrr.Emaill),
                            new Claim(ClaimTypes.Role,userrr.Rolee.RoleeName),
                        }, CookieAuthenticationDefaults.AuthenticationScheme
                );



                isAuthenticated = true;

                if (isAuthenticated)
                {
                    var claimss = new ClaimsPrincipal(identityy);
                    var loginn = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimss,

                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.Now.AddMinutes(15)
                        }

                        );



                    if (userrr.Rolee.RoleeName == "Aday")
                    {
                        return Redirect("~/Hesap/EpostaOnayHatirlatmasi");
                    }
                    else if (userrr.Rolee.RoleeName == "Uye")
                    {
                        return RedirectToAction("", "");
                    }
                    else if (userrr.Rolee.RoleeName == "Admin")
                    {
                        return Redirect("~/AdminAnasayfa/Index");
                    }

                    else if (userrr.Rolee.RoleeName == "Supervisor")
                    {
                        return Redirect("~/AdminAnasayfa/Index");
                    }

                    //else if (userrr.Rolee.RoleeName == "User Passive")    /*loginn olurken user passive ise zaten daha baştan yönlendirme yapıldığı için buna gerek kalmadı*/
                    //{
                    //    return Redirect("~/Account/SignupInformationPage");
                    //}
                    else
                    {
                        return Redirect("~/Home/Index");
                    }



                }
                return View();
            }
            return View(userr);

        }





        public async Task<IActionResult> Aktivasyon(string kkk)
        {
            string emaill = Criyptoo.Decrypted(kkk);

            Userr userr = await _context.Userrs.FirstOrDefaultAsync(a => a.Emaill == emaill);
            userr.RoleeID = 2;
            _context.Userrs.Update(userr);
            await _context.SaveChangesAsync();

            return View();
        }



        [Authorize(Roles = "Aday")]
        public IActionResult EpostaOnayHatirlatmasi()
        {



            return View();
        }

        public IActionResult KayitOl()
        {
            Userr userr = new Userr();
            return View(userr);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> KayitOl([Bind("Emaill", "Passwordd", "PasswordRepeatt")] Userr userr)
        {
            userr.RoleeID = 1;


            if (ModelState.IsValid)
            {
                Userr selectedUserr = await _context.Userrs.FirstOrDefaultAsync(a => a.Emaill == userr.Emaill);
                if (selectedUserr != null)
                {
                    ModelState.AddModelError("", "Eposta zaten kullanımda.");
                }
            }

            if (ModelState.IsValid)
            {



                await _context.Userrs.AddAsync(userr);
                await _context.SaveChangesAsync();

                EmailOperations.SendActivationMail(userr.Emaill);

                return RedirectToAction("Giris", "Hesap");

            }

            return View(userr);
        }

        public IActionResult SifremiUnuttum()
        {
            return View();
        }




        public IActionResult Cikis()
        {
            var giriş = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("", "");
        }


    }
}
