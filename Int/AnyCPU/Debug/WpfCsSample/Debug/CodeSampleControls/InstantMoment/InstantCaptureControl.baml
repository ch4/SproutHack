   M S B A M L   `   `   `  ����I  EWpfCsSample, Version=1.0.3.1096, Culture=neutral, PublicKeyToken=nullk:clr-namespace:WpfCsSample.CodeSampleControls.InstantMoment,WpfCsSample.CodeSampleControls.InstantMoment  5      H    BWpfCsSample.CodeSampleControls.InstantMoment.InstantCaptureControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      TinstantMoment:clr-namespace:WpfCsSample.CodeSampleControls.InstantMoment     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   ��.  $��0,0,0,5q�67   .+�5      �� -   5        $��Capture��5      $��5q�6'   $
��Auto��62   $
��Left=�6\   {�6r   �� *
CanCapture+�� 5      $��Uniform=�6   $��80��6&   $��60��61   $
��Left=�6=   $��20,0,0,0q�6S   ��6e   �� *
Root.Image+�� 5      $��Status:��6   $
��Left=�6'   $��Center=�6=   $��5q�6X   �� 5      $
��Left=�60   $��Center=�6F   $��5q�6a   ��6   �� *Status+6a   �� 5      $��Right=�6   $	��100��6,   $��Center=�68    � Minimum$	 0.2Q�6S    � Maximum$ 5Q�6a    �� Interval$ 1��6m    � Value 5      �� *ScaleFactor+�� 5      $
��Zoom��6   $��Right=�6$   $��Center=�6;   $��5q�6V   5      �� 5   
   $��1q�6   
���   �$��1��69   ._�5      � .+�5      �� $
��Auto=�6   $
��Auto=�6D   ��. .��5      �� $��0q�5   #   ��5   #   �� *ItemCollection+��5   #   ��  �� Path$ Root.Boundary.Width���5   #   �� $ Root.Boundary.Height� � LayoutTransform 5!      �� 5"       �� CenterX$ 0Q�5$   -    �� CenterY$ 0Q�5%   -   	 �� ScaleX	 5"   -   �� *ScaleFactor+
 �� ScaleY
 5#   -   �� *ScaleFactor+5%   -   ��5(      �� 5)      .R�5*   "   �� 5+      ��5.      �� 5/      .�50   "   ��  �� Property �@��Left �� Value 6@   �� *
Boundary.X+�� 51   "    �@��Top 6?   �� *
Boundary.Y+52      ��55      �� 56      .R�57   "   �  � ToolTip 6'   �� *	Tooltip+.+�58   &   �� $��CaptureImage��6,   ��59   ,   �� *Image+��5:   ,   �� $ Boundary.Width���6R   �� $ Boundary.Height�F� 5<   &   $��CaptureContour��6+   
���   �$��4��5>   :    J� Opacity$	 0.6Q�6N    �� StrokeLineJoin$ Round=�5?   +   ��5=   +   �� *	Outline+ 5A   *   �� 5B   .   $ 0Q�5D   =   $ 0Q�5E   =   	 5B   =   �� *OutlineScale.X+
 5C   =   �� *OutlineScale.Y+5E   =   5H   '   �� 5I   &   $��
BondingBox��60   $y�Hidden=�5J   0   
����  �$��2��5K   B    �� StrokeDashArray$	 4 4R�6V   5M   #    �� Triggers 5N   "   P� 5O   &    P� 
SourceName$ CaptureImage��6.    P� Property �@J�IsMouseOver P� Value . . �5P   *   ��  �� 
TargetName$ CaptureContour��61    � ��
 ��  �6_   �� 5Q   *   $ CaptureContour��61    �@J�BitmapEffect 5R   .   F� 5S   2   5U   +   �� 5V   *   $ CaptureContour��61    �@J�Opacity$	 1.0Q�6`   �� 5W   *   $ 
BondingBox��61    � y�$ Visible=�6_   5X   '   5Z      5\      5]      5^      5_      5`      5a      