   M S B A M L   `   `   `  ����I  EWpfCsSample, Version=1.0.3.1096, Culture=neutral, PublicKeyToken=nullo<clr-namespace:WpfCsSample.CodeSampleControls.TrackingHandler.WpfCsSample.CodeSampleControls.TrackingHandler  5      N    HWpfCsSample.CodeSampleControls.TrackingHandler.TrackingHandlerMatControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      XtrackingHandler<clr-namespace:WpfCsSample.CodeSampleControls.TrackingHandler     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   ]� $��0��6   ��.  $��0,0,0,5q�67   .+�5      �� -   5        $��CaptureButton��5      $��Capture��6*   $��5q�6<   $��70��6G   $
��Left=�6r   {�6�   �� *
CanCapture+�� 5      -   5        $��CapturePreviewImage��5      $��Uniform=�6/   $��80��6A   $��60��6L   $
��Left=�6X   $��20,0,0,0q�6n   ��6�   �� *
Root.Image+�� 5      $��Right=�6   $	��100��6,   $��Center=�68    � Minimum$	 0.2Q�6S    � Maximum$ 5Q�6a    �� Interval$ 1��6m    � Value 5      �� *ScaleFactor+�� 5      $
��Zoom��6   $��Right=�6$   $��Center=�6;   $��5q�6V   5      �� 5   
   $��1q�6   
���   �$��1��69   ._�5      � .+�5      �� $
��Auto=�6   $
��Auto=�6D   ��. .��5      �� -   5        $��ItemsControlPanel��5   #   $��0q�6c   ��6<   �� *ItemCollection+��5   #   ��  �� Path$ Root.Boundary.Width���6N   �� $ Root.Boundary.Height���5      �� 5      .R�5   "   ��  � LayoutTransform 5    &   �� 5!   *    �� CenterX$ 0Q�5#   9    �� CenterY$ 0Q�6E   	 �� ScaleX	 5!   9   �� *ScaleFactor+
 �� ScaleY
 5"   9   �� *ScaleFactor+5#   E   5%   #   5&      ��5)      �� 5*      .�5+   "   ��  �� Property �@��Left �� Value 6@   �� *
Boundary.X+�� 5,   "    �@��Top 6?   �� *
Boundary.Y+5-      ��50      �� 51      .R�52   "   � .+�53   &   �� $��capturedImage��6,   ��54   ,   �� *Image+��55   ,   �� $ Boundary.Width���56   ,   �� $ Boundary.Height��� 58   &   $��
objectName��6.   $
��Left=�5:   .   $��26(�5;   .   $��50��5<   .   $	��300��5=   .   $��Stretch=�5>   .    �� TextWrapping$
 Wrap=�5?   .   $��5q�5@   .   ��59   .   �� *Name+ �� 
IsReadOnly 5A   .   �� *
IsReadOnly+.��6P   5B   '   F� 5C   &   $��captureContour��6+   
���   �$��4��5E   :    J� Opacity$	 0.5Q�6N    �� StrokeLineJoin$ Round=�5F   +   ��5D   +   �� *	Outline+ 5H   *   �� 5I   .   $ 0Q�5K   =   $ 0Q�5L   =   	 5I   =   �� *OutlineScale.X+
 5J   =   �� *OutlineScale.Y+5L   =   5O   '   5P   #    �� Triggers 5Q   "   P� 5R   &    P� 
SourceName$ capturedImage��6.    P� Property �@J�IsMouseOver P� Value . . �5S   *   ��  �� 
TargetName$ captureContour��61    � ��
 ��  �6_   �� 5T   *   $ captureContour��61    �@J�BitmapEffect 5U   .   F� 5V   2   5X   +   �� 5Y   *   $ captureContour��61    �@J�Opacity$	 1.0Q�6`   5Z   '   5\      5^      5_      5a      5e      � 5f   
   $��2��6   .+�5g      �� -   5        $��StartButton��5g      $��Start��6(   $ 0Q�6S   $��5q�6_   $	��145��6j   $
��Left=�6v   {�.  6�   �� 5h      -   5        $��
StopButton��5h      $
��Stop��6'   $ 0Q�6Q   $��
252,10,0,0q�6]   $
��Left=�6q   {�.  6�   5i      5j      5k      