   M S B A M L   `   `   `  ����I  EWpfCsSample, Version=1.0.3.1096, Culture=neutral, PublicKeyToken=nullm;clr-namespace:WpfCsSample.CodeSampleControls.Classification-WpfCsSample.CodeSampleControls.Classification  5      M    GWpfCsSample.CodeSampleControls.Classification.ClassificationUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Vclassification;clr-namespace:WpfCsSample.CodeSampleControls.Classification     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   ��.  $��0,0,0,5q�67   .+�5      �� -   5         ��Name$ captureButton��5   ?   $��Capture and Classify��6   $��5q�64   $
��Left=�6s   $	��200��6�   5      �� 5   
   $��1q�6   
���   �$��1��69   ._�5      � .+�5      �� $
��Auto=�6   $
��Auto=�6D   ��. .��5      �� $��0q�6J   ��6#   �� *ItemCollection+��5      �� *Root.Boundary.Width+��61   �� *Root.Boundary.Height+��5      �� 5      .�5      ��  �� Property �@��Left �� Value 6<   �� *
Boundary.X+�� 5       �@��Top 6;   �� *
Boundary.Y+5      ��5      �� 5       .R�5!   "   � .+�5"   &   ��  ��Name$ capturedImage��6,   ��5#      �� *Image+��5$      �� *Boundary.Width+��5%      �� *Boundary.Height+ � ToolTip 5&   *   �� 5'   .   
���   ���68   �� *Tag+6M   5)   '   5*   #   5+      5-      5.      5/      50      51      52      