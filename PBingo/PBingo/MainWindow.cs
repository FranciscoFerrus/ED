using System;
using Gtk;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	

	List<int> numeros = new List<int> ();
	List<Button> buttons=new List<Button>();
	Table table;
	Random ran = new Random();
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		table = new Table (9, 10, true);
		table.Visible = true;

		for (uint ind = 0; ind < 90; ind++) {
			uint fila = ind / 10;
			uint columna = ind % 10;
			Button button = new Button (Stock.Ok);
			button.Label = (ind + 1).ToString();
			button.Visible = true;
			table.Attach (button, columna, columna + 1, fila, fila + 1);

			button.ModifyBg (StateType.Normal, new Gdk.Color (220, 200, 200));
			buttons.Add (button);
			numeros.Add ((int)(ind + 1));

			button.Clicked += delegate {
				button.ModifyBg(StateType.Normal, new Gdk.Color(0,220,80));
			};
		}

		vBox.Add (table);
		for(int i=0;i<90;i++){

		};
	}
	

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected void OnGoForwardActionActivated (object sender, EventArgs e)
	{
		int aux = ran.Next (numeros.Count);
		buttons [numeros[aux]-1].ModifyBg (StateType.Normal, new Gdk.Color (80, 220, 0));
		label2.Text = (numeros[aux]).ToString();
		numeros.RemoveAt (aux);

		goForwardAction.Sensitive = numeros.Count > 0;
	}



}
