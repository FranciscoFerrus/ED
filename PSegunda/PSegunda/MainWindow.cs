using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public int operacion = 0;
	public bool pendiente = false;
	public bool separador_decimal = false;
	public double primer_numero, segundo_numero, resultado; 
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void B1_clicked (object sender, EventArgs e)
	{
		if(pendiente)
		{
			primer_numero = double.Parse(recuadro.Text);
			pendiente = false;
			recuadro.Text = "";
		}
		recuadro.Text =  recuadro.Text + (sender as Button).Label; 
	}
	

	protected void Operation_clicked (object sender, EventArgs e)
	{
		if ( recuadro.Text != "")
		{
			pendiente = true;
			if ((sender as Button).Name == "BMAS") operacion = 1;
			if ((sender as Button).Name == "BMENOS") operacion = 2;
			if ((sender as Button).Name == "BMULTI") operacion = 3;
			if ((sender as Button).Name == "BDIVIDIR") operacion = 4;
			separador_decimal = false;
		} 
	}

	protected void punto_clicked (object sender, EventArgs e)
	{
		if (!separador_decimal)
		{
			if(pendiente)
			{
				primer_numero = double.Parse(recuadro.Text);
				pendiente = false;
				recuadro.Text = "0,";
			}
			else
			{
				if ( recuadro.Text == "")  
					recuadro.Text = "0,";
				else                       
					recuadro.Text = recuadro.Text + ",";
			}
			separador_decimal = true;
		} 
	}




	protected void cero_clicked (object sender, EventArgs e)
	{
		if(pendiente)
		{
			primer_numero = double.Parse(recuadro.Text);
			pendiente = false;
			recuadro.Text = "0,";
			separador_decimal = true;
		}
		else
		{
			if (recuadro.Text == "")  
			{
				recuadro.Text = "0,";
				separador_decimal = true;
			}
			else                       
				recuadro.Text = recuadro.Text + "0";
		} 
	}


	protected void igual_clicked (object sender, EventArgs e)
	{
		if ( (operacion >=1) && (operacion <=4) )
		{
			segundo_numero = double.Parse(recuadro.Text);
			switch(operacion)
			{
				case 1: resultado = primer_numero + segundo_numero; break;
				case 2: resultado = primer_numero - segundo_numero; break;
				case 3: resultado = primer_numero * segundo_numero; break;
				case 4: resultado = primer_numero / segundo_numero; break;
			}
			recuadro.Text = Convert.ToString(resultado);
			separador_decimal = false;
		} 
	}
	protected virtual void recuadro_KeyPressEvent (object o, Gtk.KeyPressEventArgs args)
	{
		string misDigitos = "0123456789";
		if (Array.IndexOf (misDigitos.ToCharArray (), Convert.ToChar (args.Event.Key)) == -1 && args.Event.Key != Gdk.Key.BackSpace) {
			args.RetVal = true;
		} 
	}
}
