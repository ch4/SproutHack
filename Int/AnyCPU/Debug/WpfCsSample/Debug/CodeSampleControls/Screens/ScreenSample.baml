   M S B A M L   `   `   `  ����I  EWpfCsSample, Version=1.0.3.1096, Culture=neutral, PublicKeyToken=null_4clr-namespace:WpfCsSample.CodeSampleControls.Screens&WpfCsSample.CodeSampleControls.Screens  5      9    3WpfCsSample.CodeSampleControls.Screens.ScreenSample   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hscreens4clr-namespace:WpfCsSample.CodeSampleControls.Screens     5        � 	Resources  5
       �� DataType;   5WpfCsSample.CodeSampleControls.Screens.ScreenTypeInfo   ScreenTypeInfoTemplate �� Path � ColumnDefinitions � RowDefinitions � ToolTip �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Padding �� StringFormat��%
  &	        �� 5   
   "  6   .R�5      �� $��2q�6   
���   �
����  ���5      �� $ PixelExtent.Width���5      �� $ PixelExtent.Height�._�5      (� .��5      � $��10q�6    5      �� 5      $
��Auto �6/   �� 5      $��10 �6/   �� 5      $
��Auto �6/   �� 5      $��* �6/    5      �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5      $
��Auto �6,   �� 5       $��50 �6,   �� 5!      $��* �6,   .+�5$      �� $��0��6$   $��0��61   $	��ID:��6A   $	��5,0q�6L   
���   �6Y   �� 5%      $��0��6$   $��2��61   $��SemiBold"�6�   
���   ���6A   �� $ ScreenId� 6`   �� $ ScreenId�  5&      ���� 5'   "   '_�       " _�6(   .�5(   &   ��  �@�OverridesDefaultStyle . 6N   �� 5)   &    � ��
 �   �6C   �� 5*   &    �@_�HasDropShadow . 6F   �� 5+   &    � �� 5,   *   �� 5-   .   "	 _�6>   .R�5.   2   �� 
�������$	
 5,2q�6K   ._�5/   6   �� 50   3   51   /   53   '   54   #   55      56      �� 58      $y�	Collapsed=�6$   $��1��6;   $��0��6H   $��Name:��6X   $	��5,0q�6e   
���   �6r   �� 59      $y�	Collapsed=�6$   $��1��6;   $��2��6H   $��SemiBold"�6y   
���   ���6X   �� $ 
ScreenName�6�   �� 5;      $��2��6$   $��0��61   $��H. PixelDensity:��6A   $	��5,0q�6Y   
���   �6f   �� 5<      $��2��6$   $��2��61   $��SemiBold"�6�   
���   ���6A   �� $ PixelDensity.X�$ {0:0.00 dots/mm}��6�   �� 5>      $��3��6$   $��0��61   $��V. PixelDensity:��6A   $	��5,0q�6Y   
���   �6f   �� 5?      $��3��6$   $��2��61   $��SemiBold"�6�   
���   ���6A   �� $ PixelDensity.Y�$ {0:0.00 dots/mm}��6�   �� 5A      $y�	Collapsed=�6$   $��4��6;   $��0��6H   $��ScreenType:��6X   $	��5,0q�6k   
���   �6x   �� 5B      $y�	Collapsed=�6$   $��4��6;   $��2��6H   $��SemiBold"�6y   
���   ���6X   �� $ 
ScreenType�6�   �� 5D      $��5��6$   $��0��61   $��
Work Area:��6A   $	��5,0q�6S   
���   �6`   �� 5E      $��5��6$   $��2��61   $��SemiBold"�6c   
���   ���6A   �� $ PixelExtent�6y   �� 5G      $��6��6$   $��0��61   $��Offset:��6A   $	��5,0q�6P   
���   �6]   �� 5H      $��6��6$   $��2��61   $��SemiBold"�6^   
���   ���6A   �� $ Origin�6t   5I      5J      5K      5L      5M      .��5N      �  5O   
   �� 5P      $��* �6    5R   
   �� 5S      $
��Auto �6   �� 5T      $��* �6   .+�5V   
   �� -   5        $��Display Screen Info��5V      $	��200��6W   $��5q�6c   (� 5W   
   $��1��6   y�6   �� *	HasInfo+   BooleanToVisibilityConverter �� 	Converter# [ .��5X      �� $��5q�6E   #��[  6P   ��6   �� $ AvailableDisplays���5Y      �� 5Z      .R�5[      �� ��6!   �� *CanvasSize.Width+��6D   �� *CanvasSize.Height+5\      ��5^      �� 5_      " ��6   .�5`      ��  �@��Left 68   �� $ Origin.X��� 5a       �@��Top 67   �� $ Origin.Y�5b      5d      5e      5f      5g      