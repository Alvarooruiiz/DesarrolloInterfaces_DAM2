   M S B A M L   `   `   `  ����  CalculadoraSalarioNeto'    !CalculadoraSalarioNeto.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Calculadora de Salario Neto��5   	   $	��350��6-   $	��500��6:   $	��500��6F   $	��350��6U    � 	Resources 5         AndroidToggleButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius A�Name	 �� Triggers
 P� Property P� Value �� 
TargetName  CustomCheckBoxStyle ��Name d� 	IsChecked �� RelativeSource  miBoton  MyRadioButtonStyle �� Triggers  CustomTextBoxStyle ��Name �� 	ClickMode �� Path �� Mode �� SelectionBoxItem �� SelectionBoxItemTemplate �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation��%l  &	        &	 �    &	     &	 �    &	 �    '�� �
    �� 5   
   " d�61   .�5      ��  � ��$ 45��6)   �� 5       � ��$ 25��6*   �� 5	       � �� �#DDDDDD6+   �� 5
       � �� �#CCCCCC6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 2q�6(   �� 5       � ��
 �   �6+   �� 5       � �� 5      �� 5      " d�6&   .R�5      �� $ border��6!   #��z��61   #��z��6[   #��z��6�   $ 12��6�   ._�5      � .+�5   "   �� $��Center=�63   $��Center=�6P   (� 5   "   .��5   &   A� $ ellipse��6.   #��z��6?   $��50��6c   $��50��6n   $��2,2,30,2q�6z   5   #   5      5      	 5      P� 5      
 �@d�	IsChecked$
 TrueY�6;   . �5   "   �� $ ellipse��6)    � ��$ 40,2,2,2q�6P   �� 5   "   $ border��6)    � ��
 � ���6S   �� 5   "   $ border��6)    � ��
 � ���6T   5      P� 5      
 �@d�	IsChecked$ FalseY�6;   . �5    "   �� $ ellipse��6)    � ��$ 2,2,45,2q�6P   �� 5!   "   $ border��6)    � �� �#DDDDDD6S   �� 5"   "   $ border��6)    � �� �#CCCCCC6T   5#      5%      5'      5(      �� 5*   
   " ��6,   .�5+      ��  � �� �#0000006+   �� 5,       � �� 5-      �� 5.      " ��6&   .R�5/      �� $ border��6!   ���#DDDDDD���#CCCCCC$��1q�6\   $ 12��6p   ._�50      � .+�51   "   (� .��52   &   �� $ checkBox��6/   #��z��6A    6k   �� *	IsChecked+ �� *TemplatedParent+53   #   54      55      	 56      P� 57      
 �@d�	IsChecked$
 TrueY�6;   . �58   "   �� $ border��6)    � ��
 � ���6S   59      P� 5:      
 �@d�	IsChecked$ FalseY�6;   . �5;   "   �� $ border��6)    � �� �#DDDDDD6S   5<      5>      5@      5A      �� 5C   
   " ��6    .�5D      ��  � ��
 � ���6+   �� 5E       � ��$ Italic$�6*   �� 5F       � ��$	 8,4q�6(   �� 5G       � ��$ 4q�6'   5H      �� 5J   
   " 	�6+   .�5K      ��  � �� �#3333336+   �� 5L       � ��$ 5q�6(   �� 5M       � �� �#FFFFFF6+    5N      P� 5O      
 �@d�	IsChecked$
 TrueY�6/   . �5P      ��  � ��
 � ���63   5Q      5S      �� 5U   
   " ��6+   .�5V      ��  � �� �#FFFFFF6+   �� 5W       � �� �#FFA5006,   �� 5X       � ��$ 1q�60   �� 5Y       � �� �#0000006+   �� 5Z       � ��$ 5q�6(   �� 5[       � ��$ 0,0,0,5q�6'   �� 5\       � �� 5]      �� 5^      " ��6&   .R�5_      �� #��z��6!   #��z��6K   #��z��6w   $ 5��6�   ._�5`      �� $ PART_ContentHost��6+   5a      5b      5d      5e      �� 5g   
   " ��6   .�5h      ��  � �� 5i      �� 5j      " ��6&   .R�5k      �� #��z��6!   #��z��6K   #��z��6w   $ 4��6�   ._�5l      � .+�5m   "   d� $��ToggleButton��5n   %   $�� ��5o   %   ���	#FFFD9717$��1q�5q   %   ���	#FFFECB8C#��z��5s   %   $��3,0,0,0q�5t   %   $
