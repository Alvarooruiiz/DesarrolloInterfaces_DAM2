   M S B A M L   `   `   `  ����F  BCalculadora, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:CalculadoraCalculadora  5   	   P LBibliotecaCalculadora, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:BibliotecaCalculadora;assembly=BibliotecaCalculadoraBibliotecaCalculadora 5   	       Calculadora.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Calculadora     5   	   dBibliotecaCalculadoraBclr-namespace:BibliotecaCalculadora;assembly=BibliotecaCalculadora     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��144* �6   �� 5      $	��73* �6    � ColumnDefinitions 5   
   �� 5      $	��69* �6   �� 5      $	��91* �6   .+�5   
   (  "BibliotecaCalculadora.UserControl1  -   5          Name$ 
componente��5   -   $��
37,0,57,10q�6A      MaxCaracteresTextBox$ 5��6U      MaxElementosListBox$ 2��6n   $	��268��6�   $��Bottom=�6�   �� 5   
   -   5         ��Name$ texboxLongitud��5      $��1��6+   $
��Left=�6;   $��
41,116,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��209��6�   6�   �� 5   
   -   5         ��Name$ button��5      $��1��6!   $(��"Obtener elemento de mayor longitud��61   $
��Left=�6^   $��
41,139,0,0q�6y   $	��Top=�6�   $��38��6�   $	��209��6�   6�   5      5      