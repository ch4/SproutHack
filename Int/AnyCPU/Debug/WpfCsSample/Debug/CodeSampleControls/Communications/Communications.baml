   M S B A M L   `   `   `  ����I  EWpfCsSample, Version=1.0.3.1096, Culture=neutral, PublicKeyToken=nullm;clr-namespace:WpfCsSample.CodeSampleControls.Communications-WpfCsSample.CodeSampleControls.Communications  5      B    <WpfCsSample.CodeSampleControls.Communications.Communications   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Vcommunications;clr-namespace:WpfCsSample.CodeSampleControls.Communications     5      .��5      � $��15q�6     � RowDefinitions  5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5        $
��15,0q�5      $��Start��6#   $	��150��63   {�6?   �� *StartIsEnabled+6d   �� 5      -   5        $
��15,0q�5      $
��Stop��6#   $	��150��63   {�6?   �� *	IsEnabled+6_   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��1q�6%   
�������._�5      �   5      �� 5      $
��Auto �6(   �� 5      $��* �6(   .+�5       �� $ 
Horizontal=�6!   $��0��6:   .+�5!      �� $��Left player��6$   $��15q�67   $��Center=�6C   �� 5"      -   5        $��Send Message��5"   !   $��30,15q�68   $	��230��6G   {�6S   �� *	IsEnabled+6s   5#      �� 5$      $��5q�6I   ��. $��1��6y   $
��Auto=�5%      ��5$      �� *LeftPlayerMessages+5%      5&      5'      �� 5(      $��1��6   $��1q�6%   
�������._�5)      �   5*      �� 5+      $
��Auto �6(   �� 5,      $��* �6(   .+�5.      �� $ 
Horizontal=�6!   $��0��6:   .+�5/      �� $��Right player��6$   $��15q�68   $��Center=�6D   �� 50      -   5        $��Send Message��50   !   $��30,15q�68   $	��230��6G   {�6S   �� *	IsEnabled+6s   51      �� 52      $��5q�6J   ��. $��1��6{   $
��Auto=�53      ��52      �� *RightPlayerMessages+53      54      55      56      57      58      