��Left=�5u   %   $��Center=�5v   %   $ Press=�5x   %    5w   %   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+��5y   &   �� 5z   *   " d�6:   .R�5{   .   �� 5|   +   5~   #   �� 5   "   $��ContentSite��5�   %   #��z 5�   %   #��z 5�   %   #��z��5�   %   $��8,0,0,0q�5�   %   $��Center=�5�   %   $
��Left=�5�   %   � 5�   "   $��Popup��5�   %   $��Bottom=�5�   %   #��z 5�   %   $
 True��5�   %   $|�False��5�   %   $��Slide=�5�   %   .��5�   &   � $��DropDown��5�   )   $
 True��5�   )   #��z 5�   )   #��z 5�   )   .+�5�   *   �� $ DropDownBorder��5�   -   ���	#FFFECB8C$��1q�5�   -   ���	#FFFD9717$ 4��5�   -   ._�5�   .   �� $
 True��5�   1   .��5�   2   �� $ 	Contained=�5�   5   5�   /   5�   +   5�   '   5�   #   5�      5�      	 5�      P� 5�      
 � {�$ False��6;   . �5�   "   ��  � �� �	#FF8888886?   5�      P� 5�      
 �@��
IsGrouping$
 True��6<   . �5�   "   ��  � ��$ False��6R   5�      5�      5�      5�      5�      .��5�      � $��0,0,0,0q�6   ��5�   
   �� 5�       �� ImageSource$D >C:\Users\alvar\OneDrive\Escritorio\Fotos\blue-1273089_1280.jpg��6    � RowDefinitions 5�   
   �� 5�      $	��40* �6   �� 5�      $	��42* �6   �� 5�      $	��48* �6   �� 5�      $	��43* �6   �� 5�      $	��45* �6   �� 5�      $	��47* �6   �� 5�      $	��69* �6    � ColumnDefinitions 5�   
   �� 5�      $
��102* �6   �� 5�      $��* �6   �� 5�      $	��99* �6   �� 5�      $	��95* �6   �� 5�      $	��85* �6   .+�5�   
   � $��0��6   $��0��5�      �� 5�   
   $��5��6   $��7��6)   $��0,-4,0,0q�6:   .+�5�      �� $��Salario Bruto Anual:��6   $��5,5,0,0q�64   �� 5�      -   5        $��txtSalarioBruto��5�      #��[ 6-   $	��155��6Y   $
��Left=�6e   $��1,5,0,0q�6�   6�   �� 5�      $��Edad:��6   $��5,5,0,0q�6%   �� 5�      -   5        $��txtEdad��5�      #��[ 6%   $��39��6Q   $
��Left=�6\   $��5,0,0,0q�6�   �� 5�      $��5,5,0,0q�6   Numero de pagas6:   	� 5�      -   5        $��	rb12Pagas��5�      $��12 pagas��6+   #��[ 6>   $��5,0,0,0q�6j   	� 5�      -   5        $��	rb14Pagas��5�      $��14 pagas��6+   #��[ 6>   $��5,0,0,0q�6j   �� 5�      $��5,5,0,0q�6   Situación Familiar:6>   �� 5�      -   5        $��cmbSituacionFamiliar��5�      $��71��63   $
��Left=�6>   $��5,0,0,0q�6Y   ���	#FFFD9717$��1q�6�   .@�5�      �� .��6   	Soltero6(   �� 5�      .��6   Casado6'   �� 5�      .��6   Viudo6&   �� 5�      .��6   
Divorciado6+   5�      �� 5�      $��5,3,0,0q�6   Discapacidad:68   d� 5�      -   5          d�Name$  tglDiscapacidad��5�      #��[  64   $
��Left=�6f   $��8��6�   $��32��6�   ! J� RenderTransformOrigin$! 
2.515,0.41&�6�   $��5,0,0,0q�6�   ���	#FFFD97176�   �� 5�      $��5,5,0,0q�6   Movilidad Geográfica:6@   d� 5�      -   5        $��tglMovilidadGeografica��5�      #��[  69   $
��Left=�6k   $��12��6�   $��38��6�   $��	5,0,0,8.7q�6�   �� 5�      -   5        $��Calcular Salario Neto��5�      $	��150��6W   $
��Left=�6c   #��[ 6~   $
��Bold"�6�   $��5,4,4,4q�6�   5�      �� 5�   
   $��2��6   $
��Left=�6$   $��	73,36,0,0q�6?   $
��Wrap=�6R   $��Calculadora de salario��6f   $	��Top=�6�   $��3��6�   $��94��6�   $��3��6�   $	��175��6�   $��30(�6�   " �� TextAlignment$" Center=�6�   $
��Bold"�6�   5�      5�      5�      