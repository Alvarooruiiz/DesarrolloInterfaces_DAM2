   M S B A M L   `   `   `  ����E  AFormulario, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GridPanel	GridPanel  5   	       GridPanel.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:GridPanel     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��945��6)   $	��450��65   $	��945��6E   $	��450��6T   $	��945��6d   .��5	      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ tbNombre��5      $��48,58,753,334q�6$   $��1��6;   6d   �� 5   
   -   5        $ tbApellidos��5      $��212,58,593,334q�6'   $��1��6?   6h   �� 5   
   -   5        $ tbDireccion��5      $��380,58,425,334q�6'   $��1��6?   6h   �� 5   
   -   5         ��Name$ btnAñadirEditar��5      $��Añadir��6*   $��67,344,761,48q�6V   $��1��6m   �� 5   
   -   5        $ btnEliminar��5      $��Eliminar��6&   $��228,344,601,48q�6P   $��1��6h   �� 5   
   -   5        $ btnReset��5      $��Reset��6#   $��396,344,433,48q�6G   $��1��6_   �� 5   
   -   5         ��Name$ btnDisminuirAltura��5      $
��Left=�63   $��20��6N   $��224,131,0,0q�6Z   $��1��6o   $	��Top=�6|   $��20��6�    �� Interval$	 100��6�    �� Delay$	 500��6�   $��<��6�   �� 5   
   -   5        $ btnAumentarAltura��5      $
��Left=�62   $��20��6M   $��316,131,0,0q�6Y   $��1��6n   $	��Top=�6{   $��20��6�   $	 100��6�   $	 500��6�   $��>��6�    J� RenderTransformOrigin$ -0.063,0.459&�6�   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ dataGrid��5      $��1��6%   	   AutoGenerateColumns$	 False��62   $��536,25,10,10q�6N   
   
IsReadOnly$

 True��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Nombre+6P     5      $ 	Apellidos��6%   $ * 6V    68   �� *	Apellidos+6V     5      $ 
Dirección��6%   $ * 6V    68   �� *	Direccion+6V     5      $ Fecha de nacimiento��6%   $ * 6\    6B   �� *Fecha+6\     5      $ Altura��6%   $ * 6P    65   �� *Altura+6P     5       $ 	Nº hijos��6%   $ * 6T    67   �� *
NumHijos+6T   5"      �� 5#   
   -
   5         ��Name$ cbTieneHijo��5#      $��Tiene hijos?��6(   $��396,120,441,272q�6?   $��1��6X   $ 0.439,1.566&�6e   6�   (  "System.Windows.Controls.DatePicker  5$   
   -   5          Name$ 
datePicker��5$      $��48,126,753,261q�6)   $��1��6A   �� 5%   
   -   5        $ tbAltura��5%      $
��Left=�6$   $��254,131,0,0q�6?   $��1��6T    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $��50��6�    �� 
IsReadOnly$
 True��6�   �� 5&   
   -   5         ��Name$ sliderNumHijos��5&      $
��Left=�6)   $��364,150,0,0q�6D   $��1��6Y   $	��Top=�6f   $	��120��6~   $y�Visible=�6�    �� IsSnapToTickEnabled$
 True��6�   �� 5'   
   -   5         ��Name$ lbHijos��5'      $��1��6#   $��231,195,617,145q�6[   $y�Hidden=�6t   6�   R� 5(   
   -   5         R�Name$ tvHijos��5(      $��1��6$   $��364,195,423,145q�61   $y�Hidden=�6J   �� 5)   
   -   5        $ tbNombreHijo��5)      $
��Left=�6(   $��52,0,0,0q�6C   $��1��6U   $
 Wrap=�6b   $��Center=�6v   $	��120��6�   $��45��6�   $y�Hidden=�6�   �� 5*   
   -   5        $ btnAgregarActualizarHijos��5*      $��Agregar hijo��64   $
��Left=�6K   $��
72,259,0,0q�6f   $��1��6z   $	��Top=�6�   $��30��6�   $��80��6�   $y�Hidden=�6�   �� 5+   
   $��Nombre��6   $
��Left=�6!   $��	48,25,0,0q�6<   $	��Top=�6O   $��1��6g   �� 5,   
   $��Apellido��6   $
��Left=�6#   $��
212,25,0,0q�6>   $	��Top=�6R   $��1��6j   �� 5-   
   $��	Direccion��6   $
��Left=�6$   $��
380,25,0,0q�6?   $	��Top=�6S   $��1��6k   �� 5.   
   -   5         ��Name$ tbNHijos��5.      $
��Left=�6&   $��502,149,0,0q�6A   $��1��6V   $
��Wrap=�6c   $	��Top=�6w   $��29��6�   $��24��6�   51       � ContextMenu 53      �� 54   
   -   5        $��MyContextMenu��54      .@�55      m� $��Cambiar Color de Fondo��6   .@�56      m� -   5        $��Verde��56      $��Verde��6(   67   m� 57      -   5        $
��Cyan��57      $
��Cyan��6'   65   m� 58      -   5        $��Blanco��58      $��Blanco��6)   69   59      m� 5:      -   5        $��VaciarLista��5:      $��Vaciar Lista��6*   6@   5<      5?      