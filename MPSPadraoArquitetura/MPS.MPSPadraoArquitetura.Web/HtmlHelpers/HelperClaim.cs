using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Configuration;
using MPS.SSO.CustomClaims;
using MPS.MPSPadraoArquitetura.SharedKernel.Util;

namespace MPS.MPSPadraoArquitetura.Web.HtmlHelpers
{
    public static class HelperClaim
{
	public static string Matricula => Claims.Matricula;

	private static string NomeCompleto => Claims.NomeCompleto;

	private static readonly string RoleAPI = "role";

	private static readonly string PrimeiroNome = Claims.PrimeiroNome;

	public static string Simulacao => Claims.Simulacao;

	/// <summary>
	/// Obtem a Matrícula do Usuário Logado
	/// </summary>
	/// <param name="claim"></param>
	/// <returns></returns>
	public static string ObterValorClaim(string claim)
	{
		return ClaimsHelper.ObterClaim(claim)?.Value;
	}

	public static int ObterMatricula()
	{
		string matricula = ClaimsHelper.ObterClaim(Claims.Matricula)?.Value;
		return matricula.ToInt();
	}

	/// <summary>
	/// Retorna o nome completo do usuário logado
	/// </summary>
	/// <returns></returns>
	public static string ObterNomeCompleto()
	{
		return ClaimsHelper.ObterClaim(Claims.NomeCompleto)?.Value;
	}

	/// <summary>
	/// Obtem a Matrícula e o Nome Completo do Usuário Logado
	/// </summary>
	/// <returns></returns>
	public static string ObterMatriculaComNomeCompleto()
	{
		string matricula = ClaimsHelper.ObterClaim(Claims.Matricula)?.Value;
		string nomeCompleto = ClaimsHelper.ObterClaim(Claims.NomeCompleto)?.Value;

		return $"{matricula} - {nomeCompleto}";
	}

	/// <summary>
	/// Seleciona todas as roles do Usuário logado
	/// </summary>
	/// <returns></returns>
	public static IList<string> SelecionarTodasRoles()
	{
		List<string> roles = new List<string>();
		if (HttpContext.Current?.User?.Identity is ClaimsIdentity identity)
		{
			//OBS: Rever quando for aplicado a segurança na API pelo SSO
			var objetoClaim = identity.Claims.Where(x => x.Type == ClaimTypes.Role || x.Type == RoleAPI);
			roles = objetoClaim.Select(x => x.Value).ToList();
		}
		return roles;
	}

	/// <summary>
	/// Seleciona todas as informações das Roles do Usuário Logado
	/// </summary>
	/// <returns></returns>
	public static IEnumerable<Claim> SelecionarTodasClaims()
	{
		if (HttpContext.Current?.User?.Identity is ClaimsIdentity identity)
		{
			return identity.Claims;
		}
		return null;
	}

	/// <summary>
	/// Verifica se o funcionário possui uma determinada Role
	/// </summary>
	/// <param name="role"></param>
	/// <returns></returns>
	public static bool PossuiRole(string role)
	{
		return HttpContext.Current?.User?.IsInRole(role) ?? false;
	}

}
}