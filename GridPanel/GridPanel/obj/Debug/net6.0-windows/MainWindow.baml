   M S B A M L   `   `   `  ����D  @GridPanel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:GridPanel	GridPanel  5   	       GridPanel.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:GridPanel     5   	     � Title$  
MainWindow��5   	   $	��640��6   $	��800��6)   .��5	      � .+�5   
   �� $
��Left=�6   $	��321��60   $��	453,0,0,0q�6=   $��Center=�6P   $	��315��6k   ���	#FFCFCFCF.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         AutoGenerateColumns$ False��6)      
IsReadOnly$
 True��6E      SelectionMode$ Single=�6W      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Nombre+6T     5      $ Apellido��6)   $ * 6X    6;   �� *
Apellido+6X     5      $ 
Dirección��6)   $ * 6Z    6<   �� *	Direccion+6Z     5      $ 	Nº Hijos��6)   $ * 6X    6;   �� *
NumHijos+6X     5      $ Fecha��6)   $ * 6k    68   �� *Fecha+	 �� StringFormat$	 
dd/MM/yyyy��6k     5      $ Altura��6)   $ * 6T    69   �� *Altura+6T   5      5      �� 5   
   -   5        
 ��Name$
 errorTextBlock��5      
���  ��$��318,94,318,191q�6=   �� 5   
   $��Nombre��6   $
��Left=�6!   $��	77,70,0,0q�6<   $	��Top=�6O   �� 5   
   -   5         ��Name$ 	txtNombre��5      $
��Left=�6%   $��
77,101,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5   
   $��Apellido��6   $
��Left=�6#   $��
77,145,0,0q�6>   $	��Top=�6R   �� 5   
   -   5        $ txtApellido��5      $
��Left=�6'   $��
77,176,0,0q�6B   $
 Wrap=�6V   $	��Top=�6j   $	��120��6�   �� 5   
   $��
Dirección��6   $
��Left=�6$   $��
77,217,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ txtDireccion��5      $
��Left=�6(   $��
77,248,0,0q�6C   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   �� 5    
   -   5         ��Name$ 
btnAddEdit��5       $��_Añadir��6%   $
��Left=�67   $��
73,501,0,0q�6R   $	��Top=�6f   $��43��6~   $��86��6�   6�   �� 5!   
   -   5        $ DeleteButton��5!      $��	_Eliminar��6'   $
��Left=�6;   $��335,501,0,0q�6V   $	��Top=�6k   $��43��6�   $��86��6�   6�   �� 5"   
   -   5        $ ResetButton��5"      $��_Reset��6&   $
��Left=�67   $��197,496,0,0q�6R   $	��Top=�6g   $��43��6   $��86��6�   6�   �� 5#   
   -	   5         ��Name$ cbHijos��5#      $��Tiene hijos?��6$   $
��Left=�6;   $��
77,283,0,0q�6V   $	��Top=�6j   6�   �� 5$   
   -
   5         ��Name$ sliderNumHijos��5$      $
��Left=�6)   $��
77,312,0,0q�6D   $	��Top=�6X   $	��120��6p    � Minimum$ 0Q�6|    � Maximum$ 10Q�6�    � Value$ 0Q�6�   $y�Hidden=�6�   (  "System.Windows.Controls.DatePicker  5%   
   -   5          Name$ 
datePicker��5%      $
��Left=�6)   $��
240,95,0,0q�6D   $	��Top=�6X   �� 5&   
   -   5         ��Name$ btnDisminuirAltura��5&      $
��Left=�63   $��20��6N   $��260,148,0,0q�6Z   $	��Top=�6o   $��20��6�    �� Interval$	 100��6�    �� Delay$	 500��6�   $��<��6�   �� 5'   
   -   5        $ btnAumentarAltura��5'      $
��Left=�62   $��20��6M   $��344,148,0,0q�6Y   $	��Top=�6n   $��20��6�   $	 100��6�   $	 500��6�   $��>��6�    J� RenderTransformOrigin$ 0.041,0.463&�6�   z�5(      V� 5)      .~�5*      �� �� 5+      �� 5,       �� Angle$ -1.101Q�6&   T� 5-       T� X$ -0.01Q�6)    T� Y$ 0.178Q�63   5.      50      �� 51   
   -   5        $ tbAltura��51      $
��Left=�6$   $��292,148,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $��40��6�    �� IsReadOnlyCaretVisible$
 True��6�   �� 52   
   -   5        $��listBoxNombresHijos��52      $��240,193,422,357q�6-   �� 53   
   -   5        $��txtNombreHijo��53      $��255,272,437,291q�6'   �� 54   
   -   5        $ AgregarHijo��54      $��Agregar Hijo��6&   $��268,335,450,241q�6W   R� 55   
   -   5        $��treeView��55      $��487,257,113,265q�6#   $	��200��6<   58      5:      