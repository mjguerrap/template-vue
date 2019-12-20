using System.Collections.Generic;
using System.Web.Optimization;

namespace MPS.MPSPadraoArquitetura.Web
{
    public static class BundleConfig
{
	// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
	public static void RegisterBundles(BundleCollection bundles)
	{
#if DEBUG
        BundleTable.EnableOptimizations = false;
#else
		BundleTable.EnableOptimizations = true;
#endif

		#region Javascripts

		//Jquery
		bundles.Add(new ScriptBundle("~/bundles/jquery")
			.Include("~/Scripts/jquery.newsTicker.js")
			.Include("~/Scripts/jquery-{version}.js"));

		//Jquery Validate
		bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
					"~/Scripts/jquery.validate*"));

		//Realiza a chamada ajax através do form, para fazer requisições sem dar POST na página.
		//Não suporta uploads de arquivos
		bundles.Add(new ScriptBundle("~/bundles/unobtrusive")
			.Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));


		//Realiza a chamada ajax através do form, para fazer requisições sem dar POST na página.
		//Suporta uploads de arquivos
		bundles.Add(new ScriptBundle("~/bundles/jqueryform")
			.Include("~/Scripts/jquery.form.min.js"));

		//Modernize
		bundles.Add(new ScriptBundle("~/bundles/modernizr")
			.Include("~/Scripts/modernizr-*"));

		//Bootstrap
		bundles.Add(new ScriptBundle("~/bundles/bootstrap")
			.Include("~/Scripts/umd/popper.min.js")
			.Include("~/Scripts/bootstrap.min.js"));

		//Toast
		bundles.Add(new ScriptBundle("~/bundles/toaster")
			.Include("~/Scripts/toastr.min.js"));

		//HighLight
		bundles.Add(new ScriptBundle("~/bundles/highlight")
			.Include("~/Scripts/highlight.pack.js")
			.Include("~/Scripts/highlight/highlightOnLoad.js"));

		//Mps Layout JS
		bundles.Add(new ScriptBundle("~/bundles/base")
			.Include("~/Scripts/mps.layoutbase.js"));

		//Summernote
		bundles.Add(new ScriptBundle("~/bundles/summernote")
			.Include("~/Scripts/summernote/summernote-bs4.js")
			.Include("~/Scripts/summernote/lang/summernote-pt-BR.js"));

		//Select2
		bundles.Add(new ScriptBundle("~/bundles/select2")
			.Include("~/Scripts/select2.js"));

		//Ranger Slider
		bundles.Add(new ScriptBundle("~/bundles/rangeslider").Include(
					"~/Scripts/ion.rangeSlider.js"));

		//Datatable
		bundles.Add(new ScriptBundle("~/bundles/datatable")
			.Include("~/Scripts/datatable/jquery.dataTables.js")
			.Include("~/Scripts/datatable/dataTables.ptBr.js")
			.Include("~/Scripts/datatable/dataTables.bootstrap4.js")
			.Include("~/Scripts/datatable/dataTables.responsive.js")
			.Include("~/Scripts/datatable/responsive.bootstrap4.js")
			.Include("~/Scripts/datatable/inputPagination.js")
			.Include("~/Scripts/datatable/select.bootstrap4.js"));

		//DatetimePicker
		bundles.Add(new ScriptBundle("~/bundles/datetimepicker")
			.Include("~/Scripts/DateTimePicker/moment.min.js")
			.Include("~/Scripts/DateTimePicker/pt-br.js")
			.Include("~/Scripts/DateTimePicker/tempusdominus-bootstrap-4.min.js")
			//.Include("~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js")  //if not using jquery
			.Include("~/Scripts/inputmask/inputmask/inputmask.js")
			.Include("~/Scripts/inputmask/inputmask/jquery.inputmask.js")
			.Include("~/Scripts/inputmask/inputmask/inputmask.extensions.js")
			.Include("~/Scripts/inputmask/inputmask/inputmask.date.extensions.js")
			//and other extensions you want to include
			.Include("~/Scripts/inputmask/inputmask/inputmask.numeric.extensions.js")
			.Include("~/Scripts/DateTimePicker/maskUtil.js"));

		//DropZone
		bundles.Add(new ScriptBundle("~/bundles/dropzone")
			.Include("~/Scripts/Dropzone/dropzone.min.js"));

		//StepProgress
		bundles.Add(new ScriptBundle("~/bundles/stepprogress")
			.Include("~/Scripts/stepProgress/step-progress.js")
			.Include("~/Scripts/stepProgress/step-progress.config.js"));

		//Bootstrapswitch
		bundles.Add(new ScriptBundle("~/bundles/bootstrapswitch")
			.Include("~/Scripts/bootstrap-switch.min.js"));

		//FullCalendar
		bundles.Add(new ScriptBundle("~/bundles/fullcalendar")
			.Include("~/Scripts/lib/moment.min.js")
			.Include("~/Scripts/fullcalendar.min.js")
			.Include("~/Scripts/locale/pt-br.js"));

		//Utilitários
		bundles.Add(new ScriptBundle("~/bundles/Utilitario")
			.Include("~/Scripts/util/util.*"));

		//Plugins
		bundles.Add(new ScriptBundle("~/bundles/plugins")
			.Include("~/Scripts/moment.min.js")
			.Include("~/Scripts/respond.js")
			.Include("~/Scripts/moment-with-locales.js"));

		#endregion

		#region Css

		//Bootstrap
		bundles.Add(new StyleBundle("~/bundlescontent/bootstrap")
			.Include("~/Content/bootstrap.min.css"));

		//Layout do template
		bundles.Add(new StyleBundle("~/bundlescontent/estilobase")
			.Include("~/Content/mps.layoutbase.css"));

		//Icones e fonts
		bundles.Add(new StyleBundle("~/bundlescontent/icones")
			.Include("~/Content/all.min.css"));

		//Toastr
		bundles.Add(new StyleBundle("~/bundlescontent/toaster")
		   .Include("~/Content/toastr.css"));

		//Highlight (Plugin para formatação de código)
		bundles.Add(new StyleBundle("~/bundlescontent/codeformat")
		   .Include("~/Content/github.min.css"));

		//Summernote
		bundles.Add(new StyleBundle("~/Content/summernote/summernoteestilo")
			.Include("~/Content/summernote/summernote-bs4.css"));

		//Select 2
		bundles.Add(new StyleBundle("~/bundlescontent/select2")
			.Include("~/Content/css/select2.css"));

		//Datatable
		bundles.Add(new StyleBundle("~/bundlescontent/datatable")
			.Include("~/Content/datatable/dataTables.customizado.css")
			.Include("~/Content/datatable/dataTables.bootstrap4.css")
			.Include("~/Content/datatable/responsive.bootstrap4.css")
			.Include("~/Content/datatable/select.bootstrap4.css"));

		//DatetimePicker
		bundles.Add(new StyleBundle("~/bundlescontent/datetimepicker")
			.Include("~/Content/DateTimePicker/tempusdominus-bootstrap-4.min.css"));

		//DropZone
		bundles.Add(new StyleBundle("~/bundlescontent/dropzone")
			.Include("~/Content/Dropzone/dropzone.css")
			.Include("~/Content/Dropzone/dropzone.customizado.css"));

		//StepProgress
		bundles.Add(new StyleBundle("~/bundlescontent/stepprogress")
			.Include("~/Content/stepProgress/step-progress.css"));

		//BootstrapSwitch
		bundles.Add(new StyleBundle("~/bundlescontent/bootstrapswitch")
			.Include("~/Content/bootstrap-switch/bootstrap3/bootstrap-switch.min.css"));

		//Ranger Slider
		bundles.Add(new StyleBundle("~/bundlescontent/rangeslider").Include(
				 "~/Content/ion.rangeSlider.css",
				 "~/Content/ion.rangeSlider.skinHTML5.css"));

		//FullCalendar
		bundles.Add(new StyleBundle("~/bundlescontent/fullcalendar")
			.Include("~/Content/fullcalendar.min.css"));

		#endregion

	}
}

public class AsIsBundleOrderer : IBundleOrderer
{
	public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
	{
		return files;
	}
}
}
