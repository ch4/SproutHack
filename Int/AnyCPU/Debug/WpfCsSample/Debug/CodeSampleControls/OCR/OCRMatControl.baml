   M S B A M L   `   `   `  ����I  EWpfCsSample, Version=1.0.3.1096, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WpfCsSample.CodeSampleControls.OCR"WpfCsSample.CodeSampleControls.OCR  5      6    0WpfCsSample.CodeSampleControls.OCR.OCRMatControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @OCR0clr-namespace:WpfCsSample.CodeSampleControls.OCR     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ]� $��0��6   ��.  $��0,0,0,5q�67   .+�5      �� -   5        $��CaptureButton��5      $��Capture and Extract Text��6*   $��5q�6M   $��70��6X   $
��Left=�6�   {�. 6�   �� 5      $��Zoom:��6   $��Center=�6%   $��Right=�6A   �� 5      -   5        $��
ZoomSlider��5      $	��100��6(   $��Center=�64    � Minimum$	 0.5Q�6O    � Maximum$
 5.00Q�6]    �� Interval$ 1��6l    � Value$ 1Q�6y   $��Right=�5      5      �� 5   
   $��1q�6   
���   �$��1��69   ._�5      � .+�5      �� $
��Auto=�6    $
��Auto=�6E   ��. .��5      �� -   5        $��ItemsControlPanel��5   '   $��0q�6g   ��6@   �� *ItemCollection+��5   #   ��  �� Path$ Root.Boundary.Width���6N   �� $ Root.Boundary.Height� � LayoutTransform 5       �� 5!   "    �� ScaleX 5"   )   ��  �� ElementName$ 
ZoomSlider��$ Value�	 �� ScaleY	 5#   )   �� $ 
ZoomSlider��$ Value���5&      �� 5'   "   .�5(   &   �� 
 �� Property
 �@��Left �� Value 6D   �� *
Boundary.X+�� 5)   &   
 �@��Top 6C   �� *
Boundary.Y+5*   #   ��5-      �� 5.   "   .R�50   "   � .+�52   *   �� $��capturedImage��60    ^� ShowDuration$ 10000��57   ,   ��53   ,   �� *Image+��54   ,   �� $ Boundary.Width���55   ,   �� $ Boundary.Height� � ToolTip 58   .   �� 59   2   
���   ���6<   �� *Text+6R   5;   +   �� 5<   &   
���  ��$��4��5A   6   ��5=   )   �� $ Boundary.Width���5>   )   �� $ Boundary.Height� �� Left 5?   )   �� $ Boundary.TopLeft.X�
 �� Top 5@   )   �� $ Boundary.TopLeft.Y�5A   6   5B   #    �� Triggers 5D   &   P� 5E   *    P� 
SourceName$ capturedImage��62    P� Property �@J�IsMouseOver P� Value . . �5F   .   ��  �� 
TargetName$ capturedImage��65   
 �@J�Opacity$	 0.3Q�6c   5G   +   5I   #   5K      5M      5N      5O      5P      5Q      