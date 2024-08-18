using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SIMS.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SIMS.Components.Account
{
    internal sealed class IdentityRedirectManager
    {
        public const string StatusCookieName = "Identity.StatusMessage";

        private static readonly CookieBuilder StatusCookieBuilder = new()
        {
            SameSite = SameSiteMode.Strict,
            HttpOnly = true,
            IsEssential = true,
            MaxAge = TimeSpan.FromSeconds(5),
        };

        private readonly NavigationManager navigationManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public IdentityRedirectManager(NavigationManager navigationManager, IHttpContextAccessor httpContextAccessor)
        {
            this.navigationManager = navigationManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        [DoesNotReturn]
        public async Task<bool> SignInAsync(string userName, string password, bool rememberMe = false)
        {
            var context = httpContextAccessor.HttpContext;
            var userManager = context.RequestServices.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;
            var signInManager = context.RequestServices.GetService(typeof(SignInManager<ApplicationUser>)) as SignInManager<ApplicationUser>;

            if (userManager == null || signInManager == null)
                throw new InvalidOperationException("UserManager or SignInManager is not available.");

            var user = await userManager.FindByNameAsync(userName);
            if (user != null && await userManager.CheckPasswordAsync(user, password))
            {
                var result = await signInManager.PasswordSignInAsync(userName, password, rememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // User authenticated successfully
                    RedirectTo("Dashboard");
                    return true;
                }
            }

            // Authentication failed
            RedirectTo("/Login");
            return false;
        }

        [DoesNotReturn]
        public void RedirectTo(string? uri)
        {
            // Default to home if uri is null or empty
            uri = string.IsNullOrEmpty(uri) ? "Dashboard" : uri;

            // Ensure uri is well-formed and not relative
            if (!Uri.IsWellFormedUriString(uri, UriKind.Relative))
            {
                uri = navigationManager.ToBaseRelativePath(uri);
            }

            // Navigate to the validated URI
            navigationManager.NavigateTo(uri);
            throw new InvalidOperationException($"{nameof(IdentityRedirectManager)} can only be used during static rendering.");
        }

        [DoesNotReturn]
        public void RedirectTo(string uri, Dictionary<string, object?> queryParameters)
        {
            var absoluteUri = navigationManager.ToAbsoluteUri(uri);
            var uriWithoutQuery = absoluteUri.GetLeftPart(UriPartial.Path);
            var newUri = navigationManager.GetUriWithQueryParameters(uriWithoutQuery, queryParameters);
            RedirectTo(newUri.ToString());
        }

        [DoesNotReturn]
        public void RedirectToWithStatus(string uri, string message, HttpContext context)
        {
            context.Response.Cookies.Append(StatusCookieName, message, StatusCookieBuilder.Build(context));
            RedirectTo(uri);
        }

        private string CurrentPath => navigationManager.ToAbsoluteUri(navigationManager.Uri).GetLeftPart(UriPartial.Path);

        [DoesNotReturn]
        public void RedirectToCurrentPage() => RedirectTo(CurrentPath);

        [DoesNotReturn]
        public void RedirectToCurrentPageWithStatus(string message, HttpContext context)
            => RedirectToWithStatus(CurrentPath, message, context);
    }
}
