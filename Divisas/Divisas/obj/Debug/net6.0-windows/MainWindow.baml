   M S B A M L   `   `   `  ����B  >Divisas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DivisasDivisas  5   	       Divisas.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Divisas     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5        $��	searchBox��5      $
��Left=�6#   $	��Top=�6>   $��10q�6V   $	��200��6b   5      �� 5   
   -   5        $��comboBox��5      $
��Left=�6#   $	��Top=�6>   $��	10,32,0,0q�6V   $	��200��6i    �� 
IsEditable$ False��5       �� IsTextSearchEnabled$ False��6&    J� RenderTransformOrigin$ 0.55,-1.197&�5   @    w� TextPath 5   B   Z� 5   @   �� 5   
   -   5        $��selectedCitiesListBox��5      $��1��6/   $��1��6<   $��10q�6L   ��5      �� 5        �� Path$ SelectedCities�6    �� RelativeSource 60   �� 	 �� AncestorType   Divisas.MainWindow"	  5"      �� 5#   
   -   5        $��Reset��5#      $��Center=�6!   $��3��6>   $��Center=�6K   $��63��6f   $	��128��6r   6~   5'      5(      