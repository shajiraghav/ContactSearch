   M S B A M L   `   `   `  ����H  DContactSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ContactSearchContactSearch  5   	   H DSearchTextBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>/clr-namespace:UIControls;assembly=SearchTextBox
UIControls 5   	   C&clr-namespace:ContactSearch.ConvertersContactSearch.Converters  5   	       ContactSearch.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ContactSearch     5   	   Actrls/clr-namespace:UIControls;assembly=SearchTextBox     5   	   6cnv&clr-namespace:ContactSearch.Converters     5   	     � Title$  Contact Search by Shaji��5
   	   $
��Auto��6)   $
��Auto��67    � SizeToContent$ WidthAndHeight=�6D    � 
ResizeMode$ NoResize=�6c   
����ح� � 	Resources 5      -   'ContactSearch.Converters.ImageConverter   imgConverter  VisibilityConverter  headerTemplate �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value  controlSeperator  tooltiptemplate � ToolTip �� Orientation	 �� Path
 �� 	Converter��%	  &	        &	      &	 &     &	 �     &	 V    7     5   
   6   �� 5   
   6'   �� 5   
   "  6'   .�5      ��  � ��$
 Bold"�6,   �� 5       � ��$
 Left=�64   �� 5       � ��$ Center=�6;   �� 5       � ��
 �  ��6,   5      �� 5   
   " ��6)   .�5      ��  � ��$ 4��6&   �� 5       �@J�Opacity$ 0Q�6(   5      �� 5   
   .R�5      �� $��Photo��6   $��	Underline{�6%   
����  � 5      �� 5      $ Vertical=�6!   .+�5      �� ��6    �� $	 Photo�8
   �� 5      
�������
���   ��� 5      �6"   �� *	FirstName+ �� 5       �6"   �� *
MiddleName+ �� 5!      �6"   �� *
LastName+5"      5#      5%      5&      5'      .��5)      � $
��Auto��6   $��10q�6   {�6$   �� *
UiEnable+ � ColumnDefinitions 5*   
   �� 5+      6!   �� 5,      6!    � RowDefinitions 5.   
   �� 5/      $	��15* �6   6+   �� 50      $��5* �6   6*   �� 51      $
��100* �6   6,   .+�54   
     UIControls.SearchTextBox  -   5          Name$ 	searchBox��55   "   $��0��54      $��0��6.   $��25��55   �   $	��250��6�   
�������$
��Left=�56   9   ��55   5   �� *	SearchKey+ �� Mode$ OneWayToSource=� �� UpdateSourceTrigger$ PropertyChanged=�   Command 56   T   �� *SearchCommand+   CommandTarget 57   "   ��  �� ElementName$ 	searchBox��$	 CommandTarget�   SelectedItems 58   "   �� *SearchFields+$ TwoWay=�$ PropertyChanged=��� 5:   
   $ 
Horizontal=�6   $��Right=�6.   $	��Top=�6J   $��0��6_   $��0��6o   $��3��6|   .+�5;      �� $��23��6   .��6    Load all data:60   �� 5<      $��15��6    d� 	IsChecked 6#   �� *LoadAllData+$ TwoWay=�$ PropertyChanged=�{�5=      �� *EnableDataCountInput+��6B   �� *LoadAllDataCommand+�� 5>      $��23��6   .��6    Data Count:6-   �� 5?      $��22��6k   $��50��6w   
���   �$��0q�6�   ��6   �� *	DataCount+$ OneWayToSource=�$ PropertyChanged=�{�5@      �� *EnableDataCountInput+�� 5A      #��[ 6   �� 5B      -   5         ��Name$ generateData��5B      $��25��6+   $	��100��67   $��Generate data��6m   $	��0,8q�6�   ��6C   �� *GenerateButtonCommand+6�   �� 5C      #��[ 6   �� 5D      -   5        $ 
deleteData��5D      $��25��6)   $	��100��65   $��Delete data��6i   $	��0,8q�6   ��6A   �� *DeleteButtonCommand+6   5E      � 5G   
   $��0��6   $��1��6&   $��3��63   $��4��6G    � Minimum$ 0Q�5I   %    � Maximum$	 100Q�61   
����  � � Value 5H      �� *CurrentProgress+$ OneWay=�y�6=   �� *ProgressVisibility+#
 [  �� FallbackValue$ Hidden�� � IsIndeterminate 5I   ?   �� *ProgressVisibility+6n   &   System.Windows.Controls.DataGrid  5K   
   -   5        $��SearchResultGrid��5K   k   $��0��6   $��2��6#   $��4��60      GridLinesVisibility$	 All=�6D   $
��Auto��6^      AutoGenerateColumns . $
��Left=�5L      $	��Top=�6+   $��Stretch=�6K   $	��Top=�5M      5N      5O      5P      