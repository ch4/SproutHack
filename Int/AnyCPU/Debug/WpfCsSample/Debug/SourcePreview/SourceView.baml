   M S B A M L   `   `   `  ����  WpfCsSample*    $WpfCsSample.SourcePreview.SourceView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Source Viewer��5   	   $	��800��5   	   $	��600��5   	    � 	Resources 5       �� 
TargetType �� Property �� Value   SourceCodeTabItemStyle �� 
TargetType �Name ��Name �� Padding	 �� Triggers
 P� Property P� Value �� 
TargetName  HPBrandingDarkGrey  HPBrandingLightColor  ButtonForegroundColor  FlowDocumentConverter �� 	Converter-  'System.Windows.Input.KeyboardNavigation   TabNavigation � RowDefinitions ��Name K� ZIndex K� IsItemsHost   TabIndex ��Name   DirectionalNavigation ��Name��%2  '��       '/�      &	  �     7  7  7  7  '�� �    7  �� 5	   
   " ��6   �� 5
   
   " /�6   .�5      ��  �@/�TextAlignment$
 Left=�6.   �� 5       �@/�
FontFamily$ Lucida Console)�6+   �� 5       �@/�PagePadding$ 5q�6,   5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � $ 
HeaderGrid��6   .+�5      � $��Center=�6#   $
��Left=�6>   .+�5   "   �� $ HeaderTextBlock��6,   $	��120��6E   $ 10q�6T   #��z��6a   $
��13px(�6�   5      5      	 5      P� 5      
 �@��
IsSelected . . �5   "   �� $ 
HeaderGrid��6)   8    � ��6W   �� 5   "   $ HeaderTextBlock��6)   8   � ��6\   5      5       5"      �� 5$       � ��$
 Left=�64   �� 5%       � ��8  6+   �� 5&       � �� 6'   �� *
FileName+�� 5'       � �� 6(   �� �� 5(       � �� 5)      �� 5*      .R�5+      �� ��6)   �� 8  5,      5.      5/      �� 51   
   " ��6   .�52      ��  � �� 53      �� 54      " ��6&   .R�55      � $ Local=�6    56      �� 57   "   $
��Auto �60   �� 58   "   $��* �60   .+�5:      �� $ HeaderPanel��6'   $��0��5;   '   $ 1��5<   '    . $ 1��5>   '   
������ 5?   '   �� 5@      $ Border��6%   8��  $��1��5B   %   $ Local=�5C   %   $ 	Contained=�5D   %   $ 2��5E   %   ._�5F   "   �� $ PART_SelectedContentHost��63   $��SelectedContent��6U   5G      5H      5I      5K      5L      5M      .��5N      �   DarkGreyBkg#��[ 6   .+�5O   
   �� #��[  5P       �� SelectedIndex$ 0��5Q      ��5O      �� 5Q      5S      5T      