   M S B A M L   `   `   `  ����I  EWpfCsSample, Version=1.0.3.1096, Culture=neutral, PublicKeyToken=nulle7clr-namespace:WpfCsSample.CodeSampleControls.InputLayer)WpfCsSample.CodeSampleControls.InputLayer  5   	   @    :WpfCsSample.CodeSampleControls.InputLayer.HorizontalWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   N
inputLayer7clr-namespace:WpfCsSample.CodeSampleControls.InputLayer     5   	   $	��768��5	   	   $
��1024��6     � 
ResizeMode$  NoResize=�5
   	    � Topmost . 
������� � ShowInTaskbar .   � WindowStyle$
 None=�5   	    � AllowsTransparency .   � Title$ Input Layer Window��5   	   y�5   	   �� *CanShowInputLayer+    BooleanToVisibilityConverter �� 	Converter# [  .��5      � .+�5   
   �� 
���   �$
��Left=�6'   $	��Top=�6B   $��14(�6Z   $
��Auto��6h   $
��Auto��6u   ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      �� 5      	 �� Binding	 6&   �� *IsInputLayerVisible+
 �� Value
 True6N   .a�5      ��  �� Property � �� �� Value$ Input layer is visible��65   5      �� 5      	 6&   �� *IsInputLayerVisible+	
 False6N   .a�5      ��  � ��$  Input layer is not visible��65   5      5      5!      5"      5#      