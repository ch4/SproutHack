   M S B A M L   `   `   `  ����I  EWpfCsSample, Version=1.0.3.1096, Culture=neutral, PublicKeyToken=nullg8clr-namespace:WpfCsSample.CodeSampleControls.TouchBypass*WpfCsSample.CodeSampleControls.TouchBypass  5   	   ?    9WpfCsSample.CodeSampleControls.TouchBypass.ControlsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Gtb8clr-namespace:WpfCsSample.CodeSampleControls.TouchBypass     5   	   $	��768��5	   	   $
��1024��5
   	     � 
ResizeMode$  NoResize=�5   	    � Topmost . 
������� � ShowInTaskbar .   � WindowStyle$
 None=�5   	    � AllowsTransparency .   � Title$ Input Layer Window��5   	   y�5   	   �� *IsMatAvailable+    BooleanToVisibilityConverter �� 	Converter# [   � 	Resources 5        CircleButton �� 
TargetType	 �� Property
 �� Value �� 
TargetType � Offset � Color��%  &	       �� 5   
   " ��6%   .�5      �� 	 � ��$	
 100��6&   �� 5      	 � ��$	
 100��6'   �� 5      	 � ��$
 30(�6)   �� 5      	 � ��
 5      �� 5      " ��6&   .R�5      �� ._�5      � .+�5   "   A� #��z��6*   A� 5   "   ��5    &   
� 5!   *   .��5"   .   � $	 0.0Q�6;   $ 	#00000000��6H   � 5#   .   $	 0.8Q�6;   $ 	#00000000��6H   � 5$   .   $	 1.0Q�6;   $ 	#80000000��6H   5%   +   5'   #   A� 5(   "   $��10q�6*   ��5)   &   �� 5*   *   .��5+   .   � $ 0Q�6;   $ 	#50FFFFFF��6F   � 5,   .   $	 0.5Q�6;   $ 	#00FFFFFF��6H   � 5-   .   $ 1Q�6;   $ 	#50FFFFFF��6F   5.   +   50   #   �� 51   "   $��Center=�63   $��Center=�6P   52      53      54      56      57      58      .��59      � .+�5:   
   �� .+�5;      �� E   ?WpfCsSample.CodeSampleControls.TouchBypass.TouchBypassViewModel   VK_PRIOR#��Z 6;   $��Page Up��6z    �� Left$	 238��6�   
 �� Top$	 356��6�   #��[ 6�     HPBrandingBlue#��[ 6�   ��6   �� *ControllerCommand+6�   �� 5<         VK_NEXT#��Z 6;   $��	Page Down��6y   $	 238��6�   $	 556��6�   #��[ 6�   #��[ 6�   ��6   �� *ControllerCommand+6�   �� 5=         VK_HOME#��Z 6;   $
��Home��6y   $	 138��6�   $	 456��6�   #��[ 6�   #��[ 6�   ��6   �� *ControllerCommand+6�   �� 5>         VK_END#��Z 6;   $	��End��6x   $	 338��6�   $	 456��6�   #��[ 6�   #��[ 6�   ��6   �� *ControllerCommand+6�   �� 5?         VK_UP#��Z 6;   $��Up��6w   $	 638��6�   $	 356��6�   #��[ 6�     HPBrandingRed#��[ 6�   ��6   �� *ControllerCommand+6�   �� 5@         VK_DOWN#��Z 6;   $
��Down��6y   $	 638��6�   $	 556��6�   #��[ 6�   #��[ 6�   ��6   �� *ControllerCommand+6�   �� 5A         VK_LEFT#��Z 6;   $
��Left��6y   $	 538��6�   $	 456��6�   #��[ 6�   #��[ 6�   ��6   �� *ControllerCommand+6�   �� 5B         VK_RIGHT#��Z 6;   $��Right��6z   $	 738��6�   $	 456��6�   #��[ 6�   #��[ 6�   ��6   �� *ControllerCommand+6�   5C      5D      5E      