   M S B A M L   `   `   `  ����I  EWpfCsSample, Version=1.0.3.1096, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfCsSampleWpfCsSample  5   	       WpfCsSample.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1wpfCsSampleclr-namespace:WpfCsSample     5   	   -   5          � ShowInTaskbar  .  � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      WindowBackgroundColor#��[  5   	    � WindowStyle$
 None=�5   	    � Title$# Sprout SDK Sample App for WPF��5   	   $	��810��5   	   $
��1100��6    � 	Resources 5       �� 
TargetType �� Property �� Value	 �� 
TargetType
 � ColumnDefinitions K� IsItemsHost  PageBackgroundColor �� Padding � RowDefinitions  StringToVisibilityConverter �� 	Converter   BooleanToVisibilityConverter  SampleTabItemStyle �� Padding �� Triggers P� Property P� Value �� 
TargetName  HighlightColor  ButtonForegroundColor��%S  '��       7  7  7  &	 �    7  7  7  �� 5   
   " ��6   .�5      ��  �@��TabStripPlacement$
 Left=�62   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      � 
 5      �� 5   "   $
��Auto �63   �� 5   "   $��* �63   .+�5      ��  . 6'   � 5       $��1��6#   .+�5!   "   �� 8��  $ 30q�6[   ._�5"   &   �� $��Stretch=�5#   +   $��Stretch=�5$   +   $��SelectedContent��5%   +   $��0q�5&   +   ��5'   *   �� 5(   .   .R�5)   2   � 
 5*   6   �� 5+   :   $��* �6K    5-   6   �� 5.   :   $
��Auto �6H   �� 5/   :   $
��Auto �6H   �� 50   :   $��* �6H   .+�52   6   �� $��0��6@   $
��Wrap=�6M   ��6a   �� *Description+y�6~   �� *Description+8  �� 53   6   -   5        $��1��53   =   $��Show Source Code��6J   y�6~   �� *HasSourceCodes+8  �� 54   6   $��2��6E   ��6R   �� *SampleContent+55   3   56   /   58   '   59   #   5:      5;      5<      5>      5?      �� 5A   
   " ��6   .�5B      ��  � �� 5C      �� 5D      "	 ��6&   .R�5E      � $
��Grid��6   .+�5F      � $��Center=�6#   $
��Left=�6>   .+�5G   "   �� $	��180��6,   $ 10, 10, 0, 10q�68   $
��13px(�6g   ��6P   �� *Title+6g   5H      5I       5K      P� 5L       �@��
IsSelected . . �5M   "   �� $
 Grid��6)   8    � ��5N   !   5O      P� 5P       � {� .  . �5Q   "   �� $
 Grid��6)   8   � ��5R   !   5S      5V      5X      �� 5Z       � ��$
 Left=�64   �� 5[       � ��8  6+   5\      5]      .��5_      �  5`   
   �� 5a      $
��Auto �6   �� 5b      $��* �6   �� 5c      $
��Auto �6   .+�5f   
   � -   5        $��76��5f        DarkGreyBkg#��[ 6   
 5g      �� 5h      $��76 �6#   �� 5i      $��* �6#   �� 5j      $��76 �6#   .+�5l      �� $&�� /AppAssets/sprout_blue_64x64.png��6   $��64��6>   $��64��6J   z�5m      T� 5n       T� X$ 1Q�6)    T� Y$ 1Q�6/   5p      �� 5r      $��1��6   ._�5s      �� $
��25px(�6   $��14, 0, 0, 0q�6,     HPSimplifiedRegular#��[ 6A   $��Center=�6s   $#��Sprout SDK Sample App for WPF��6�   5t      �� 5u      -   5        $��2��5u      $��0q�6>   $��0q�6I   ��5v      �� 5w      .R�5x      �� $��AppAssets/X.png��6    $��28��69   $��28��6D   5y      5{      5|      �� 5~   
   -   5        $��1��5~      #��[ 5�       �� TabStripPlacement$
 Left=�5�      ��5      �� *Tabs+ �� SelectedIndex 5�      �� *SelectedIndex+5�      �� 5�   
   
���  ��$��2��6"   y�6/   �� *ErrorStatus+# [ ._�5�      �� $
��Wrap=�6   $��2��6,   $
��15,5q�69   
�������$��14(�6Z   $
��Bold"�6h   $
��Left=�6z   ��6�   �� *ErrorStatus+5�      5�      5�      